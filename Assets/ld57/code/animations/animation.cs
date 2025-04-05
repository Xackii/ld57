using UnityEngine;
using DG.Tweening;
public class animation : initializable
{
    protected virtual void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}
