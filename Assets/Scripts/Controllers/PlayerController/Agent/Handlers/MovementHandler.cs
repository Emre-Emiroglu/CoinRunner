using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class MovementHandler : AgentHandler
    {
        #region Fields
        #endregion

        #region Core
        public override void Initialize(PlayerSettings settings)
        {
            base.Initialize(settings);
        }
        public override void Execute(Vector2 input)
        {
            classicMovement(input);
        }
        #endregion

        #region Movements
        private void classicMovement(Vector2 input)
        {
            transform.position += transform.forward * settings.MovementSpeed * Time.deltaTime;
        }
        #endregion
    }
}
