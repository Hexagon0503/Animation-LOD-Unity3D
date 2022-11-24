using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorLODGroup : MonoBehaviour
{
    #region SERIALIZE FIELDS
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private AnimatorLODProfile profile;
    #endregion

    #region FIELDS
    /// <summary>
    /// 
    /// </summary>
    private LODGroup lodGroup;

    /// <summary>
    /// 
    /// </summary>
    private LOD[] allLods;
    #endregion

    #region UNITY METHODS
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        lodGroup = GetComponent<LODGroup>();
    }

    /// <summary>
    /// 
    /// </summary>
    private void LateUpdate()
    {
        animatorLOD.animFPS = GetAnimFPS();
    }
    #endregion

    #region FUNCTIONS
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetAnimFPS()
    {
        return profile.GetLODData(GetActiveLODIndex()).animFrame;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private int GetActiveLODIndex()
    {
        if(allLods == null)
        {
            allLods = lodGroup.GetLODs();
        }
        for (int i = 0; i < allLods.Length; i++)
        {
            for (int e = 0; e < allLods[i].renderers.Length; e++)
            {
                if(allLods[i].renderers[e].isVisible)
                {
                    return i;
                }
            }
        }
        return allLods.Length - 1;
    }
    #endregion

    #region GETTER
    /// <summary>
    /// 
    /// </summary>
    private AnimatorLOD _animatorLOD = null;
    private AnimatorLOD animatorLOD
    {
        get
        {
            if(_animatorLOD == null)
            {
                _animatorLOD = GetComponentInParent<AnimatorLOD>();
            }
            return _animatorLOD;
        }
    }
    #endregion
}
