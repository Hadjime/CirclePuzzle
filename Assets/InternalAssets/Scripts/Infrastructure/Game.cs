using InternalAssets.Scripts.Infrastructure.Scene;
using InternalAssets.Scripts.Infrastructure.Services.StaticDI;


namespace InternalAssets.Scripts.Infrastructure
{
	public class Game
	{
		public GameStateMachine.GameStateMachine StateMachine;

		public Game(ICoroutineRunner coroutineRunner)
		{
			StateMachine = new GameStateMachine.GameStateMachine(new SceneLoader(coroutineRunner), ServicesLocator.Container);
		}
	}
}
