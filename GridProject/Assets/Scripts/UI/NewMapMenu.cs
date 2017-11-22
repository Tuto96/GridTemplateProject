using UnityEngine;

public class NewMapMenu : MonoBehaviour
{

	public HexGrid hexGrid;

	[SerializeField]
	private RectTransform gameUI, editorUI;

	public void Open ()
	{
		gameObject.SetActive (true);
		HexMapCamera.Locked = true;
	}

	public void Close ()
	{
		gameObject.SetActive (false);
		HexMapCamera.Locked = false;
	}

	public void CreateSmallMap ()
	{
		CreateMap (20, 15);
	}

	public void CreateMediumMap ()
	{
		CreateMap (40, 30);
	}

	public void CreateLargeMap ()
	{
		CreateMap (80, 60);
	}

	void CreateMap (int x, int z)
	{
		GameManager.instance.EditMap (x, z);
		GameManager.instance.inGame = !GameManager.instance.isEditMode;
		if (GameManager.instance.isEditMode)
		{
			editorUI.gameObject.SetActive (true);
		}
		else
		{
			gameUI.gameObject.SetActive (true);
		}
		Close ();
	}
}