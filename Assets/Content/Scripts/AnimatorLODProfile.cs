using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animator LOD Profile", menuName ="Animation LOD/ Create New LOD Profile")]
public class AnimatorLODProfile : ScriptableObject
{
    #region SERIALIZE FIELDS
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private LODData[] lodDatas;
    #endregion

    #region FUNCTIONS
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lodIndex"></param>
    /// <returns></returns>
    public LODData GetLODData(int lodIndex)
    {
        return lodDatas[Mathf.Clamp(lodIndex, 0, lodDatas.Length - 1)];
    }
    #endregion

    #region NESTED CLASS
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class LODData
    {
        public int animFrame;
    }
    #endregion
}
