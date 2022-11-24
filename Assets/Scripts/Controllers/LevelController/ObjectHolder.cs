using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Core;
using DevShirme.Utils;
using DevShirme.PoolModule;

public class ObjectHolder : MonoBehaviour
{
    #region Fields
    private Enums.GameItemType itemType;
    private Enums.ObstacleType obstacleType;
    private PoolObject myObj;
    #endregion

    #region Core
    public void Activate()
    {
        //switch (itemType)
        //{
        //    case Enums.GameItemType.Collectable:
        //        spawn(itemType.ToString());
        //        break;
        //    case Enums.GameItemType.Obstacle:
        //        obstacleType = (Enums.ObstacleType)Random.Range(0, (int)Enums.ObstacleType.Count);
        //        spawn(obstacleType.ToString());
        //        break;
        //}
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
}
