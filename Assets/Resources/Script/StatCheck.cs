using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class StatCheck : MonoBehaviour 
{
	private List<float> MSPDList = null;
	private List<float> ASPDList = null;
	private List<float> HelperMSPDList = null;
	private List<float> HelperASPDList = null;
	private List<Hashtable> QueueUpList = null;
	private List<Hashtable> FoodList = null;
	private List<Hashtable> TDisplayList = null;
	private List<Hashtable> BarList = null;
	private List<Hashtable> CashierList = null;
	private List<Hashtable> HelperList = null;
	private List<Hashtable> DecoList = null;
	private List<Hashtable> ThemeList = null;
	private List<Hashtable> HelperLevelList = null;
	
	private List<Hashtable> LeaveList = null;
	
	private void Start()
	{
		Init();
	}
	private void Init()
	{
		MSPDList = new List<float>(new float[]{0.3f,0.25f,0.2f,0.15f,0.1f});
		
		ASPDList = new List<float>(new float[]{2f,1.8f,1.5f,1.2f,1f});
		
		HelperMSPDList = new List<float>(new float[]{0.3f,0.25f,0.2f,0.15f,0.1f});
		
		HelperASPDList = new List<float>(new float[]{2f,1.8f,1.5f,1.2f,1f});
		
		QueueUpList = new List<Hashtable>();
		QueueUpList.Add(HashObject.Hash ("WaitingTime", 0f));
		QueueUpList.Add(HashObject.Hash ("WaitingTime", 0.1f));
		QueueUpList.Add(HashObject.Hash ("WaitingTime", 0.2f));
		
		FoodList = new List<Hashtable>();
		FoodList.Add (HashObject.Hash ("WaitingTime", 0f));
		FoodList.Add (HashObject.Hash ("WaitingTime", 0.1f));
		FoodList.Add (HashObject.Hash ("WaitingTime", 0.2f));
		
		TDisplayList = new List<Hashtable>();
		TDisplayList.Add (HashObject.Hash ("WaitingTime", 0f));
		TDisplayList.Add (HashObject.Hash ("WaitingTime", 0.1f));
		TDisplayList.Add (HashObject.Hash ("WaitingTime", 0.2f));
		
		BarList = new List<Hashtable>();
		BarList.Add (HashObject.Hash ("WaitingTime", 0f));
		BarList.Add (HashObject.Hash ("WaitingTime", 0.1f));
		BarList.Add (HashObject.Hash ("WaitingTime", 0.2f));
		
		CashierList = new List<Hashtable>();
		CashierList.Add (HashObject.Hash ("WaitingTime", 0f, "LikeRate", 0f));
		CashierList.Add (HashObject.Hash ("WaitingTime", 0.1f, "LikeRate", 0f));
		CashierList.Add (HashObject.Hash ("WaitingTime", 0.2f, "LikeRate", 0f));
		CashierList.Add (HashObject.Hash ("WaitingTime", 0.25f, "LikeRate", 0.05f));
		CashierList.Add (HashObject.Hash ("WaitingTime", 0.3f, "LikeRate", 0.1f));
		
		LeaveList = new List<Hashtable>();
		LeaveList.Add (HashObject.Hash ("LeaveWaitingTime", 1f));
		
		HelperList = new List<Hashtable>();
		HelperList.Add (HashObject.Hash ("ID", 1, "Name", "Helper1", "MovementSpeed", HelperMSPDList, "ActionSpeed", HelperASPDList));
		HelperList.Add (HashObject.Hash ("ID", 2, "Name", "Helper2", "MovementSpeed", HelperMSPDList, "ActionSpeed", HelperASPDList));
		HelperList.Add (HashObject.Hash ("ID", 3, "Name", "Helper3", "MovementSpeed", HelperMSPDList, "ActionSpeed", HelperASPDList));
		HelperList.Add (HashObject.Hash ("ID", 4, "Name", "Helper4", "MovementSpeed", HelperMSPDList, "ActionSpeed", HelperASPDList));
		HelperList.Add (HashObject.Hash ("ID", 5, "Name", "Helper5", "MovementSpeed", HelperMSPDList, "ActionSpeed", HelperASPDList));
		HelperList.Add (HashObject.Hash ("ID", 6, "Name", "Helper6", "MovementSpeed", HelperMSPDList, "ActionSpeed", HelperASPDList));
		HelperList.Add (HashObject.Hash ("ID", 7, "Name", "Helper7", "MovementSpeed", HelperMSPDList, "ActionSpeed", HelperASPDList));
		//HelperList.Add (HashObject.Hash ("ID", 8, "Name", "Helper8", "MovementSpeed", 0.1f, "ActionSpeed", 1.0f));
		
		DecoList = new List<Hashtable>();
		/*DecoList.Add (HashObject.Hash ("ID", 1, "Name", "Deco1", "WaitingTime", 0.05f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 2, "Name", "Deco2", "WaitingTime", 0.1f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 3, "Name", "Deco3", "WaitingTime", 0.15f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 4, "Name", "Deco4", "WaitingTime", 0.2f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0f));
		
		DecoList.Add (HashObject.Hash ("ID", 5, "Name", "Deco5", "WaitingTime", 0f, "Satisfaction", 0.125f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 6, "Name", "Deco6", "WaitingTime", 0f, "Satisfaction", 0.25f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 7, "Name", "Deco7", "WaitingTime", 0f, "Satisfaction", 0.375f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 8, "Name", "Deco8", "WaitingTime", 0f, "Satisfaction", 0.5f, "LikeRate", 0f, "TipsRate", 0f));
		
		DecoList.Add (HashObject.Hash ("ID", 9, "Name", "Deco9", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0.05f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 10, "Name", "Deco10", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0.1f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 11, "Name", "Deco11", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0.15f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 12, "Name", "Deco12", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0.2f, "TipsRate", 0f));
		
		DecoList.Add (HashObject.Hash ("ID", 13, "Name", "Deco13", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0.05f));
		DecoList.Add (HashObject.Hash ("ID", 14, "Name", "Deco14", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0.1f));
		DecoList.Add (HashObject.Hash ("ID", 15, "Name", "Deco15", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0.15f));
		DecoList.Add (HashObject.Hash ("ID", 16, "Name", "Deco16", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0.2f));
		
		DecoList.Add (HashObject.Hash ("ID", 17, "Name", "Deco17", "WaitingTime", 0.07f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 18, "Name", "Deco18", "WaitingTime", 0f, "Satisfaction", 0.175f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 19, "Name", "Deco19", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0.07f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 20, "Name", "Deco20", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0.07f));
		
		DecoList.Add (HashObject.Hash ("ID", 21, "Name", "Deco21", "WaitingTime", 0.05f, "Satisfaction", 0.125f, "LikeRate", 0f, "TipsRate", 0f));
		DecoList.Add (HashObject.Hash ("ID", 22, "Name", "Deco22", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0.05f, "TipsRate", 0.05f));
		DecoList.Add (HashObject.Hash ("ID", 23, "Name", "Deco23", "WaitingTime", 0.03f, "Satisfaction", 0.075f, "LikeRate", 0.03f, "TipsRate", 0.03f));
		DecoList.Add (HashObject.Hash ("ID", 24, "Name", "Deco24", "WaitingTime", 0.07f, "Satisfaction", 0.175f, "LikeRate", 0.07f, "TipsRate", 0.07f));
		DecoList.Add (HashObject.Hash ("ID", 25, "Name", "Deco25", "WaitingTime", 0.1f, "Satisfaction", 0.25f, "LikeRate", 0.1f, "TipsRate", 0.1f));
		*/
		DecoList.Add (HashObject.Hash ("ID", 1, "Name", "Deco1", "WaitingTime", 0.05f, "Satisfaction", 0.125f, "LikeRate", 0.05f, "TipsRate", 0.05f));
		DecoList.Add (HashObject.Hash ("ID", 2, "Name", "Deco2", "WaitingTime", 0.1f, "Satisfaction", 0.25f, "LikeRate", 0.1f, "TipsRate", 0.1f));
		DecoList.Add (HashObject.Hash ("ID", 3, "Name", "Deco3", "WaitingTime", 0.15f, "Satisfaction", 0.375f, "LikeRate", 0.15f, "TipsRate", 0.15f));
		DecoList.Add (HashObject.Hash ("ID", 4, "Name", "Deco4", "WaitingTime", 0.2f, "Satisfaction", 0.5f, "LikeRate", 0.2f, "TipsRate", 0.2f));
		DecoList.Add (HashObject.Hash ("ID", 5, "Name", "Deco5", "WaitingTime", 0.3f, "Satisfaction", 0.75f, "LikeRate", 0.3f, "TipsRate", 0.3f));
		
		
		ThemeList = new List<Hashtable>();
		ThemeList.Add (HashObject.Hash ("ID", 1, "Name", "Theme1", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0f));
		ThemeList.Add (HashObject.Hash ("ID", 2, "Name", "Theme2", "WaitingTime", 0f, "Satisfaction", 0f, "LikeRate", 0f, "TipsRate", 0f));
		
	}
	
	public Hashtable GetDecoStatByID(int ID)
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
	public Hashtable GetThemeStatByID(int ID)
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
	
	public Hashtable GetHelperStatByID(int ID)
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
	
	public Hashtable GetCashierStatByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= CashierList.Count && Level >0)
		{
			MyHash = (Hashtable)CashierList[Level-1].Clone ();	
		}
		return MyHash;
	}
	
	public Hashtable GetLeaveStat()
	{
		Hashtable MyHash = new Hashtable();
		MyHash = (Hashtable)LeaveList[0].Clone();
		return MyHash;
	}
	
	public Hashtable GetBarStatByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= BarList.Count && Level >0)
		{
			MyHash = (Hashtable)BarList[Level-1].Clone ();	
		}
		return MyHash;
	}
	public Hashtable GetTDisplayStatByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= TDisplayList.Count && Level >0)
		{
			MyHash = (Hashtable)TDisplayList[Level-1].Clone ();	
		}
		return MyHash;
	}
	public Hashtable GetFoodStatByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= FoodList.Count && Level >0)
		{
			MyHash = (Hashtable)FoodList[Level-1].Clone ();	
		}
		return MyHash;
	}
	
	public Hashtable GetQueueUpStatByLevel(int Level)
	{
		Hashtable MyHash = new Hashtable();
		if(Level <= QueueUpList.Count && Level >0)
		{
			MyHash = (Hashtable)QueueUpList[Level-1].Clone ();
		}
		return MyHash;
	}
	
	public float GetMSPDByLevel(int Level)
	{
		float TemFloat = 0f;
		if(Level <= MSPDList.Count && Level>0)
		{
			TemFloat = MSPDList[Level-1];	
		}
		return TemFloat;
	}
	public float GetASPDByLevel(int Level)
	{
		float TemFloat = 0f;
		if(Level <= ASPDList.Count && Level >0)
		{
			TemFloat = ASPDList[Level-1];
		}
		return TemFloat;
	}
}
