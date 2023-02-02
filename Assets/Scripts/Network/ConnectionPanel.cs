using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Network
{
    public class ConnectionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _userName;
        [SerializeField] private Button _serverButton;
        [SerializeField] private Button _hostButton;
        [SerializeField] private Button _clientButton;

        private void OnEnable()
        {
            _userName.SetText(PlayerInfo.UserName);
            _serverButton.onClick.AddListener(()=>NetworkManager.Singleton.StartServer());
            _hostButton.onClick.AddListener(()=>NetworkManager.Singleton.StartHost());
            _clientButton.onClick.AddListener(()=>NetworkManager.Singleton.StartClient());
        }

        private void OnDisable()
        {
            _serverButton.onClick.RemoveListener(()=>NetworkManager.Singleton.StartServer());
            _hostButton.onClick.RemoveListener(()=>NetworkManager.Singleton.StartHost());
            _clientButton.onClick.RemoveListener(()=>NetworkManager.Singleton.StartClient());
        }
    }
}