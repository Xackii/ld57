using System.Collections.Generic;
using UnityEngine;

public class shop_panel : initializable
{
    public List<purchable> to_store_from;

    public List<shop_slot> slots;

    public override void Init()
    {
        base.Init();
    }
    public void generate_store()
    {
        List<purchable> shop_cart = new List<purchable>();
        foreach(purchable p in to_store_from)
        {
            if(p.purched) continue;
            shop_cart.Add(p);
        }
        for(int i = 1; i <= 3; i++)
        {
            int randomNumber = Random.Range(1, shop_cart.Count - 1);
            slots[i].binded_purchable = shop_cart[randomNumber];
            shop_cart[randomNumber].gameObject.transform.position = slots[i].gameObject.transform.position;
        }
    }
}
