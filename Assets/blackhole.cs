using UnityEngine;

public class blackhole : MonoBehaviour
{
    public float gravityForce = 10f;  // Сила притяжения
    public float pullRadius = 15f;    // Радиус действия черной дыры

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ship"))  // Если объект — это корабль
        {
            // Получаем Rigidbody объекта
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Вычисляем направление к черной дыре
                Vector2 directionToBlackHole = (transform.position - other.transform.position).normalized;

                // Применяем силу притяжения (гравитацию) к кораблю
                rb.AddForce(directionToBlackHole * gravityForce);
            }
        }
    }

    // Отображение радиуса черной дыры для визуализации (опционально)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }
}
