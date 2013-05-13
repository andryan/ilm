using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class SaveSystem : MonoBehaviour 
{
	private void Start()
	{
		Init();	
	}
	private void Init()
	{
			
	}
	public bool CheckData()
	{
		bool Flag = false;
		if(PlayerPrefs.HasKey ("FirstTime"))
		{
			Flag = true;	
		}
		return Flag;
	}
	public void Save()
	{
		BoolPrefs.SetBool("FirstTime", Main.MyPlayerAtr.ReturnFirstTime());
		PlayerPrefs.SetInt ("Like", Main.MyPlayerAtr.ReturnLike());
		PlayerPrefs.SetInt ("TotalCoin", Main.MyPlayerAtr.ReturnTotalCoin());
		PlayerPrefs.SetInt ("Coin", Main.MyPlayerAtr.ReturnCoin ());
		PlayerPrefs.SetInt ("Diamond", Main.MyPlayerAtr.ReturnDiamond());
		PlayerPrefs.SetInt ("TotalDiamond", Main.MyPlayerAtr.ReturnTotalDiamond());
		PlayerPrefs.SetInt ("Day", Main.MyPlayerAtr.ReturnDay());
		PlayerPrefs.SetInt ("HotelRank", Main.MyPlayerAtr.ReturnHotelRank());
		PlayerPrefs.SetInt ("Like", Main.MyPlayerAtr.ReturnLike());
		PlayerPrefs.SetInt ("CountOf3Star", Main.MyPlayerAtr.ReturnCountOf3Star());
		PlayerPrefs.SetInt ("CountOf4Star", Main.MyPlayerAtr.ReturnCountOf4Star());
		PlayerPrefs.SetInt ("CountOf5Star", Main.MyPlayerAtr.ReturnCountOf5Star());
		PlayerPrefs.SetInt ("CountOf6Star", Main.MyPlayerAtr.ReturnCountOf6Star());
		PlayerPrefs.SetInt ("RunawayCount", Main.MyPlayerAtr.ReturnRunawayCount());
		PlayerPrefs.SetInt ("BarCount", Main.MyPlayerAtr.ReturnBarCount());
		PlayerPrefs.SetInt ("TDisplayCount", Main.MyPlayerAtr.ReturnTDisplayCount());
		PlayerPrefs.SetInt ("FoodCount", Main.MyPlayerAtr.ReturnFoodCount ());
		PlayerPrefs.SetInt ("LiftCount", Main.MyPlayerAtr.ReturnLiftCount());
		PlayerPrefs.SetInt ("CashierCount", Main.MyPlayerAtr.ReturnCashierCount());
		
		int[] QueueUpLevel = Main.MyPlayerAtr.ReturnQueueUpLevelFull().ToArray();
		PlayerPrefsX.SetIntArray("QueueUpLevel", QueueUpLevel);
		int[] FoodLevel = Main.MyPlayerAtr.ReturnFoodLevelFull ().ToArray();
		PlayerPrefsX.SetIntArray("FoodLevel", FoodLevel);
		int[] TDisplayLevel = Main.MyPlayerAtr.ReturnTDisplayLevelFull().ToArray ();
		PlayerPrefsX.SetIntArray("TDisplayLevel", TDisplayLevel);
		int[] BarLevel = Main.MyPlayerAtr.ReturnBarLevelFull().ToArray();
		PlayerPrefsX.SetIntArray("BarLevel", BarLevel);
		int[] DecoList = Main.MyPlayerAtr.ReturnDecoList().ToArray ();
		PlayerPrefsX.SetIntArray("DecoList", DecoList);
		int[] Helper = Main.MyPlayerAtr.ReturnHelperFull ().ToArray ();
		PlayerPrefsX.SetIntArray("Helper", Helper);
		int[] HelperDura = Main.MyPlayerAtr.ReturnHelperDuraFull ().ToArray ();
		PlayerPrefsX.SetIntArray("HelperDura", HelperDura);
		int[] ThemeList = Main.MyPlayerAtr.ReturnThemeList ().ToArray ();
		PlayerPrefsX.SetIntArray("ThemeList", ThemeList);
		
		PlayerPrefs.SetInt ("Theme", Main.MyPlayerAtr.ReturnTheme ());
		PlayerPrefs.SetInt ("ExtraDeco", Main.MyPlayerAtr.ReturnExtraDeco());
		PlayerPrefs.SetInt ("CashierLevel", Main.MyPlayerAtr.ReturnCashierLevel());
		PlayerPrefs.SetInt ("SpentCoin", Main.MyPlayerAtr.ReturnSpentCoin());
		PlayerPrefs.SetInt ("SpentDiamond", Main.MyPlayerAtr.ReturnSpentDiamond());
		PlayerPrefs.SetInt ("UpgradeCount", Main.MyPlayerAtr.ReturnUpgradeCount());
		PlayerPrefs.SetInt ("MovementSpeedLevel", Main.MyPlayerAtr.ReturnMovementSpeedLevel());
		PlayerPrefs.SetInt ("ActionSpeedLevel", Main.MyPlayerAtr.ReturnActionSpeedLevel());
		
		int[] AchievementList = Main.MyPlayerAtr.ReturnAchievementList().ToArray();
		PlayerPrefsX.SetIntArray ("AchievementList", AchievementList);
	}
}
