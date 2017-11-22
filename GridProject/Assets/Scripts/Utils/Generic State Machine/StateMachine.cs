// Generic State Machine by Willy Campos
// https://github.com/wcampospro/Unity_References/blob/master/StateMachines/Complete/StateMachine/StateMachine.cs

public class StateMachine<T>
{
    public State<T> currentState { get; private set; }

    public void ChangeState (State<T> newState)
    {
        if (currentState != null)
            currentState.Exit ();

        currentState = newState;
        currentState.Enter ();
    }

    public void UpdateState ()
    {
        if (currentState != null)
            currentState.Update ();
    }

}