using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class rotate_right_basic : button
{
    public override void Init()
    {
        on_click();
        gameObject.GetComponent<Button>().onClick.AddListener(() => g.sc.TurnRight());
        base.Init();
    }
}
