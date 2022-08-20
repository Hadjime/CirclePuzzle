using System;
using System.Collections.Generic;
using InternalAssets.Scripts.Infrastructure.Factories;
using InternalAssets.Scripts.Infrastructure.GameStateMachine.States;
using InternalAssets.Scripts.Infrastructure.Scene;
using InternalAssets.Scripts.Infrastructure.Services.StaticData;
using InternalAssets.Scripts.Infrastructure.Services.StaticDI;
using InternalAssets.Scripts.Utils.Log;
using UnityEngine;


namespace InternalAssets.Scripts.Infrastructure.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
	{
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, ServicesLocator servicesLocator)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
				        
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, servicesLocator),
                [typeof(LoadSceneState)] = new LoadSceneState(
                    this,
                    sceneLoader,
                    servicesLocator.Single<IGameFactory>(),
                    servicesLocator.Single<IStaticDataService>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState  state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
			CustomDebug.Log($"Exit {_activeState?.GetType().Name} state", Color.green);
			_activeState?.Exit();
            
            TState state = GetState<TState>();
            _activeState = state;
			CustomDebug.Log($"Enter {_activeState?.GetType().Name} state", Color.green);
			
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}