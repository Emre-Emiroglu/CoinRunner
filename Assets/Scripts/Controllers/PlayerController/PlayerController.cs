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
            inputController.ClampDistance = 10;
            inputController.Lerp = true;
            inputController.LerpSpeed = .1f;
            inputController.Sensitivity = .1f;

            isActive = true;
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
        private void agentUpdate()
        {
            if (isActive)
            {
                inputController.Update();
                inputDir.x = inputController.DeltaPos.x * Time.deltaTime;
                inputDir.y = 0f;

                agent.Rotation(inputDir);
                agent.Movement(inputDir);
            }
        }
        private void Update()
        {
            agentUpdate();
        }
        #endregion
    }

}
