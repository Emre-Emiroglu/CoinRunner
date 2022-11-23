using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevShirme
{
    public abstract class DevShirmeController: MonoBehaviour, IGameCycle
    {
        #region Fields
        [SerializeField] protected DevSettings settings;
        #endregion

        #region Getters
        public DevSettings Settings => settings;
        #endregion

        #region Core
        public abstract void Initialize();
        public abstract void GameFail();
        public abstract void GameOver();
        public abstract void GameStart();
        public abstract void GameSuccess();
        public abstract void Reload();
        #endregion
    }
}
