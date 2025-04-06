using UnityEngine;

public class charges_upgrade : purchable
{
    int initial_charges = 3;
    public override void Init()
    {
        infinity = true;
        base.Init();
    }

    public override void on_buy()
    {
        g.charges_we_have++;
        g.max_charges++;
        base.on_buy();
    }

    public override void on_refund()
    {
        g.charges_we_have = initial_charges;
        g.max_charges = initial_charges;
        base.on_refund();
    }
}
