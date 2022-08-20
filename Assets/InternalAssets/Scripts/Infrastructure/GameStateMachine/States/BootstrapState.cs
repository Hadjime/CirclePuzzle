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
			// RegisterAdsService();

			_servicesLocator.RegisterSingle<IGameStateMachine>(_stateMachine);
			
			RegisterAssetProvider();
			
			// _servicesLocator.RegisterSingle<IRandomService>(new UnityRandomService());
			// _servicesLocator.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());

			// RegisterIAPService(new IAPProvider(), _servicesLocator.Single<IPersistentProgressService>());
			RegisterStaticDataService();
			
			// RegisterWindowsServiceAndUIFactory();

			// _servicesLocator.RegisterSingle<IInputService>(SetupInputServices());
			_servicesLocator.RegisterSingle<IGameFactory>(new GameFactory(
				_servicesLocator.Single<IAssets>(),
				_servicesLocator.Single<IStaticDataService>()
				) );
			
			// _servicesLocator.RegisterSingle<ISaveLoadService>(new SaveLoadService(
			// 	_servicesLocator.Single<IPersistentProgressService>(),
			// 	_servicesLocator.Single<IGameFactory>()));
			
			// SRDebug.Instance.AddOptionContainer(new CheatsThroughDI(
			// 	_servicesLocator.Single<IPersistentProgressService>(),
			// 	_servicesLocator.Single<ISaveLoadService>(),
			// 	_servicesLocator.Single<IGameFactory>()));
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


		// private void RegisterWindowsServiceAndUIFactory()
		// {
		// 	var windowService = new WindowService();
		// 	_servicesLocator.RegisterSingle<IWindowService>(windowService);
		//
		// 	UIFactory uiFactory = new UIFactory(
		// 		_servicesLocator.Single<IAssets>(),
		// 		_servicesLocator.Single<IStaticDataService>(),
		// 		_servicesLocator.Single<IPersistentProgressService>(),
		// 		_servicesLocator.Single<IAdsService>(),
		// 		_servicesLocator.Single<IWindowService>());
		// 	_servicesLocator.RegisterSingle<IUIFactory>(uiFactory);
		//
		// 	windowService.Initialize(uiFactory);
		// }


		// private IInputService SetupInputServices()
		// {
		// 	var _inputServices = new NewInputSystemService();
		// 	_inputServices.Init();
		// 	return _inputServices;
		// }


		// private void RegisterAdsService()
		// {
		// 	IAdsService adsService = new AdsService();
		// 	adsService.Initialize(true);
		// 	_servicesLocator.RegisterSingle<IAdsService>(adsService);
		// }


		// private void RegisterIAPService(IAPProvider iapProvider, IPersistentProgressService progressService)
		// {
		// 	IAPService iapService = new IAPService(iapProvider, progressService);
		// 	iapService.Initialize();
		// 	_servicesLocator.RegisterSingle<IIAPService>(iapService);
		// }
	}
}