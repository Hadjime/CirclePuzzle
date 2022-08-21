using UnityEngine;


namespace InternalAssets.Scripts.Infrastructure.AssetManagement
{
    public class AssetsProvider : IAssets
    {
		// private readonly Dictionary<string, AsyncOperationHandle> _competedCache = new Dictionary<string, AsyncOperationHandle>();
		// private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();
		private bool isActivateLog;
		private string loadingLog;
		private IAssets _assets;
		

		public GameObject Instantiate(GameObject gameObject)
		{
			return Object.Instantiate(gameObject);
		}
	}
}