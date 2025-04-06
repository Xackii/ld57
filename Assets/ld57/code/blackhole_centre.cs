using UnityEngine;
using UnityEngine.PlayerLoop;

public class blackhole_centre : initializable
{
    public float gravityForce = 0.002f;
    public float pullRadius = 15f;

    public void blackhole_gogogo(GameObject nomnomnom)
    {
        Rigidbody2D rb = nomnomnom.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 directionToBlackHole = (transform.position - nomnomnom.transform.position).normalized;
            rb.AddForce(directionToBlackHole * gravityForce * Time.deltaTime);
        }
    }
}
