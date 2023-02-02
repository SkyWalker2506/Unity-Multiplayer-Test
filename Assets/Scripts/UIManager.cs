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
        _loginPanel.gameObject.SetActive(true);
        _connectionPanel.SetActive(false);
        _gamePanel.SetActive(false);
    }

    private void OnEnable()
    {
        _loginPanel.OnLogin += OnLogin;
        GameEventsManager.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _loginPanel.OnLogin -= OnLogin;
        GameEventsManager.OnGameStarted -= OnGameStarted;
    }
    
    private void OnLogin()
    {
        _loginPanel.gameObject.SetActive(false);
        _connectionPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }
    
    private void OnGameStarted()
    {
        _connectionPanel.SetActive(false);
        _gamePanel.SetActive(true);
        AddUserToScorePanelServerRpc(GameInfo.Player.Name);
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void AddUserToScorePanelServerRpc(string userName)
    {
        GameInfo.Users.Add(new UserInfo(userName));
        foreach (var user in GameInfo.Users)
        {
            AddUserToScorePanelClientRpc(user.Name);
        }
    }
    
    [ClientRpc]
    private void AddUserToScorePanelClientRpc(string userName)
    {
        _scorePanel.AddScorePanelObject(userName);
    }
}