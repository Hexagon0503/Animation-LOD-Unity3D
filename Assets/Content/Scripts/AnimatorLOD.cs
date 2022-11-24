using UnityEngine;

public class AnimatorLOD : MonoBehaviour
{
    #region SERIALIZE FIELDS
    /// <summary>
    /// 
    /// </summary>
    public int animFPS;
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
    public bool IsCulled
    {
        get;
        set;
    }

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
    private void Start()
    {
        if (animator.enabled)
        {
            animator.enabled = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        if (!Active || IsCulled)
        {
            return;
        }
        if (Time.frameCount % FrameDelay == 0)
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
        animator.Update(deltaTime * FrameDelay);
    }
    #endregion

    #region GETTER
    /// <summary>
    /// 
    /// </summary>
    private int FrameDelay
    {
        get
        {
            return Mathf.Max(1, Mathf.CeilToInt(Time.frameCount / Time.time) / animFPS);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private float deltaTime
    {
        get
        {
            if (UnscaledTime)
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
            if (_animator == null)
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
