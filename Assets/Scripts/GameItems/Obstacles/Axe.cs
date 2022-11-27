using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

public class Axe : Obstacle
{
    #region Fields
    [Header("Axe Fields")]
    [SerializeField] private Animator animator;
    private readonly int multiplier_hash = Animator.StringToHash(Constants.AxeSpeedMultiplier);
    #endregion

    #region Core
    public override void initilaze()
    {
        base.initilaze();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
        animator.SetFloat(multiplier_hash, Random.Range(.75f, 1.25f));
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
    }
    public override void OnPlayerContact(Vector3 contactPos)
    {
        base.OnPlayerContact(contactPos);
    }
    #endregion
}
