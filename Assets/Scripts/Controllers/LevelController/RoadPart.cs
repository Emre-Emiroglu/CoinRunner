using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PoolModule;
using DevShirme.Utils;

namespace DevShirme.LevelModule
{
    public class RoadPart : PoolObject
    {
        #region Fields
        [Header("Componenets")]
        [SerializeField] private Transform attachPos;
        [SerializeField] private List<ObjectHolder> objectHolders;
        #endregion

        #region Getters
        public Transform AttachPos => attachPos;
        #endregion

        #region Core
        public override void initilaze()
        {
            base.initilaze();
        }
        public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
        {
            base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
        }
        public override void DespawnObj()
        {
            base.DespawnObj();
        }
        #endregion

        #region Executes
        public void SetHolders(bool isActive)
        {

            var shuffleList = Utilities.Shuffle(objectHolders);
            for (int i = 0; i < shuffleList.Count; i++)
            {
                if (isActive)
                {
                    objectHolders[i].Activate();
                }
                else
                    objectHolders[i].DeActivate();
            }
        }
        #endregion
    }
}

