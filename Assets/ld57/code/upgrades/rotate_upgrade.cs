using UnityEngine;

public class rotate_upgrade : purchable
{
    int rotate_speed_to_give = 25;
    int initial_rotate = 0;
    public override void Init()
    {
        infinity = true;
        base.Init();
    }

    public override void on_buy()
    {
        g.sc.rotationSpeed += rotate_speed_to_give;
        initial_rotate += rotate_speed_to_give;
        base.on_buy();
    }

    public override void on_refund()
    {
        g.sc.rotationSpeed -= initial_rotate;
        initial_rotate = 0;
        base.on_refund();
    }
}
