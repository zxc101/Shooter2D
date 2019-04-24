using UnityEngine;
using UnityEngine.Networking;

using Shooter2D.Stats;

namespace Shooter2D
{
    public class Unit : NetworkBehaviour
    {
        [SerializeField] protected UnitMotor motor;
        [SerializeField] protected UnitStats stats;

        protected bool isDead;

        private void Update()
        {
            OnUpdate();
        }

        protected virtual void OnAliveUpdate()
        {

        }

        protected virtual void OnDeadUpdate()
        {

        }

        protected void OnUpdate()
        {
            if (!isServer) return;
            if (!isDead)
            {
                if (stats.HP == 0) Die();
                else OnAliveUpdate();
            }
            else
            {
                OnDeadUpdate();
            }
        }

        [ClientCallback]
        protected virtual void Die()
        {
            isDead = true;
        }

        [ClientRpc]
        private void RpcDie()
        {
            isDead = false;
        }

        [ClientCallback]
        protected virtual void Revive()
        {
            isDead = false;
            if (!isServer) return;
            stats.SetHPRate(1);
            RpcRevive();
        }

        [ClientRpc]
        private void RpcRevive()
        {
            if (!isServer) Revive();
        }
    }
}
