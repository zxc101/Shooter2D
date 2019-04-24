using UnityEngine;
using UnityEngine.Networking;

namespace Shooter2D.Stats
{
    public class UnitStats : NetworkBehaviour
    {
        [SerializeField] private int _maxHP;
        [SyncVar] private int hp;

        public Stat Damage;

        public int HP => hp;

        public override void OnStartServer()
        {
            SetHPRate(1);
        }

        public void SetHPRate(float rate)
        {
            hp = rate == 0 ? 0 : (int)(_maxHP * rate);
        }
    }
}
