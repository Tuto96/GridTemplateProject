using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HexUnitStats
{

	public Stat health, strenght, agility, intelligence, attack, defence;
	public HexUnitStats ()
	{

	}

	public void Init () { }

	public float GetMaxHealth ()
	{

		return health.getMaxValue ();
	}

}

public enum UnitStats
{
	Strenght,
	Agility,
	Intelligence
}