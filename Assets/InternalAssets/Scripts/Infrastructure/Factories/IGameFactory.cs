using System.Threading.Tasks;
using InternalAssets.Scripts.Infrastructure.Services.StaticDI;
using UnityEngine;


namespace InternalAssets.Scripts.Infrastructure.Factories
{
    public interface IGameFactory : IService
    {
		GameObject HeroGameObject { get; }
		void Cleanup();
		Task WarmUp();
	}	
}