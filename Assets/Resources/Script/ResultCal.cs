using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class ResultCal : MonoBehaviour 
{
	private int Coin = 0;
	private int TotalCoin = 0;
	private int Like = 0;
	
	private int HotelRank = 0;
	
	private int CountOf3Star = 0;
	private int CountOf4Star = 0;
	private int CountOf5Star = 0;
	private int CountOf6Star = 0;
	
	public int RunawayCount = 0;
	private int TDisplayCount = 0;
	private int BarCount = 0;
	private int FoodCount = 0;
	private int CashierCount = 0;
	private int LiftCount = 0;
	
	
	private void Start()
	{
		
	}
	//@Kaizer: Data Update
	public void AddCoin(int Add = 0)
	{
		Coin += Add;	
	}
	public void AddTotalCoin(int Add = 0)
	{
		TotalCoin += Add;	
	}
	public void AddLike(int Add = 0)
	{
		Like += Add;	
	}
	public void AddHotelRank(int Add = 0)
	{
		HotelRank += Add;	
	}
	public void AddCountOf3Star(int Add = 0)
	{
		CountOf3Star += Add;	
	}
	public void AddCountOf4Star(int Add = 0)
	{
		CountOf4Star += Add;	
	}
	public void AddCountOf5Star(int Add = 0)
	{
		CountOf5Star += Add;
	}
	public void AddCountOf6Star(int Add = 0)
	{
		CountOf6Star += Add;	
	}
	public void AddTDisplayCount(int Add = 0)
	{
		TDisplayCount += Add;	
	}
	public void AddBarCount(int Add = 0)
	{
		BarCount += Add;	
	}
	public void AddFoodCount(int Add = 0)
	{
		FoodCount += Add;	
	}
	public void AddCashierCount(int Add = 0)
	{
		CashierCount += Add;	
	}
	public void AddLiftCount(int Add = 0)
	{
		LiftCount += Add;	
	}
	public void AddRunawayCount(int Add = 0)
	{
		RunawayCount += Add;	
	}
	public void UpdatePlayerAtr()
	{
		Main.MyPlayerAtr.AddCoin (Coin);
		Main.MyPlayerAtr.AddTotalCoin(TotalCoin);
		Main.MyPlayerAtr.AddLike (Like);
		Main.MyPlayerAtr.AddHotelRank(HotelRank);
		Main.MyPlayerAtr.AddCountOf3Star(CountOf3Star);
		Main.MyPlayerAtr.AddCountOf4Star (CountOf4Star);
		Main.MyPlayerAtr.AddCountOf5Star (CountOf5Star);
		Main.MyPlayerAtr.AddCountOf6Star (CountOf6Star);
		Main.MyPlayerAtr.AddTDisplayCount(TDisplayCount);
		Main.MyPlayerAtr.AddBarCount (BarCount);
		Main.MyPlayerAtr.AddFoodCount(FoodCount);
		Main.MyPlayerAtr.AddCashierCount(CashierCount);
		Main.MyPlayerAtr.AddLiftCount(LiftCount);
		Main.MyPlayerAtr.AddRunawayCount(RunawayCount);
		Main.MyAchievement.UpdateHotelRank();
		Clear();
	}
	
	//@Kaizer: Return Data
	public int ReturnCoin()
	{
		return Coin;	
	}
	public int ReturnTotalCoin()
	{
		return TotalCoin;	
	}
	public int ReturnLike()
	{
		return Like;	
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
	public int ReturnCashierCount()
	{
		return CashierCount;	
	}
	public int ReturnLiftCount()
	{
		return LiftCount;	
	}
	public int ReturnRunawayCount()
	{
		return RunawayCount;	
	}
	//@ Kaizer: Clearance
	public void Clear()
	{
		if(Main.MyResultCal != null)
		{
			Destroy (this.gameObject.GetComponent ("ResultCal"));
			Main.MyResultCal = null;
		}
	}
}
