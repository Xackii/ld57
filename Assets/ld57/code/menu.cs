using Unity.VisualScripting;
using UnityEngine;

public class menu : initializable
{
    menu_panel mp;
    public override void Init()
    {
        mp = FindFirstObjectByType<menu_panel>();
        mp.gameObject.SetActive(false);
        base.Init();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu_status();
        }
    }

    public void menu_status()
    {
        mp.is_activated = !mp.is_activated;
        mp.gameObject.SetActive(mp.is_activated);
        if(mp.is_activated)
            g.game_paused = true;
        else
            g.game_paused = false;
    }
}
