﻿using System.Threading.Tasks;
using InternalAssets.Scripts.Infrastructure.AssetManagement;


namespace InternalAssets.Scripts.Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string MonstersLabel = "Monsters";
		private const string LevelsLabel = "Levels";
		private const string windowStaticDataPath = "WindowStaticData";
		
		private readonly IAssets _assets;
		// private Dictionary<MonsterTypeId, MonstersStaticData> _monsters = new Dictionary<MonsterTypeId, MonstersStaticData>();
		// private Dictionary<string, LevelStaticData> _levels = new Dictionary<string, LevelStaticData>();
		// private Dictionary<WindowId, WindowConfig> _windowConfigs = new Dictionary<WindowId, WindowConfig>();


		public StaticDataService(IAssets assets) {
			_assets = assets;
		}


		public async Task Load()
		{
		// 	_assets.LoadAllAsyncByLabel<MonstersStaticData>(MonstersLabel, onFinish: list =>
		// 	{
		// 		// _monsters = list.ToDictionary(data => data.MonsterTypeId, data => data); //странная штука повторяется ключ
		// 		list.ForEach(data => _monsters[data.MonsterTypeId] = data);
		// 	});
		// 	
		// 	_assets.LoadAllAsyncByLabel<LevelStaticData>(LevelsLabel, onFinish: list =>
		// 	{
		// 		// _levels = list.ToDictionary(data => data.LevelKey, data => data); //странная штука повторяется ключ
		// 		list.ForEach(data => _levels[data.LevelKey] = data);
		// 	});
		//
		// 	var tmp = await _assets.LoadAsync<WindowStaticData>(windowStaticDataPath);
		// 	_windowConfigs = tmp
		// 					 .Configs
		// 					 .ToDictionary(config => config.WindowId, config => config);
		}
		
		
		// public MonstersStaticData ForMonsters(MonsterTypeId monsterTypeId) =>
		// 	_monsters.TryGetValue(monsterTypeId, out MonstersStaticData monstersStaticData) 
		// 		? monstersStaticData 
		// 		: null;
		//
		//
		// public LevelStaticData ForLevel(string sceneKey) =>
		// 	_levels.TryGetValue(sceneKey, out LevelStaticData levelStaticData)
		// 		? levelStaticData
		// 		: null;
		//
		//
		// public WindowConfig ForWindow(WindowId windowId) =>
		// 	_windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig)
		// 		? windowConfig
		// 		: null;
	}
}