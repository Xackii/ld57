using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class game_controller : MonoBehaviour
{
    public ship_controller sc;
    public menu m;
    public bool game_paused = false;
    public int player_on_lvl = 1;
    public int last_level = 2;

    public GameObject ship;
    List<spawner> spawns = new List<spawner>();
    void Awake()
    {
        sc = FindAnyObjectByType<ship_controller>();
        m = FindAnyObjectByType<menu>();
        foreach(initializable to_init in FindObjectsByType<initializable>(FindObjectsSortMode.None))
        {
            to_init.g = this;
            to_init.Init();
        }
        foreach(spawner spawn in FindObjectsByType<spawner>(FindObjectsSortMode.None))
        {
            spawns.Add(spawn);
            if(spawn.what_lvl <= 1)
            {
                sc.set_spawnpoint(spawn);
            }
        }

        go_play();
    }

    public void go_play()
    {
        prepare_game();
        m.menu_status();
    }

    public void station_entered()
    {
        sc.stop_ship();
        player_on_lvl++;
        if(player_on_lvl > last_level) m.menu_status();
        set_spawn();
    }

    public void set_spawn()
    {
        foreach(spawner spawn in spawns)
        {
            if(spawn.what_lvl != player_on_lvl) continue;
            sc.set_spawnpoint(spawn);
            break;
        }
    }      
    public void collect_box(GameObject box)
    {
        collectable b = box.GetComponent<collectable>();
        Destroy(box);
    }

    public void prepare_game()
    {
        set_spawn();
    }

    public void on_lose()
    {
        sc.stop_ship();
        sc.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        m.menu_status();
    }
}
