using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "DevShirme/Settings/Level Settings", order = 1)]
    public class LevelSettings : DevSettings
    {
        #region Fields
        [Min(1)][SerializeField] private int minRoadCount = 1;
        [Min(1)][SerializeField] private int maxRoadCount = 10;
        [SerializeField] private AnimationCurve difficultCurve;
        #endregion

        #region Getters
        public int MinRoadCount => minRoadCount;
        public int MaxRoadCount => maxRoadCount;
        public AnimationCurve DifficultCurve => difficultCurve;
        #endregion
    }
}

