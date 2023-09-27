using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using static Unity.Collections.AllocatorManager;

public class DoTweenMove : MonoBehaviour
{
    Tween myTween;
    Tween myTween2;
    [SerializeField] Transform objectToMove;
    [SerializeField] Transform destination;
    [SerializeField] float animationTime;
    [Tooltip("Тип перемещения")]
    [SerializeField] Ease easeType;
    [SerializeField] bool isLoop;
    [Tooltip("Тип зацикливания")]
    [SerializeField] LoopType loopType;   
    [SerializeField] int loopsCount;   
    [Tooltip("Перемещение только по целым целочисленными координатам")]
    [SerializeField] bool isSnapping;
    // Start is called before the first frame update
    void Start()
    {
        





    }
    public void StartMove()
    {
        myTween = objectToMove.DOMove(destination.position, animationTime, isSnapping);
        myTween.SetEase(easeType);
        if (isLoop)
            myTween.SetLoops(loopsCount, loopType);

        myTween.OnComplete(() =>
        {
            Debug.Log("Complete");
            myTween.Rewind();
            myTween.Play();
            
            //myTween.Kill();
        });
        myTween.Play();

        myTween2 = objectToMove.DOMoveY(-5, animationTime * 0.2f)
           .SetLoops(-1, LoopType.Yoyo)
           .SetEase(Ease.InOutSine);
        myTween2.Play();
    }
    public void PauseMove()
    {
        myTween.Pause();
        myTween2.Pause();
    }
    void StartFunction()
    {
        Debug.Log("Начало анимации");
    }
    void EndFunction()
    {
        Debug.Log("Конец анимации");
    }
}
