using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.DataModule
{
    public class PlayerData : Data
    {
        #region Fields
        public int Level;
        public int Coin;
        #endregion

        #region Executes
        public override void LoadData()
        {
            Coin = PlayerPrefs.GetInt(Constants.PlayerDataCoin, 0);
            Level = PlayerPrefs.GetInt(Constants.PlayerDataLevel, 1);
            PlayerPrefs.Save();
        }
        public override void SaveData()
        {
            PlayerPrefs.SetInt(Constants.PlayerDataCoin, Coin);
            PlayerPrefs.SetInt(Constants.PlayerDataLevel, Level);
            PlayerPrefs.Save();
        }
        #endregion

    }

}
