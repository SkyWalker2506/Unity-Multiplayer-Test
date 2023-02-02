using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIManager : NetworkBehaviour
{
    [SerializeField] private LoginPanel _loginPanel;
    [SerializeField] private GameObject _connectionPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private ScorePanel _scorePanel;
    

    private void Awake()
    {
        _loginPanel?.gameObject.SetActive(true);
        _connectionPanel?.SetActive(false);
        _gamePanel?.SetActive(false);
    }

    private void OnEnable()
    {
        _loginPanel.OnLogin += OnLogin;
        if (NetworkManager.Singleton)
        {        
            NetworkManager.Singleton.OnServerStarted += OnServerStarted;
        }
    }

    private void OnDisable()
    {
        _loginPanel.OnLogin -= OnLogin;
        if (NetworkManager.Singleton)
        {
            NetworkManager.Singleton.OnServerStarted -= OnServerStarted;

        }
    }
    
    private void OnLogin()
    {
        _loginPanel?.gameObject.SetActive(false);
        _connectionPanel?.SetActive(true);
        _gamePanel?.SetActive(false);
    }
    private void OnServerStarted()
    {
        _connectionPanel?.SetActive(false);
        _gamePanel?.SetActive(true);
        AddUserToScorePanelServerRpc(Random.Range(0,100).ToString());
    }
    
    private void OnClientConnected(ulong id)
    {
        Debug.LogWarning("id "+id);
        _connectionPanel?.SetActive(false);
        _gamePanel?.SetActive(true);
        AddUserToScorePanelServerRpc(id.ToString());
    }

    [ServerRpc(RequireOwnership = false)]
    private void AddUserToScorePanelServerRpc(string userName)
    {
        Debug.LogWarning("userName "+userName);
        //_scorePanel.AddScorePanelObject(userName);
        AddUserToScorePanelClientRpc(userName);
    }
    
    [ClientRpc]
    private void AddUserToScorePanelClientRpc(string userName)
    {
        Debug.LogWarning("userName "+userName);
        _scorePanel.AddScorePanelObject(userName);
    }
}