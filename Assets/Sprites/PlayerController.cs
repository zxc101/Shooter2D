using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;

    private Vector2 _currentDirection = new Vector3(0, 1, 0);
    
    public void Rotate()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = _player.position;
        _player.up = Vector2.Lerp(_player.forward, mousePosition - playerPosition, 0.1f);
    }

    public void Move(Vector2 direction)
    {
        _player.Translate(Time.deltaTime * direction * _speed, Space.World);
    }
}
