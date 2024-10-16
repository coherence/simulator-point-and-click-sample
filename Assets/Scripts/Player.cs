using Coherence;
using Coherence.Toolkit;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        _simulatorSync = FindFirstObjectByType<Simulator>().GetComponent<CoherenceSync>();
        _coherenceBridge.onLiveQuerySynced.RemoveListener(OnLiveQuerySynced);
        _connected = true;
    }
    
    private void Update()
    {
        if (!_connected) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main!.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                RequestMoveTo(hit.point);
            }
        }
    }

    private void RequestMoveTo(Vector3 desiredPosition)
    {
        _simulatorSync.SendCommand<Simulator>(nameof(Simulator.MoveCharacterTo), MessageTarget.AuthorityOnly,
            (uint)_coherenceBridge.ClientConnections.GetMine().ClientId, desiredPosition);
        
        _positionMarker.SetActive(true);
        _positionMarker.transform.position = desiredPosition;
    }
}
