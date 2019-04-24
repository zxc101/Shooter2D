using UnityEngine;

using Shooter2D.Stats;

namespace Shooter2D
{
    [RequireComponent(typeof(EnemyMotor), typeof(EnemyStats))]
    public class Enemy : Unit
    {
        [SerializeField] float _reviveDelay = 5f;
        [SerializeField] GameObject _gfx;
        [SerializeField] bool _aggressive;

        Vector3 _startPosition;
        float _reviveTime;

        void Start()
        {
            motor = GetComponent<EnemyMotor>();
            stats = GetComponent<EnemyStats>();

            _startPosition = transform.position;
            _reviveTime = _reviveDelay;
        }

        void Update()
        {
            OnUpdate();
        }

        protected override void OnDeadUpdate()
        {
            base.OnDeadUpdate();
            if (_reviveTime > 0)
            {
                _reviveTime -= Time.deltaTime;
            }
            else
            {
                _reviveTime = _reviveDelay;
                Revive();
            }
        }

        protected override void Die()
        {
            base.Die();
            _gfx.SetActive(false);
        }

        protected override void Revive()
        {
            base.Revive();
            transform.position = _startPosition;
            _gfx.SetActive(true);
        }

        public void Move()
        {
            if (!isDead)
            {
                motor.Move();
            }
        }
    }
}
