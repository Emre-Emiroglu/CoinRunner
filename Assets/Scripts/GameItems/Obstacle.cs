using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : GameItem
{
    #region Core
    public override void initilaze()
    {
        base.initilaze();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
        SetRotatorActivation(true);
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
        SetRotatorActivation(false);
    }
    #endregion

    #region Executes
    public override void OnPlayerContact()
    {
        base.OnPlayerContact();
    }
    #endregion
}
