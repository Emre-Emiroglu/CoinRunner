using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.PlayerModule
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "DevShirme/Settings/Player Settings", order = 1)]
    public class PlayerSettings : DevSettings
    {
        #region Fields
        [Header("Movement Settings")]
        [SerializeField] private float movementSpeed = 10f;
        [Header("Rotation Settings")]
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float rotationSmoothFactor = .5f;
        [SerializeField] private float minYRot = -30f;
        [SerializeField] private float maxYRot = 30f;
        #endregion

        #region Getters
        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        public float RotationSmoothFactor => rotationSmoothFactor;
        public float MinYRot => minYRot;
        public float MaxYRot => maxYRot;
        #endregion
    }
}
