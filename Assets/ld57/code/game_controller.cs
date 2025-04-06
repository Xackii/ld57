using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class game_controller : MonoBehaviour
{
    public enum game_status
    {
        game_start,
        game_loop,
        game_end
    }
    public ship_controller sc;
    public shop s;
    public menu m;
    public cargo c;
    public nullspace ns;
    public followingtooltip ft;
    public spawn_purchable spawn_p;
    public game_status game_check = game_status.game_start;
    public bool game_paused = false;
    public int player_on_lvl = 1;
    public int last_level = 5;
    public int max_charges = 3;
    public int charges_we_have = 3;
    public int money = 0;
    public GameObject ship;

    public rotate_left_basic rlb;
    public rotate_right_basic rrb;
    public move_up_basic mub;
    public wheel w;
    public richag_panel rp;
    public rotators rts;
    public List<purchable> upgrades_buyed = new List<purchable>();
    public List<loot_respawner> loot_spawners;
    public List<text_info> text_to_update = new List<text_info>();

    List<spawner> spawns = new List<spawner>();
    void Awake()
    {
        DOTween.SetTweensCapacity(1000, 50);

        spawn_p = FindAnyObjectByType<spawn_purchable>();
        sc = FindAnyObjectByType<ship_controller>();
        w = FindAnyObjectByType<wheel>();
        m = FindAnyObjectByType<menu>();
        s = FindAnyObjectByType<shop>();
        c = FindAnyObjectByType<cargo>();
        ns = FindAnyObjectByType<nullspace>();
        ft = FindAnyObjectByType<followingtooltip>();
        rlb = FindAnyObjectByType<rotate_left_basic>();
        rrb = FindAnyObjectByType<rotate_right_basic>();
        mub = FindAnyObjectByType<move_up_basic>();
        rts = FindAnyObjectByType<rotators>();
        rp = FindAnyObjectByType<richag_panel>();


        foreach(initializable to_init in FindObjectsByType<initializable>(FindObjectsSortMode.None))
        {
            to_init.g = this;
            to_init.Init();
        }
        ft.tooltip_status(false, "");

        foreach(text_info text in FindObjectsByType<text_info>(FindObjectsSortMode.None))
            text_to_update.Add(text);

        foreach(loot_respawner lr in FindObjectsByType<loot_respawner>(FindObjectsSortMode.None))
            loot_spawners.Add(lr);

        foreach(spawner spawn in FindObjectsByType<spawner>(FindObjectsSortMode.None))
        {
            spawns.Add(spawn);
            if(spawn.what_lvl <= 1)
            {
                sc.set_spawnpoint(spawn);
            }
        }

        m.menu_status();
    }

    public void update_info()
    {
        foreach(text_info text in text_to_update)
            text.update_text();
    }

    public void close_shop()
    {
        s.sp.clear_shop();
        s.shop_status();
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
        update_info();
        if(player_on_lvl > last_level) m.menu_status();
        set_spawn();
    }

    public void sell_cargo()
    {
        List<collectable> check_cargo = c.slots_filled_with.ToList(); 
        foreach(collectable to_sell in check_cargo)
        {
            money_change(to_sell.cost);
            c.slots_filled_with.Remove(to_sell);
            Destroy(to_sell.ui_cash);
            delete_from_nullspace(to_sell.gameObject);
        }
    }

    public void money_change(int value)
    {
        money += value;
        update_info();
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
        b.ui_cash = box_ui;
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
        foreach(loot_respawner lr in loot_spawners)
            lr.spawn_loot();
        if(upgrades_buyed.Count > 0)
        {
            foreach(purchable upgrade in upgrades_buyed)
            {
                upgrade.on_refund();
            }
        }
        upgrades_buyed.Clear();
        set_spawn();
    }

    public void on_lose()
    {
        foreach(loot_respawner lr in loot_spawners)
            lr.delete_loot();
        sc.stop_ship();
        sc.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        m.menu_status();
    }
}
