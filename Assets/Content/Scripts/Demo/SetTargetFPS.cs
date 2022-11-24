using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetFPS : MonoBehaviour
{
    [SerializeField] private int initFPS = 60;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        SetFPS(initFPS);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetFPS"></param>
    public void SetFPS(int targetFPS)
    {
        Application.targetFrameRate = targetFPS;
    }
}
