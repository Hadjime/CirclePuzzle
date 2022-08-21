using System.Threading.Tasks;
using InternalAssets.Scripts.Infrastructure.AssetManagement;


namespace InternalAssets.Scripts.Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string PazzleControllerLabel = "PazzleController";

		private readonly IAssets _assets;


		public StaticDataService(IAssets assets) {
			_assets = assets;
		}


		public async Task Load()
		{
		// TODO сделать загрузку из базы данных prefaba PazzleController, сейчас он просто на сцене
		}
	}
}
