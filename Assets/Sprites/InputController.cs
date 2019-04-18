using UnityEngine;

public class InputController : MonoBehaviour, IFixedUpdate
{
    private PlayerController _playerController;
    private CameraController _cameraController;

    void Start()
    {
        FindObjectOfType<FixedUpdateController>()?.AddFixedUpdate(this);

        if (FindObjectOfType<PlayerController>())
        {
            _playerController = FindObjectOfType<PlayerController>();
        }
        else
        {
            Debug.LogError("Didn't find PlayerController");
        }

        if (FindObjectOfType<CameraController>())
        {
            _cameraController = FindObjectOfType<CameraController>();
        }
        else
        {
            Debug.LogError("Didn't find PlayerController");
        }
    }

    public void OnFixedUpdate()
    {
        _playerController?.Rotate();
        _playerController?.Move(Input.GetAxis("Vertical") * Vector2.up +
                                Input.GetAxis("Horizontal") * Vector2.right);
        _cameraController?.Move();

    }
}
