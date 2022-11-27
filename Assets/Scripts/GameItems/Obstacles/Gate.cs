using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : Obstacle
{
    #region Fields
    [SerializeField] private float animSpeed = 2f;
    [SerializeField] private float height = 1f;
    private Vector3 pos;
    #endregion

    #region Core
    public override void initilaze()
    {
        base.initilaze();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
        this.pos = pos;
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

    #region GateAnim
    private void Update()
    {
        if (InUse)
        {
            float newY = Mathf.Sin(Time.time * animSpeed) * height + pos.y;
            transform.position = new Vector3(pos.x, newY, pos.z);
        }
    }
    #endregion
}
