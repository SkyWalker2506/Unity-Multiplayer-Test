using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Network
{
    public class ConnectionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _userName;
        [SerializeField] private Button _hostButton;
        [SerializeField] private Button _clientButton;

        private void OnEnable()
        {
            _userName.SetText(GameInfo.Player.Name);
            _hostButton.onClick.AddListener(OnStartHost);
            _clientButton.onClick.AddListener(OnStartClient);
        }

        private void OnDisable()
        {
            _hostButton.onClick.RemoveListener(OnStartHost);
            _clientButton.onClick.RemoveListener(OnStartClient);
        }
        
        private void OnStartHost()
        {
            if (NetworkManager.Singleton.StartHost())
            {
                Invoke(nameof(CallGameStarted),1);
            }
        }
        
        private void OnStartClient()
        {
            if (NetworkManager.Singleton.StartClient())
            {
                Invoke(nameof(CallGameStarted),1);
            }
        }

        private void CallGameStarted()
        {
            GameEventsManager.OnGameStarted?.Invoke();
        }
    }
}