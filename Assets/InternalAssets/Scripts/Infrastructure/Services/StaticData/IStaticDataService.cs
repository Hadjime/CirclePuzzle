using System.Threading.Tasks;
using InternalAssets.Scripts.Infrastructure.Services.StaticDI;


namespace InternalAssets.Scripts.Infrastructure.Services.StaticData
{
	public interface IStaticDataService: IService
	{
		Task Load();
	}
}
