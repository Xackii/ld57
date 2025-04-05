using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class game_controller : MonoBehaviour
{
    public ship_controller sc;
    public shop s;
    public wheel w;
    public menu m;
    public cargo c;
    public nullspace ns;
    public followingtooltip ft;
    public spawn_purchable spawn_p;
    public bool game_paused = false;
    public int player_on_lvl = 1;
    public int last_level = 2;
    public int money = 0;
    public GameObject ship;
    List<spawner> spawns = new List<spawner>();
    void Awake()
    {
        spawn_p = FindAnyObjectByType<spawn_purchable>();
        sc = FindAnyObjectByType<ship_controller>();
        w = FindAnyObjectByType<wheel>();
        m = FindAnyObjectByType<menu>();
        s = FindAnyObjectByType<shop>();
        c = FindAnyObjectByType<cargo>();
        ns = FindAnyObjectByType<nullspace>();
        ft = FindAnyObjectByType<followingtooltip>();
        foreach(initializable to_init in FindObjectsByType<initializable>(FindObjectsSortMode.None))
        {
            to_init.g = this;
            to_init.Init();
        }
        ft.tooltip_status(false, "");
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
        player_on_lvl = 1;
        prepare_game();
        m.menu_status();
    }

    public void station_entered()
    {
        sc.stop_ship();
        s.shop_status();
        sell_cargo();
        player_on_lvl++;
        if(player_on_lvl > last_level) m.menu_status();
        set_spawn();
    }

    public void sell_cargo()
    {
        foreach(collectable to_sell in c.slots_filled_with)
        {
            money += to_sell.cost;
            Destroy(to_sell.ui_cash);
            delete_from_nullspace(to_sell.gameObject);
        }
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
        GameObject box_ui = Instantiate(b.ui_ref);
        box_ui.transform.SetParent(c.fc.gameObject.transform); 
        box_ui.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        c.slots_filled_with.Add(b);
        move_to_nullspace(box);
    }

    public void move_to_nullspace(GameObject you_gonna_brazil)
    {
        you_gonna_brazil.transform.position = ns.transform.position;
        ns.contants.Add(you_gonna_brazil);
    }

    public void remove_from_nullspace(GameObject pick_me_please, Transform new_pos)
    {
        pick_me_please.transform.position = new_pos.position;
        ns.contants.Remove(pick_me_please);
    }      

    public void delete_from_nullspace(GameObject noo_dont_delete_me)
    {
        ns.contants.Remove(noo_dont_delete_me);
        Destroy(noo_dont_delete_me);
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
