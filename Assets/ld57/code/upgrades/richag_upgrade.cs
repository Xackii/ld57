using System.Linq.Expressions;
using UnityEngine;

public class richag_upgrade : purchable
{
    public override void Init()
    {
        g.rp.gameObject.SetActive(false);
        base.Init();
    }

    public override void on_buy()
    {
        g.rp.gameObject.SetActive(true);
        base.on_buy();
    }

    public override void on_refund()
    {
        g.rp.gameObject.SetActive(false);
        base.on_refund();
    }
}
