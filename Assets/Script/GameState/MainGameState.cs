using MemoFramework.Extension;
using MemoFramework.GameState;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GMTK
{
    public class MainGameState : GameStateBase
    {
        protected override void OnStateEnter()
        {
            base.OnStateEnter();
            SceneManager.LoadScene(SceneConstants.Game);
            if (MF.Cutscene.IsPlaying)
            {
                MF.Cutscene.FadeCutScene(1);
            }
            Transform root = new GameObject("Managers").transform;
            
        }
        

        protected override void OnStateExit()
        {
            base.OnStateExit();
           
        }
    }
}