using MemoFramework.Extension;
using MemoFramework.GameState;

namespace GMTK
{
    public class SplashState : GameStateBase
    {
        protected override void OnStateEnter()
        {
            base.OnStateEnter();
            MF.Cutscene.EnterCutScene(1, () =>
            {
                GameStateComponent.RequestStateChange(EGameState.Menu.ToString());
            });
        }

        protected override void OnStateExit()
        {
            base.OnStateExit();
            MF.Cutscene.FadeCutScene(1);
        }
    }
}