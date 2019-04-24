using UnityEngine;

namespace Shooter2D
{
    public class EnemyMotor : UnitMotor
    {
        [SerializeField] private Transform _target;

        public override void Move()
        {
            Vector2 directionToTarget = (_target.position - transform.position).normalized;
            transform.Translate(directionToTarget * speed * Time.deltaTime);
        }

    }
}