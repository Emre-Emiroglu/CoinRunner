using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PoolModule;
using DevShirme.Utils;
using DevShirme.Core;

namespace DevShirme.LevelModule
{
    public class RoadPart : PoolObject
    {
        #region Fields
        [Header("Componenets")]
        [SerializeField] private Transform attachPos;
        [SerializeField] private List<ObjectHolder> collectableObjectHolders;
        [SerializeField] private List<ObjectHolder> obstacleObjectHolders;
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
        public void SetHolders(bool isActive, AnimationCurve diffCurve, int level = 1)
        {
            #region Collectables
            for (int i = 0; i < collectableObjectHolders.Count; i++)
            {
                if (isActive)
                    collectableObjectHolders[i].Activate();
                else
                    collectableObjectHolders[i].DeActivate();
            }
            #endregion

            #region Obstacles
            var shuffleList = Utilities.Shuffle(obstacleObjectHolders);
            int count = (int)(shuffleList.Count * diffCurve.Evaluate(level * .01f));
            for (int i = 0; i < count; i++)
            {
                if (isActive)
                    shuffleList[i].Activate();
                else
                    shuffleList[i].DeActivate();
            }
            #endregion
        }
        #endregion
    }
}

