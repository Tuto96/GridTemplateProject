using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadMenu : MonoBehaviour
{
	public HexGrid hexGrid;

	public Text menuLabel, actionButtonLabel;

	public InputField nameInput;

	public RectTransform listContent;

	public SaveLoadItem itemPrefab;

	bool saveMode;

	public void Open (bool saveMode)
	{
		this.saveMode = saveMode;
		if (saveMode)
		{
			menuLabel.text = "Save Map";
			actionButtonLabel.text = "Save";
		}
		else
		{
			menuLabel.text = "Load Map";
			actionButtonLabel.text = "Load";
		}
		FillList ();
		gameObject.SetActive (true);
		HexMapCamera.Locked = true;
	}

	public void Close ()
	{
		gameObject.SetActive (false);
		HexMapCamera.Locked = false;
	}

	string GetSelectedPath ()
	{
		string mapName = nameInput.text;
		if (mapName.Length == 0)
		{
			return null;
		}
		return Path.Combine (Application.persistentDataPath, mapName + ".hexmap");
	}

	void Save (string path)
	{
		using (
			BinaryWriter writer =
			new BinaryWriter (File.Open (path, FileMode.Create))
		)
		{
			writer.Write (HexMetrics.mapFileVersion);
			GameManager.instance.Save (writer);
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
				GameManager.instance.Load (reader, header);
				HexMapCamera.ValidatePosition ();
			}
			else
			{
				Debug.LogWarning ("Unknown map format " + header);
			}
		}
	}

	public void Action ()
	{
		string path = GetSelectedPath ();
		if (path == null)
		{
			return;
		}
		if (saveMode)
		{
			Save (path);
		}
		else
		{
			Load (path);
		}
		Close ();
	}

	public void SelectItem (string name)
	{
		nameInput.text = name;
	}

	void FillList ()
	{
		for (int i = 0; i < listContent.childCount; i++)
		{
			Destroy (listContent.GetChild (i).gameObject);
		}
		string[] paths =
			Directory.GetFiles (Application.persistentDataPath, "*.hexmap");
		Array.Sort (paths);
		for (int i = 0; i < paths.Length; i++)
		{
			SaveLoadItem item = Instantiate (itemPrefab);
			item.menu = this;
			item.MapName = Path.GetFileNameWithoutExtension (paths[i]);
			item.transform.SetParent (listContent, false);
		}
	}

	public void Delete ()
	{
		string path = GetSelectedPath ();
		if (path == null)
		{
			return;
		}
		if (File.Exists (path))
		{
			File.Delete (path);
		}
		nameInput.text = "";
		FillList ();
	}
}