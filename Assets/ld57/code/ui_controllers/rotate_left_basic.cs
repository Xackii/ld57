using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class rotate_left_basic : initializable
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => g.sc.TurnLeft());
        base.Init();
    }
}
