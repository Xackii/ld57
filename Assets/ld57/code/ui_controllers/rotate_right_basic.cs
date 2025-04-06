using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class rotate_right_basic : button
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => on_click(false));
        base.Init();
    }

    public override void on_click(bool forced)
    {
        if(!forced)
            g.sc.TurnRight();
        if(g.rlb.isclicked)
            g.rlb.on_click(false);
        base.on_click(forced);
    }
}
