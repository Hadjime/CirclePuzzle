using InternalAssets.Scripts.Infrastructure.Services.StaticDI;
using UnityEngine;


namespace InternalAssets.Scripts.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
		GameObject Instantiate(GameObject gameObject);
	}
}