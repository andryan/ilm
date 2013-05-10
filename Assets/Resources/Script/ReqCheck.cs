using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class ReqCheck : MonoBehaviour 
{
	private List<Hashtable> MSPDList = null;
	private List<Hashtable> ASPDList = null;
	private List<Hashtable> QueueUpUnlock = null;
	private List<Hashtable> QueueUpLevel = null;
	private List<Hashtable> FoodUnlock = null;
	private List<Hashtable> FoodLevel = null;
	private List<Hashtable> TDisplayUnlock = null;
	private List<Hashtable> TDisplayLevel = null;
	private List<Hashtable> BarUnlock = null;
	private List<Hashtable> BarLevel = null;
	private List<Hashtable> CashierLevel = null;
	private List<Hashtable> HelperList = null;
	private List<Hashtable> DecoList = null;
	private List<Hashtable> ThemeList = null;
	
	private void Start()
	{
		Init();		
	}
	private void Init()
	{
		MSPDList = new List<Hashtable>();
		MSPDList.Add(HashObject.Hash("Coin", 0, "Like", 0, "Description","MOV+"));
		MSPDList.Add (HashObject.Hash ("Coin", 5000, "Like", 0 , "Description","MOV+"));
		MSPDList.Add (HashObject.Hash ("Coin", 23000, "Like", 65 , "Description","MOV+"));
		MSPDList.Add (HashObject.Hash("Coin", 59000, "Like", 230, "Description","MOV+"));
		MSPDList.Add(HashObject.Hash ("Coin", 167000, "Like", 1800, "Description","MOV+"));
		
		ASPDList = new List<Hashtable>();
		ASPDList.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "SPD+"));
		ASPDList.Add (HashObject.Hash ("Coin", 5000, "Like", 0 , "Description", "SPD+"));
		ASPDList.Add (HashObject.Hash ("Coin", 23000, "Like", 50 , "Description", "SPD+"));
		ASPDList.Add (HashObject.Hash ("Coin", 59000, "Like", 200, "Description", "SPD+"));
		ASPDList.Add (HashObject.Hash ("Coin", 167000, "Like", 1500, "Description", "SPD+"));
		
		QueueUpUnlock = new List<Hashtable>();
		QueueUpUnlock.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Slot increase"));
		QueueUpUnlock.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Slot increase"));
		QueueUpUnlock.Add (HashObject.Hash ("Coin", 1000, "Like", 0, "Description", "Slot increase"));
		QueueUpUnlock.Add (HashObject.Hash ("Coin", 8000, "Like", 100, "Description", "Slot increase"));
		QueueUpUnlock.Add (HashObject.Hash ("Coin", 57000, "Like", 600, "Description", "Slot increase"));
		
		QueueUpLevel = new List<Hashtable>();
		QueueUpLevel.Add (HashObject.Hash("Coin", 0, "Like", 0, "Description", "Wait Time+"));
		QueueUpLevel.Add (HashObject.Hash("Coin", 3000, "Like", 0, "Description", "Wait Time+"));
		QueueUpLevel.Add (HashObject.Hash("Coin", 24000, "Like", 200, "Description", "Wait Time+"));
		
		FoodUnlock = new List<Hashtable>();
		FoodUnlock.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Slot increase"));
		FoodUnlock.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Slot increase"));
		FoodUnlock.Add (HashObject.Hash ("Coin", 4000, "Like", 20, "Description", "Slot increase"));
		FoodUnlock.Add (HashObject.Hash ("Coin", 28000, "Like", 250, "Description", "Slot increase"));
		
		FoodLevel = new List<Hashtable>();
		FoodLevel.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Wait Time+"));
		FoodLevel.Add (HashObject.Hash ("Coin", 3000, "Like", 25, "Description", "Wait Time+"));
		FoodLevel.Add (HashObject.Hash ("Coin", 24000, "Like", 240, "Description", "Wait Time+"));
		
		TDisplayUnlock = new List<Hashtable>();
		TDisplayUnlock.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Slot increase"));
		TDisplayUnlock.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Slot increase"));
		TDisplayUnlock.Add (HashObject.Hash ("Coin", 4000, "Like", 30, "Description", "Slot increase"));
		TDisplayUnlock.Add (HashObject.Hash ("Coin", 28000, "Like", 350, "Description", "Slot increase"));
		
		TDisplayLevel = new List<Hashtable>();
		TDisplayLevel.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Wait Time+"));
		TDisplayLevel.Add (HashObject.Hash ("Coin", 3000, "Like", 35, "Description", "Wait Time+"));
		TDisplayLevel.Add (HashObject.Hash ("Coin", 24000, "Like", 250, "Description", "Wait Time+"));
		
		BarUnlock = new List<Hashtable>();
		BarUnlock.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Slot increase"));
		BarUnlock.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Slot increase"));
		BarUnlock.Add (HashObject.Hash ("Coin", 4000, "Like", 40, "Description", "Slot increase"));
		BarUnlock.Add (HashObject.Hash ("Coin", 28000, "Like", 450, "Description", "Slot increase"));
		
		BarLevel = new List<Hashtable>();
		BarLevel.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Wait Time+"));
		BarLevel.Add (HashObject.Hash ("Coin", 3000, "Like", 45, "Description", "Wait Time+"));
		BarLevel.Add (HashObject.Hash ("Coin", 24000, "Like", 260, "Description", "Wait Time+"));
		
		CashierLevel = new List<Hashtable>();
		CashierLevel.Add (HashObject.Hash ("Coin", 0, "Like", 0, "Description", "Wait Time+"));
		CashierLevel.Add (HashObject.Hash ("Coin", 3000, "Like", 50, "Description", "Wait Time+"));
		CashierLevel.Add (HashObject.Hash ("Coin", 24000, "Like", 400, "Description", "Wait Time+"));
		CashierLevel.Add (HashObject.Hash ("Coin", 66000, "Like", 700, "Description", "Wait Time+, Like %+"));
		CashierLevel.Add (HashObject.Hash ("Coin", 192000, "Like", 2000, "Description", "Wait Time+, Like %+"));
		 
		HelperList = new List<Hashtable>();
		HelperList.Add (HashObject.Hash ("ID", 1, "Coin", 5000, "Diamond", 0, "Like", 300, "Description", "MOV:0.3, SPD:2.0"));
		HelperList.Add (HashObject.Hash ("ID", 2, "Coin", 26000, "Diamond", 0, "Like", 500, "Description", "MOV:0.3, SPD:2.0"));
		HelperList.Add (HashObject.Hash ("ID", 3, "Coin", 132000, "Diamond", 0, "Like", 1200, "Description", "MOV:0.25, SPD:1.8"));
		HelperList.Add (HashObject.Hash ("ID", 4, "Coin", 654000, "Diamond", 0, "Like", 5000, "Description", "MOV:0.2, SPD:1.5"));
		HelperList.Add (HashObject.Hash ("ID", 5, "Coin", 0, "Diamond", 350, "Like", 0, "Description", "MOV:0.2, SPD:1.5"));
		HelperList.Add (HashObject.Hash ("ID", 6, "Coin", 0, "Diamond", 700, "Like", 0, "Description", "MOV:0.2, SPD:1.5"));
		HelperList.Add (HashObject.Hash ("ID", 7, "Coin", 0, "Diamond", 1000, "Like", 0, "Description", "MOV:0.15, SPD:1.2"));
	//	HelperList.Add (HashObject.Hash ("ID", 8, "Coin", 0, "Diamond", 100, "Like", 0));
		
		DecoList = new List<Hashtable>();
		DecoList.Add (HashObject.Hash ("ID", 1, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", true, "Description", "WT+, ST+, LR+, TR+"));
		DecoList.Add (HashObject.Hash ("ID", 2, "Coin", 8000, "Diamond", 0, "Like", 100, "Shop", true, "Description", "WT+, ST+, LR+, TR+"));
		DecoList.Add (HashObject.Hash ("ID", 3, "Coin", 54000, "Diamond", 0, "Like", 700, "Shop", true, "Description", "WT+, ST+, LR+, TR+"));
		DecoList.Add (HashObject.Hash ("ID", 4, "Coin", 260000, "Diamond", 0, "Like", 1500, "Shop", true, "Description", "WT+, ST+, LR+, TR+"));
		
		DecoList.Add (HashObject.Hash ("ID", 5, "Coin", 522000, "Diamond", 0, "Like", 2800, "Shop", true, "Description", "WT+, ST+, LR+, TR+"));
		/*DecoList.Add (HashObject.Hash ("ID", 6, "Coin", 36000, "Diamond", 0, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 7, "Coin", 92000, "Diamond", 0, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 8, "Coin", 260000, "Diamond", 0, "Like", 0, "Shop", true));
		
		DecoList.Add (HashObject.Hash ("ID", 9, "Coin", 8000, "Diamond", 0, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 10, "Coin", 36000, "Diamond", 0, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 11, "Coin", 92000, "Diamond", 0, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 12, "Coin", 260000, "Diamond", 0, "Like", 0, "Shop", true));
		
		DecoList.Add (HashObject.Hash ("ID", 13, "Coin", 10000, "Diamond", 0, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 14, "Coin", 42000, "Diamond", 0, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 15, "Coin", 138000, "Diamond", 0, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 16, "Coin", 522000, "Diamond", 0, "Like", 0, "Shop", true));
		
		DecoList.Add (HashObject.Hash ("ID", 17, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		DecoList.Add (HashObject.Hash ("ID", 18, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		DecoList.Add (HashObject.Hash ("ID", 19, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		DecoList.Add (HashObject.Hash ("ID", 20, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		
		DecoList.Add (HashObject.Hash ("ID", 21, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		DecoList.Add (HashObject.Hash ("ID", 22, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		DecoList.Add (HashObject.Hash ("ID", 23, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		DecoList.Add (HashObject.Hash ("ID", 24, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		DecoList.Add (HashObject.Hash ("ID", 25, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		
		DecoList.Add (HashObject.Hash ("ID", 26, "Coin", 0, "Diamond", 300, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 27, "Coin", 0, "Diamond", 500, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 28, "Coin", 0, "Diamond", 1000, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 29, "Coin", 0, "Diamond", 2000, "Like", 0, "Shop", true));
		DecoList.Add (HashObject.Hash ("ID", 30, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		
		*/
		ThemeList = new List<Hashtable>();
		ThemeList.Add (HashObject.Hash ("ID", 1, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", false));
		ThemeList.Add (HashObject.Hash ("ID", 2, "Coin", 0, "Diamond", 0, "Like", 0, "Shop", true));
	}
	
	public List<Hashtable> GetDecoToShop()
	{
		List<Hashtable> MyHashList = new List<Hashtable>();
		for(int a = 0;a<DecoList.Count;a++)
		{
			if((bool)DecoList[a]["Shop"] == true)
			{
				MyHashList.Add((Hashtable)DecoList[a].Clone ());	
			}
		}
		return MyHashList;
	}
	public Hashtable GetDecoReqByID(int ID)
	{
		Hashtable MyHash = new Hashtable();
		for(int a = 0; a<DecoList.Count;a++)
		{
			if((int)DecoList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)DecoList[a].Clone ();
				break;
			}
		}
		return MyHash;		
	}
	
	public List<Hashtable> GetThemeToShop()
	{
		List<Hashtable> MyHashList = new List<Hashtable>();
		for(int a = 0;a<ThemeList.Count;a++)
		{
			if((bool)ThemeList[a]["Shop"] == true)
			{
				MyHashList.Add ((Hashtable)ThemeList[a].Clone());	
			}
		}
		return MyHashList;
	}
	
	public Hashtable GetThemeReqByID(int ID)
	{
		Hashtable MyHash = new Hashtable();
		for(int a = 0; a<ThemeList.Count;a++)
		{
			if((int)ThemeList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)ThemeList[a].Clone ();
				break;
			}
		}
		return MyHash;	
	}
	
	public Hashtable GetHelperReqByID(int ID)
	{
		Hashtable MyHash = new Hashtable();
		for(int a = 0;a<HelperList.Count;a++)
		{
			if((int)HelperList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)HelperList[a].Clone ();
				break;
			}
		}
		return MyHash;
	}
	
	public Hashtable GetCashierLevelReqByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= CashierLevel.Count && Level >0)
		{
			MyHash = (Hashtable)CashierLevel[Level-1].Clone ();
		}
		return MyHash;
	}
	public Hashtable GetBarLevelReqByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= BarLevel.Count && Level >0)
		{
			MyHash = (Hashtable)BarLevel[Level-1].Clone ();
		}
		return MyHash;
	}
	public Hashtable GetBarUnlockReqBySlot(int Slot)
	{
		Hashtable MyHash = new Hashtable();
		if(Slot < BarUnlock.Count)
		{
			MyHash = (Hashtable)BarUnlock[Slot].Clone ();
		}
		return MyHash;
	}
	public Hashtable GetTDisplayLevelReqByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();	
		if(Level <= TDisplayLevel.Count && Level>0)
		{
			MyHash = (Hashtable)TDisplayLevel[Level-1].Clone ();	
		}
		return MyHash;
	}
	public Hashtable GetTDisplayUnlockReqBySlot(int Slot)
	{
		Hashtable MyHash = new Hashtable();
		if(Slot < TDisplayUnlock.Count)
		{
			MyHash = (Hashtable)TDisplayUnlock[Slot].Clone ();	
		}
		return MyHash;
	}
	public Hashtable GetFoodLevelReqByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= FoodLevel.Count && Level >0)
		{
			MyHash = (Hashtable)FoodLevel[Level-1].Clone ();
		}
		return MyHash;
	}
	public Hashtable GetFoodUnlockReqBySlot(int Slot)
	{
		Hashtable MyHash = new Hashtable();
		if(Slot < FoodUnlock.Count)
		{
			MyHash = (Hashtable)FoodUnlock[Slot].Clone ();	
		}
		return MyHash;
	}
	public Hashtable GetQueueUpLevelReqByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= QueueUpLevel.Count && Level >0)
		{
			MyHash = (Hashtable)QueueUpLevel[Level-1].Clone ();	
		}
		return MyHash;
	}
	public Hashtable GetQueueUpUnlockReqBySlot(int Slot)
	{
		Hashtable MyHash = new Hashtable();
		if(Slot <QueueUpUnlock.Count)
		{
			MyHash = (Hashtable)QueueUpUnlock[Slot].Clone ();	
		}
		return MyHash;
	}
	
	public Hashtable GetMSPDReqByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= MSPDList.Count && Level >0)
		{
			MyHash = (Hashtable)MSPDList[Level-1].Clone ();	
		}
		return MyHash;
	}
	public Hashtable GetASPDReqByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= ASPDList.Count && Level > 0)
		{
			MyHash = (Hashtable)ASPDList[Level-1].Clone();	
		}
		return MyHash;
	}
}
