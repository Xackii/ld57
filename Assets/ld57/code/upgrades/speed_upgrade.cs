using UnityEngine;

public class speed_upgrade : purchable
{
    int speed_to_give = 2;
    int initial_speed = 0;
    public override void Init()
    {
        infinity = true;
        base.Init();
    }

    public override void on_buy()
    {
        g.sc.speed += speed_to_give;
        initial_speed += speed_to_give;
        base.on_buy();
    }

    public override void on_refund()
    {
        g.sc.speed -= initial_speed;
        initial_speed = 0;
        base.on_refund();
    }
}
