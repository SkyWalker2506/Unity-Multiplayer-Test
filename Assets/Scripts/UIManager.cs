using System;
using Unity.Netcode;
using UnityEngine;

public class UIManager : NetworkBehaviour
{
    [SerializeField] private GameObject _connectionPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private ScorePanel _scorePanel;


    private void Awake()
    {
        _connectionPanel?.SetActive(true);
        _gamePanel?.SetActive(false);
    }

    private void OnEnable()
    {
        if (NetworkManager.Singleton)
        {        
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        }
    }

    private void OnDisable()
    {
        if (NetworkManager.Singleton)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        }
    }
    

    private void OnClientConnected(ulong id)
    {
        Debug.LogWarning("id "+id);
        _connectionPanel?.SetActive(false);
        _gamePanel?.SetActive(true);
        //AddUserToScorePanelServerRpc(id.ToString());
        AddUserToScorePanelClientRpc(id.ToString());
    }

    [ServerRpc(RequireOwnership = false)]
    private void AddUserToScorePanelServerRpc(string userName)
    {
        Debug.LogWarning("userName "+userName);
        _scorePanel.AddScorePanelObject(userName);
    }
    
    [ClientRpc]
    private void AddUserToScorePanelClientRpc(string userName)
    {
        Debug.LogWarning("userName "+userName);
        _scorePanel.AddScorePanelObject(userName);
    }
}