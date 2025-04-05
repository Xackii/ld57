using UnityEngine;

public class finish : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ship_controller>())
        {
            Debug.Log("Корабль сломался!");
        }
    }
}
