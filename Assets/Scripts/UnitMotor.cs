using UnityEngine;
using UnityEngine.Networking;

namespace Shooter2D
{
    public abstract class UnitMotor : NetworkBehaviour
    {
        [SerializeField] protected float speed = 0.1f;

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
        }

        public abstract void Move();
    }
}
