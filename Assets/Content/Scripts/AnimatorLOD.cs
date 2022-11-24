using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorLOD : MonoBehaviour
{
    #region SERIALIZE FIELDS
    /// <summary>
    /// 
    /// </summary>
    public AnimatorLODType animatorLODType;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float frameDelay;
    #endregion

    #region FIELDS
    /// <summary>
    /// 
    /// </summary>
    public bool Active
    {
        get;
        set;
    } = true;

    /// <summary>
    /// 
    /// </summary>
    public bool UnscaledTime
    {
        get;
        set;
    } = false;
    #endregion

    #region UNITY METHODS
    /// <summary>
    /// 
    /// </summary>
    private void OnEnable()
    {
        animator.enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        if(!Active)
        {
            return;
        }
        if(Time.frameCount % frameDelay == 0)
        {
            UpdateAnimator();
        }
    }
    #endregion

    #region METHODS
    /// <summary>
    /// 
    /// </summary>
    public void UpdateAnimator()
    {
        animator.Update(deltaTime * frameDelay);
    }
    #endregion

    #region GETTER
    /// <summary>
    /// 
    /// </summary>
    private float deltaTime
    {
        get
        {
            if(UnscaledTime)
            {
                return Time.unscaledDeltaTime;
            }
            return Time.deltaTime;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private Animator _animator;
    private Animator animator
    {
        get
        {
            if(_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
            return _animator;
        }
    }
    #endregion

    #region NESTED CLASS
    /// <summary>
    /// 
    /// </summary>
    public enum AnimatorLODType
    {
        LODGroup,
        Distance,
        Custom,
    }
    #endregion
}
