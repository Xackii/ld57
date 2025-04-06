using Unity.VisualScripting;
using UnityEngine;

public class loot_respawner : initializable
{
    public GameObject to_spawn;
    GameObject generated_loot;

    public override void Init()
    {
        base.Init();
    }

    public void spawn_loot()
    {
        generated_loot = Instantiate(to_spawn, transform.position, transform.rotation, transform);
    }

    public void delete_loot()
    {
        if(generated_loot == null) return;
        collectable loot = generated_loot.GetComponent<collectable>(); 
        g.c.slots_filled_with.Remove(loot);
        if(loot == null) return;
        loot.on_del();
    }
}
