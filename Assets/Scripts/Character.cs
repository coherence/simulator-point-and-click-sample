using Coherence;
using Coherence.Toolkit;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _cmCameraPrefab;
    
    [Sync] public uint clientId;
    [Sync] public CoherenceSync targetInteractable;
    [Sync, OnValueSynced(nameof(OnColorChanged))] public Color color;
    
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private CoherenceBridge _coherenceBridge;
    private CoherenceSync _coherenceSync;
    private bool _isMoving;

    private void Awake()
    {
#if COHERENCE_SIMULATOR
        _coherenceSync = GetComponent<CoherenceSync>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }
#else
        // Only the Client needs to listen to OnLiveQuerySynced
        CoherenceBridgeStore.TryGetBridge(gameObject.scene, out _coherenceBridge);
        _coherenceBridge.onLiveQuerySynced.AddListener(OnLiveQuerySynced);
    }
    
    private void OnLiveQuerySynced(CoherenceBridge arg0)
    {
        _coherenceBridge.onLiveQuerySynced.RemoveListener(OnLiveQuerySynced);

        // At this point, with the LiveQuery synced,
        // we can be sure that the clientId property is set
        if(clientId == (uint)_coherenceBridge.ClientConnections.GetMine().ClientId)
            CreateCinemachineCamera();
    }

    private void CreateCinemachineCamera()
    {
        CinemachineCamera cinemachineCamera = Instantiate(_cmCameraPrefab);
        cinemachineCamera.Target.TrackingTarget = cinemachineCamera.Target.LookAtTarget = transform;
    }
#endif

#if COHERENCE_SIMULATOR
    // This method is called by the Simulator script when the character is spawned on the Simulator side
    public void Setup(uint newClientID, Color newColor)
    {
        clientId = newClientID;
        
        color = newColor;
        OnColorChanged(newColor, Color.clear);
    }

    // This is called on the Simulator, when the move NetworkCommand is received from the Client
    public void MoveTo(Vector3 newPosition, CoherenceSync targetInteractable = null)
    {
        _isMoving = true;
        _navMeshAgent.destination = newPosition;
        _animator.SetBool("IsMoving", _isMoving);
        this.targetInteractable = targetInteractable;
    }

    // Only the Simulator should check for the remaining distance,
    // as the NavMeshAgent is only enabled on the Simulator side
    public void Update()
    {
        if (_isMoving &&
            _navMeshAgent.remainingDistance < 0.1f)
        {
            _isMoving = false;
            
            if (targetInteractable != null)
            {
                // Notice MessageTarget.Other, as we want to trigger the animation on all Clients
                Debug.Log($"Client ID {clientId} is interacting with {targetInteractable.gameObject.name}");
                _coherenceSync.SendCommand<Animator>(nameof(Animator.SetTrigger), MessageTarget.Other, "Interact");
            }
            _animator.SetBool("IsMoving", _isMoving);
        }
    }
#endif
    
    public void OnColorChanged(Color oldValue, Color newValue)
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = newValue;
    }
}
