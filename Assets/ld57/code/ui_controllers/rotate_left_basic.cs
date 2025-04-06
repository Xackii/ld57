using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class rotate_left_basic : button
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => on_click(false));
        base.Init();
    }

    public override void on_click(bool forced)
    {
        if(!forced)
            g.sc.TurnLeft();
        if(g.rrb.isclicked)
            g.rrb.on_click(false);
        base.on_click(forced);
    }
}
