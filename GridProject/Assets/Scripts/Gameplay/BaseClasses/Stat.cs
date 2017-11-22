using UnityEngine;
[System.Serializable]
public struct Stat
{

	public UnitStats myStat;
	[SerializeField]
	[Range (0, 20)]
	private int baseValue;
	private float value;
	private float maxValue;
	private float minValue;
	private float addMod;
	private float multMod;

	public void Init ()
	{
		maxValue = (baseValue * multMod) + addMod;
		value = maxValue;
	}

	public float GetCurrentValue ()
	{
		return value;
	}

	public float getMaxValue ()
	{
		return maxValue;
	}

	public void ModifyAdd (float val)
	{

		addMod += val;
		value = value + val;
		UpdateStat ();
	}

	public void ModifyMult (float val)
	{

		multMod += val;
		value = val > 0 ? value * (1 + val) : value / (1 + val);
		UpdateStat ();
	}

	public void UpdateStat ()
	{
		maxValue = (baseValue * multMod) + addMod;
		value = Mathf.Clamp (value, minValue, maxValue);
	}
}