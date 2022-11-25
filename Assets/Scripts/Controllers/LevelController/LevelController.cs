using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Core;
using DevShirme.PoolModule;
using DevShirme.Utils;

namespace DevShirme.LevelModule
{
    public class LevelController : DevShirmeController
    {
        #region Fields
        [SerializeField] private List< string> roadNames;
        private List<RoadPart> roadParts;
        #endregion

        #region Getters
        private RoadPart getRandomRoadPart(Vector3 spawnPos)
        {
            PoolManager pm = DevShirmeCore.Instance.GetAManager(Enums.ManagerType.PoolManager) as PoolManager;
            roadNames = Utilities.Shuffle(roadNames);
            RoadPart roadPart = (RoadPart)pm.GetObj(roadNames[0], spawnPos);
            roadPart.SetHolders(true);
            return roadPart;
        }
        #endregion

        #region Core
        public override void Initialize()
        {
            roadParts = new List<RoadPart>();

            generateRandomLevel();
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

        #region Clear
        private void clearOldLevel()
        {
            if (roadParts.Count > 0)
            {
                for (int i = 0; i < roadParts.Count; i++)
                {
                    roadParts[i].DespawnObj();
                    roadParts[i].SetHolders(false);
                }
                roadParts.Clear();
            }
        }
        #endregion

        #region Generator
        [ContextMenu("Random Level Generate")]
        private void generateRandomLevel()
        {
            clearOldLevel();

            LevelSettings ls = settings as LevelSettings;
            int roadCount = Random.Range(ls.MinRoadCount, ls.MaxRoadCount + 1);

            for (int i = 0; i < roadCount; i++)
            {
                Vector3 spawnPos = Vector3.zero;
                if (i > 0)
                {
                    spawnPos = roadParts[i - 1].AttachPos.position;
                }

                RoadPart currentPart = getRandomRoadPart(spawnPos);

                if (!roadParts.Contains(currentPart))
                {
                    roadParts.Add(currentPart);
                }
            }
        }
        #endregion
    }
}

