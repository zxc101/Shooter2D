using UnityEngine;
using UnityEngine.Networking;

namespace Shooter2D
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private LayerMask _movementMask;

        [SerializeField] private Player _player;
        private Camera _cam;

        private void Awake()
        {
            _cam = Camera.main;
        }

        public void SetPlayer(Player player, bool isLocalPlayer)
        {
            _player = player;
            if (isLocalPlayer) _cam.GetComponent<CameraController>().Target = player.transform;
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
            if (!_player) return;
            CmdSetMovePoint();
        }

        [Command]
        public void CmdSetMovePoint()
        {
            _player.Move();
        }

        private void OnDestroy()
        {
            if (_player) Destroy(_player.gameObject);
        }
    }
}
