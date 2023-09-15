using BlazorState;
using MediatR;

namespace Karami.Blazor.States;

public class CounterState : State<CounterState>
{
    public int Count { get; private set;}

    public override void Initialize() => Count = 3;
    
    public class IncrementAction : IAction
    {
        public int Amount { get; set; }
    }
    
    public class IncrementActionHandler : ActionHandler<IncrementAction>
    {
        public IncrementActionHandler(IStore store) : base(store) {}

        public CounterState State => Store.GetState<CounterState>();
        
        public override Task Handle(IncrementAction aAction, CancellationToken aCancellationToken)
        {
            State.Count = aAction.Amount;

            return Unit.Task;
        }
    }
}