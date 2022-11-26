using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;
using DevShirme.Core;

namespace DevShirme.Helpers
{
    public class FailChecker : MonoBehaviour
    {
        #region Physics
        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody.gameObject.CompareTag(Constants.PlayerTag))
            {
                GameManager gm = DevShirmeCore.Instance.GetAManager(Enums.ManagerType.GameManager) as GameManager;
                gm.GameOver();
                gm.GameFail();
            }
        }
        #endregion
    }
}
