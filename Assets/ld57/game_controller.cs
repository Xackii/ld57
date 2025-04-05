using UnityEngine;

public class game_controller : MonoBehaviour
{
    public ship_controller sc;
    void Awake()
    {
        sc = FindAnyObjectByType<ship_controller>();
        foreach(initializable to_init in FindObjectsByType<initializable>(FindObjectsSortMode.None))
        {
            to_init.g = this;
            to_init.Init();
        }
    }
}
