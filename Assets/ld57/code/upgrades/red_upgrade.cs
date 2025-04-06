using UnityEngine;

public class red_upgrade : purchable
{
    public override void when_selling_effect()
    {
        bool effect_works = false;
        
        if(g.c.slots_filled_with.Count < 2)
            effect_works = true;

        foreach(collectable box in g.c.slots_filled_with)
        {
            if(box.cost == 3 && effect_works)
            {
                g.money_change(3);
            }
        }
        base.when_selling_effect();
    }
}
