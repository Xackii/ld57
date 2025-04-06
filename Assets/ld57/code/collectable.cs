using UnityEngine;

public class collectable : MonoBehaviour
{
    public int cost;

    public GameObject ui_ref;

    public GameObject ui_cash;

    public void on_del()
    {
        Destroy(ui_cash);
        Destroy(gameObject);
    }
}
