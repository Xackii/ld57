using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class rotate_left_basic : button
{
    public override void Init()
    {
        on_click();
        gameObject.GetComponent<Button>().onClick.AddListener(() => g.sc.TurnLeft());
        base.Init();
    }
}
