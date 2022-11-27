using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;
using DevShirme.Helpers;
using System;

namespace DevShirme.PlayerModule
{
    public class PlayerAgent : MonoBehaviour, IUseRotator
    {
        #region Fields
        public Action<PlayerAgent> OnObstacleContact;
        [Header("Handlers")]
        [SerializeField] private MovementHandler movementHandler;
        [SerializeField] private RotationHandler rotationHandler;
        [Header("Components")]
        [SerializeField] private Rotator rotator;
        [SerializeField] private Rigidbody rb;
        [Header("Follow Fields")]
        [SerializeField] private Transform followPointParent;
        [SerializeField] private GameObject followPointPrefab;
        private List<GameObject> followPoints;
        private PlayerSettings playerSettings;
        private int collectableCount;
        #endregion

        #region Core
        public void Initialize(PlayerSettings playerSettings)
        {
            this.playerSettings = playerSettings;
            movementHandler.Initialize(this.playerSettings);
            rotationHandler.Initialize(this.playerSettings);
            collectableCount = 0;
            followPoints = new List<GameObject>();
        }
        public void GameStart()
        {
            createFollowPoints();
            SetRotator(true);
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
        }
        public void GameOver()
        {
            SetRotator(false);
        }
        public void GameSuccess()
        {
        }
        public void GameFail()
        {
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

        #region CreateFollowPoints
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

                ScoreHandler.SetCurrentScore(1);
            }
        }
        private void obstacleContact(Collider other)
        {
            collectableCount = 0;
            OnObstacleContact?.Invoke(this);
            ScoreHandler.SetCurrentScore(-ScoreHandler.CurrentScore);
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
        }
        #endregion
    }

}
