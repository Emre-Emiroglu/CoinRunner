using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DevShirme.UIModule
{
    public class UIController : DevShirmeController
    {
        #region Fields
        [Header("Module Fields")]
        [SerializeField] private List<UIPanel> panels;
        #endregion

        #region Core
        public override void Initialize()
        {
            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].Initialize(panels[i].gameObject);
            }
            panels[0].Show();
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

        #region PanelProcess
        public UIPanel GetPanel(string name)
        {
            UIPanel panel = panels.First(x => x.PanelName == name);
            return panel;
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