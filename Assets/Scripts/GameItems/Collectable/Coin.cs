using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PlayerModule;

public class Coin : Collectable, IUseRotator
{
    #region Fields
    [Header("Coin Fields")]
    [SerializeField] private Rotator rotator;
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
        SetRotator(false);
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
        following = false;
        SetRotator(false);
    }
    public override void OnPlayerContact(Vector3 contactPos)
    {
        base.OnPlayerContact(contactPos);
        SetRotator(true);
    }
    #endregion

    #region Receivers
    public void OnPlayerContactToObstacle(PlayerAgent agent)
    {
        DespawnObj();
        agent.OnObstacleContact -= OnPlayerContactToObstacle;
    }
    #endregion

    #region Follow
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

    #region Rotator
    public void SetRotator(bool isActive)
    {
        rotator.IsActive = isActive;
    }
    #endregion
}
