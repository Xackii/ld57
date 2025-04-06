using System.Linq.Expressions;
using UnityEngine;

public class blue_upgrade : purchable
{
    public override void when_selling_effect()
    {
        bool effect_works = false;
        foreach(collectable box in g.c.slots_filled_with)
        {
            if(box.cost != 2)
            {
                effect_works = true;
                break;
            } 
        }
        foreach(collectable box in g.c.slots_filled_with)
        {
            if(box.cost == 2 && effect_works)
            {
                g.money_change(1);
            }
        }
        base.when_selling_effect();
    }
}
