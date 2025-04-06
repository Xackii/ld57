using UnityEngine;

public class green_upgrade : purchable
{
    public override void when_selling_effect()
    {
        bool effect_works = true;
        foreach(collectable box in g.c.slots_filled_with)
        {
            if(box.cost == 2 || box.cost == 3)
            {
                effect_works = false;
                break;
            } 
        }
        foreach(collectable box in g.c.slots_filled_with)
        {
            if(box.cost == 1 && effect_works)
            {
                g.money_change(1);
            }
        }
        base.when_selling_effect();
    }
}
