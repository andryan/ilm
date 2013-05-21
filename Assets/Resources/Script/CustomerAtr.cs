using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class CustomerAtr : MonoBehaviour 
{
	private string Type = "";
	public int TypeID;
	private float TipsRate = 0.0f;
	private float Satisfaction = 0.0f;
	private float CurrentWaitingTime = 0.0f;
	public float WaitingTime = 0.0f;
	public float minusTime = 0.0f;
	
	private float LikeRate = 0.0f;
	private int Coin = 0;
	public List<string> ActionList = null;
	public List<int> ActionCount = null;
	public List<string> TypeList = null;
	public List<int> TypeRate = null;
	public List<Hashtable> TipsList = null;
	public List<int> CoinList = null;
	public List<string> ActionTypeList = null;
	public List<int> STList = null;
	public List<int> WTList = null;
	public List<float> LRList = null;
	public List<int> STRateList = null;
	public List<float> STEffectList = null;
	
	private GameObject Emoticon = null;
	private Material EmoticonImg = null;
	private Vector3 StoredPost;
	
	private float TemStationWT = 0f;
	
	private string CurrentStation = "";
	
	private bool ObtainLike = false;
	
	private Vector3 StoredScale;
	private int ScaleFactor = 1;
	
	public float disappearIcon = 0;
	
	public int normalAction = 0;
	public int VIPAction = 0;
	public int shortTAction = 0;
	public int casualAction = 0;
	
	private void Start()
	{
		Init();	
		Debug.Log (StoredPost);
	}
	private void Init()
	{
		normalAction = 4;
		VIPAction = 6;
		shortTAction = 4;
		casualAction = 3;
		
		TypeList = new List<string>(new string[]{"Normal","VIP","ShortT","Casual"});
		TypeRate = new List<int>(new int[]{40,10,25,25});
		ActionTypeList = new List<string>(new string[]{"nF","nB","nTD"});
		ActionCount = new List<int>(new int[]{normalAction,VIPAction,shortTAction,casualAction});
		CoinList = new List<int>(new int[]{50,100,60,40});
		STList = new List<int>(new int[]{2,2,2,3});
		WTList = new List<int>(new int[]{30,30,20,40});
		LRList = new List<float>(new float[]{0f,0f,0f,0f});
		STRateList = new List<int>(new int[]{15,15,15,15,40});
		STEffectList = new List<float>(new float[]{0.2f,0.4f,0.6f,0.8f,1f});
		TipsList = new List<Hashtable>();
		TipsList.Add (HashObject.Hash("Star",2,"TR",-0.2f));
		TipsList.Add (HashObject.Hash("Star",3,"TR",0.0f));
		TipsList.Add (HashObject.Hash("Star",4,"TR",+0.2f));
		TipsList.Add (HashObject.Hash("Star",5,"TR",+0.4f));
		TipsList.Add (HashObject.Hash("Star",6,"TR",+0.6f));
		
		disappearIcon = 10f;
		
		ActionList = new List<string>();
		
		GetCustomerATR(Main.MyPlayerAtr.ReturnDayType ());
	}
	//@Kaizer: EnterFrame
	
	private void EnterFrame()
	{
		CurrentWaitingTime --;
		//print ("CurrentWaitingTime"+CurrentWaitingTime);
		
		if(CurrentWaitingTime == 0)
		{
			Main.MyCustomer.runAway(this.gameObject);
			Runaway ();
			CancelInvoke("EnterFrame");	
		}
	}
	
	//@Kaizer: E&E randomized Customer ATR
	private void GetCustomerATR(string DayType)
	{
		GetType (DayType);
		GetInitSatisfaction();
		GetInitTipsRate();
		GetInitLikeRate();
		GetInitActionList();
		//GetWaitingTime();
	}
	private void GetInitActionList()
	{
		for(int a = 0;a<ActionCount[TypeID];a++)
		{
			if(a == 0)
			{
				ActionList.Add ("nQ");	
			}
			else if (a == ActionCount[TypeID]-1)
			{
				ActionList.Add ("nC");	
			}
			else
			{
				int StoreInt = Random.Range (0,3);
				ActionList.Add (ActionTypeList[StoreInt]);
			}
		}
		for(int b = 0;b<ActionList.Count;b++)
		{
			Debug.Log ("Action"+b+" "+ActionList[b]);	
		}
	}
	private void GetInitLikeRate()
	{
		LikeRate = LRList[TypeID] + Main.MyPlayerAtr.ReturnGlobalLR ();	
		Debug.Log ("LikeRate "+LikeRate);
	}
	private void GetInitTipsRate()
	{
		TipsRate = Main.MyPlayerAtr.ReturnGlobalTR ();	
		Debug.Log ("TipsRate "+TipsRate);
	}
	public void GetWaitingTime(float StationWT = 0f)
	{
		WaitingTime = (int)((float)WTList[TypeID]*(1+Main.MyPlayerAtr.ReturnGlobalWT ()+StationWT) - minusTime);
		
		CurrentWaitingTime = WaitingTime;
		TemStationWT = StationWT;
		InvokeRepeating ("EnterFrame",0f,1f);
		Debug.Log ("WaitingTime "+WaitingTime);
	}
	private void GetCurStationWT()
	{
		WaitingTime = (int)((float)WTList[TypeID]*(1+Main.MyPlayerAtr.ReturnGlobalWT ()+TemStationWT) - minusTime);
		
		CurrentWaitingTime = WaitingTime;
		InvokeRepeating ("EnterFrame",0f,1f);
		Debug.Log ("WaitingTime "+WaitingTime);
	}
	private void GetInitSatisfaction()
	{
		Satisfaction = 	STList[TypeID] + Main.MyPlayerAtr.ReturnGlobalST ();
		Debug.Log ("ST "+Satisfaction);
	}
	private void GetType(string DayType)
	{
		if(DayType == "Bonus")
		{
			TypeID = 1;
			
		}
		else
		{
			int StoreInt = 0;
			int CatchInt = Random.Range (0,100);
			for(int a = 0;a<TypeRate.Count;a++)
			{
				StoreInt += TypeRate[a];
//				if(CatchInt <StoreInt)
//				{
//					TypeID = a;
//					break;
//				}
			}

		}
		
		Type = TypeList[TypeID];
		Debug.Log ("Type "+Type);
	}
	
	//@Kaizer: Data Update
	public void StartQueueUp(Hashtable Effect)
	{
		CurrentStation = "nQ";
		ActionList.RemoveAt (0);
		Hashtable TemHash = (Hashtable)Effect.Clone ();
		
		if(TemHash.ContainsKey("WaitingTime"))
		{
			GetWaitingTime((float)TemHash["WaitingTime"]);				
		}
		if(TemHash.ContainsKey("LikeRate"))
		{
			AddLR ((float)TemHash["LikeRate"]);	
		}
		if(TemHash.ContainsKey("Satisfaction"))
		{
			AddST((float)TemHash["Satisfaction"]);	
		}
		if(TemHash.ContainsKey("TipsRate"))
		{
			AddTR ((float)TemHash["TipsRate"]);	
		}
		SpawnIcon (ActionList[0]);
	}
	public void Runaway()
	{
		Main.MyResultCal.AddRunawayCount(1);	
	}
	public void Pause()
	{
		CancelInvoke("EnterFrame");	
	}
	public void Resume()
	{
		InvokeRepeating("EnterFrame",0f,1f);	
	}
	public void AssignStation(string Station, Hashtable Effect)
	{
		CancelInvoke("EnterFrame");
		CurrentStation = Station;
		
		if(ActionList != null && ActionList.Count > 0)
		{
			if(CurrentStation == ActionList[0])
			{
				Hashtable TemHash = (Hashtable)Effect.Clone ();
			
				if(TemHash.ContainsKey("WaitingTime"))
				{
					GetWaitingTime((float)TemHash["WaitingTime"]);	
				}
				if(TemHash.ContainsKey("LikeRate"))
				{
					AddLR ((float)TemHash["LikeRate"]);	
				}
				if(TemHash.ContainsKey("Satisfaction"))
				{
					AddST((float)TemHash["Satisfaction"]);	
				}
				if(TemHash.ContainsKey("TipsRate"))
				{
					AddTR ((float)TemHash["TipsRate"]);	
				}
				if(CurrentStation == "nC")
				{
					//SpawnIcon ("nC");	
					SpawnIcon ("nC",HashObject.Hash ("Post", new Vector3(140,-345,this.gameObject.transform.localPosition.z)));
				}
				else
				{
					SpawnIcon ("Serve");	
				}
				
			}
			else
			{
				Runaway ();
			}	
		}
		
		
	}
	public void AddCoin(int Add = 0)
	{
		int TemCoin = 0;
		if(Add == 0)
		{
			TemCoin = CoinList[TypeID];
		}
		else
		{
			TemCoin = Add;	
		}
		Coin+= TemCoin;	
	}
	public void AddST(float Add = 0f)
	{
		float TemST = 0f;
		if(Add == 0f)
		{
			int StoreInt = 0;
			int CatchInt = (int)((float)((float)CurrentWaitingTime/(float)WaitingTime)*100);
			for(int a = 0;a<STRateList.Count;a++)
			{
				StoreInt += STRateList[a];
				if(CatchInt < StoreInt)
				{ 
					TemST = STEffectList[a];
					//Satisfaction += TemST;
					//SpawnText ("+ST "+TemST, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-10, - 60));
					break;
				}
			}
		}
		else
		{
			TemST = Add;	
		}
		Satisfaction += TemST;
	}
	public void AddTR(float Add = 0f)
	{
		float TemTR = 0f;
		if(Add == 0f)
		{
			for(int a = 0;a<TipsList.Count;a++)
			{
				if((int)Mathf.Floor(Satisfaction) == (int)TipsList[a]["Star"])
				{
					TemTR = (float)TipsList[a]["TR"];
					break;
				}
			}
		}
		else
		{
			TemTR = Add;	
		}
		TipsRate += TemTR;
	}
	public void AddLR(float Add = 0f)
	{
		float TemLR = 0f;
		if(Add == 0f)
		{
			TemLR = 0f;	
		}
		else
		{
			TemLR = Add;	
		}
		LikeRate += TemLR;
	}
	public void CompleteAction()
	{
		if(ActionList.Count >0)
		{
			//CancelInvoke("EnterFrame");
			AddCoin ();
			AddST ();
			switch(CurrentStation)
			{
				case "nF":Main.MyResultCal.AddFoodCount(1);break;
				case "nB":Main.MyResultCal.AddBarCount(1);break;
				case "nTD":Main.MyResultCal.AddTDisplayCount(1);break;
				case "nC":Main.MyResultCal.AddCashierCount(1);break;
			}
			ActionList.RemoveAt (0);
			
			//AddLR ();
			//CurrentStation = "";
			if(ActionList.Count >0)
			{
				if(ActionList[0] != "nC")
				{
					GetCurStationWT();	
					SpawnIcon (ActionList[0]);
				}
				else
				{
					Main.MyCustomer.moveCustomerToCashier(this.gameObject);
					CustomerBehaviour MyCB = (CustomerBehaviour)this.gameObject.transform.gameObject.GetComponent("CustomerBehaviour");
					Main.MyModuleClass.SetOccupy((string)MyCB.CustomerPrevData["Type"], (int)MyCB.CustomerPrevData["ID"], "-");
					MyCB.CustomerStatus = 0;
					Main.MyModuleClass.SetHelperStatus((string)MyCB.CustomerPrevData["Name"], 0);
					//SpawnIcon(ActionList[0],HashObject.Hash ("Post", new Vector3(140,-345,this.gameObject.transform.position.z)) );
				}	
			}
			else
			{
				Main.MyCustomer.runAway(this.gameObject);
			}
			
			
		}
		else
		{
			ActionList = null;	
		}
	}
	public void CalResult()
	{
		CompleteAction();
		AddTR ();
		CalTotalCoin ();
		CalTotalLike();
		
		UpdateAchievement ();
		DestroyIcon ();
	}
	private void UpdateAchievement()
	{
		string TemString = "";
		Main.MyResultCal.AddCoin(Coin);
		Main.MyResultCal.AddTotalCoin(Coin);
		TemString = "+$"+Coin;
		if(ObtainLike == true)
		{
			Main.MyResultCal.AddLike (1);
			TemString = TemString+" +1 Like";
		}
		
		
		int TemST = (int)Mathf.Floor(Satisfaction);
		if(TemST >2)
		{
			for(int a = 3;a<7;a++)
			{
				if(TemST >=a)
				{
					Main.MyResultCal.SendMessage("AddCountOf"+a+"Star", 1);		
				}
			}
		}
		SpawnText (TemString, new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y-10, - 60));
	}
	
	private void CalTotalCoin()
	{
		Coin = (int)((float)Coin * (1+TipsRate));
	}
	private void CalTotalLike()
	{
		int TemLike = (int)(50 + LikeRate * 100);
		if(TemLike > 100)
		{
			TemLike = 100;	
		}
		int CatchInt = Random.Range (0,100);
		if(CatchInt < TemLike)
		{
			ObtainLike = true;	
		}
	}
		
	//@Kaizer: ReturnData
	public int ReturnCoin()
	{
		return Coin;	
	}
	public int ReturnSatisfaction()
	{
		return (int)Satisfaction;	
	}
	public bool ReturnObtainLike()
	{
		return ObtainLike;	
	}
	public float ReturnCurrentWaitingTime()
	{
		return CurrentWaitingTime;	
	}
	public float ReturnWaitingTime()
	{
		return WaitingTime;	
	}
	public float ReturnLikeRate()
	{
		return LikeRate;	
	}
	public float ReturnTipsRate()
	{
		return TipsRate;	
	}
	public List<string> ReturnActionList()
	{
		List<string> TemList = new List<string>(ActionList.ToArray());
		return TemList;	
	}
	public string ReturnRequest()
	{
		string TemString = "None";
		if(ActionList.Count >0)
		{
			TemString = ActionList[0];	
		}
		return TemString;
	}
	public string ReturnCurrentStation()
	{
		return CurrentStation;	
	}
	//@Kaizer: Features
	private void SpawnText(string PassString, Vector3 Post)
	{
		GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite"));
		Main.AddParent(MySprite);
		MySprite.name = "SpawnText";
		MySprite.transform.localPosition = Post;
		MySprite.transform.localScale = new Vector3(1.5f*Main.FontFactor, 1.5f*Main.FontFactor, 1.5f*Main.FontFactor);
		MySprite.transform.Rotate(0,-180,0);
		MySprite.renderer.material.color = Color.black;
		((TextMesh)MySprite.GetComponent("TextMesh")).text = PassString;
		MySprite.AddComponent("TextVFX");
		MySprite = null;
	}
	public void Serving()
	{
		CancelInvoke ("EnterFrame");
		//SpawnText ("WT "+CurrentWaitingTime, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-10, - 60));
		if(Emoticon != null)
		{
			Emoticon.renderer.enabled = false;	
		}
	}
	
	private void CheckIconPost()
	{
		Emoticon.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x,this.gameObject.transform.localPosition.y+35,this.gameObject.transform.localPosition.z-20);
		if(Mathf.Abs(Emoticon.transform.localPosition.x - StoredPost.x) > 0 || Mathf.Abs (Emoticon.transform.localPosition.y - StoredPost.y) >0)
		{
			//Emoticon.renderer.enabled = false;	
		}
		else
		{
			//Emoticon.renderer.enabled = true;	
		}
		if(Emoticon != null && CurrentWaitingTime <= disappearIcon)
		{
			if(Emoticon.transform.localScale.x >= StoredScale.x+5)
			{
				ScaleFactor = -2;	
			}
			else if(Emoticon.transform.localScale.x <= StoredScale.x -5)
			{
				ScaleFactor = 2;	
			}
			Emoticon.transform.localScale = new Vector3(Emoticon.transform.localScale.x +ScaleFactor, Emoticon.transform.localScale.y +ScaleFactor, Emoticon.transform.localScale.z);
			
		}
	}
	public void SetTimeToClear(float Times)
	{
		Invoke ("Clear",Times);	
	}
	public void SpawnIcon(string Request, Hashtable SpecificPost = null)
	{
		DestroyIcon ();
		EmoticonImg = (Material)Resources.Load ("Materials/"+Request+"Icon");
		Emoticon = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
		Main.AddParent(Emoticon);
		Emoticon.name = this.gameObject.name;
		Emoticon.renderer.material = EmoticonImg;
		Emoticon.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x,this.gameObject.transform.localPosition.y+35,this.gameObject.transform.localPosition.z-20);
		Emoticon.transform.localScale = new Vector3(50,64,0.1f);
		Emoticon.transform.Rotate (0,0,-180);
		StoredScale = Emoticon.transform.localScale;
		if(SpecificPost == null)
		{
			StoredPost = Emoticon.transform.localPosition;	
		}
		else
		{
			StoredPost = (Vector3)SpecificPost["Post"];	
		}
		Debug.Log ("Kaizer Check");
		InvokeRepeating ("CheckIconPost", 0, 0.02f);
	}
	public void DestroyIcon()
	{
		if(Emoticon != null)
		{
			CancelInvoke("CheckIconPost");
			//StoredPost = null;
			Destroy (Emoticon);	
			EmoticonImg = null;
			Emoticon = null;	
		}
	}
	
	//@Kaizer: Clearance
	public void Clear()
	{
		ActionList = null;
		ActionCount = null;
		TypeList = null;
		TypeRate = null;
		TipsList = null;
		CoinList = null;
		ActionTypeList = null;
		STList = null;
		WTList = null;
		LRList = null;
		STRateList = null;
		STEffectList = null;
		DestroyIcon ();
		Destroy (this.gameObject.GetComponent("CustomerAtr"));
		Main.MyCustomer.destroyCustomer(this.gameObject);
	}
	
	private void Update()
	{
		
		if(Main.MySpawn.myMinusTime > minusTime)
		{
			if(minusTime <= 15)
			{
				minusTime+=0.5f;
			}
			if(disappearIcon > 3.0f)
			{
				disappearIcon-=0.2f;
			}	
		}
		
		if(minusTime >= 5 && minusTime < 10)
		{
			normalAction += 5;
			VIPAction += 7;
			shortTAction += 5;
			casualAction += 4;
		}
		
		else if(minusTime >= 10 && minusTime < 15)
		{
			normalAction += 6;
			VIPAction += 8;
			shortTAction += 6;
			casualAction += 5;
		}
		
		else if(minusTime >= 15)
		{
			normalAction += 7;
			VIPAction += 9;
			shortTAction += 7;
			casualAction += 6;
		}
		
	}	
}
