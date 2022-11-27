using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;
using DevShirme.Helpers;
using DevShirme.Core;
using System;

namespace DevShirme.PlayerModule
{
    public class PlayerAgent : MonoBehaviour, IUseRotator, IGameCycle
    {
        #region Fields
        public Action<PlayerAgent, BounceEffect> OnObstacleContact;
        [Header("Components")]
        [SerializeField] private Rotator rotator;
        [SerializeField] private Rigidbody rb;
        [Header("Handlers")]
        [SerializeField] private MovementHandler movementHandler;
        [SerializeField] private RotationHandler rotationHandler;
        [Header("Follow Fields")]
        [SerializeField] private Transform followPointParent;
        [SerializeField] private GameObject followPointPrefab;
        [Header("Bounce")]
        [SerializeField] private BounceEffect bounceEffect;
        private List<GameObject> followPoints;
        private PlayerSettings playerSettings;
        private int collectableCount;
        private Transform finalPlatform;
        private Coroutine finalReplaceAnim;
        #endregion

        #region Core
        public void Initialize(PlayerSettings playerSettings)
        {
            this.playerSettings = playerSettings;
            movementHandler.Initialize(this.playerSettings);
            rotationHandler.Initialize(this.playerSettings);
            bounceEffect.Initialize();

            collectableCount = 0;
            followPoints = new List<GameObject>();

            mobility(false);
        }
        public void Initialize()
        {
        }
        public void GameStart()
        {
            createFollowPoints();
            mobility(true);
        }
        public void Reload()
        {
            collectableCount = 0;
            for (int i = 0; i < followPoints.Count; i++)
            {
                Destroy(followPoints[i]);
            }
            followPoints.Clear();

            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;

            bounceEffect.ClearObjects();
        }
        public void GameOver()
        {
            mobility(false);
        }
        public void GameSuccess()
        {
            transform.rotation = Quaternion.identity;
            mobility(false);
            pyramidFormation();
        }
        public void GameFail()
        {
        }
        private void mobility(bool isActive)
        {
            SetRotator(isActive);
            rb.isKinematic = !isActive;
            rb.useGravity = isActive;
        }
        #endregion

        #region Rotator
        public void SetRotator(bool isActive)
        {
            rotator.IsActive = isActive;
        }
        #endregion

        #region Handlers
        public void Movement(Vector2 input)
        {
            movementHandler.Execute(input);
        }
        public void Rotation(Vector2 input)
        {
            rotationHandler.Execute(input);
        }
        #endregion

        #region Follow
        private void createFollowPoints(int count = 10)
        {
            int lastCount = followPoints.Count + 1;
            for (int i = 0; i < count; i++)
            {
                GameObject obj = Instantiate(followPointPrefab, followPointParent);
                obj.name = "FollowPoint";
                followPoints.Add(obj);
                obj.transform.localPosition += Vector3.back * playerSettings.FollowData.FollowDist * (lastCount + i);
            }
        }
        private void pyramidFormation()
        {
            float yDist = 1f;
            float xDist = .2f;
            int rowCount = 0;
            for (int i = 0; i < collectableCount; i += 5)
            {
                rowCount++;
                for (int j = 0; j < 5; j++)
                {
                    followPoints[j + i].transform.localPosition = new Vector3(-.4f + (j * xDist), (i + 5) / 5 * -yDist, 0f);
                }
            }

            finalReplace(yDist, rowCount);
        }
        private void finalReplace(float yDist, int rowCount)
        {
            Vector3 targetPos = new Vector3(finalPlatform.position.x, yDist * (rowCount), transform.position.z);
            if (finalReplaceAnim != null)
            {
                StopCoroutine(finalReplaceAnim);
            }
            finalReplaceAnim = StartCoroutine(finalReplaceAnimation(1f, targetPos));
        }
        private IEnumerator finalReplaceAnimation(float duration, Vector3 targetpos)
        {
            float t = 0f;
            Vector3 orgPos = transform.position;
            while (t < duration)
            {
                t += Time.deltaTime;
                transform.position = Vector3.Lerp(orgPos, targetpos, t / duration);
                yield return null;
            }
            transform.position = targetpos;
        }
        #endregion

        #region Physics
        private void coinContact(Collider other)
        {
            Coin collectable = other.GetComponentInParent<Coin>();
            if (!collectable.Following)
            {
                collectableCount++;

                Transform followPoint = followPoints[collectableCount - 1].transform;
                float followSpeed = playerSettings.FollowData.FollowSpeed - ((collectableCount - 1) * .33f);
                followSpeed = followSpeed < 1f ? 1f : followSpeed;

                collectable.OnPlayerContact(transform.position);
                collectable.GetFollowDatas(transform, followPoint, followSpeed);
                OnObstacleContact += collectable.OnPlayerContactToObstacle;
                if (collectableCount % 10 == 0)
                {
                    createFollowPoints();
                }

                ScoreHandler.SetCurrentScore(1, true, false);

                bounceEffect.AddNewObj(collectable);
                bounceEffect.StartBounceEffect();
            }
        }
        private void obstacleContact(Collider other)
        {
            collectableCount = 0;
            OnObstacleContact?.Invoke(this, bounceEffect);
            ScoreHandler.SetCurrentScore(-ScoreHandler.CurrentScore, true, false);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Enums.GameItemType.Collectable.ToString()))
            {
                coinContact(other);
            }
            if (other.gameObject.CompareTag(Enums.GameItemType.Obstacle.ToString()))
            {
                obstacleContact(other);
            }
            if (other.gameObject.CompareTag(Constants.PlatformTag))
            {
                Platform platform = other.gameObject.GetComponentInParent<Platform>();
                int amount = (int)(ScoreHandler.CurrentScore * platform.XValue);
                ScoreHandler.SetCurrentScore(amount);

                GameManager gm = DevShirmeCore.Instance.GetAManager(Enums.ManagerType.GameManager) as GameManager;
                gm.GameOver();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(Constants.FinalPlatformTag))
            {
                finalPlatform = other.gameObject.transform;

                GameManager gm = DevShirmeCore.Instance.GetAManager(Enums.ManagerType.GameManager) as GameManager;
                gm.GameSuccess();
            }
        }
        #endregion
    }

}
