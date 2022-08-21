using InternalAssets.Scripts.Infrastructure.Factories;
using InternalAssets.Scripts.Infrastructure.Scene;
using InternalAssets.Scripts.Infrastructure.Services.StaticData;


namespace InternalAssets.Scripts.Infrastructure.GameStateMachine.States
{
	public class LoadSceneState : IPayloadState<string>
	{
		private readonly GameStateMachine _stateMachine;
		private readonly SceneLoader _sceneLoader;
		private readonly IGameFactory _gameFactory;
		private readonly IStaticDataService _staticDataService;


		public LoadSceneState(
				GameStateMachine stateMachine,
				SceneLoader sceneLoader,
				IGameFactory gameFactory,
				IStaticDataService staticDataService
			)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
			_gameFactory = gameFactory;
			_staticDataService = staticDataService;
		}

		public void Enter(string sceneName)
		{
			_gameFactory.Cleanup();
			_gameFactory.WarmUp();
			_sceneLoader.Load(sceneName, OnLoaded);
		}

		public void Exit() {}

		private async void OnLoaded()
		{
			//TODO проинициализировать PazzleController, BallGenerator (пока они просто компонентами сделаны)
		}
	}
}
