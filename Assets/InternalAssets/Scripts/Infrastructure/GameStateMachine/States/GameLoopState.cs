using UnityEngine;


namespace InternalAssets.Scripts.Infrastructure.GameStateMachine.States
{
    public class GameLoopState : IPayloadState<GameObject>
    {
        private readonly GameStateMachine _gameStateMachine;
		// private HeroDeath _heroDeath;

		public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

		public void Enter(/*HeroDeath heroDeath*/)
		{
			// _heroDeath = heroDeath;
			// _heroDeath.HeroDead += OnHeroDead;
		}

		public void Enter(GameObject payload)
		{
			// TODO: Здесь подписаться на событие конца игры и перезапустить игру 
		}

		public void Exit()
        {
			// _heroDeath.HeroDead -= OnHeroDead;
        }

		private void OnHeroDead() =>
			_gameStateMachine.Enter<BootstrapState>();
	}
}