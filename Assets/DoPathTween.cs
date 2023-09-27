using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoPathTween : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform[] objects;
    [SerializeField] float duration;
    [SerializeField] PathType pathType;
    [SerializeField] PathMode pathMode;
    Vector3[] path;
    void Start()
    {
        int counter = 0;
        path = new Vector3[objects.Length];
        foreach (Transform t in objects)
        {
            path[counter++] = t.position;
        }
        
    }

    public void StartPath()
    {
        target.DOPath(path, duration, pathType, pathMode,
            gizmoColor: Color.white)
            .Play()
            .OnStart(() =>
            {
                Debug.Log("Start");
            })
            .OnComplete(() =>
            {
                target.DORewind();
                target.DOKill();
            });

    }
}
