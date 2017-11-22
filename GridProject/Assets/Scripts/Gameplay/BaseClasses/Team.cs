using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Team
{
	public int teamIndex;

	bool playerCanShareVisibility;

	public bool isPlayerControlled;

	public Color teamColor;

	List<HexUnit> units = new List<HexUnit> ();

	public Team (int index)
	{
		teamIndex = index;
		if (index > 0)
		{
			playerCanShareVisibility = Random.value > 0.5f;
			isPlayerControlled = false;
		}
		else
		{
			playerCanShareVisibility = true;
			isPlayerControlled = true;
		}
		units = new List<HexUnit> ();
	}

	public void BeginTurn ()
	{
		for (int i = 0; i < units.Count; i++)
		{
			units[i].BeginTurn ();
		}
	}

	public void EndTurn ()
	{
		for (int i = 0; i < units.Count; i++)
		{
			units[i].EndTurn ();
		}
	}

	#region Units

	public HexUnit AddUnit (HexUnit unit, HexCell location, HexDirection direction)
	{
		units.Add (unit);
		unit.transform.SetParent (GameManager.instance.grid.transform, false);
		unit.Grid = GameManager.instance.grid;
		unit.Direction = direction;
		unit.TeamIndex = teamIndex;
		unit.SetColor (teamColor);

		// Update location last as it updates visibility
		unit.Location = location;
		return unit;
	}
	public void ClearUnits ()
	{
		if (units.Count > 0)
		{
			foreach (HexUnit unit in units)
			{
				if (unit) unit.Die ();
			}
		}
		units.Clear ();
	}

	public HexUnit GetFirstUnit ()
	{
		if (units.Count > 0)
		{
			return units[0];
		}
		else
		{
			return null;
		}
	}

	public bool HasUnit (HexUnit unit)
	{
		return units.Contains (unit);
	}

	public int GetUnitCount ()
	{
		return units.Count;
	}

	public bool PlayerShareVisibility ()
	{
		return playerCanShareVisibility;
	}

	public bool RemoveUnit (HexUnit unit)
	{
		bool success = units.Remove (unit);
		return success;
	}

	#endregion

	#region Save Load

	public void Save (BinaryWriter writer)
	{
		writer.Write ((byte) teamIndex);
		//writer.write(teamColor.);
		writer.Write (units.Count);
		for (int i = 0; i < units.Count; i++)
		{
			units[i].Save (writer);
		}
	}

	public void Load (BinaryReader reader, int header)
	{
		if (header >= 2)
		{
			teamIndex = reader.ReadByte ();
			int unitCount = reader.ReadInt32 ();
			for (int i = 0; i < unitCount; i++)
			{
				HexUnit.Load (reader, header);
			}
		}
	}

	#endregion

}