using UnityEngine;
using DG.Tweening;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] Transform graphics;

    Vector3 flyDirection;
    Vector3 normflyDirection;

    [SerializeField] float speed = 500f;
    [SerializeField] float yawAmount = 100f;

    [SerializeField] Joystick joystickFly;
    [SerializeField] Joystick joystickUpDown;

    float yaw;
    float pitch;
    float roll;

    void Start()
    {
        joystickFly = GameObject.FindGameObjectWithTag("JoystickFly").GetComponent<Joystick>();
        joystickUpDown = GameObject.FindGameObjectWithTag("JoystickUpDown").GetComponent<Joystick>();
    }

    void Update()
    {
        FlyInput();
        DroneFly();
        DroneRotation();
    }

    void FlyInput()
    {
        flyDirection = new Vector3(joystickFly.Horizontal, joystickUpDown.Vertical, joystickFly.Vertical);

        normflyDirection = flyDirection.normalized;
    }

    void DroneFly()
    {
        transform.localPosition += (transform.right * normflyDirection.x + transform.up * normflyDirection.y + transform.forward * normflyDirection.z) * speed * Time.deltaTime;
    }

    void DroneRotation()
    {
        yaw += normflyDirection.x * yawAmount * Time.deltaTime;
        pitch = Mathf.Lerp(0, 20, Mathf.Abs(normflyDirection.z)) * Mathf.Sign(normflyDirection.z);
        roll = Mathf.Lerp(0, 30, Mathf.Abs(normflyDirection.x)) * -Mathf.Sign(normflyDirection.x);

        transform.DORotate(Vector3.up * yaw, 1f);
        graphics.DOLocalRotate(new Vector3(pitch, 0, roll), 1f);
    }
}
