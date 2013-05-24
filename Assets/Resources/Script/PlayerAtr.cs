using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class PlayerAtr : MonoBehaviour 
{
	private bool FirstTime = false;
	private int Like = 0;
	private int Coin = 0;
	private int TotalCoin = 0;
	private int Diamond = 0;
	private int TotalDiamond = 0;
	public int Day = 0;
	private int HotelRank = 0;
	
	private string DayType = "";
	
	private int CountOf3Star = 0;
	private int CountOf4Star = 0;
	private int CountOf5Star = 0;
	private int CountOf6Star = 0;
	
	private int RunawayCount = 0;
	
	private int TDisplayCount = 0;
	private int BarCount = 0;
	private int FoodCount = 0;
	private int LiftCount = 0;
	private int CashierCount = 0;
	
	private List<int> QueueUpLevel = null;
	private List<int> FoodLevel = null;
	private List<int> TDisplayLevel = null;
	private List<int> BarLevel = null;
	private int ExtraDeco = 0;
	private List<int> DecoList = null;
	private int Theme = 0;
	private List<int> ThemeList = null;
	private int CashierLevel = 0;
	private List<int> Helper = null;
	private List<int> HelperDura = null;
	private List<int> HelperLevel = null;
	
	private int SpentCoin = 0;
	private int SpentDiamond = 0;
	private int UpgradeCount = 0;
	private int MovementSpeedLevel = 0;
	private int ActionSpeedLevel = 0;
	private float MovementSpeed = 0f;
	private float ActionSpeed = 0f;
	
	private float GlobalWT = 0f;
	private float GlobalST = 0f;
	private float GlobalTR = 0f;
	private float GlobalLR = 0f;
	
	private List<int> AchievementList = null;
	
	private void Start()
	{
		Init();	
		CalAll();
	}
	private void Init()
	{
		if(Loadable() == false)
		{
			FirstTime = true;
			Like = 5000;
			TotalCoin = 1000000;
			Coin = 1000000;
			Diamond = 10000;
			TotalDiamond = 10000;
			Day = 1;
			HotelRank = 6;
			
			CountOf3Star = 0;
			CountOf4Star = 0;
			CountOf5Star = 0;
			CountOf6Star = 0;
			
			RunawayCount = 0;
			BarCount = 0;
			TDisplayCount = 0;
			FoodCount = 0;
			LiftCount = 0;
			CashierCount = 0;
			
			QueueUpLevel = new List<int>(new int[]{1,1,1,1,1});
			FoodLevel = new List<int>(new int[]{1,1,1,1});
			TDisplayLevel = new List<int>(new int[]{1,1,1,1});
			BarLevel = new List<int>(new int[]{1,1,1,1});
			ExtraDeco = 4;
			DecoList = new List<int>();
			Theme = 1;
			ThemeList = new List<int>();
			CashierLevel = 4;
			Helper = new List<int>(new int[]{0,0,0,0,0,0,0});
			HelperDura = new List<int>(new int[]{0,0,0,0,0,0,0});
			HelperLevel = new List<int>(new int[]{0,0,0,0,0,0,0});
			
			SpentCoin = 0;
			SpentDiamond = 0;
			UpgradeCount = 0;
			MovementSpeedLevel = 1;
			ActionSpeedLevel = 1;
			
			EquipExtraDeco(ExtraDeco);
			EquipTheme(Theme);
			
			AchievementList = new List<int>();
			for(int a = 0;a<132;a++)
			{
				AchievementList.Add (0);	
			}
			Debug.Log (AchievementList.Count);
			
			Debug.Log ("New game");
		}
		else
		{
			FirstTime = BoolPrefs.GetBool ("FirstTime");
			Like = PlayerPrefs.GetInt ("Like");
			TotalCoin = PlayerPrefs.GetInt ("TotalCoin");
			Coin = PlayerPrefs.GetInt ("Coin");
			Diamond = PlayerPrefs.GetInt ("Diamond");
			TotalDiamond = PlayerPrefs.GetInt ("TotalDiamond");
			Day = PlayerPrefs.GetInt ("Day");
			HotelRank = PlayerPrefs.GetInt("HotelRank");
			
			CountOf3Star = PlayerPrefs.GetInt ("CountOf3Star");
			CountOf4Star = PlayerPrefs.GetInt ("CountOf4Star");
			CountOf5Star = PlayerPrefs.GetInt ("CountOf5Star");
			CountOf6Star = PlayerPrefs.GetInt ("CountOf6Star");
			
			RunawayCount = PlayerPrefs.GetInt ("RunawayCount");
			BarCount = PlayerPrefs.GetInt ("BarCount");
			TDisplayCount = PlayerPrefs.GetInt ("TDisplayCount");
			FoodCount = PlayerPrefs.GetInt ("FoodCount");
			LiftCount = PlayerPrefs.GetInt ("LiftCount");
			CashierCount = PlayerPrefs.GetInt ("CashierCount");
			
			QueueUpLevel = new List<int>(PlayerPrefsX.GetIntArray("QueueUpLevel"));
			FoodLevel = new List<int>(PlayerPrefsX.GetIntArray ("FoodLevel"));
			TDisplayLevel = new List<int>(PlayerPrefsX.GetIntArray ("TDisplayLevel"));
			BarLevel = new List<int>(PlayerPrefsX.GetIntArray ("BarLevel"));
			DecoList = new List<int>(PlayerPrefsX.GetIntArray ("DecoList"));
			ThemeList = new List<int>(PlayerPrefsX.GetIntArray("ThemeList"));
			Helper = new List<int>(PlayerPrefsX.GetIntArray ("Helper"));
			HelperDura = new List<int>(PlayerPrefsX.GetIntArray ("HelperDura"));
			HelperLevel = new List<int>(PlayerPrefsX.GetIntArray ("HelperLevel"));
			
			Theme = PlayerPrefs.GetInt ("Theme");
			ExtraDeco = PlayerPrefs.GetInt ("ExtraDeco");
			CashierLevel = PlayerPrefs.GetInt ("CashierLevel");
			SpentCoin = PlayerPrefs.GetInt ("SpentCoin");
			SpentDiamond = PlayerPrefs.GetInt ("SpentDiamond");
			UpgradeCount = PlayerPrefs.GetInt ("UpgradeCount");
			MovementSpeedLevel = PlayerPrefs.GetInt ("MovementSpeedLevel");
			ActionSpeedLevel = PlayerPrefs.GetInt ("ActionSpeedLevel");
			AchievementList = new List<int>(PlayerPrefsX.GetIntArray("AchievementList"));
			
			EquipExtraDeco(ExtraDeco);
			EquipTheme(Theme);
			
			Debug.Log ("Load game");
		}
	}
	public void HelperLevelUp(int ID)
	{
		HelperLevel[ID]++;
	}
	
	public int GetHelperLevel(int ID)
	{
		return HelperLevel[ID];
	}
	//@Kaizer: Modify Methods
	public void AddLike(int Add = 1)
	{
		Like += Add;
	}
	public void AddCoin(int Add = 1)
	{
		Coin += Add;	
	}
	public void AddTotalCoin(int Add = 1)
	{
		TotalCoin += Add;	
	}
	public void AddDiamond(int Add = 1)
	{
		Diamond += Add;	
	}
	public void AddTotalDiamond(int Add = 1)
	{
		TotalDiamond += Add;	
	}
	public void AddDay(int Add = 1)
	{
		Day += Add;
	}
	public void AddHotelRank(int Add = 1)
	{
		HotelRank += Add;	
	}
	
	public void AddCountOf3Star(int Add = 1)
	{
		CountOf3Star += Add;	
	}
	public void AddCountOf4Star(int Add = 1)
	{
		CountOf4Star += Add;	
	}
	public void AddCountOf5Star(int Add = 1)
	{
		CountOf5Star += Add;	
	}
	public void AddCountOf6Star(int Add = 1)
	{
		CountOf6Star += Add;	
	}
	
	public void AddRunawayCount(int Add = 1)
	{
		RunawayCount += Add;	
	}
	
	public void AddTDisplayCount(int Add = 1)
	{
		TDisplayCount += Add;	
	}
	public void AddBarCount(int Add = 1)
	{
		BarCount += Add;	
	}
	public void AddFoodCount(int Add = 1)
	{
		FoodCount += Add;
	}
	public void AddLiftCount(int Add = 1)
	{
		LiftCount += Add;	
	}
	public void AddCashierCount(int Add = 1)
	{
		CashierCount += Add;	
	}
	
	public void AddQueueUpSlot()
	{
		for(int a = 0; a<QueueUpLevel.Count;a++)
		{
			if(QueueUpLevel[a] == 0)
			{
				QueueUpLevel[a] = 1;
				break;
			}
		}
	}
	public void LevelQueueUpSlot(int TargetSlot, int TargetLevel)
	{
		if(TargetSlot < QueueUpLevel.Count)
		{
			QueueUpLevel[TargetSlot] = TargetLevel;	
		}
	}
	
	public void AddFoodSlot()
	{
		for(int a = 0;a <FoodLevel.Count;a++)
		{
			if(FoodLevel[a] == 0)
			{
				FoodLevel[a] = 1;
				break;
			}
		}
	}
	public void LevelFoodSlot(int TargetSlot, int TargetLevel)
	{
		if(TargetSlot < FoodLevel.Count)
		{
			FoodLevel[TargetSlot] = TargetLevel;	
		}
	}
	
	public void AddTDisplaySlot()
	{
		for(int a = 0; a <TDisplayLevel.Count; a++)
		{
			if(TDisplayLevel[a] == 0)
			{
				TDisplayLevel[a] = 1;
				break;
			}
		}
	}
	public void LevelTDisplaySlot(int TargetSlot, int TargetLevel)
	{
		if(TargetSlot < TDisplayLevel.Count)
		{
			TDisplayLevel[TargetSlot] = TargetLevel;	
		}
	}
	
	public void AddBarSlot()
	{
		for(int a = 0;a <BarLevel.Count;a++)
		{
			if(BarLevel[a] == 0)
			{
				BarLevel[a] = 1;
				break;
			}
		}
	}
	public void LevelBarSlot(int TargetSlot, int TargetLevel)
	{
		if(TargetSlot < BarLevel.Count)
		{
			BarLevel[TargetSlot] = TargetLevel;	
		}
	}
	public void AddTheme(int ID)
	{
		ThemeList.Add (ID);	
	}
	public void DeleteThemeByID(int ID)
	{
		ThemeList.Remove (ID);	
	}
	public void AddExtraDeco(int ID)
	{
		DecoList.Add (ID);	
	}
	public void DeleteExtraDecoByID(int ID)
	{
		DecoList.Remove (ID);
	}
	public void DeleteExtraDecoBySlot(int TargetSlot)
	{
		DecoList.RemoveAt (TargetSlot);	
	}
	public void EquipExtraDeco(int ID)
	{
		UnequipExtraDeco();
		ExtraDeco = ID;
		UpdateDnTEffect();
	}
	public void UnequipExtraDeco()
	{
		ExtraDeco = 0;	
	}
	public void EquipTheme(int ID)
	{
		UnequipTheme();
		Theme = ID;
		UpdateDnTEffect();
	}
	public void UnequipTheme()
	{
		Theme = 0;	
	}
	
	public void LevelCashierLevel(int TargetLevel)
	{
		CashierLevel = TargetLevel;	
	}
	
	public void AddHelperSlot(int TargetSlot)
	{
		if(TargetSlot < Helper.Count)
		{
			Helper[TargetSlot] = TargetSlot+1;
			if(TargetSlot == 7)
			{
				HelperDura[TargetSlot] = 5;	
			}
			else
			{
				HelperDura[TargetSlot] = 99;	
			}
		}
	}
	public void RemoveHelperSlot(int TargetSlot)
	{
		if(TargetSlot < Helper.Count)
		{
			Helper[TargetSlot] = 0;	
			HelperDura[TargetSlot] = 0;
		}
	}
	public void ReduceHelperDura()
	{
		for(int a = 0; a<HelperDura.Count;a++)
		{
			if(HelperDura[a] != 99)
			{
				HelperDura[a] = (int)HelperDura[a] -1;
			}
		}
		UpdateHelperList();
	}
	
	public void AddSpentCoin(int Add = 1)
	{
		SpentCoin += Add;	
	}
	public void AddSpentDiamond(int Add = 1)
	{
		SpentDiamond += Add;	
	}
	public void AddUpgradeCount(int Add = 1)
	{
		UpgradeCount += Add;	
	}
	public void LevelMovementSpeedLevel(int TargetLevel)
	{
		MovementSpeedLevel = TargetLevel;
		GetMovementSpeed();
	}
	public void LevelActionSpeedLevel(int TargetLevel)
	{
		ActionSpeedLevel = TargetLevel;	
		GetActionSpeed();
	}
	public void SetFirstTime(bool Flag)
	{
		FirstTime = Flag;	
	}
	public void AddGlobalWT(float Add)
	{
		GlobalWT += Add;	
	}
	public void AddGlobalST(float Add)
	{
		GlobalST += Add;
	}
	public void AddGlobalTR(float Add)
	{
		GlobalTR += Add;	
	}
	public void AddGlobalLR(float Add)
	{
		GlobalLR += Add;	
	}
	public void UpdateAchievementList(int ID =0, int Update = 0)
	{
		if(ID < AchievementList.Count)
		{
			AchievementList[ID] = Update;	
		}
	}
	
	
	//@Kaizer: Calculation Methods
	private void CalAll()
	{
		UpdateDnTEffect();
		GetMovementSpeed();
		GetActionSpeed ();
		UpdateHelperList();
		GetDayType();
	}
	private void UpdateDnTEffect()
	{
		Hashtable MyTheme = Main.MyStatCheck.GetThemeStatByID(Theme);	
		Hashtable MyDeco = Main.MyStatCheck.GetDecoStatByID(ExtraDeco);
		GlobalWT = (float)MyDeco["WaitingTime"] + (float)MyTheme["WaitingTime"];
		GlobalST = (float)MyDeco["Satisfaction"] + (float)MyTheme["Satisfaction"];
		GlobalLR = (float)MyDeco["LikeRate"] + (float)MyTheme["LikeRate"];
		GlobalTR = (float)MyDeco["TipsRate"] + (float)MyTheme["TipsRate"];
	}
	
		
	private void GetDayType()
	{
		if(Day % 5 ==0)
		{
			DayType = "Bonus";	
		}
		else
		{
			DayType = "Normal";	
		}
	}
	private void UpdateHelperList()
	{
		for(int a = 0;a<Helper.Count;a++)
		{
			if(HelperDura[a] <=0 && a ==7)
			{
				Helper[a] = 0;	
			}
		}
	}
	private void GetMovementSpeed()
	{
		MovementSpeed = Main.MyStatCheck.GetMSPDByLevel(MovementSpeedLevel);
	}
	private void GetActionSpeed()
	{
		ActionSpeed = Main.MyStatCheck.GetASPDByLevel(ActionSpeedLevel);
	}
	
	//@Kaizer: Return Methods
	public int ReturnLike()
	{
		return Like;	
	}
	public int ReturnCoin()
	{
		return Coin;	
	}
	public int ReturnTotalCoin()
	{
		return TotalCoin;	
	}
	public int ReturnDiamond()
	{
		return Diamond;	
	}
	public int ReturnTotalDiamond()
	{
		return TotalDiamond;	
	}
	public int ReturnDay()
	{
		return Day;	
	}
	public int ReturnHotelRank()
	{
		return HotelRank;	
	}
	public int ReturnCountOf3Star()
	{
		return CountOf3Star;	
	}
	public int ReturnCountOf4Star()
	{
		return CountOf4Star;	
	}
	public int ReturnCountOf5Star()
	{
		return CountOf5Star;	
	}
	public int ReturnCountOf6Star()
	{
		return CountOf6Star;	
	}
	public int ReturnRunawayCount()
	{
		return RunawayCount;	
	}
	public int ReturnTDisplayCount()
	{
		return TDisplayCount;	
	}
	public int ReturnBarCount()
	{
		return BarCount;
	}
	public int ReturnFoodCount()
	{
		return FoodCount;	
	}
	public int ReturnLiftCount()
	{
		return LiftCount;
	}
	public int ReturnCashierCount()
	{
		return CashierCount;	
	}
	
	public List<int> ReturnQueueUpLevelFull()
	{
		List<int> TemList = new List<int>(QueueUpLevel.ToArray());
		return TemList;
	}
	public int ReturnQueueUpLevel(int TargetSlot = 0)
	{
		int TemInt = QueueUpLevel[TargetSlot];
		return TemInt;
	}
	
	public List<int> ReturnFoodLevelFull()
	{
		List<int> TemList = new List<int>(FoodLevel.ToArray());
		return TemList;	
	}
	public int ReturnFoodLevel(int TargetSlot = 0)
	{
		int TemInt = FoodLevel[TargetSlot];
		return TemInt;
	}
	
	public List<int> ReturnTDisplayLevelFull()
	{
		List<int> TemList = new List<int>(TDisplayLevel.ToArray ());
		return TemList;	
	}
	public int ReturnTDisplayLevel(int TargetSlot = 0)
	{
		int TemInt = TDisplayLevel[TargetSlot];
		return TemInt;
	}
	
	public List<int> ReturnBarLevelFull()
	{
		List<int> TemList = new List<int>(BarLevel.ToArray ());
		return TemList;	
	}
	public int ReturnBarLevel(int TargetSlot = 0)
	{
		int TemInt = BarLevel[TargetSlot];
		return TemInt;
	}
	public int ReturnTheme()
	{
		return Theme;	
	}
	public List<int> ReturnThemeList()
	{
		List<int> TemList = new List<int>(ThemeList.ToArray ());
		return TemList;	
	}
	public int ReturnExtraDeco()
	{
		return ExtraDeco;	
	}
	public List<int> ReturnDecoList()
	{
		List<int> TemList = new List<int>(DecoList.ToArray ());
		return TemList;	
	}
	public int ReturnCashierLevel()
	{
		return CashierLevel;
	}
	public List<int> ReturnHelperFull()
	{
		List<int> TemList = new List<int>(Helper.ToArray ());
		return TemList;	
	}
	public List<int> ReturnHelperLevel()
	{
		List<int> TemList = new List<int>(HelperLevel.ToArray());
		return TemList;
	}
	public int ReturnHelper(int TargetSlot = 0)
	{
		int TemInt = Helper[TargetSlot];
		return TemInt;
	}
	public List<int> ReturnHelperDuraFull()
	{
		List<int> TemList = new List<int>(HelperDura.ToArray());
		return TemList;
	}
	public int ReturnHelperDura(int TargetSlot = 0)
	{
		int TemInt = HelperDura[TargetSlot];
		return TemInt;
	}
	
	public int ReturnSpentCoin()
	{
		return SpentCoin;	
	}
	public int ReturnSpentDiamond()
	{
		return SpentDiamond;	
	}
	public int ReturnUpgradeCount()
	{
		return UpgradeCount;	
	}
	public int ReturnMovementSpeedLevel()
	{
		return MovementSpeedLevel;	
	}
	public int ReturnActionSpeedLevel()
	{
		return ActionSpeedLevel;	
	}
	public float ReturnMovementSpeed()
	{
		return MovementSpeed;
	}
	public float ReturnActionSpeed()
	{
		return ActionSpeed;	
	}
	public bool ReturnFirstTime()
	{
		return FirstTime;	
	}
	public string ReturnDayType()
	{
		return DayType;	
	}
	public float ReturnGlobalWT()
	{
		return GlobalWT;	
	}
	public float ReturnGlobalST()
	{
		return GlobalST;	
	}
	public float ReturnGlobalLR()
	{
		return GlobalLR;	
	}
	public float ReturnGlobalTR()
	{
		return GlobalTR;	
	}
	public int ReturnAchievementByID(int ID)
	{
		int TemInt = AchievementList[ID];
		return TemInt;
	}
	public List<int> ReturnAchievementList()
	{
		List<int> TemList= new List<int>(AchievementList.ToArray ());
		return TemList;	
	}
	
	private bool Loadable()
	{
		bool Flag = false;
		if(Main.MySaveSystem.CheckData () == true)
		{
			Flag = true;	
		}
		return Flag;
	}
	
	private void Update()
	{
		if(HotelRank > 6)
			HotelRank = 6;
		if(HotelRank < 1)
			HotelRank = 1;	
	}
}
