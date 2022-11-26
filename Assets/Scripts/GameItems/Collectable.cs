using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : GameItem
{
    #region Fields
    private Transform playerAgent;
    private Transform followPoint;
    private float followSpeed;
    private bool following;
    #endregion

    #region Getters
    public bool Following => following;
    #endregion

    #region Core
    public override void initilaze()
    {
        base.initilaze();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
        following = false;
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
        SetRotatorActivation(false);
        following = false;
    }
    #endregion

    #region Executes
    public override void OnPlayerContact(Vector3 contactPos)
    {
        base.OnPlayerContact(contactPos);
        SetRotatorActivation(true);
    }
    public void GetFollowDatas(Transform agent, Transform followPoint, float followSpeed)
    {
        this.playerAgent = agent;
        this.followPoint = followPoint;
        this.followSpeed = followSpeed;
        following = true;
    }
    private void follow()
    {
        if (following)
        {
            Vector3 followPos = followPoint.position;
            transform.position = Vector3.Lerp(transform.position, followPos, followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, playerAgent.rotation, 10f * Time.deltaTime);
        }
    }
    private void Update()
    {
        follow();
    }
    #endregion
}
