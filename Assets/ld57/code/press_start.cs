using UnityEngine;
using UnityEngine.UI;
public class press_start : initializable
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => g.go_play());
        base.Init();
    }
}
