namespace InternalAssets.Scripts.Infrastructure.GameStateMachine.States
{
    public class LoadProgressState : IState
    {
        private const string MAIN_SCENE_NAME = "MainScene";

        private readonly GameStateMachine _gameStateMachine;

		public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
		}

        public void Enter()
        {
            LoadProgressOrInitNew();
            // TODO: перенести имя сцены в staticData scriptableObject
            _gameStateMachine.Enter<LoadSceneState, string>(MAIN_SCENE_NAME);
        }

        public void Exit()
        {
            
        }

        private void LoadProgressOrInitNew()
        {
			// TODO найти прогресс игры или инициализировать новый прогресс
        }
	}
}