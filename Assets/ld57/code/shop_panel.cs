using System.Collections.Generic;
using UnityEngine;

public class shop_panel : initializable
{
    public List<purchable> to_store_from;
    public List<shop_slot> slots;
    List<GameObject> cash_to_del = new List<GameObject>();
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
        for(int i = 0; i < 3; i++)
        {
            int randomNumber = Random.Range(0, shop_cart.Count - 1);
            purchable new_item_component = shop_cart[randomNumber];
            GameObject new_item = Instantiate(shop_cart[randomNumber].gameObject);
            new_item_component.g = g;
            new_item.GetComponent<hover>().g = g;
            new_item.GetComponent<hover>().Init();
            new_item.transform.SetParent(g.spawn_p.gameObject.transform); 
            new_item.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            cash_to_del.Add(new_item);
            slots[i].binded_purchable = new_item_component;
            shop_cart[randomNumber].gameObject.transform.position = slots[i].gameObject.transform.position;
        }
    }

    public void clear_shop()
    {
        foreach(GameObject to_del in cash_to_del)
            Destroy(to_del);
    }
}
