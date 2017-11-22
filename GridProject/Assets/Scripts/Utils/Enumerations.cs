using UnityEngine;

public enum HexDirection
{
    NE,
    E,
    SE,
    SW,
    W,
    NW
}

public enum HexAngleType
{
    Narrow,
    Regular,
    Wide,
    AllAround
}

public enum HexEdgeType
{
    Flat,
    Slope,
    Cliff
}

public enum HexUnitState
{
    Idle,
    Moving,
    Attacking,
    Disabled,
    Tired
}

public enum HexAttackType
{
    Melee,
    Ranged,
    Magic,
    None
}

public static class HexDirectionExtensions
{

    public static HexDirection Opposite (this HexDirection direction)
    {
        return (int) direction < 3 ? (direction + 3) : (direction - 3);
    }
    public static HexDirection Previous (this HexDirection direction)
    {
        return direction == HexDirection.NE ? HexDirection.NW : (direction - 1);
    }
    public static HexDirection Next (this HexDirection direction)
    {
        return direction == HexDirection.NW ? HexDirection.NE : (direction + 1);
    }
    public static HexDirection Previous2 (this HexDirection direction)
    {
        direction -= 2;
        return direction >= HexDirection.NE ? direction : (direction + 6);
    }

    public static HexDirection Next2 (this HexDirection direction)
    {
        direction += 2;
        return direction <= HexDirection.NW ? direction : (direction - 6);
    }
}