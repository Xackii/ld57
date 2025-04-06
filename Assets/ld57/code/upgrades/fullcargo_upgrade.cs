using UnityEngine;

public class fullcargo_upgrade : purchable
{
    public override void on_buy()
    {
        g.sell_on_step = true;
        base.on_buy();
    }

    public override void on_refund()
    {
        g.sell_on_step = false;
        base.on_refund();
    }
}
