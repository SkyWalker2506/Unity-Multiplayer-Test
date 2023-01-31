using System;
using Unity.Netcode;
using UnityEngine;

public class UIManager : NetworkBehaviour
{
    [SerializeField] private GameObject _connectionPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _scorePanel;

    private void OnEnable()
    {
        if (NetworkManager.Singleton)
        {        
            NetworkManager.Singleton.OnServerStarted += OnServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        }
    }

    private void OnDisable()
    {
        if (NetworkManager.Singleton)
        {
            NetworkManager.Singleton.OnServerStarted -= OnServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        }
    }
    
    private void OnServerStarted()
    {
        _connectionPanel.SetActive(false);
        _gamePanel.SetActive(true);
    }

    private void OnClientConnected(ulong id)
    {
        
    }
    
}