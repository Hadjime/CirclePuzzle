namespace Infrastructure.GameStateMachine.States
{
    public class LoadProgressState : IState
    {
        private const string MAIN_SCENE_NAME = "MainScene";

        private readonly GameStateMachine _gameStateMachine;
        // private readonly IPersistentProgressService _progressService;
        // private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine/*, IPersistentProgressService progressService, ISaveLoadService saveLoadService*/)
        {
            _gameStateMachine = gameStateMachine;
            // _progressService = progressService;
            // _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            // TODO: перенести имя сцены в staticData scriptableObject
            _gameStateMachine.Enter<LoadSceneState, string>(MAIN_SCENE_NAME/*_progressService.Progress.WorldData.PositionOnLevel.Level*/);
        }

        public void Exit()
        {
            
        }

        private void LoadProgressOrInitNew()
        {
            // _progressService.Progress =
            //     _saveLoadService.LoadProgress()
            //     ?? NewProgress();
        }

   //      private PlayerProgress NewProgress()
   //      {
   //          var progress = new PlayerProgress("Main");
   //          progress.PlayerState.MaxHp = 100;
   //          progress.PlayerState.ResetHp();
			// progress.HeroStats.Damage = 10;
			// progress.HeroStats.DamageRadius = 1.5f;
   //
   //          return progress;
   //      }
    }
}