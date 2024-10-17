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
        _coherenceSync = GetComponent<CoherenceSync>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        
        CoherenceBridgeStore.TryGetBridge(gameObject.scene, out _coherenceBridge);
        _coherenceBridge.onLiveQuerySynced.AddListener(OnLiveQuerySynced);
    }

    private void OnLiveQuerySynced(CoherenceBridge arg0)
    {
        _coherenceBridge.onLiveQuerySynced.RemoveListener(OnLiveQuerySynced);
        
        if(clientId == (uint)_coherenceBridge.ClientConnections.GetMine().ClientId)
            CreateCinemachineCamera();
    }

    private void CreateCinemachineCamera()
    {
        CinemachineCamera cinemachineCamera = Instantiate(_cmCameraPrefab);
        cinemachineCamera.Target.TrackingTarget = cinemachineCamera.Target.LookAtTarget = transform;
    }

    public void AssignColor(Color newColor)
    {
        color = newColor;
        OnColorChanged(newColor, Color.clear);
    }
    
    public void OnColorChanged(Color oldValue, Color newValue)
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = newValue;
    }
    
    public void MoveTo(Vector3 newPosition, CoherenceSync targetInteractable = null)
    {
        _isMoving = true;
        _navMeshAgent.destination = newPosition;
        _animator.SetBool("IsMoving", _isMoving);
        this.targetInteractable = targetInteractable;
    }

    public void Update()
    {
        if (_isMoving &&
            _navMeshAgent.remainingDistance < 0.1f)
        {
            _isMoving = false;
            
            if (targetInteractable != null)
            {
                _coherenceSync.SendCommand<Animator>(nameof(Animator.SetTrigger), MessageTarget.Other, "Interact");
            }
            _animator.SetBool("IsMoving", _isMoving);
        }
    }
}
