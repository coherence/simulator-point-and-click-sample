using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Connection;
using Coherence.Toolkit;
using UnityEngine;
using Random = UnityEngine.Random;

public class Simulator : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    
    private CoherenceBridge _coherenceBridge;
    private Dictionary<ClientID, Character> _characters = new();

#if COHERENCE_SIMULATOR //|| UNITY_EDITOR
    private void Awake()
    {
        CoherenceBridgeStore.TryGetBridge(gameObject.scene, out _coherenceBridge);
    }

    private void OnEnable()
    {
        _coherenceBridge.ClientConnections.OnSynced += OnSynced;
        _coherenceBridge.ClientConnections.OnCreated += CreateCharacter;
        _coherenceBridge.ClientConnections.OnDestroyed += RemoveCharacter;
    }
    
    private void OnDisable()
    {
        _coherenceBridge.ClientConnections.OnSynced -= OnSynced;
        _coherenceBridge.ClientConnections.OnCreated -= CreateCharacter;
        _coherenceBridge.ClientConnections.OnDestroyed -= RemoveCharacter;
    }

    private void OnSynced(CoherenceClientConnectionManager clientConnectionManager)
    {
        foreach (CoherenceClientConnection clientConnection in clientConnectionManager.GetAllClients())
        {
            CreateCharacter(clientConnection);
        }
        
        _coherenceBridge.ClientConnections.OnSynced -= OnSynced;
    }

    private void CreateCharacter(CoherenceClientConnection clientConnection)
    {
        if (_characters.ContainsKey(clientConnection.ClientId))
        {
            Debug.LogError($"Character with ID {clientConnection.ClientId} already exists.");
            return;
        }

        if (clientConnection == _coherenceBridge.ClientConnections.GetMine()) return;
        
        Character character = Instantiate(_characterPrefab, Utilities.RandomPositionInCircle(.5f), Quaternion.identity);
        character.AssignColor(Utilities.RandomColor());
        character.clientId = (uint)clientConnection.ClientId;
        _characters.Add(clientConnection.ClientId, character);
        Debug.Log($"Character with ID {clientConnection.ClientId} created.");
    }
    
    private void RemoveCharacter(CoherenceClientConnection clientConnection)
    {
        if (!_characters.TryGetValue(clientConnection.ClientId, out Character characterToRemove))
        {
            Debug.LogError($"Character with ID {clientConnection.ClientId} does not exist.");
            return;
        }
        
        Destroy(characterToRemove.gameObject);
        _characters.Remove(clientConnection.ClientId);
    }
#endif

    [Command(defaultRouting = MessageTarget.AuthorityOnly)]
    public void MoveCharacterTo(uint clientID, Vector3 newPosition)
    {
#if COHERENCE_SIMULATOR
        _characters[(ClientID)clientID].MoveTo(newPosition);
#endif
    }
}
