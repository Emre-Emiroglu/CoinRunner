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
        private bool isGameOver;
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
        }
        public override void GameStart()
        {
            inputController.RemoveInputs();
            isActive = true;
            isGameOver = false;
            agent.GameStart();
        }
        public override void Reload()
        {
            agent.Reload();
        }
        public override void GameOver()
        {
            isActive = false;
            isGameOver = true;
            agent.GameOver();
        }
        public override void GameFail()
        {
            agent.GameFail();
        }
        public override void GameSuccess()
        {
            isGameOver = true;
            agent.GameSuccess();
        }
        #endregion

        #region Updates
        private void agentUpdate()
        {
            if (isActive)
            {
                inputController.Update();
                inputDir.x = isGameOver == true ? 0f : inputController.DeltaPos.x * Time.deltaTime;
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
