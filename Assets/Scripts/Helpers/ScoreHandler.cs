using System;
using DevShirme.Core;
using DevShirme.DataModule;

namespace DevShirme.Helpers
{
    public static class ScoreHandler
    {
        #region Fields
        public static Action<int> OnScoreChanged;
        private static int currentScore;
        #endregion

        #region Getters
        public static int CurrentScore => currentScore;
        #endregion

        #region Executes
        public static void SetCurrentScore(int amount, bool uiRefresh = true, bool save = true)
        {
            currentScore += amount;
            if (uiRefresh)
            {
                OnScoreChanged?.Invoke(currentScore);
            }
            if (save)
            {
                DataManager dm = DevShirmeCore.Instance.GetAManager(Utils.Enums.ManagerType.DataManager) as DataManager;
                dm.PlayerData.Coin += amount;
                dm.PlayerData.SaveData();
            }
        }
        public static void Reload()
        {
            currentScore = 0;
            OnScoreChanged?.Invoke(currentScore);
        }
        #endregion
    }
}
