using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InteractionButtonTweener : MonoBehaviour
{
    [SerializeField] private float tweenTime;
    private bool isBig;
    
    void Start()
    {
        transform.localScale = Vector3.zero;
        isBig = false;
    }

    public void TweenIn()
    {
        if(isBig == true)
            return;
        transform.DOScale(Vector3.one, tweenTime).SetEase(Ease.OutBounce);
        isBig = true;
    }

    public void TweenOut()
    {
        if(isBig == false)
            return;
        transform.DOScale(Vector3.zero, tweenTime).SetEase(Ease.InCirc);
        isBig = false;
    }
}
