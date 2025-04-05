using UnityEngine;

public class shop : initializable
{
    shop_panel sp;

    bool toggled = false;
    public override void Init()
    {
        sp = FindAnyObjectByType<shop_panel>();
        sp.Init();
        sp.gameObject.SetActive(false);
        base.Init();
    }

    public void shop_status()
    {
        toggled = !toggled;
        if(toggled)
        {
            sp.gameObject.SetActive(true);
            sp.generate_store();
        }
        else
        {
            sp.gameObject.SetActive(false);
        }
    }
}
