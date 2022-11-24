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

    /// <summary>
    /// 
    /// </summary>
    private int lodIndex = -1;
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
        lodIndex = GetActiveLODIndex();
        animatorLOD.animFPS = GetAnimFPS();
        animatorLOD.IsCulled = !IsVisible();
    }
    #endregion

    #region FUNCTIONS
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private int GetAnimFPS()
    {
        if (lodIndex == -1)
        {
            return 0;
        }
        return profile.GetLODData(lodIndex).animFrame;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool IsVisible()
    {
        return lodIndex != -1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private int i_lod, i_renderers;
    private int GetActiveLODIndex()
    {
        if(allLods == null)
        {
            allLods = lodGroup.GetLODs();
        }
        for (i_lod = 0; i_lod < allLods.Length; i_lod++)
        {
            for (i_renderers = 0; i_renderers < allLods[i_lod].renderers.Length; i_renderers++)
            {
                if(allLods[i_lod].renderers[i_renderers].isVisible)
                {
                    return i_lod;
                }
            }
        }
        return -1;
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
