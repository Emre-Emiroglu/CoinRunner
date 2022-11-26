using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PoolModule;

public class GameItem : PoolObject
{
    #region Fields
    [SerializeField] protected Rotator rotator;
    #endregion

    #region Core
    public override void initilaze()
    {
        base.initilaze();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
    }
    #endregion

    #region Executes
    public virtual void OnPlayerContact(Vector3 contactPos) { }
    protected void SetRotatorActivation(bool isActive)
    {
        if (rotator != null)
        {
            rotator.IsActive = isActive;
        }
    }
    #endregion
}
