using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevShirme.PlayerModule
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "DevShirme/Settings/Player Settings", order = 1)]
    public class PlayerSettings : DevSettings
    {
        #region Fields
        [Header("Movement Settings")]
        [SerializeField] private MovementData movementData;
        [Header("Rotation Settings")]
        [SerializeField] private RotationData rotationData;
        [Header("Follow Settings")]
        [SerializeField] private FollowData followData;
        #endregion

        #region Getters
        public MovementData MovementData => movementData;
        public RotationData RotationData => rotationData;
        public FollowData FollowData => followData;
        #endregion
    }
}
[Serializable]
public struct FollowData
{
    [SerializeField] private float followDist;
    [SerializeField] private float followSpeed;
    public FollowData(float followDist, float followSpeed)
    {
        this.followDist = followDist;
        this.followSpeed = followSpeed;
    }
    public float FollowDist => followDist;
    public float FollowSpeed => followSpeed;
}

[Serializable]
public struct MovementData
{
    [SerializeField] private float movementSpeed;
    public float MovementSpeed => movementSpeed;
}

[Serializable]
public struct RotationData
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationSmoothFactor;
    [SerializeField] private float minYRot;
    [SerializeField] private float maxYRot;
    public float RotationSpeed => rotationSpeed;
    public float RotationSmoothFactor => rotationSmoothFactor;
    public float MinYRot => minYRot;
    public float MaxYRot => maxYRot;
}