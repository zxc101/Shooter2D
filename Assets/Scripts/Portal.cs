using UnityEngine;

namespace Shooter2D
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Transform _output;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag.Equals("Player"))
                collision.transform.position = _output.position;
        }
    }
}
