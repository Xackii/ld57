using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class move_up_basic : button
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => on_click(false));
        base.Init();
    }

    public override void on_click(bool forced)
    {   
        if(!forced)
            g.sc.MoveForward();
        base.on_click(forced);
    }
}
