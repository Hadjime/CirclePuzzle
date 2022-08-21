using System.Threading.Tasks;
using InternalAssets.Scripts.Infrastructure.AssetManagement;
using InternalAssets.Scripts.Infrastructure.Services.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;


namespace InternalAssets.Scripts.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
		private readonly IStaticDataService _staticDataService;

		
		public GameObject HeroGameObject { get; private set; }


		public GameFactory(
				IAssets assets,
				IStaticDataService staticDataService
		)
        {
            _assets = assets;
			_staticDataService = staticDataService;
        }


		public async Task WarmUp()
		{
			//TODO: подгрузить заранее, если что-то понадобится
		}

		public void Cleanup()
        {
	        // _assets.CleanUp();
        }

		private GameObject InstantiateRegistered(GameObject prefab)
		{
			GameObject gameObject = Object.Instantiate(prefab);
			return gameObject;
		}
	}
}