using Coherence;
using Coherence.Toolkit;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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
        _navMeshAgent.destination = newPosition;
        _animator.SetBool("IsMoving", true);
        this.targetInteractable = targetInteractable;
    }

    public void Update()
    {
        if (_navMeshAgent.remainingDistance < 0.1f)
        {
            if (targetInteractable != null)
            {
                _coherenceSync.SendMessage<Animator>(nameof(Animator.SetTrigger), MessageTarget.AuthorityOnly, "Interact");
            }
            _animator.SetBool("IsMoving", false);
        }
    }
}
