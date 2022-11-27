using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlatform : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<Platform> platforms;
    [SerializeField] private List<Material> materials;
    [SerializeField] private Vector3 distPerPlatform;
    [SerializeField] private float xPerPlatform = .2f;
    private int matIndex;
    #endregion

    #region Core
    public void Initialize(Vector3 replacePos)
    {
        matIndex = -1;
        transform.position = replacePos;
        for (int i = 0; i < platforms.Count; i++)
        {
            matIndex++;
            matIndex = matIndex == materials.Count ? 0 : matIndex;
            Material mat = materials[matIndex];
            Vector3 localPos = distPerPlatform * (i + 1);
            float xValue = (i + 1) * xPerPlatform + 1;
            platforms[i].Initialize(mat, localPos, xValue);
        }
    }
    #endregion
}
