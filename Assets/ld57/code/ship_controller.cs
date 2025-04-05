using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class ship_controller : tickable
{
    public float speed = 10f;
    public float rotationSpeed = 100f;

    bool isTurningLeft = false;
    bool isMoveForward = false;
    bool isTurningRight = false;

    public float smoothSpeed = 0.25f;
    public Vector3 offset = new Vector3(0,0);
    Camera c;
    public override void Init()
    {
        c = FindAnyObjectByType<Camera>();
        base.Init();
    }

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

    public override void Tick()
    {
        if(isTurningLeft)
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if(isTurningRight)
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        if(isMoveForward)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        Vector3 desiredPosition = transform.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.z = -100;
        c.transform.position = smoothedPosition;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<die_on_bump>())
        {
            Debug.Log("Корабль столкнулся с астероидом!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<finish>())
        {
    
            Debug.Log("Корабль столкнулся с астероидом!");
    
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<finish>())
        {
    
            Debug.Log("Корабль находится вблизи астероида!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<finish>())
        {
    
            Debug.Log("Корабль покинул зону астероида.");
        }
    }
}
