using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class RotationHandler : AgentHandler
    {
        #region Fields
        private RotationData rotationData;
        private float rotY;
        #endregion

        #region Core
        public override void Initialize(PlayerSettings settings)
        {
            base.Initialize(settings);
            this.rotationData = settings.RotationData;
        }
        public override void Execute(Vector2 input)
        {
            if (input.sqrMagnitude > 0f)
            {
                rotY += input.x * rotationData.RotationSpeed;
                rotY = Mathf.Clamp(rotY, rotationData.MinYRot, rotationData.MaxYRot);

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, rotY, 0f)), Time.deltaTime * rotationData.RotationSmoothFactor);
            }
        }
        #endregion
    }
}
