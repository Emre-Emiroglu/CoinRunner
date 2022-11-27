using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PlayerModule;
using DevShirme.Helpers;

public class Coin : Collectable, IUseRotator, IBouncable
{
    #region Fields
    [Header("Coin Fields")]
    [SerializeField] private Rotator rotator;
    private Rigidbody rb;
    private Transform playerAgent;
    private Transform followPoint;
    private float followSpeed;
    private bool following;
    private Coroutine bounce;
    #endregion

    #region Getters
    public bool Following => following;
    #endregion

    #region Core
    public override void initilaze()
    {
        base.initilaze();
        rb = GetComponent<Rigidbody>();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
        following = false;
        SetRotator(false);
        rb.isKinematic = true;
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
        following = false;
        SetRotator(false);
        rb.isKinematic = true;
    }
    public override void OnPlayerContact(Vector3 contactPos)
    {
        base.OnPlayerContact(contactPos);
        SetRotator(true);
    }
    #endregion

    #region Receivers
    public void OnPlayerContactToObstacle(PlayerAgent agent, BounceEffect bounceEffect)
    {
        following = false;

        seperateAnimation();

        if (bounce != null)
        {
            StopCoroutine(bounce);
        }
        bounceEffect.RemoveObj(this);

        agent.OnObstacleContact -= OnPlayerContactToObstacle;
    }
    private void seperateAnimation()
    {
        rb.isKinematic = false;
        Vector3 expPos = new Vector3(transform.position.x + Random.Range(-.1f, .1f), transform.position.y - .1f, transform.position.z - .1f);
        rb.AddExplosionForce(Random.Range(8f, 12f), expPos, .5f, 1f, ForceMode.VelocityChange);
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

    #region Bounce
    public void BounceAnimation(float targetScale, float duration)
    {
        if (bounce != null)
        {
            StopCoroutine(bounce);
        }
        bounce = StartCoroutine(bounceAnim(targetScale, duration));
    }
    public IEnumerator bounceAnim(float targetScale, float duration)
    {
        float t = 0f;
        float orgScale = 1f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float scale = Mathf.PingPong(t / duration, targetScale - orgScale) + orgScale;
            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }
    }
    #endregion
}
