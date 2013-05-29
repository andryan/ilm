using UnityEngine;
using System.Collections;

public class ItemConfig : MonoBehaviour {
	
	public Main Parent = null;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	private void OnGUI()
	{	
		if(GUI.Button(new Rect(0, 0, 100, 25), "Skip 1 Day"))
		{
			KillCustomer();
			Cleaning();
		}
		if(GUI.Button(new Rect(0, 25, 100, 25), "Jump 5 Days"))
		{
			KillCustomer();
			Parent.ClearGameScreen();
			Parent.ShowGameScreen();
			Main.MyPlayerAtr.AddDay (5);
			Main.MySpawn.normalCount = 0;
			Main.MySpawn.vipCount = 0;
			Main.MySpawn.shortTCount = 0;
			Main.MySpawn.casualCount = 0;
		
			Main.MySpawn.myNormalCount = 0;
			Main.MySpawn.myVipCount = 0;
			Main.MySpawn.myShortTCount = 0;
			Main.MySpawn.myCasualCount = 0;
		
			Main.MySpawn.totalCustomer = 0;
			Main.MySpawn.tempTotalCust = 0;
		}
		
		if(GUI.Button(new Rect(0, 50, 100, 25), "Jump 10 Days"))
		{
			KillCustomer();
			Parent.ClearGameScreen();
			Parent.ShowGameScreen();
			Main.MyPlayerAtr.AddDay (10);
			Main.MySpawn.normalCount = 0;
			Main.MySpawn.vipCount = 0;
			Main.MySpawn.shortTCount = 0;
			Main.MySpawn.casualCount = 0;
		
			Main.MySpawn.myNormalCount = 0;
			Main.MySpawn.myVipCount = 0;
			Main.MySpawn.myShortTCount = 0;
			Main.MySpawn.myCasualCount = 0;
		
			Main.MySpawn.totalCustomer = 0;
			Main.MySpawn.tempTotalCust = 0;
		}
		if(GUI.Button (new Rect(0, 75, 100, 25), "Rewind"))
		{
			Main.MyTile.TotalTime -= 60;
		}
		
		if(GUI.Button (new Rect(0, 100, 100, 25), "Fast Forward"))
		{
			Main.MyTile.TotalTime += 60;
		}
		
	}
	private void KillCustomer()
	{
		Main.MyCustomer.destroyAllCustomer();
		for(int i=0;i<Main.MyCustomer.customerList.Count;i++)
		{
			CustomerAtr MyCA = (CustomerAtr)Main.MyCustomer.customerList[i].GetComponent("CustomerAtr");
			
			MyCA.ActionList = null;
			MyCA.ActionCount = null;
			MyCA.TypeList = null;
			MyCA.TypeRate = null;
			MyCA.TipsList = null;
			MyCA.CoinList = null;
			MyCA.ActionTypeList = null;
			MyCA.STList = null;
			MyCA.WTList = null;
			MyCA.LRList = null;
			MyCA.STRateList = null;
			MyCA.STEffectList = null;
			MyCA.DestroyIcon ();
		}
	}
	
	private void Cleaning()
	{
		Parent.ClearGameScreen();
		Parent.ShowGameScreen();
		Main.MyPlayerAtr.AddDay (1);
		
		Main.MySpawn.normalCount = 0;
		Main.MySpawn.vipCount = 0;
		Main.MySpawn.shortTCount = 0;
		Main.MySpawn.casualCount = 0;
		
		Main.MySpawn.myNormalCount = 0;
		Main.MySpawn.myVipCount = 0;
		Main.MySpawn.myShortTCount = 0;
		Main.MySpawn.myCasualCount = 0;
		
		Main.MySpawn.totalCustomer = 0;
		Main.MySpawn.tempTotalCust = 0;
	}
	
}