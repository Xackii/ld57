using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class move_up_basic : initializable
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => g.sc.MoveForward());
        base.Init();
    }
}
