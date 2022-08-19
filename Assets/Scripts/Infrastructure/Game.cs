using Infrastructure.Scene;
using Infrastructure.Services.StaticDI;

namespace Infrastructure
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
