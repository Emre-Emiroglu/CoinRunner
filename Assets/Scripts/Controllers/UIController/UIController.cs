using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DevShirme.Utils;

namespace DevShirme.UIModule
{
    public class UIController : DevShirmeController
    {
        #region Fields
        [SerializeField] private ViewContainer viewContainer;
        [Header("UI Panels")]
        [SerializeField] private List<UIPanel> panels;
        #endregion

        #region Core
        public override void Initialize()
        {
            viewContainer.Initialize();

            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].Initialize(panels[i].gameObject);
            }
            transation(Constants.MainMenuPanelTag);
        }
        public override void GameStart()
        {
            transation(Constants.InGamePanelTag);
        }
        public override void Reload()
        {
            viewContainer.Reload();

            transation(Constants.MainMenuPanelTag);
        }
        public override void GameOver()
        {
            transation(Constants.EndGamePanelTag);
        }
        public override void GameFail()
        {
            EndGamePanel endGamePanel = GetPanel(Constants.EndGamePanelTag) as EndGamePanel;
            endGamePanel.SetEndPanels(false);
        }
        public override void GameSuccess()
        {
            EndGamePanel endGamePanel = GetPanel(Constants.EndGamePanelTag) as EndGamePanel;
            endGamePanel.SetEndPanels(true);
        }
        #endregion

        #region PanelProcess
        public UIPanel GetPanel(string name)
        {
            UIPanel panel = panels.First(x => x.PanelName == name);
            return panel;
        }
        private void transation(string name)
        {
            panels.ForEach(x => x.Hide());
            UIPanel panel = GetPanel(name);
            panel.Show();
        }
        #endregion
    }
}

[System.Serializable]
public struct PanelDatas
{
    [SerializeField] private bool smoothPanels;
    [SerializeField] private float showDuration;
    [SerializeField] private float hideDuration;

    #region Getters
    public bool SmoothPanels => smoothPanels;
    public float ShowDuration => showDuration;
    public float HideDuration => hideDuration;
    #endregion
}