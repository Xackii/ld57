using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class rotate_right_basic : initializable
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => g.sc.TurnRight());
        base.Init();
    }
}
