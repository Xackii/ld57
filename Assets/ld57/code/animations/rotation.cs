using DG.Tweening;
using UnityEngine;
public class rotation : animation
{
    public float rotationdegree = 0.01f;
    public float duration = 0.1f;      
    public float delayRange = 0.1f;
    public bool isMovingUp = true;    

    private void Start()
    {
        StartCoroutine(AnimateUpDownWithChaos());
    }

    private System.Collections.IEnumerator AnimateUpDownWithChaos()
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
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationdegree), duration)
                .OnComplete(() => AnimateDown());
        }
        else
        {
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - rotationdegree), duration)
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
