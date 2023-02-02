using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LoginPanel : MonoBehaviour
{
    public Action OnLogin;
    
    [SerializeField] private TMP_InputField _userName;
    [SerializeField] private Button _loginButton;

    private void Awake()
    {
        _loginButton.onClick.AddListener(Login);
    }

    private void Login()
    {
        string userName = _userName.text;
        if (string.IsNullOrEmpty(userName))
        {
            userName = $"User{Random.Range(0, 10000)}";
        }

        GameInfo.Player.Name = userName;
        OnLogin?.Invoke();
    }

}