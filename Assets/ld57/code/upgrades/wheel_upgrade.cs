using System.Linq.Expressions;
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
        g.rts.gameObject.SetActive(false);
        g.sc.system_we_have = ship_controller.rotation_system.wheel;
        base.on_buy();
    }

    public override void on_refund()
    {
        g.w.gameObject.SetActive(false);
        g.rts.gameObject.SetActive(true);
        g.sc.system_we_have = ship_controller.rotation_system.buttons;
        base.on_refund();
    }
}
