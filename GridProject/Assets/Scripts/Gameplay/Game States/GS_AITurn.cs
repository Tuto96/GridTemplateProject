using UnityEngine;

public class GS_AITurn : State<Team>
{
    string _TeamName;
    int _TeamIndex;
    public GS_AITurn (Team owner, HexGrid grid) : base (owner, grid)
    {
        _TeamIndex = owner.teamIndex;
        _TeamName = " ";
    }

    public override void Enter ()
    {
        _Owner.BeginTurn ();
        Debug.Log (_TeamIndex + _TeamName + "Begin Turn");
    }

    public override void Exit ()
    {
        _Owner.EndTurn ();
        Debug.Log (_TeamIndex + _TeamName + "End Turn");
    }

    public override void Update ()
    {

    }
}