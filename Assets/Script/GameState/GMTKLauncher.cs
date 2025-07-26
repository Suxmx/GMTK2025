using MemoFramework;
using MemoFramework.GameState;

namespace GMTK
{
    public class GMTKLauncher : MFLauncher
    {
        public override void InitGameStatesFsm(GameStateComponent gameStateComponent)
        {
            // gameStateComponent.PushGameState(EGameState.Init.ToString(), new InitState());
            gameStateComponent.PushGameState(EGameState.Splash.ToString(), new SplashState());
            gameStateComponent.PushGameState(EGameState.Menu.ToString(), new MenuState());
            // gameStateComponent.PushGameState(EGameState.Preload.ToString(), new PreloadState());
            gameStateComponent.PushGameState(EGameState.Game.ToString(), new MainGameState());
            gameStateComponent.PushGameState(EGameState.GameOver.ToString(), new GameOverState());

            gameStateComponent.SetAsStartState(EGameState.Splash.ToString());
        }
    }
}