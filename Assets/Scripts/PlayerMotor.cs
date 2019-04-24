using UnityEngine;
using UnityEngine.Networking;

namespace Shooter2D
{
    public class PlayerMotor : UnitMotor
    {
        public override void Move()
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(0, speed, 0, Space.World);
            if (Input.GetKey(KeyCode.A))
                transform.Translate(-speed, 0, 0, Space.World);
            if (Input.GetKey(KeyCode.S))
                transform.Translate(0, -speed, 0, Space.World);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(speed, 0, 0, Space.World);

            Vector3 mousePosition = Input.mousePosition;
            //mousePosition.z = transform.position.z - Camera.main.transform.position.z; // это только для перспективной камеры необходимо
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты
            var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х
            transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);//немного магии на последок
        }
    }
}
