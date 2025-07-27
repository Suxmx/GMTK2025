using MemoFramework.Extension;
using MemoFramework.GameState;

namespace GMTK
{
    public class SplashState : GameStateBase
    {
        protected override void OnStateEnter()
        {
            base.OnStateEnter();
            MF.Cutscene.EnterCutScene(GlobalConstants.CutSceneEnterDuration, () =>
            {
                GameStateComponent.RequestStateChange(EGameState.Menu.ToString());
            });
        }

        protected override void OnStateExit()
        {
            base.OnStateExit();
            MF.Cutscene.FadeCutScene(GlobalConstants.CutSceneFadeDuration);
        }
    }
}