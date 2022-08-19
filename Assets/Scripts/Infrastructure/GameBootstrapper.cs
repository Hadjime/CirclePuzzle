using Infrastructure.GameStateMachine.States;
using Infrastructure.Scene;
using UnityEngine;
using Utils.Log;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
	{
		private Game _game;


		private void Awake()
		{
			_game = new Game(this);
			_game.StateMachine.Enter<BootstrapState>();

			DontDestroyOnLoad(this);
			CustomDebug.Log($"[Game] Init", Color.grey);
		}
	}
}
