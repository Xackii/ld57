using UnityEngine;

public class game_controller : MonoBehaviour
{
    public ship_controller sc;
    public menu m;
    public bool game_paused = false;
    void Awake()
    {
        sc = FindAnyObjectByType<ship_controller>();
        m = FindAnyObjectByType<menu>();
        foreach(initializable to_init in FindObjectsByType<initializable>(FindObjectsSortMode.None))
        {
            to_init.g = this;
            to_init.Init();
        }
    }
}
