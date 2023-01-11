using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Network
{
    public class NetworkConnectionView : MonoBehaviour
    {
        [SerializeField] private Button _serverButton;
        [SerializeField] private Button _hostButton;
        [SerializeField] private Button _clientButton;

        public void OnServerButtonClicked(Action onServerClicked)
        {
            _serverButton.onClick.AddListener(onServerClicked.Invoke);
        }

        public void OnHostButtonClicked(Action onHostClicked)
        {
            _hostButton.onClick.AddListener(onHostClicked.Invoke);
        }

        public void OnClientButtonClicked(Action onClientClicked)
        {
            _clientButton.onClick.AddListener(onClientClicked.Invoke);
        }
    }
}