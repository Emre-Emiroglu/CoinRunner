using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DevShirme.Utils;

namespace DevShirme.CameraModule
{
    public class CameraController : DevShirmeController
    {
        #region Fields
        [SerializeField] private List<CinemachineVirtualCamera> cameras;
        #endregion

        #region Core
        public override void Initialize()
        {
            toNewCam(Enums.Cameras.Follow);
        }
        public override void GameStart()
        {
        }
        public override void Reload()
        {
            toNewCam(Enums.Cameras.Follow);
        }
        public override void GameOver()
        {
        }
        public override void GameFail()
        {
        }
        public override void GameSuccess()
        {
            toNewCam(Enums.Cameras.Success);
        }
        #endregion

        #region Executes
        private void toNewCam(Enums.Cameras newCam)
        {
            cameras.ForEach(x => x.Priority = 0);
            cameras[((int)newCam)].Priority = 99;
        }
        #endregion

    }

}
