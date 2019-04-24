using UnityEngine;
using UnityEngine.Networking;

namespace Shooter2D
{
    public class PlayerLoader : NetworkBehaviour
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private PlayerController _controller;

        [SyncVar(hook = nameof(HookUnitIdentity))] NetworkIdentity _unitIdentity;

        public override void OnStartAuthority()
        {
            if (isServer)
            {
                SpawnPlayer(true);
            }
            else
            {
                CmdCreatePlayer();
            }
        }

        [Command]
        public void CmdCreatePlayer()
        {
            SpawnPlayer(false);
        }

        [ClientCallback]
        private void HookUnitIdentity(NetworkIdentity unit)
        {
            Debug.Log($"isLocalPlayer: {isLocalPlayer}");
            //if (!isLocalPlayer) return;
            _unitIdentity = unit;
            _controller.SetPlayer(unit.GetComponent<Player>(), true);
        }

        public void SpawnPlayer(bool isLocalPlayer)
        {
            var unit = Instantiate(_unitPrefab, transform.position, Quaternion.identity);
            NetworkServer.Spawn(unit);
            _unitIdentity = unit.GetComponent<NetworkIdentity>();
        }
    }
}
