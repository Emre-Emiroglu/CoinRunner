using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : GameItem
{
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
    public override void OnPlayerContact(Vector3 contactPos)
    {
        base.OnPlayerContact(contactPos);
    }
    #endregion
}
