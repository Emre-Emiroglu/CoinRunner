using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class EndGamePanel : UIPanel
    {
        #region Fields
        [SerializeField] private GameObject successPanel;
        [SerializeField] private GameObject failPanel;
        #endregion

        #region Core
        public override void Initialize(GameObject obj)
        {
            base.Initialize(obj);
        }
        public override void Show()
        {
            base.Show();
        }
        public override void Hide()
        {
            base.Hide();
        }
        #endregion

        #region Executes
        public void SetEndPanels(bool isGameSuccess)
        {
            successPanel.SetActive(isGameSuccess);
            failPanel.SetActive(!isGameSuccess);
        }
        #endregion
    }
}
