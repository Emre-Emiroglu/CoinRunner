using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.PlayerModule
{
    public class PlayerController : DevShirmeController
    {
        #region Fields
        [Header("Player Controller Settings")]
        [SerializeField] private PlayerAgent agent;
        private bool isActive;
        private InputController inputController;
        private Vector2 inputDir;
        #endregion

        #region Core
        public override void Initialize()
        {
            agent?.Initialize(settings as PlayerSettings);

            inputController = new InputController();
            inputController.Behavior = InputBehavior.Clamped;
            inputController.ClampDistance = 80;
            inputController.Lerp = true;
            inputController.LerpSpeed = 0.1f;
            inputController.Sensitivity = 1f;
        }
        public override void GameStart()
        {
        }
        public override void Reload()
        {
        }
        public override void GameOver()
        {
        }
        public override void GameFail()
        {
        }
        public override void GameSuccess()
        {
        }
        #endregion

        #region Updates
        private void MovementSetup()
        {
            if (isActive)
            {
                inputController.Update();
                inputDir.x = inputController.DeltaPos.x * Time.deltaTime;
                inputDir.y = 0f;

                agent.Movement(inputDir);
            }
        }
        private void Update()
        {
            MovementSetup();
        }
        #endregion
    }

}
