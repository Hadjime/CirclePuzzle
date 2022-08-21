using UnityEngine;


namespace InternalAssets.Scripts.Infrastructure.GameStateMachine.States
{
    public class GameLoopState : IPayloadState<GameObject>
    {
        private readonly GameStateMachine _gameStateMachine;

		public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

		public void Enter(GameObject payload)
		{
			// TODO: Здесь подписаться на событие конца игры и перезапустить игру 
		}

		public void Exit()
        {
			// TODO: Здесь отписаться от события конца игры 
        }

		private void OnPuzzleCompleted() =>
			_gameStateMachine.Enter<BootstrapState>();
	}
}