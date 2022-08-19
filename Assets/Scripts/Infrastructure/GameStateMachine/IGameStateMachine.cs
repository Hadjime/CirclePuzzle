using Infrastructure.Services.StaticDI;

namespace Infrastructure.GameStateMachine
{
	public interface IGameStateMachine : IService
	{
		void Enter<TState>() where TState : class, IState;


		void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
	}
}
