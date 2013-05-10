using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class Achievement : MonoBehaviour 
{
	private List<Hashtable> LikeList = null;
	private List<Hashtable> TotalCoinList = null;
	private List<Hashtable> TotalDiamondList = null;
	private List<Hashtable> DayList = null;
	private List<Hashtable> HotelRankList = null;
	private List<Hashtable> CountOf3StarList = null;
	private List<Hashtable> CountOf4StarList = null;
	private List<Hashtable> CountOf5StarList = null;
	private List<Hashtable> CountOf6StarList = null;
	private List<Hashtable> RunawayCountList = null;
	private List<Hashtable> TDisplayCountList = null;
	private List<Hashtable> BarCountList = null;
	private List<Hashtable> FoodCountList = null;
	private List<Hashtable> CashierCountList = null;
	private List<Hashtable> QueueUpSlotList = null;
	private List<Hashtable> FoodSlotList = null;
	private List<Hashtable> TDisplaySlotList = null;
	private List<Hashtable> BarSlotList = null;
	private List<Hashtable> CashierLevelList = null;
	private List<Hashtable> HelperList = null;
	private List<Hashtable> SpentCoinList = null;
	private List<Hashtable> SpentDiamondList = null;
	private List<Hashtable> UpgradeCountList = null;
	private List<Hashtable> MSPDLevelList = null;
	private List<Hashtable> ASPDLevelList = null;
	
	private List<Hashtable> RewardList = null;
	
	private List<string> CheckList = null;
	
	private List<int> HotelRankCoinReq = null;
	private List<int> HotelRankLikeReq = null;

	private void Start()
	{
		Init();	
	}
	private void Init()
	{
		//@ Kaizer: Achievement List
		
		HotelRankCoinReq = new List<int>(new int[]{0,10000,50000,100000,500000,1000000});
		HotelRankLikeReq = new List<int>(new int[]{0,50,200,500,1000,2000});
		
		CheckList = new List<string>();
		CheckList.Add ("LikeList");
		CheckList.Add ("TotalCoinList");
		CheckList.Add ("TotalDiamondList");
		CheckList.Add ("DayList");
		CheckList.Add ("HotelRankList");
		CheckList.Add ("CountOf3StarList");
		CheckList.Add ("CountOf4StarList");
		CheckList.Add ("CountOf5StarList");
		CheckList.Add ("CountOf6StarList");
		CheckList.Add ("RunawayList");
		CheckList.Add ("TDisplayCountList");
		CheckList.Add ("BarCountList");
		CheckList.Add ("FoodCountList");
		CheckList.Add ("CashierCountList");
		CheckList.Add ("QueueUpSlotList");
		CheckList.Add ("FoodSlotList");
		CheckList.Add ("TDisplaySlotList");
		CheckList.Add ("BarSlotList");
		CheckList.Add ("CashierLevelList");
		CheckList.Add ("HelperList");
		CheckList.Add ("SpentCoinList");
		CheckList.Add ("SpentDiamondList");
		CheckList.Add ("UpgradeCountList");
		CheckList.Add ("MSPDLevelList");
		CheckList.Add ("ASPDLevelList");
		
		LikeList = new List<Hashtable>();
		LikeList.Add (HashObject.Hash ("ID", 0, "Name", "Like 0", "Description", "Obtain 1 like or above", "Req", 1));
		LikeList.Add (HashObject.Hash ("ID", 1, "Name", "Like 1", "Description", "Obtain 20 like or above", "Req", 20));
		LikeList.Add (HashObject.Hash ("ID", 2, "Name", "Like 2", "Description", "Obtain 50 like or above", "Req", 50));
		LikeList.Add (HashObject.Hash ("ID", 3, "Name", "Like 3", "Description", "Obtain 100 like or above", "Req", 100));
		LikeList.Add (HashObject.Hash ("ID", 4, "Name", "Like 4", "Description", "Obtain 200 like or above", "Req", 200));
		LikeList.Add (HashObject.Hash ("ID", 5, "Name", "Like 5", "Description", "Obtain 500 like or above", "Req", 500));
		LikeList.Add (HashObject.Hash ("ID", 6, "Name", "Like 6", "Description", "Obtain 1,000 like or above", "Req", 1000));
		LikeList.Add (HashObject.Hash ("ID", 7, "Name", "Like 7", "Description", "Obtain 2,500 like or above", "Req", 2500));
		LikeList.Add (HashObject.Hash ("ID", 8, "Name", "Like 8", "Description", "Obtain 5,000 like or above", "Req", 5000));
		LikeList.Add (HashObject.Hash ("ID", 9, "Name", "Like 9", "Description", "Obtain 10,000 like or above", "Req", 10000));
		
		TotalCoinList = new List<Hashtable>();
		TotalCoinList.Add (HashObject.Hash ("ID", 10, "Name", "TotalCoin 10", "Description", "Collect 1,000 coins or more", "Req", 1000));
		TotalCoinList.Add (HashObject.Hash ("ID", 11, "Name", "TotalCoin 11", "Description", "Collect 1,0000 coins or more", "Req", 10000));
		TotalCoinList.Add (HashObject.Hash ("ID", 12, "Name", "TotalCoin 12", "Description", "Collect 50,000 coins or more", "Req", 50000));
		TotalCoinList.Add (HashObject.Hash ("ID", 13, "Name", "TotalCoin 13", "Description", "Collect 100,000 coins or more", "Req", 100000));
		TotalCoinList.Add (HashObject.Hash ("ID", 14, "Name", "TotalCoin 14", "Description", "Collect 250,000 coins or more", "Req", 250000));
		TotalCoinList.Add (HashObject.Hash ("ID", 15, "Name", "TotalCoin 15", "Description", "Collect 500,000 coins or more", "Req", 500000));
		TotalCoinList.Add (HashObject.Hash ("ID", 16, "Name", "TotalCoin 16", "Description", "Collect 1,000,000 coins or more", "Req", 1000000));
		TotalCoinList.Add (HashObject.Hash ("ID", 17, "Name", "TotalCoin 17", "Description", "Collect 2,500,000 coins or more", "Req", 2500000));
		TotalCoinList.Add (HashObject.Hash ("ID", 18, "Name", "TotalCoin 18", "Description", "Collect 5,000,000 coins or more", "Req", 5000000));
		TotalCoinList.Add (HashObject.Hash ("ID", 19, "Name", "TotalCoin 19", "Description", "Collect 10,000,000 coins or more", "Req", 10000000));
		
		TotalDiamondList = new List<Hashtable>();
		TotalDiamondList.Add (HashObject.Hash ("ID", 20, "Name", "TotalDiamond 20", "Description", "Acquired 100 Diamond or more", "Req", 100));
		TotalDiamondList.Add (HashObject.Hash ("ID", 21, "Name", "TotalDiamond 21", "Description", "Acquired 500 Diamond or more", "Req", 500));
		TotalDiamondList.Add (HashObject.Hash ("ID", 22, "Name", "TotalDiamond 22", "Description", "Acquired 2,000 Diamond or more", "Req", 2000));
		TotalDiamondList.Add (HashObject.Hash ("ID", 23, "Name", "TotalDiamond 23", "Description", "Acquired 5,000 Diamond or more", "Req", 5000));
		TotalDiamondList.Add (HashObject.Hash ("ID", 24, "Name", "TotalDiamond 24", "Description", "Acquired 10,000 Diamond or more", "Req", 10000));
		
		DayList = new List<Hashtable>();
		DayList.Add(HashObject.Hash ("ID", 25, "Name", "Day 25", "Description", "Reach 7 days", "Req", 7));
		DayList.Add(HashObject.Hash ("ID", 26, "Name", "Day 26", "Description", "Reach 14 days", "Req", 14));
		DayList.Add(HashObject.Hash ("ID", 27, "Name", "Day 27", "Description", "Reach 21 days", "Req", 21));
		DayList.Add(HashObject.Hash ("ID", 28, "Name", "Day 28", "Description", "Reach 28 days", "Req", 28));
		DayList.Add(HashObject.Hash ("ID", 29, "Name", "Day 29", "Description", "Reach 56 days", "Req", 56));
		DayList.Add(HashObject.Hash ("ID", 30, "Name", "Day 30", "Description", "Reach 100 days", "Req", 100));
		DayList.Add(HashObject.Hash ("ID", 31, "Name", "Day 31", "Description", "Reach 150 days", "Req", 150));
		DayList.Add(HashObject.Hash ("ID", 32, "Name", "Day 32", "Description", "Reach 200 days", "Req", 200));
		DayList.Add(HashObject.Hash ("ID", 33, "Name", "Day 33", "Description", "Reach 250 days", "Req", 250));
		DayList.Add(HashObject.Hash ("ID", 34, "Name", "Day 34", "Description", "Reach 364 days", "Req", 364));
		
		HotelRankList = new List<Hashtable>();
		HotelRankList.Add (HashObject.Hash ("ID", 35, "Name", "HotelRank 35", "Description", "Hotel rank reach 2 stars", "Req", 2));
		HotelRankList.Add (HashObject.Hash ("ID", 36, "Name", "HotelRank 36", "Description", "Hotel rank reach 3 stars", "Req", 3));
		HotelRankList.Add (HashObject.Hash ("ID", 37, "Name", "HotelRank 37", "Description", "Hotel rank reach 4 stars", "Req", 4));
		HotelRankList.Add (HashObject.Hash ("ID", 38, "Name", "HotelRank 38", "Description", "Hotel rank reach 5 stars", "Req", 5));
		HotelRankList.Add (HashObject.Hash ("ID", 39, "Name", "HotelRank 39", "Description", "Hotel rank reach 6 stars", "Req", 6));
		
		CountOf3StarList = new List<Hashtable>();
		CountOf3StarList.Add (HashObject.Hash("ID", 40, "Name", "CountOf3Star 40", "Description", "Served 80 customers with 3stars or above", "Req", 80));
		CountOf3StarList.Add (HashObject.Hash("ID", 41, "Name", "CountOf3Star 41", "Description", "Served 400 customers with 3stars or above", "Req", 400));
		CountOf3StarList.Add (HashObject.Hash("ID", 42, "Name", "CountOf3Star 42", "Description", "Served 1,600 customers with 3stars or above", "Req", 1600));
		CountOf3StarList.Add (HashObject.Hash("ID", 43, "Name", "CountOf3Star 43", "Description", "Served 4,000 customers with 3stars or above", "Req", 4000));
		CountOf3StarList.Add (HashObject.Hash("ID", 44, "Name", "CountOf3Star 44", "Description", "Served 8,000 customers with 3stars or above", "Req", 8000));
		
		CountOf4StarList = new List<Hashtable>();
		CountOf4StarList.Add (HashObject.Hash("ID", 45, "Name", "CountOf4Star 45", "Description", "Served 40 customers with 4stars or above", "Req", 40));
		CountOf4StarList.Add (HashObject.Hash("ID", 46, "Name", "CountOf4Star 46", "Description", "Served 200 customers with 4stars or above", "Req", 200));
		CountOf4StarList.Add (HashObject.Hash("ID", 47, "Name", "CountOf4Star 47", "Description", "Served 800 customers with 4stars or above", "Req", 800));
		CountOf4StarList.Add (HashObject.Hash("ID", 48, "Name", "CountOf4Star 48", "Description", "Served 2,000 customers with 4stars or above", "Req", 2000));
		CountOf4StarList.Add (HashObject.Hash("ID", 49, "Name", "CountOf4Star 49", "Description", "Served 4,000 customers with 4stars or above", "Req", 4000));
		
		CountOf5StarList = new List<Hashtable>();
		CountOf5StarList.Add (HashObject.Hash("ID", 50, "Name", "CountOf5Star 50", "Description", "Served 20 customers with 5stars or above", "Req", 20));
		CountOf5StarList.Add (HashObject.Hash("ID", 51, "Name", "CountOf5Star 51", "Description", "Served 100 customers with 5stars or above", "Req", 100));
		CountOf5StarList.Add (HashObject.Hash("ID", 52, "Name", "CountOf5Star 52", "Description", "Served 400 customers with 5stars or above", "Req", 400));
		CountOf5StarList.Add (HashObject.Hash("ID", 53, "Name", "CountOf5Star 53", "Description", "Served 1,000 customers with 5stars or above", "Req", 1000));
		CountOf5StarList.Add (HashObject.Hash("ID", 54, "Name", "CountOf5Star 54", "Description", "Served 2,000 customers with 5stars or above", "Req", 2000));
		
		CountOf6StarList = new List<Hashtable>();
		CountOf6StarList.Add (HashObject.Hash("ID", 55, "Name", "CountOf6Star 55", "Description", "Served 10 customers with 6stars or above", "Req", 10));
		CountOf6StarList.Add (HashObject.Hash("ID", 56, "Name", "CountOf6Star 56", "Description", "Served 50 customers with 6stars or above", "Req", 50));
		CountOf6StarList.Add (HashObject.Hash("ID", 57, "Name", "CountOf6Star 57", "Description", "Served 200 customers with 6stars or above", "Req", 200));
		CountOf6StarList.Add (HashObject.Hash("ID", 58, "Name", "CountOf6Star 58", "Description", "Served 500 customers with 6stars or above", "Req", 500));
		CountOf6StarList.Add (HashObject.Hash("ID", 59, "Name", "CountOf6Star 59", "Description", "Served 1,000 customers with 6stars or above", "Req", 1000));
		
		RunawayCountList = new List<Hashtable>();
		RunawayCountList.Add (HashObject.Hash ("ID", 60, "Name", "Runawaycount 60", "Description", "Total 1 customer leave the hotel", "Req", 1));
		RunawayCountList.Add (HashObject.Hash ("ID", 61, "Name", "Runawaycount 61", "Description", "Total 10 customer leave the hotel", "Req", 10));
		RunawayCountList.Add (HashObject.Hash ("ID", 62, "Name", "Runawaycount 62", "Description", "Total 50 customer leave the hotel", "Req", 50));
		RunawayCountList.Add (HashObject.Hash ("ID", 63, "Name", "Runawaycount 63", "Description", "Total 100 customer leave the hotel", "Req", 100));
		RunawayCountList.Add (HashObject.Hash ("ID", 64, "Name", "Runawaycount 64", "Description", "Total 200 customer leave the hotel", "Req", 200));
		
		TDisplayCountList = new List<Hashtable>();
		TDisplayCountList.Add (HashObject.Hash ("ID", 65, "Name", "TDisplay 65", "Description", "Served 10 times at Talent Display Station", "Req", 10));
		TDisplayCountList.Add (HashObject.Hash ("ID", 66, "Name", "TDisplay 66", "Description", "Served 100 times at Talent Display Station", "Req", 100));
		TDisplayCountList.Add (HashObject.Hash ("ID", 67, "Name", "TDisplay 67", "Description", "Served 1,000 times at Talent Display Station", "Req", 1000));
		TDisplayCountList.Add (HashObject.Hash ("ID", 68, "Name", "TDisplay 68", "Description", "Served 2,500 times at Talent Display Station", "Req", 2500));
		TDisplayCountList.Add (HashObject.Hash ("ID", 69, "Name", "TDisplay 69", "Description", "Served 5,000 times at Talent Display Station", "Req", 5000));
		
		BarCountList = new List<Hashtable>();
		BarCountList.Add (HashObject.Hash("ID", 70, "Name", "Bar 70", "Description", "Served 10 times at Bar station", "Req", 10));
		BarCountList.Add (HashObject.Hash("ID", 71, "Name", "Bar 71", "Description", "Served 100 times at Bar station", "Req", 100));
		BarCountList.Add (HashObject.Hash("ID", 72, "Name", "Bar 72", "Description", "Served 1,000 times at Bar station", "Req", 1000));
		BarCountList.Add (HashObject.Hash("ID", 73, "Name", "Bar 73", "Description", "Served 2,500 times at Bar station", "Req", 2500));
		BarCountList.Add (HashObject.Hash("ID", 74, "Name", "Bar 74", "Description", "Served 5,000 times at Bar station", "Req", 5000));
		
		FoodCountList = new List<Hashtable>();
		FoodCountList.Add (HashObject.Hash ("ID", 75, "Name", "Food 75", "Description", "Served 10 times at Food station", "Req", 10));
		FoodCountList.Add (HashObject.Hash ("ID", 76, "Name", "Food 76", "Description", "Served 100 times at Food station", "Req", 100));
		FoodCountList.Add (HashObject.Hash ("ID", 77, "Name", "Food 77", "Description", "Served 1,000 times at Food station", "Req", 1000));
		FoodCountList.Add (HashObject.Hash ("ID", 78, "Name", "Food 78", "Description", "Served 2,500 times at Food station", "Req", 2500));
		FoodCountList.Add (HashObject.Hash ("ID", 79, "Name", "Food 79", "Description", "Served 5,000 times at Food station", "Req", 5000));
		
		CashierCountList = new List<Hashtable>();
		CashierCountList.Add (HashObject.Hash ("ID", 80, "Name", "Cashier 80", "Description", "Collect coin 15 times at cashier", "Req", 15));
		CashierCountList.Add (HashObject.Hash ("ID", 81, "Name", "Cashier 81", "Description", "Collect coin 120 times at cashier", "Req", 120));
		CashierCountList.Add (HashObject.Hash ("ID", 82, "Name", "Cashier 82", "Description", "Collect coin 1,200 times at cashier", "Req", 1200));
		CashierCountList.Add (HashObject.Hash ("ID", 83, "Name", "Cashier 83", "Description", "Collect coin 3,000 times at cashier", "Req", 3000));
		CashierCountList.Add (HashObject.Hash ("ID", 84, "Name", "Cashier 84", "Description", "Collect coin 6,000 times at cashier", "Req", 6000));
		
		QueueUpSlotList = new List<Hashtable>();
		QueueUpSlotList.Add (HashObject.Hash ("ID", 85, "Name", "QueueUpSlot 85", "Description", "Own 4 queue up chairs", "Req", 4));
		QueueUpSlotList.Add (HashObject.Hash ("ID", 86, "Name", "QueueUpSlot 86", "Description", "Own one Lv2 queue up chairs", "Req", 2));
		QueueUpSlotList.Add (HashObject.Hash ("ID", 87, "Name", "QueueUpSlot 87", "Description", "Own one Lv3 queue up chairs", "Req", 3));
		
		FoodSlotList = new List<Hashtable>();
		FoodSlotList.Add (HashObject.Hash ("ID", 88, "Name", "FoodSlot 88", "Description", "Own 3 tables at food station", "Req", 3));
		FoodSlotList.Add (HashObject.Hash ("ID", 89, "Name", "FoodSlot 89", "Description", "Own one Lv2 table at food station", "Req", 2));
		FoodSlotList.Add (HashObject.Hash ("ID", 90, "Name", "FoodSlot 90", "Description", "Own one Lv3 table at food station", "Req", 3));
		
		TDisplaySlotList = new List<Hashtable>();
		TDisplaySlotList.Add (HashObject.Hash ("ID", 91, "Name", "TDisplaySlot 91", "Description", "Own 3 slots at Talent Display section", "Req", 3));
		TDisplaySlotList.Add (HashObject.Hash ("ID", 92, "Name", "TDisplaySlot 92", "Description", "Own one Lv2 slot at Talent Display section", "Req", 2));
		TDisplaySlotList.Add (HashObject.Hash ("ID", 93, "Name", "TDisplaySlot 93", "Description", "Own one Lv3 slot at Talent Display section", "Req", 3));
		
		BarSlotList = new List<Hashtable>();
		BarSlotList.Add (HashObject.Hash ("ID", 94, "Name", "BarSlot 94", "Description", "Own 3 sits at Bar station", "Req", 3));
		BarSlotList.Add (HashObject.Hash ("ID", 95, "Name", "BarSlot 95", "Description", "Own one Lv2 sits at Bar station", "Req", 2));
		BarSlotList.Add (HashObject.Hash ("ID", 96, "Name", "BarSlot 96", "Description", "Own one Lv3 sits at Bar station", "Req", 3));
		
		CashierLevelList = new List<Hashtable>();
		CashierLevelList.Add (HashObject.Hash ("ID", 97, "Name", "CashierLevel 97", "Description", "Own Lv2 Cashier", "Req", 2));
		CashierLevelList.Add (HashObject.Hash ("ID", 98, "Name", "CashierLevel 98", "Description", "Own Lv3 Cashier", "Req", 3));
		CashierLevelList.Add (HashObject.Hash ("ID", 99, "Name", "CashierLevel 99", "Description", "Own Lv4 Cashier", "Req", 4));
		CashierLevelList.Add (HashObject.Hash ("ID", 100, "Name", "CashierLevel 100", "Description", "Own Lv5 Cashier", "Req", 5));
		
		HelperList = new List<Hashtable>();
		HelperList.Add (HashObject.Hash ("ID", 101, "Name", "Helper 101", "Description", "Own 1 helper", "Req", 1));
		HelperList.Add (HashObject.Hash ("ID", 102, "Name", "Helper 102", "Description", "Own 2 helpers", "Req", 2));
		HelperList.Add (HashObject.Hash ("ID", 103, "Name", "Helper 103", "Description", "Own 3 helpers", "Req", 3));
		HelperList.Add (HashObject.Hash ("ID", 104, "Name", "Helper 104", "Description", "Own 4 helpers", "Req", 4));
		HelperList.Add (HashObject.Hash ("ID", 105, "Name", "Helper 105", "Description", "Own 5 helpers", "Req", 5));
		HelperList.Add (HashObject.Hash ("ID", 106, "Name", "Helper 106", "Description", "Own 6 helpers", "Req", 6));
		HelperList.Add (HashObject.Hash ("ID", 107, "Name", "Helper 107", "Description", "Own 7 helpers", "Req", 7));
		HelperList.Add (HashObject.Hash ("ID", 108, "Name", "Helper 108", "Description", "Own 8 helpers", "Req", 8));
		
		SpentCoinList = new List<Hashtable>();
		SpentCoinList.Add (HashObject.Hash ("ID", 109, "Name", "SpentCoin 109", "Description", "Spent 5,000 coins", "Req", 5000));
		SpentCoinList.Add (HashObject.Hash ("ID", 110, "Name", "SpentCoin 110", "Description", "Spent 50,000 coins", "Req", 50000));
		SpentCoinList.Add (HashObject.Hash ("ID", 111, "Name", "SpentCoin 111", "Description", "Spent 100,000 coins", "Req", 100000));
		SpentCoinList.Add (HashObject.Hash ("ID", 112, "Name", "SpentCoin 112", "Description", "Spent 500,000 coins", "Req", 500000));
		SpentCoinList.Add (HashObject.Hash ("ID", 113, "Name", "SpentCoin 113", "Description", "Spent 1,000,000 coins", "Req", 1000000));
		
		SpentDiamondList = new List<Hashtable>();
		SpentDiamondList.Add (HashObject.Hash ("ID", 114, "Name", "SpentDiamond 114", "Description", "Spent 100 diamonds", "Req", 100));
		SpentDiamondList.Add (HashObject.Hash ("ID", 115, "Name", "SpentDiamond 115", "Description", "Spent 500 diamonds", "Req", 500));
		SpentDiamondList.Add (HashObject.Hash ("ID", 116, "Name", "SpentDiamond 116", "Description", "Spent 1,000 diamonds", "Req", 1000));
		SpentDiamondList.Add (HashObject.Hash ("ID", 117, "Name", "SpentDiamond 117", "Description", "Spent 2,000 diamonds", "Req", 2000));
		SpentDiamondList.Add (HashObject.Hash ("ID", 118, "Name", "SpentDiamond 118", "Description", "Spent 5,000 diamonds", "Req", 5000));
		
		UpgradeCountList = new List<Hashtable>();
		UpgradeCountList.Add (HashObject.Hash ("ID", 119, "Name", "UpgradeCount 119", "Description", "Upgrades 1 time", "Req", 1));
		UpgradeCountList.Add (HashObject.Hash ("ID", 120, "Name", "UpgradeCount 120", "Description", "Upgrades 10 time", "Req", 10));
		UpgradeCountList.Add (HashObject.Hash ("ID", 121, "Name", "UpgradeCount 121", "Description", "Upgrades 25 time", "Req", 25));
		UpgradeCountList.Add (HashObject.Hash ("ID", 122, "Name", "UpgradeCount 122", "Description", "Upgrades 45 time", "Req", 45));
		UpgradeCountList.Add (HashObject.Hash ("ID", 123, "Name", "UpgradeCount 123", "Description", "Upgrades 60 time", "Req", 60));
		
		MSPDLevelList = new List<Hashtable>();
		MSPDLevelList.Add (HashObject.Hash ("ID", 124, "Name", "MSPDLevel 124", "Description", "Character movement speed reach Lv2", "Req", 2));
		MSPDLevelList.Add (HashObject.Hash ("ID", 125, "Name", "MSPDLevel 125", "Description", "Character movement speed reach Lv3", "Req", 3));
		MSPDLevelList.Add (HashObject.Hash ("ID", 126, "Name", "MSPDLevel 126", "Description", "Character movement speed reach Lv4", "Req", 4));
		MSPDLevelList.Add (HashObject.Hash ("ID", 127, "Name", "MSPDLevel 127", "Description", "Character movement speed reach Lv5", "Req", 5));
		
		ASPDLevelList = new List<Hashtable>();
		ASPDLevelList.Add (HashObject.Hash ("ID", 128, "Name", "ASPDLevel 128", "Description", "Character action speed reach Lv2", "Req", 2));
		ASPDLevelList.Add (HashObject.Hash ("ID", 129, "Name", "ASPDLevel 129", "Description", "Character action speed reach Lv3", "Req", 3));
		ASPDLevelList.Add (HashObject.Hash ("ID", 130, "Name", "ASPDLevel 130", "Description", "Character action speed reach Lv4", "Req", 4));
		ASPDLevelList.Add (HashObject.Hash ("ID", 131, "Name", "ASPDLevel 131", "Description", "Character action speed reach Lv5", "Req", 5));
		
		//@ Kaizer: Rewards List
		
		RewardList = new List<Hashtable>();
		RewardList.Add (HashObject.Hash ("ID", 0, "RewardStat", "Coin", "RewardNum", 100, "Description", "100 coins"));
		RewardList.Add (HashObject.Hash ("ID", 1, "RewardStat", "Diamond", "RewardNum", 5, "Description", "5 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 2, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 3, "RewardStat", "Diamond", "RewardNum", 10, "Description", "10 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 4, "RewardStat", "Coin", "RewardNum", 5000, "Description", "5,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 5, "RewardStat", "Diamond", "RewardNum", 15, "Description", "15 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 6, "RewardStat", "Coin", "RewardNum", 10000, "Description", "10,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 7, "RewardStat", "Diamond", "RewardNum", 20, "Description", "20 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 8, "RewardStat", "Coin", "RewardNum", 50000, "Description", "50,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 9, "RewardStat", "Diamond", "RewardNum", 25, "Description", "25 diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 10, "RewardStat", "Diamond", "RewardNum", 5, "Description", "5 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 11, "RewardStat", "Diamond", "RewardNum", 10, "Description", "10 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 12, "RewardStat", "Diamond", "RewardNum", 15, "Description", "15 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 13, "RewardStat", "Diamond", "RewardNum", 20, "Description", "20 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 14, "RewardStat", "Diamond", "RewardNum", 25, "Description", "25 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 15, "RewardStat", "Diamond", "RewardNum", 30, "Description", "30 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 16, "RewardStat", "Diamond", "RewardNum", 35, "Description", "35 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 17, "RewardStat", "Diamond", "RewardNum", 40, "Description", "40 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 18, "RewardStat", "Diamond", "RewardNum", 45, "Description", "45 diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 19, "RewardStat", "Diamond", "RewardNum", 50, "Description", "50 diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 20, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 21, "RewardStat", "Coin", "RewardNum", 5000, "Description", "5,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 22, "RewardStat", "Coin", "RewardNum", 20000, "Description", "20,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 23, "RewardStat", "Coin", "RewardNum", 50000, "Description", "50,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 24, "RewardStat", "Coin", "RewardNum", 100000, "Description", "100,000 coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 25, "RewardStat", "Coin", "RewardNum", 700, "Description", "700 coins"));
		RewardList.Add (HashObject.Hash ("ID", 26, "RewardStat", "Coin", "RewardNum", 1400, "Description", "1,400 coins"));
		RewardList.Add (HashObject.Hash ("ID", 27, "RewardStat", "Coin", "RewardNum", 2100, "Description", "2,100 coins"));
		RewardList.Add (HashObject.Hash ("ID", 28, "RewardStat", "Coin", "RewardNum", 2800, "Description", "2,800 coins"));
		RewardList.Add (HashObject.Hash ("ID", 29, "RewardStat", "Coin", "RewardNum", 5600, "Description", "5,600 coins"));
		RewardList.Add (HashObject.Hash ("ID", 30, "RewardStat", "Coin", "RewardNum", 10000, "Description", "10,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 31, "RewardStat", "Coin", "RewardNum", 15000, "Description", "15,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 32, "RewardStat", "Coin", "RewardNum", 20000, "Description", "20,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 33, "RewardStat", "Coin", "RewardNum", 25000, "Description", "25,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 34, "RewardStat", "Coin", "RewardNum", 36400, "Description", "36,400 coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 35, "RewardStat", "Coin", "RewardNum", 20000, "Description", "20,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 36, "RewardStat", "Coin", "RewardNum", 30000, "Description", "30,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 37, "RewardStat", "Coin", "RewardNum", 40000, "Description", "40,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 38, "RewardStat", "Coin", "RewardNum", 50000, "Description", "50,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 39, "RewardStat", "Coin", "RewardNum", 60000, "Description", "60,000 coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 40, "RewardStat", "Coin", "RewardNum", 100, "Description", "100 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 41, "RewardStat", "Coin", "RewardNum", 250, "Description", "250 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 42, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 43, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 44, "RewardStat", "Coin", "RewardNum", 2500, "Description", "2,500 Coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 45, "RewardStat", "Coin", "RewardNum", 200, "Description", "200 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 46, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 47, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 48, "RewardStat", "Coin", "RewardNum", 2000, "Description", "2,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 49, "RewardStat", "Coin", "RewardNum", 5000, "Description", "5,000 Coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 50, "RewardStat", "Like", "RewardNum", 5, "Description", "5 Like"));
		RewardList.Add (HashObject.Hash ("ID", 51, "RewardStat", "Like", "RewardNum", 10, "Description", "10 Like"));
		RewardList.Add (HashObject.Hash ("ID", 52, "RewardStat", "Like", "RewardNum", 25, "Description", "25 Like"));
		RewardList.Add (HashObject.Hash ("ID", 53, "RewardStat", "Like", "RewardNum", 50, "Description", "50 Like"));
		RewardList.Add (HashObject.Hash ("ID", 54, "RewardStat", "Like", "RewardNum", 100, "Description", "100 Like"));
		
		RewardList.Add (HashObject.Hash ("ID", 55, "RewardStat", "Diamond", "RewardNum", 5, "Description", "5 Diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 56, "RewardStat", "Diamond", "RewardNum", 10, "Description", "10 Diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 57, "RewardStat", "Diamond", "RewardNum", 15, "Description", "15 Diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 58, "RewardStat", "Diamond", "RewardNum", 20, "Description", "20 Diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 59, "RewardStat", "Diamond", "RewardNum", 25, "Description", "25 Diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 60, "RewardStat", "Coin", "RewardNum", 100, "Description", "100 coins"));
		RewardList.Add (HashObject.Hash ("ID", 61, "RewardStat", "Coin", "RewardNum", 500, "Description", "100 coins"));
		RewardList.Add (HashObject.Hash ("ID", 62, "RewardStat", "Coin", "RewardNum", 2000, "Description", "100 coins"));
		RewardList.Add (HashObject.Hash ("ID", 63, "RewardStat", "Coin", "RewardNum", 5000, "Description", "100 coins"));
		RewardList.Add (HashObject.Hash ("ID", 64, "RewardStat", "Deco", "RewardNum", 17, "Description", "100 coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 65, "RewardStat", "Coin", "RewardNum", 100, "Description", "100 coins"));
		RewardList.Add (HashObject.Hash ("ID", 66, "RewardStat", "Coin", "RewardNum", 200, "Description", "200 coins"));
		RewardList.Add (HashObject.Hash ("ID", 67, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 coins"));
		RewardList.Add (HashObject.Hash ("ID", 68, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 69, "RewardStat", "Diamond", "RewardNum", 5, "Description", "5 Diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 70, "RewardStat", "Coin", "RewardNum", 100, "Description", "100 coins"));
		RewardList.Add (HashObject.Hash ("ID", 71, "RewardStat", "Coin", "RewardNum", 200, "Description", "200 coins"));
		RewardList.Add (HashObject.Hash ("ID", 72, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 coins"));
		RewardList.Add (HashObject.Hash ("ID", 73, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 74, "RewardStat", "Diamond", "RewardNum", 5, "Description", "5 Diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 75, "RewardStat", "Coin", "RewardNum", 100, "Description", "100 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 76, "RewardStat", "Coin", "RewardNum", 200, "Description", "200 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 77, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 78, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 79, "RewardStat", "Diamond", "RewardNum", 5, "Description", "5 Diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 80, "RewardStat", "Coin", "RewardNum", 100, "Description", "100 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 81, "RewardStat", "Coin", "RewardNum", 200, "Description", "200 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 82, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 83, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 84, "RewardStat", "Diamond", "RewardNum", 5, "Description", "5 Diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 85, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 86, "RewardStat", "Coin", "RewardNum", 1000, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 87, "RewardStat", "Coin", "RewardNum", 2000, "Description", "500 Coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 88, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 89, "RewardStat", "Coin", "RewardNum", 1000, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 90, "RewardStat", "Coin", "RewardNum", 2000, "Description", "500 Coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 91, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 92, "RewardStat", "Coin", "RewardNum", 1000, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 93, "RewardStat", "Coin", "RewardNum", 2000, "Description", "500 Coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 94, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 95, "RewardStat", "Coin", "RewardNum", 1000, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 96, "RewardStat", "Coin", "RewardNum", 2000, "Description", "500 Coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 97, "RewardStat", "Coin", "RewardNum", 500, "Description", "500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 98, "RewardStat", "Coin", "RewardNum", 1000, "Description", "1000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 99, "RewardStat", "Coin", "RewardNum", 5000, "Description", "5000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 100, "RewardStat", "Coin", "RewardNum", 10000, "Description", "10000 Coins"));
		
		RewardList.Add (HashObject.Hash ("ID", 101, "RewardStat", "Coin", "RewardNum", 200, "Description", "200 coins"));
		RewardList.Add (HashObject.Hash ("ID", 102, "RewardStat", "Coin", "RewardNum", 2000, "Description", "2,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 103, "RewardStat", "Coin", "RewardNum", 12000, "Description", "12,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 104, "RewardStat", "Coin", "RewardNum", 14000, "Description", "14,000 coins%"));
		RewardList.Add (HashObject.Hash ("ID", 105, "RewardStat", "Coin", "RewardNum", 15000, "Description", "15,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 106, "RewardStat", "Coin", "RewardNum", 20000, "Description", "20,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 107, "RewardStat", "Coin", "RewardNum", 30000, "Description", "30,000 coins"));
		RewardList.Add (HashObject.Hash ("ID", 108, "RewardStat", "Coin", "RewardNum", 40000, "Description", "40,000"));
		
		RewardList.Add (HashObject.Hash ("ID", 109, "RewardStat", "Coin", "RewardNum", 250, "Description", "250 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 110, "RewardStat", "Coin", "RewardNum", 2500, "Description", "2,500 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 111, "RewardStat", "Coin", "RewardNum", 5000, "Description", "5,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 112, "RewardStat", "Coin", "RewardNum", 25000, "Description", "25,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 113, "RewardStat", "Coin", "RewardNum", 35000, "Description", "35,000"));
		
		RewardList.Add (HashObject.Hash ("ID", 114, "RewardStat", "Diamond", "RewardNum", 5, "Description", "5 Diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 115, "RewardStat", "Diamond", "RewardNum", 25, "Description", "25 Diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 116, "RewardStat", "Diamond", "RewardNum", 50, "Description", "50 Diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 117, "RewardStat", "Diamond", "RewardNum", 100, "Description", "100 Diamonds"));
		RewardList.Add (HashObject.Hash ("ID", 118, "RewardStat", "Diamond", "RewardNum", 150, "Description", "150 Diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 119, "RewardStat", "Like", "RewardNum", 5, "Description", "5 Like"));
		RewardList.Add (HashObject.Hash ("ID", 120, "RewardStat", "Like", "RewardNum", 10, "Description", "10 Like"));
		RewardList.Add (HashObject.Hash ("ID", 121, "RewardStat", "Like", "RewardNum", 20, "Description", "20 Like"));
		RewardList.Add (HashObject.Hash ("ID", 122, "RewardStat", "Like", "RewardNum", 25, "Description", "25 Like"));
		RewardList.Add (HashObject.Hash ("ID", 123, "RewardStat", "Like", "RewardNum", 50, "Description", "50 Like"));
		
		RewardList.Add (HashObject.Hash ("ID", 124, "RewardStat", "Coin", "RewardNum", 2000, "Description", "2,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 125, "RewardStat", "Like", "RewardNum", 20, "Description", "20 Like"));
		RewardList.Add (HashObject.Hash ("ID", 126, "RewardStat", "Coin", "RewardNum", 10000, "Description", "10,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 127, "RewardStat", "Diamond", "RewardNum", 10, "Description", "10 Diamonds"));
		
		RewardList.Add (HashObject.Hash ("ID", 128, "RewardStat", "Coin", "RewardNum", 2000, "Description", "2,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 129, "RewardStat", "Like", "RewardNum", 20, "Description", "20 Like"));
		RewardList.Add (HashObject.Hash ("ID", 130, "RewardStat", "Coin", "RewardNum", 10000, "Description", "10,000 Coins"));
		RewardList.Add (HashObject.Hash ("ID", 131, "RewardStat", "Diamond", "RewardNum", 10, "Description", "10 Diamonds"));
		
		InvokeRepeating("Check", 5f,1);
	}
	//@ Kaizer: Claim Reward Checking & Update
	
	public void ClaimRewardByID(int ID)
	{
		if(Main.MyPlayerAtr.ReturnAchievementByID(ID) == 1)
		{
			Hashtable TemHash = GetRewardByID(ID);
			switch((string)TemHash["RewardStat"])
			{
				case "Coin":
				{
					Main.MyPlayerAtr.AddCoin ((int)TemHash["RewardNum"]);
					Main.MyPlayerAtr.AddTotalCoin((int)TemHash["RewardNum"]);
				}break;
				case "Like":
				{
					Main.MyPlayerAtr.AddLike ((int)TemHash["RewardNum"]);
				}break;
				case "Diamond":
				{
					Main.MyPlayerAtr.AddDiamond ((int)TemHash["RewardNum"]);
					Main.MyPlayerAtr.AddTotalDiamond((int)TemHash["RewardNum"]);
				}break;
				case "Deco":
				{
					Main.MyPlayerAtr.AddExtraDeco((int)TemHash["RewardNum"]);
					
				}break;
				default:
				{
					
				}break;
			}	
			Main.MyPlayerAtr.UpdateAchievementList(ID, 2);
		}
	}
	
	//@ Kaizer: Achievement Checking MainFrame
	public void UpdateHotelRank()
	{
		int GetCoin = Main.MyPlayerAtr.ReturnTotalCoin ();
		int GetLike = Main.MyPlayerAtr.ReturnLike();
		for(int a = 0;a<HotelRankCoinReq.Count;a++)
		{
			if(GetCoin >= HotelRankCoinReq[a] && GetLike >= HotelRankLikeReq[a])
			{
				if(Main.MyPlayerAtr.ReturnHotelRank() < (a+1))
				{
					Main.MyPlayerAtr.AddHotelRank(1);	
				}
			}
		}
		Debug.Log (Main.MyPlayerAtr.ReturnHotelRank());
	}
	
	private void Check()
	{
		CheckLikeList();
		CheckTotalCoinList();
		CheckTotalDiamondList();
		CheckDayList();
		CheckHotelRankList();
		CheckCountOf3StarList();
		CheckCountOf4StarList();
		CheckCountOf5StarList();
		CheckCountOf6StarList();
		CheckRunawayCountList();
		CheckTDisplayCountList();
		CheckBarCountList();
		CheckFoodCountList();
		CheckCashierCountList();
		CheckQueueUpSlotList();
		CheckFoodSlotList();
		CheckTDisplaySlotList();
		CheckBarSlotList();
		CheckCashierLevelList();
		CheckHelperList();
		CheckSpentCoinList();
		CheckSpentDiamondList();
		CheckUpgradeCountList();
		CheckMSPDLevelList();
		CheckASPDLevelList();
		
	}
	private void CheckASPDLevelList()
	{
		for(int a = 0;a<ASPDLevelList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnActionSpeedLevel() >= (int)ASPDLevelList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)ASPDLevelList[a]["Req"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)ASPDLevelList[a]["ID"], 1);
				}
			}
		}	
	}
	private void CheckMSPDLevelList()
	{
		for(int a = 0;a<MSPDLevelList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnMovementSpeedLevel() >= (int)MSPDLevelList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)MSPDLevelList[a]["Req"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)MSPDLevelList[a]["ID"], 1);
				}
			}
		}
	}
	private void CheckUpgradeCountList()
	{
		for(int a= 0;a<UpgradeCountList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnUpgradeCount() >= (int)UpgradeCountList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)UpgradeCountList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)UpgradeCountList[a]["ID"], 1);
				}
			}
		}
	}
	private void CheckSpentDiamondList()
	{
		for(int a = 0;a<SpentDiamondList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnSpentDiamond() >= (int)SpentDiamondList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)SpentDiamondList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)SpentDiamondList[a]["ID"], 1);	
				}
			}
		}
	}
	private void CheckSpentCoinList()
	{
		for(int a = 0;a<SpentCoinList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnSpentCoin() >= (int)SpentCoinList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)SpentCoinList[a]["ID"]) ==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)SpentCoinList[a]["ID"], 1);
				}
			}
		}
	}
	private void CheckHelperList()
	{
		List<int> TemList = Main.MyPlayerAtr.ReturnHelperFull();
		int TemInt = 0;
		for(int b = 0;b<TemList.Count;b++)
		{
			if(TemList[b] <0)
			{
				TemInt++;	
			}
		}
		for(int a = 0;a<HelperList.Count;a++)
		{
			if(TemInt >= (int)HelperList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)HelperList[a]["ID"]) ==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)HelperList[a]["ID"], 1);	
				}
			}
		}
	}
	private void CheckCashierLevelList()
	{
		for(int a = 0;a<CashierLevelList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnCashierLevel() >= (int)CashierLevelList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)CashierLevelList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)CashierLevelList[a]["ID"], 1);	
				}
			}
		}
	}
	private void CheckBarSlotList()
	{
		for(int a = 0;a<BarSlotList.Count;a++)
		{
			List<int> TemList = Main.MyPlayerAtr.ReturnBarLevelFull();
			if(a ==0)
			{
				int TemInt = 0;
				for(int b = 0;b<TemList.Count;b++)
				{
					if(TemList[b] >0)
					{
						TemInt++;	
					}
				}
				if(TemInt >=(int)BarSlotList[a]["Req"] && Main.MyPlayerAtr.ReturnAchievementByID((int)BarSlotList[a]["ID"])==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)BarSlotList[a]["ID"], 1);	
				}
			}
			else
			{
				bool Flag = false;
				for(int c = 0;c<TemList.Count;c++)
				{
					if(TemList[c] >= (int)BarSlotList[a]["Req"])
					{
						Flag = true;
					}
				}
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)BarSlotList[a]["ID"]) ==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)BarSlotList[a]["ID"], 1);	
				}
			}
		}	
	}
	private void CheckTDisplaySlotList()
	{
		for(int a = 0;a<TDisplaySlotList.Count;a++)
		{
			List<int> TemList = Main.MyPlayerAtr.ReturnTDisplayLevelFull();
			if(a ==0)
			{
				int TemInt = 0;
				for(int b = 0;b<TemList.Count;b++)
				{
					if(TemList[b] >0)
					{
						TemInt++;	
					}
				}
				if(TemInt >=(int)TDisplaySlotList[a]["Req"] && Main.MyPlayerAtr.ReturnAchievementByID((int)TDisplaySlotList[a]["ID"])==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)TDisplaySlotList[a]["ID"], 1);	
				}
			}
			else
			{
				bool Flag = false;
				for(int c = 0;c<TemList.Count;c++)
				{
					if(TemList[c] >= (int)TDisplaySlotList[a]["Req"])
					{
						Flag = true;
					}
				}
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)TDisplaySlotList[a]["ID"]) ==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)TDisplaySlotList[a]["ID"], 1);	
				}
			}
		}	
	}
	private void CheckFoodSlotList()
	{
		for(int a = 0;a<FoodSlotList.Count;a++)
		{
			List<int> TemList = Main.MyPlayerAtr.ReturnFoodLevelFull();
			if(a ==0)
			{
				int TemInt = 0;
				for(int b = 0;b<TemList.Count;b++)
				{
					if(TemList[b] >0)
					{
						TemInt++;	
					}
				}
				if(TemInt >=(int)FoodSlotList[a]["Req"] && Main.MyPlayerAtr.ReturnAchievementByID((int)FoodSlotList[a]["ID"])==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)FoodSlotList[a]["ID"], 1);	
				}
			}
			else
			{
				bool Flag = false;
				for(int c = 0;c<TemList.Count;c++)
				{
					if(TemList[c] >= (int)FoodSlotList[a]["Req"])
					{
						Flag = true;
					}
				}
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)FoodSlotList[a]["ID"]) ==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)FoodSlotList[a]["ID"], 1);	
				}
			}
		}	
	}
	
	private void CheckQueueUpSlotList()
	{
		for(int a = 0;a<QueueUpSlotList.Count;a++)
		{
			List<int> TemList = Main.MyPlayerAtr.ReturnQueueUpLevelFull();
			if(a ==0)
			{
				int TemInt = 0;
				for(int b = 0;b<TemList.Count;b++)
				{
					if(TemList[b] >0)
					{
						TemInt++;	
					}
				}
				if(TemInt >=(int)QueueUpSlotList[a]["Req"] && Main.MyPlayerAtr.ReturnAchievementByID((int)QueueUpSlotList[a]["ID"])==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)QueueUpSlotList[a]["ID"], 1);	
				}
			}
			else
			{
				bool Flag = false;
				for(int c = 0;c<TemList.Count;c++)
				{
					if(TemList[c] >= (int)QueueUpSlotList[a]["Req"])
					{
						Flag = true;
					}
				}
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)QueueUpSlotList[a]["ID"]) ==0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)QueueUpSlotList[a]["ID"], 1);	
				}
			}
		}
	}
	private void CheckCashierCountList()
	{
		for(int a = 0;a<CashierCountList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnCashierCount() >= (int)CashierCountList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)CashierCountList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)CashierCountList[a]["ID"],1);	
				}
			}
		}	
	}
	private void CheckFoodCountList()
	{
		for(int a = 0;a<FoodCountList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnFoodCount() >= (int)FoodCountList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)FoodCountList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)FoodCountList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckBarCountList()
	{
		for(int a = 0;a<BarCountList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnBarCount() >= (int)BarCountList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)BarCountList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)BarCountList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckTDisplayCountList()
	{
		for(int a = 0;a<TDisplayCountList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnTDisplayCount() >= (int)TDisplayCountList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)TDisplayCountList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)TDisplayCountList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckRunawayCountList()
	{
		for(int a = 0;a<RunawayCountList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnRunawayCount() >= (int)RunawayCountList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)RunawayCountList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)RunawayCountList[a]["ID"],1);	
				}
			}
		}	
	}
	private void CheckCountOf6StarList()
	{
		for(int a = 0;a<CountOf6StarList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnCountOf6Star() >= (int)CountOf6StarList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)CountOf6StarList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)CountOf6StarList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckCountOf5StarList()
	{
		for(int a = 0;a<CountOf5StarList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnCountOf5Star() >= (int)CountOf5StarList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)CountOf5StarList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)CountOf5StarList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckCountOf4StarList()
	{
		for(int a = 0;a<CountOf4StarList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnCountOf4Star() >= (int)CountOf4StarList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)CountOf4StarList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)CountOf4StarList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckCountOf3StarList()
	{
		for(int a = 0;a<CountOf3StarList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnCountOf3Star() >= (int)CountOf3StarList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)CountOf3StarList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)CountOf3StarList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckHotelRankList()
	{
		for(int a = 0;a<HotelRankList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnHotelRank() >= (int)HotelRankList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)HotelRankList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)HotelRankList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckDayList()
	{
		for(int a = 0;a<DayList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnDay() >= (int)DayList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)DayList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)DayList[a]["ID"],1);	
				}
			}
		}		
	}
	private void CheckTotalDiamondList()
	{
		for(int a = 0;a<TotalDiamondList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnTotalDiamond() >= (int)TotalDiamondList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)TotalDiamondList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)TotalDiamondList[a]["ID"],1);	
				}
			}
		}	
	}
	private void CheckTotalCoinList()
	{
		for(int a = 0;a<TotalCoinList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnTotalCoin() >= (int)TotalCoinList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)TotalCoinList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)TotalCoinList[a]["ID"],1);	
				}
			}
		}
	}
	private void CheckLikeList()
	{
		for(int a = 0;a<LikeList.Count;a++)
		{
			if(Main.MyPlayerAtr.ReturnLike () >= (int)LikeList[a]["Req"])
			{
				if(Main.MyPlayerAtr.ReturnAchievementByID((int)LikeList[a]["ID"]) == 0)
				{
					Main.MyPlayerAtr.UpdateAchievementList((int)LikeList[a]["ID"],1);
				}
			}
		}
	}
	
	
	//@ Kaizer: Single Ach Return
	
	public Hashtable GetRewardByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<RewardList.Count;a++)
		{
			if((int)RewardList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)RewardList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetAchievementByID(int ID)
	{
		Hashtable MyHash = null;
		List<Hashtable> MyHashList = ReturnFullAchievement();
		for(int a = 0;a<MyHashList.Count;a++)
		{
			if((int)MyHashList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)MyHashList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetASPDLevelListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<ASPDLevelList.Count;a++)
		{
			if((int)ASPDLevelList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)ASPDLevelList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetMSPDLevelListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<MSPDLevelList.Count;a++)
		{
			if((int)MSPDLevelList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)MSPDLevelList[a].Clone ();
			}
		}
		return MyHash;
	}
	
	public Hashtable GetUpgradeCountListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<UpgradeCountList.Count;a++)
		{
			if((int)UpgradeCountList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)UpgradeCountList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetSpentDiamondListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<SpentDiamondList.Count;a++)
		{
			if((int)SpentDiamondList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)SpentDiamondList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetSpentCointListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<SpentCoinList.Count;a++)
		{
			if((int)SpentCoinList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)SpentCoinList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetHelperListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<HelperList.Count;a++)
		{
			if((int)HelperList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)HelperList[a].Clone ();	
			}
		}
		return MyHash;
	}	
	
	public Hashtable GetCashierLevelListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<CashierLevelList.Count;a++)
		{
			if((int)CashierLevelList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)CashierLevelList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetBarSlotListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<BarSlotList.Count;a++)
		{
			if((int)BarSlotList[a]["ID"] == ID)		
			{
				MyHash = (Hashtable)BarSlotList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetTDisplayListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<TDisplaySlotList.Count;a++)
		{
			if((int)TDisplaySlotList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)TDisplaySlotList[a].Clone ();	
			}
		}
		return MyHash;
	}
	public Hashtable GetFoodSlotListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a <FoodSlotList.Count;a++)
		{
			if((int)FoodSlotList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)FoodSlotList[a].Clone();
			}
		}
		return MyHash;
	}
	
	public Hashtable GetQueueUpSlotListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0; a <QueueUpSlotList.Count;a++)
		{
			if((int)QueueUpSlotList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)QueueUpSlotList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetCashierCountListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<CashierCountList.Count;a++)
		{
			if((int)CashierCountList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)CashierCountList[a].Clone();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetFoodCountListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<FoodCountList.Count;a++)
		{
			if((int)FoodCountList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)FoodCountList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetBarCountListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0; a<BarCountList.Count; a++)
		{
			if((int)BarCountList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)BarCountList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetTDisplayCountListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<TDisplayCountList.Count;a++)
		{
			if((int)TDisplayCountList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)TDisplayCountList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetRunawayCountListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<RunawayCountList.Count;a++)
		{
			if((int)RunawayCountList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)RunawayCountList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetCountOf6StarListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<CountOf6StarList.Count;a++)
		{
			if((int)CountOf6StarList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)CountOf6StarList[a].Clone ();	
			}
		}	
		return MyHash;
	}
	
	public Hashtable GetCountOf5StarListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<CountOf5StarList.Count;a++)
		{
			if((int)CountOf5StarList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)CountOf5StarList[a].Clone ();	
			}
		}	
		return MyHash;
	}
	
	public Hashtable GetCountOf4StarListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<CountOf4StarList.Count;a++)
		{
			if((int)CountOf4StarList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)CountOf4StarList[a].Clone ();	
			}
		}	
		return MyHash;
	}
	
	public Hashtable GetCountOf3StarListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<CountOf3StarList.Count;a++)
		{
			if((int)CountOf3StarList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)CountOf3StarList[a].Clone ();	
			}
		}	
		return MyHash;
	}
	
	public Hashtable GetHotelRankListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<HotelRankList.Count;a++)
		{
			if((int)HotelRankList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)HotelRankList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetDayListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<DayList.Count;a++)
		{
			if((int)DayList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)DayList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetTotalDiamondListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<TotalDiamondList.Count;a++)
		{
			if((int)TotalDiamondList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)TotalDiamondList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	public Hashtable GetTotalCoinListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0; a<TotalCoinList.Count;a++)
		{
			if((int)TotalCoinList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)TotalCoinList[a].Clone ();
			}
		}
		return MyHash;
	}
	
	public Hashtable GetLikeListByID(int ID)
	{
		Hashtable MyHash = null;
		for(int a = 0;a<LikeList.Count;a++)
		{
			if((int)LikeList[a]["ID"] == ID)
			{
				MyHash = (Hashtable)LikeList[a].Clone ();	
			}
		}
		return MyHash;
	}
	
	//@ Kaizer: Full list Return
	public List<Hashtable> ReturnFullReward()
	{
		List<Hashtable> FullList = new List<Hashtable>();
		for(int a = 0;a<RewardList.Count;a++)
		{
			FullList.Add ((Hashtable)RewardList[a].Clone ());	
		}
		return FullList;
	}
	
	public List<Hashtable> ReturnFullAchievement()
	{
		List<Hashtable> FullList = new List<Hashtable>();
		for(int a = 0;a <LikeList.Count;a++)
		{
			FullList.Add((Hashtable)LikeList[a].Clone ());	
		}
		for(int b = 0;b <TotalCoinList.Count;b++)
		{
			FullList.Add ((Hashtable)TotalCoinList[b].Clone ());	
		}
		for(int c = 0;c<TotalDiamondList.Count;c++)
		{
			FullList.Add ((Hashtable)TotalDiamondList[c].Clone ());	
		}
		for(int d = 0;d<DayList.Count;d++)
		{
			FullList.Add ((Hashtable)DayList[d].Clone ());	
		}
		for(int e = 0;e<HotelRankList.Count;e++)
		{
			FullList.Add((Hashtable)HotelRankList[e].Clone ());	
		}
		for(int f = 0;f<CountOf3StarList.Count;f++)
		{
			FullList.Add((Hashtable)CountOf3StarList[f].Clone ());	
		}
		for(int g =0;g<CountOf4StarList.Count;g++)
		{
			FullList.Add((Hashtable)CountOf4StarList[g].Clone ());	
		}
		for(int h = 0;h<CountOf5StarList.Count;h++)
		{
			FullList.Add((Hashtable)CountOf5StarList[h].Clone ());	
		}
		for(int i = 0;i<CountOf6StarList.Count;i++)
		{
			FullList.Add((Hashtable)CountOf6StarList[i].Clone ());	
		}
		for(int j = 0;j<RunawayCountList.Count;j++)
		{
			FullList.Add((Hashtable)RunawayCountList[j].Clone ());	
		}
		for(int k = 0;k<TDisplayCountList.Count;k++)
		{
			FullList.Add((Hashtable)TDisplayCountList[k].Clone ());
		}
		for(int l = 0;l<BarCountList.Count;l++)
		{
			FullList.Add((Hashtable)BarCountList[l].Clone ());	
		}
		for(int m = 0;m<FoodCountList.Count;m++)
		{
			FullList.Add ((Hashtable)FoodCountList[m].Clone ());	
		}
		for(int n = 0;n<CashierCountList.Count;n++)
		{
			FullList.Add((Hashtable)CashierCountList[n].Clone ());	
		}
		for(int o = 0;o<QueueUpSlotList.Count;o++)
		{
			FullList.Add ((Hashtable)QueueUpSlotList[o].Clone ());	
		}
		for(int p = 0;p<FoodSlotList.Count;p++)
		{
			FullList.Add((Hashtable)FoodSlotList[p].Clone ());	
		}
		for(int q = 0;q<TDisplaySlotList.Count;q++)
		{
			FullList.Add ((Hashtable)TDisplaySlotList[q].Clone ());	
		}
		for(int r = 0;r<BarSlotList.Count;r++)
		{
			FullList.Add((Hashtable)BarSlotList[r].Clone ());	
		}
		for(int s = 0;s<CashierLevelList.Count;s++)
		{
			FullList.Add((Hashtable)CashierLevelList[s].Clone ());	
		}
		for(int t = 0;t<HelperList.Count;t++)
		{
			FullList.Add((Hashtable)HelperList[t].Clone ());	
		}
		for(int u = 0;u<SpentCoinList.Count;u++)
		{
			FullList.Add((Hashtable)SpentCoinList[u].Clone ());	
		}
		for(int v = 0;v<SpentDiamondList.Count;v++)
		{
			FullList.Add ((Hashtable)SpentDiamondList[v].Clone ());	
		}
		for(int w = 0;w<UpgradeCountList.Count;w++)
		{
			FullList.Add((Hashtable)UpgradeCountList[w].Clone ());	
		}
		for(int x = 0;x<MSPDLevelList.Count;x++)
		{
			FullList.Add ((Hashtable)MSPDLevelList[x].Clone ());	
		}
		for(int y = 0;y<ASPDLevelList.Count;y++)
		{
			FullList.Add ((Hashtable)ASPDLevelList[y].Clone ());	
		}
		
		return FullList;
	}
}


