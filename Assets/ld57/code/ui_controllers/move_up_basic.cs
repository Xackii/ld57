using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class move_up_basic : button
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => on_click());
        base.Init();
    }

    public override void on_click()
    {
        g.sc.MoveForward();
        base.on_click();
    }
}
