// Generic State by Willy Campos
// https://github.com/wcampospro/Unity_References/blob/master/StateMachines/Complete/StateMachine/State.cs

public abstract class State<T>
{
    protected T _Owner;

    protected HexGrid _Grid;

    protected State (T owner, HexGrid grid)
    {
        _Owner = owner;
        _Grid = grid;
    }

    public abstract void Enter ();

    public abstract void Update ();

    public abstract void Exit ();
}