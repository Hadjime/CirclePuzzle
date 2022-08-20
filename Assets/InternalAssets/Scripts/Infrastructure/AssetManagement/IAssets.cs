using InternalAssets.Scripts.Infrastructure.Services.StaticDI;
using UnityEngine;


namespace InternalAssets.Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
		// void Initialize();
        GameObject Instantiate(GameObject gameObject);
  //       Task<GameObject> InstantiateAsync(string path);
  //       Task<GameObject> InstantiateAsync(string path, Vector3 at);
		// void LoadAllAsyncByLabel<T>(string path, System.Action<List<T>> onFinish);
		// Task<GameObject> InstantiateAsync(string path, Vector3 at, Transform parent);
		// Task<T> LoadAsync<T>(AssetReference assetReference) where T : class;
		// Task<T> LoadAsync<T>(string address) where T : class;
		// void CleanUp();
	}
}