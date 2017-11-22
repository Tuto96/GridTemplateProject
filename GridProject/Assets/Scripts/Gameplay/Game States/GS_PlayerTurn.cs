using UnityEngine;

public class GS_PlayerTurn : State<Team>
{
    public GS_PlayerTurn (Team owner, HexGrid grid) : base (owner, grid)
    { }

    public override void Enter ()
    {
        Debug.Log ("Players Turn");
        HexUnit firstUnit = _Owner.GetFirstUnit ();
        if (firstUnit)
        {
            // HexmapCamera.focus is broken right now
            HexMapCamera.instance.transform.position = firstUnit.transform.position;
        }
        _Owner.BeginTurn ();
    }

    public override void Exit ()
    {
        _Owner.EndTurn ();
        GameManager.instance.sun.EndTurn ();
    }

    public override void Update ()
    {

    }
}