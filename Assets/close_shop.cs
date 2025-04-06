using UnityEngine;
using UnityEngine.UI;
public class close_shop : initializable
{
    public override void Init()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => g.close_shop());
        base.Init();
    }
}
