using InternalAssets.Scripts.Infrastructure.AssetManagement;
using InternalAssets.Scripts.Infrastructure.Factories;
using InternalAssets.Scripts.Infrastructure.Scene;
using InternalAssets.Scripts.Infrastructure.Services.StaticData;
using InternalAssets.Scripts.Infrastructure.Services.StaticDI;


namespace InternalAssets.Scripts.Infrastructure.GameStateMachine.States
{
    public class BootstrapState: IState
    {
		private const string INITIAL_SCENE_NAME = "InitialScene";
		
		
        private readonly GameStateMachine _stateMachine;
		private readonly SceneLoader _sceneLoader;
		private readonly ServicesLocator _servicesLocator;


		public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServicesLocator servicesLocator)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
			_servicesLocator = servicesLocator;
			
			RegisterServices();
		}

        public void Enter()
        {
	        _sceneLoader.Load(INITIAL_SCENE_NAME, onLoaded: EnterInLoadLevel);
        }


        public void Exit()
        {
            
        }


		private void EnterInLoadLevel() =>
			_stateMachine.Enter<LoadProgressState>();


		private void RegisterServices()
		{
			_servicesLocator.RegisterSingle<IGameStateMachine>(_stateMachine);
			
			RegisterAssetProvider();
			
			RegisterStaticDataService();
			
			//TODO: Для UI понадобится фабрика
			
			_servicesLocator.RegisterSingle<IGameFactory>(new GameFactory(
				_servicesLocator.Single<IAssets>(),
				_servicesLocator.Single<IStaticDataService>()
				) );
		}


		private void RegisterAssetProvider()
		{
			var assetsProvider = new AssetsProvider();
			_servicesLocator.RegisterSingle<IAssets>(assetsProvider);
		}


		private void RegisterStaticDataService()
		{
			IStaticDataService staticDataService = new StaticDataService(_servicesLocator.Single<IAssets>());
			staticDataService.Load();
			_servicesLocator.RegisterSingle<IStaticDataService>(staticDataService);
		}
	}
}