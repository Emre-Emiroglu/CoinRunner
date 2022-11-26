using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Coin = PlayerPrefs.GetInt("Coin", 0);
            Level = PlayerPrefs.GetInt("Level", 1);
            PlayerPrefs.Save();
        }
        public override void SaveData()
        {
            PlayerPrefs.SetInt("Coin", Coin);
            PlayerPrefs.Save();
        }
        #endregion

    }

}
