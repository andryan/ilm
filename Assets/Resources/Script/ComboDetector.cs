using UnityEngine;
using System.Collections;

public class ComboDetector : MonoBehaviour
{
	
	public enum ComboType{
		None = 0,
		Medium = 1,
		High = 2,
		VeryHigh = 3,
	}
	
	private ComboType curComboType;
	private int ComboStreak;
	
	
	public ComboDetector ()
	{
		this.curComboType = ComboType.None;
	}
	
	public void UpdateCombo(int satisfaction)
	{
		ComboType tempCombo = ComboType.None;
		switch(satisfaction)
		{
			case 5 :
				tempCombo = ComboType.VeryHigh;
				break;
			case 4 :
				tempCombo = ComboType.High;
				break;
			case 3:
				tempCombo = ComboType.Medium;
				break;
			default:
				this.ComboBreak();
				break;
		}
	
		if(curComboType != ComboType.None)
		{
			if(curComboType == tempCombo)
			{
				ComboStreak++;
			}
			else
				this.ComboBreak();
		}
		else
		{
			curComboType = tempCombo;
			ComboStreak = 1;
		}
		Debug.LogError("Combo : " + ComboStreak);
	}
	
	public void ComboBreak()
	{
		this.ComboStreak = 0;
		this.curComboType = ComboType.None;
	}
	
	public int getComboStreak()
	{
		return ComboStreak;
	}
}

