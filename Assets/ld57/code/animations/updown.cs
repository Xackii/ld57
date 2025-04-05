using DG.Tweening;
using UnityEngine;
using System.Collections;
public class updown : MonoBehaviour
{
    public float moveDistance = 0.01f;
    public float duration = 0.1f;      
    public float delayRange = 0.1f;
    public bool isMovingUp = true;    

    private void Start()
    {
        StartCoroutine(AnimateUpDownWithChaos());
    }

    private IEnumerator AnimateUpDownWithChaos()
    {
        float randomDelay = Random.Range(0f, delayRange);
        yield return new WaitForSeconds(randomDelay);

        AnimateUpDown();
    }

    private void AnimateUpDown()
    {
        if(gameObject == null) return;

        if (isMovingUp)
        {
            transform.DOMoveY(transform.position.y + moveDistance, duration)
                .OnComplete(() => AnimateDown());
        }
        else
        {
            transform.DOMoveY(transform.position.y - moveDistance, duration)
                .OnComplete(() => AnimateUp());
        }
    }

    private void AnimateDown()
    {
        isMovingUp = false;
        AnimateUpDown(); 
    }

    private void AnimateUp()
    {
        isMovingUp = true;
        AnimateUpDown();
    }
}
