using Coherence;
using Coherence.Toolkit;
using UnityEngine;

public class Player : MonoBehaviour
{
#if !COHERENCE_SIMULATOR
    [SerializeField] private GameObject _positionMarker;
    
    private CoherenceBridge _coherenceBridge;
    private CoherenceSync _simulatorSync;
    private bool _connected;
    
    private void Awake()
    {
        _positionMarker.SetActive(false);
        
        CoherenceBridgeStore.TryGetBridge(gameObject.scene, out _coherenceBridge);
        _coherenceBridge.onLiveQuerySynced.AddListener(OnLiveQuerySynced);
    }

    private void OnLiveQuerySynced(CoherenceBridge bridge)
    {
        // This assumes that the Simulator is already connected.
        // If not, an error will be thrown because the Simulator-type object is not present.
        _simulatorSync = FindFirstObjectByType<Simulator>().GetComponent<CoherenceSync>();
        _connected = true;
        
        _coherenceBridge.onLiveQuerySynced.RemoveListener(OnLiveQuerySynced);
    }
    
    private void Update()
    {
        if (!_connected) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main!.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                RequestMoveTo(hit);
            }
        }
    }

    private void RequestMoveTo(RaycastHit hit)
    {
        Vector3 desiredPosition;

        // A different NetworkMessage is sent,
        // depending on if the raycast detected an interactable object or not.
        if (hit.collider.gameObject.CompareTag("Interactable"))
        {
            CoherenceSync targetInteractable = hit.collider.gameObject.GetComponent<CoherenceSync>();
            desiredPosition = hit.collider.transform.position - hit.collider.transform.forward * 2f; // Move slightly back from the interactable
            
            // Notice how we use MessageTarget.AuthorityOnly because the target is the Simulator,
            // who has authority over the Simulator entity
            _simulatorSync.SendCommand<Simulator>(nameof(Simulator.MoveCharacterToInteract), MessageTarget.AuthorityOnly,
                (uint)_coherenceBridge.ClientConnections.GetMine().ClientId, desiredPosition, targetInteractable);
        }
        else
        {
            desiredPosition = hit.point;
            _simulatorSync.SendCommand<Simulator>(nameof(Simulator.MoveCharacterTo), MessageTarget.AuthorityOnly,
                (uint)_coherenceBridge.ClientConnections.GetMine().ClientId, desiredPosition);
        }
        
        // Setting the marker locally provides immediate feedback for the click
        _positionMarker.SetActive(true);
        _positionMarker.transform.position = desiredPosition;
    }
#endif
}
