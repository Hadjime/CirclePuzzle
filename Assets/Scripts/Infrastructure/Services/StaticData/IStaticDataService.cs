using System.Threading.Tasks;
using Infrastructure.Services.StaticDI;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService: IService
	{
		Task Load();
		// MonstersStaticData ForMonsters(MonsterTypeId monsterTypeId);
		// LevelStaticData ForLevel(string sceneKey);
		// WindowConfig ForWindow(WindowId shop);
	}
}
