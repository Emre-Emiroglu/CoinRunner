using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Core;
using DevShirme.Utils;
using DevShirme.PoolModule;

public class ObjectHolder : MonoBehaviour
{
    #region Fields
    [SerializeField] private Enums.GameItemType itemType;
    [SerializeField] private Enums.ObstacleType obstacleType;
    private PoolObject myObj;
    #endregion

    #region Core
    public void Activate()
    {
        switch (itemType)
        {
            case Enums.GameItemType.Collectable:
                spawn(itemType.ToString());
                break;
            case Enums.GameItemType.Obstacle:
                spawn(obstacleType.ToString());
                myObj.transform.eulerAngles = transform.eulerAngles;
                break;
        }
    }
    public void DeActivate()
    {
        myObj?.DespawnObj();
    }
    private void spawn(string objName)
    {
        myObj = ((PoolManager)DevShirmeCore.Instance.GetAManager(Enums.ManagerType.PoolManager)).GetObj(objName, transform.position);
    }
    #endregion

    #region Visualise
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        switch (itemType)
        {
            case Enums.GameItemType.Collectable:
                Gizmos.color = Color.yellow;
                break;
            case Enums.GameItemType.Obstacle:
                switch (obstacleType)
                {
                    case Enums.ObstacleType.Axe:
                        Gizmos.color = Color.blue;
                        break;
                    case Enums.ObstacleType.Fan:
                        Gizmos.color = Color.magenta;
                        break;
                    case Enums.ObstacleType.Gate:
                        Gizmos.color = Color.red;
                        break;
                }
                break;
        }
        Gizmos.DrawWireSphere(transform.position + Vector3.up * .5f, 1f);
    }
#endif
    #endregion
}
