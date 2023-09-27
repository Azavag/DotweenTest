using DG.Tweening;
using UnityEngine;

public class DoTweenRotate : MonoBehaviour
{
    Tween myTween;
    [SerializeField] Transform objectToRotate;
    [SerializeField] Vector3 rotateVector;
    [SerializeField] float rotationTime;
    [SerializeField] Ease easeType;
    [Tooltip("Тип перемещения")]
    [SerializeField] RotateMode rotateType;
    [SerializeField] bool isLoop;
    [Tooltip("Тип зацикливания")]
    [SerializeField] LoopType loopType;
    [SerializeField] int loopsCount;
    bool isRotate;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    public void PauseRotation()
    {
        myTween.Pause();
    }

    public void StartRotation()
    {
        if (isRotate)
            return;
        isRotate = !isRotate;
        myTween = objectToRotate.DORotate(rotateVector, rotationTime, rotateType);
        myTween.SetEase(easeType);
        if (isLoop)
            myTween.SetLoops(loopsCount, loopType);
       
        myTween.OnKill(() => { isRotate = false; });
        myTween.Play();
    }
}

