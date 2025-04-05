using UnityEngine;
using UnityEngine.EventSystems;

public class ship_controller : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;

    bool isTurningLeft = false;
    bool isMoveForward = false;
    bool isTurningRight = false;

    public void MoveForward()
    {
        isMoveForward = !isMoveForward;
    }

    public void TurnLeft()
    {
        isTurningLeft = !isTurningLeft;
    }

    public void TurnRight()
    {
        isTurningRight = !isTurningRight;
    }

    void Update()
    {
        if(isTurningLeft)
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if(isTurningRight)
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        if(isMoveForward)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
