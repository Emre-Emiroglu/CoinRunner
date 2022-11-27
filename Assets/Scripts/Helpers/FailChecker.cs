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
            if (other.gameObject.CompareTag(Constants.PlayerTag))
            {
                GameManager gm = DevShirmeCore.Instance.GetAManager(Enums.ManagerType.GameManager) as GameManager;
                gm.GameOver();
                gm.GameFail();
            }
            if (other.gameObject.CompareTag(Constants.CollectableTag))
            {
                Collectable c = other.GetComponentInParent<Collectable>();
                c.DespawnObj();
            }
        }
        #endregion
    }
}
