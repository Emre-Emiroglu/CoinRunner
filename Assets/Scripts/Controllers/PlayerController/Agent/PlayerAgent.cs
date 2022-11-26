using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;
using System;

namespace DevShirme.PlayerModule
{
    public class PlayerAgent : MonoBehaviour
    {
        public Action<PlayerAgent> OnObstacleContact;
        #region Fields
        [Header("Handlers")]
        [SerializeField] private MovementHandler movementHandler;
        [SerializeField] private RotationHandler rotationHandler;
        [SerializeField] private Rotator rotator;
        [Header("Components")]
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
            //TODO: StartGame
            createFollowPoints();
        }
        public void Reload()
        {
            collectableCount = 0;
            for (int i = 0; i < followPoints.Count; i++)
            {
                Destroy(followPoints[i]);
            }
            followPoints.Clear();
        }
        #endregion

        #region Handlers
        public void Movement(Vector2 input)
        {
            movementHandler.Execute(input);
            rotator.IsActive = true;
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
        private void collectableContact(Collider other)
        {
            Collectable collectable = other.GetComponentInParent<Collectable>();
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
            }
        }
        private void obstacleContact(Collider other)
        {
            collectableCount = 0;
            OnObstacleContact?.Invoke(this);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Enums.GameItemType.Collectable.ToString()))
            {
                collectableContact(other);
            }
            if (other.gameObject.CompareTag(Enums.GameItemType.Obstacle.ToString()))
            {
                obstacleContact(other);
            }
        }
        #endregion
    }

}
