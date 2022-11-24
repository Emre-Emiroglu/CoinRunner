using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PoolModule;

namespace DevShirme.LevelModule
{
    public class RoadPart : PoolObject
    {
        #region Fields
        [Header("Componenets")]
        [SerializeField] private Transform attachPos;
        [SerializeField] private ObjectHolder[] holders;
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

            for (int i = 0; i < holders.Length; i++)
            {
                holders[i].Activate();
            }
        }
        public override void DespawnObj()
        {
            base.DespawnObj();

            for (int i = 0; i < holders.Length; i++)
            {
                holders[i].DeActivate();
            }
        }
        #endregion
    }
}

