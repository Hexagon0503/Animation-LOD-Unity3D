using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    #region SERIALIZE FIELDS
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float rotateSpeed = 5;
    #endregion

    #region FIELDS
    /// <summary>
    /// 
    /// </summary>
    private Transform m_Transform;
    #endregion

    #region UNITY METHODS
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        m_Transform = transform;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        m_Transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
    #endregion
}
