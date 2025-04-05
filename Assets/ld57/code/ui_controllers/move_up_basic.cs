using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class move_up_basic : button
{
    public override void Init()
    {
        on_click();
        gameObject.GetComponent<Button>().onClick.AddListener(() => g.sc.MoveForward());
        base.Init();
    }
}
