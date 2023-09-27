using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SequenceTween : MonoBehaviour
{   
    [SerializeField] Transform objectToAnimation;
    [SerializeField] Transform[] points;
    [SerializeField] float transitionDuration;
    DG.Tweening.Sequence sequence;
    bool isPlaying;
    void Start()
    {
        sequence = DOTween.Sequence();
        
        foreach (Transform point in points)
        {
            sequence.Append(objectToAnimation.DOMove(point.position, transitionDuration));           
        }
        sequence.OnComplete(() => 
        {
            //objectToAnimation.DOShakeScale(2f, 5f).Play();
            objectToAnimation.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).Play();
        });
       
                
        //sequence.SetLoops(-1, LoopType.Restart);          
    }

    public void StartSequence()
    {
        isPlaying = !isPlaying;
        if (isPlaying) sequence.Play();
        else sequence.Pause();

    }
   
}
