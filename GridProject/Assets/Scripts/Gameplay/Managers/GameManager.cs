using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public HexGrid grid { get; private set; }
	[Header ("Hex Cell Colors")]
	public Color selectedCellColor = Color.white;
	public Color pathColor = Color.grey;
	public Color validColor = Color.green;
	public Color nonValidColor = Color.black;
	public Color attackColor = Color.red;
	public Color interactableColor = Color.blue;

	public bool isEditMode = false;

	public bool inGame = false;

	public int maxNumberOfTeams = 8;

	public Color[] teamColors;

	public Team[] teams;

	public int currentTeamIndex { get; private set; }

	public Team currentTeam;

	public Sun sun;

	StateMachine<Team> stateMachine = new StateMachine<Team> ();

	public override void SingletonAwake ()
	{
		Shader.DisableKeyword ("HEX_MAP_EDIT_MODE");
		grid = FindObjectOfType<HexGrid> ();
		sun = FindObjectOfType<Sun> ();
		grid.Init (20, 15);
		InitTeams ();
	}

	public void EditMap (int sizeX, int sizeZ)
	{
		grid.Init (sizeX, sizeZ);
		InitTeams ();
		StartMatch ();
	}

	public void StartGame ()
	{
		Load ("Assets/Maps/Level 1.hexmap");
		StartMatch ();
	}

	private void InitTeams ()
	{
		for (int i = 0; i < teams.Length; i++)
		{
			teams[i] = new Team (i);
			teams[i].teamColor = teamColors[i];
		}
	}

	private void StartMatch ()
	{
		currentTeamIndex = 0;
		currentTeam = teams[currentTeamIndex];
		stateMachine.ChangeState (new GS_PlayerTurn (currentTeam, grid));
	}

	public void EndTurn ()
	{

		StopCoroutine ("TurnTimer");
		grid.EndTurn ();
		currentTeamIndex++;
		if (currentTeamIndex >= teams.GetLength (0))
		{
			currentTeamIndex = 0;
		}
		currentTeam = teams[currentTeamIndex];
		if (currentTeamIndex > 0)
		{
			stateMachine.ChangeState (new GS_AITurn (currentTeam, grid));
			float delay = currentTeam.GetUnitCount () > 0 ? 0.5f : 0.0f;
			StartCoroutine (TurnTimer (delay));

		}
		else
		{
			stateMachine.ChangeState (new GS_PlayerTurn (currentTeam, grid));
		}
	}

	IEnumerator TurnTimer (float delay)
	{
		yield return new WaitForSeconds (delay);
		EndTurn ();
	}

	void ClearUnits ()
	{
		foreach (Team t in teams)
		{
			t.ClearUnits ();
		}
	}

	public bool CreateMap (int x, int z)
	{
		ClearUnits ();
		InitTeams ();
		return grid.CreateMap (x, z);
	}

	#region Save Load

	public void Save (BinaryWriter writer)
	{
		writer.Write ((byte) maxNumberOfTeams);

		grid.Save (writer);

		for (int i = 0; i < teams.Length; i++)
		{
			teams[i].Save (writer);
		}
	}

	public void Load (BinaryReader reader, int header)
	{
		ClearUnits ();
		maxNumberOfTeams = reader.ReadByte ();
		grid.Load (reader, header);
		InitTeams ();
		for (int i = 0; i < teams.Length; i++)
		{
			teams[i].Load (reader, header);
		}
	}

	void Load (string path)
	{
		if (!File.Exists (path))
		{
			Debug.LogError ("File does not exist " + path);
			return;
		}
		using (BinaryReader reader = new BinaryReader (File.OpenRead (path)))
		{
			int header = reader.ReadInt32 ();
			if (header <= HexMetrics.mapFileVersion)
			{
				Load (reader, header);
				HexMapCamera.ValidatePosition ();
			}
			else
			{
				Debug.LogWarning ("Unknown map format " + header);
			}
		}
	}

	#endregion
}