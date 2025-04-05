using UnityEngine;

public class wheel_upgrade : purchable
{
    public override void Init()
    {
        g.w.gameObject.SetActive(false);
        base.Init();
    }

    public override void on_buy()
    {
        g.w.gameObject.SetActive(true);
        base.on_buy();
    }
}
