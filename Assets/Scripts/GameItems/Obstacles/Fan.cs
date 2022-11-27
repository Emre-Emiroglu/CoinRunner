using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Obstacle, IUseRotator
{
    #region Fields
    [Header("Fan Fields")]
    [SerializeField] private Rotator rotator;
    #endregion

    #region Core
    public override void initilaze()
    {
        base.initilaze();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
        SetRotator(true);
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
        SetRotator(false);
    }
    public override void OnPlayerContact(Vector3 contactPos)
    {
        base.OnPlayerContact(contactPos);
    }
    #endregion

    #region Rotator
    public void SetRotator(bool isActive)
    {
        rotator.IsActive = isActive;
    }
    #endregion
}
