using System;
using Unity.Netcode;
using UnityEngine;

namespace Game.Network
{
    public class NetworkConnectionPresenter : MonoBehaviour
    {
        [SerializeField] private NetworkConnectionView _networkConnectionView;

        private void Awake()
        {
            SetView();
        }

        private void SetView()
        {
            _networkConnectionView.OnServerButtonClicked(()=>NetworkManager.Singleton.StartServer());
            _networkConnectionView.OnHostButtonClicked(()=>NetworkManager.Singleton.StartHost());
            _networkConnectionView.OnClientButtonClicked(()=>NetworkManager.Singleton.StartClient());
        }
    }
}
