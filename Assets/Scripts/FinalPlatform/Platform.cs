using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DevShirme.Utils;
using DevShirme.Core;

public class Platform : MonoBehaviour
{
    #region Fields
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private TMP_Text xText;
    #endregion

    #region Core
    public void Initialize(Material mat, Vector3 localPos, float xValue)
    {
        transform.localPosition = localPos;
        meshRenderer.sharedMaterial = mat;
        xText.SetText("X" + xValue);
    }
    #endregion

    #region Physic
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.CollectableTag))
        {
            Coin c = other.GetComponentInParent<Coin>();
            c.Stop();
        }
    }
    #endregion
}
