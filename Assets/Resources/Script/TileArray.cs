//author "Blooded"

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TileArray : MonoBehaviour {
	
	public Main Parent = null;
	
	private float timer = 2f;
	
	public bool isLose;
	
	public int maxCustOut = 10;
	
	private List<List<int>> tileArr = null; 
	
	public int TotalPath = 0;
	public static int tileWidth = 50;
	public static int tileHeight = 64;
	
	private GameObject TopUIGO = null;
	private Material TopUIBmp = null;
	
	private GameObject TopCoinGO = null;
	private Material TopCoinBmp = null;
	
	private GameObject HotelStarGO = null;
	private Material HotelStarBmp = null;
	
	private List<GameObject> StarGOList = null;
	private List<Material> StarBmpList = null;
	
	private GameObject DayText = null;
	private GameObject TimeText = null;
	private GameObject LikeText = null;
	private GameObject CoinText = null;
		
	private GameObject DayPanelGO = null;
	private Material DayPanelBmp = null;
		
	private GameObject TimePanelGO = null;
	private Material TimePanelBmp = null;
		
	private GameObject LikePanelGO = null;
	private Material LikePanelBmp = null;
	
	
	private int Hour = 0;
	private int Minutes = 0;
	public int TotalTime = 0;
	
	//Use this for initialization
	/// <summary>
	/// The F path.
	/// </summary>//
	//private List<List<int>> FPath;
	/// <summary>
	/// Start this instance.
	/// </summary>//
	void Start () {
		
		isLose = false;
		//Init();
		
	}
	public void Reset()
	{
		List<List<int>> tileArr = null;
		TotalPath = 0;
		ClearTopUI();
		CancelInvoke("UpdateUIText");
		CancelInvoke ("UpdateTimeText");
	}
	public void Init()
	{
		//values
		tileArrInfo();
		BuildTopUI();
	}
	void tweenY(object values) {
		if(Main.MyPlayer.MapObj != null)
		{
			Hashtable ht = (Hashtable)values;
		
			List<List<int>> FPath = (List<List<int>>) ht["FPath"];
			GameObject tweenObject = (GameObject)ht["tweenObject"];
			float AISpeed = (float)ht ["AISpeed"];
			
			int tempPosition = -(tileHeight/2) - (tileHeight * FPath[1][0]) + (int) Res.DefaultHeight()/2;
			
			//itween's oncompleteparams requires hashtag to support multiple variable passing
			Hashtable completeParams = new Hashtable();
			completeParams.Add ("tweenObject", tweenObject);
			completeParams.Add ("FPath", FPath);
			completeParams.Add ("AISpeed", AISpeed);
			
			if(tempPosition == tweenObject.transform.localPosition.y)
			{
				tweenX(completeParams);
			} else {
				Hashtable tweenHash = new Hashtable();
				tweenHash.Add("y", tempPosition);
				tweenHash.Add("time", AISpeed);
				tweenHash.Add("easeType", "linear");
				tweenHash.Add("onComplete", "tweenX");
				tweenHash.Add ("onCompleteParams", completeParams);
				tweenHash.Add("onCompleteTarget", Main.MyPlayer.MapObj);
				iTween.MoveTo(tweenObject, tweenHash);
			}
		}
	}
	void tweenX(object values) {
		if(Main.MyPlayer.MapObj != null)
		{
			Hashtable ht = (Hashtable)values;
		
			List<List<int>> FPath = (List<List<int>>) ht["FPath"];
			GameObject tweenObject = (GameObject)ht["tweenObject"];
			float AISpeed = (float)ht["AISpeed"];
			
			int tempPosition;
			tempPosition = (tileWidth/2) + (tileWidth * FPath[1][1]) - (int)Res.DefaultWidth()/2;
			
			Hashtable completeParams = new Hashtable();
			completeParams.Add ("tweenObject", tweenObject);
			completeParams.Add ("FPath", FPath);
			completeParams.Add ("AISpeed", AISpeed);
			
			FPath.RemoveAt(1);//<<<this is temporary here(before this is in loopTween but was put here when need to create FPath for multiple AI)
			if(tempPosition == tweenObject.transform.localPosition.x)
			{
				loopTween(completeParams);
			} else {
				Hashtable tweenHash = new Hashtable();
				tweenHash.Add("x", tempPosition);
				tweenHash.Add("time", AISpeed);
				tweenHash.Add("easeType", "linear");
				tweenHash.Add("onComplete", "loopTween");
				tweenHash.Add ("onCompleteParams", completeParams);
				tweenHash.Add("onCompleteTarget", Main.MyPlayer.MapObj);
				iTween.MoveTo(tweenObject, tweenHash);
				
			}
		}
	}

	void Update() {
		//UpdateUIText();
		if(Main.MyResultCal.RunawayCount >= maxCustOut)
		{
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				isLose = true;
			}
		}
	}
	void tileArrInfo() {
		/*tile array info
		empty 		= 0
		entrance 	= 1
		lift 		= 2
		queue up	= 3
		hot spring 	= 4
		food		= 5
		cashier		= 6
		sauna		= 7
		extra deco	= 8
		unpassable	= 9
		*/
		tileArr = new List<List<int>>();
		tileArr.Add(new List<int>(new int[]{9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}));//row 0
		tileArr.Add(new List<int>(new int[]{9,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,9}));//1
		tileArr.Add(new List<int>(new int[]{9,9,9,0,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}));//2
		tileArr.Add(new List<int>(new int[]{0,0,0,0,9,9,3,9,3,9,3,9,3,9,3,9,9,9,0,0}));//3
		tileArr.Add(new List<int>(new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}));//4
		tileArr.Add(new List<int>(new int[]{0,0,0,0,0,0,0,9,9,9,9,9,0,0,0,5,0,5,0,0}));//5
		tileArr.Add(new List<int>(new int[]{0,0,0,0,0,0,0,9,9,9,9,9,0,0,0,0,0,0,0,0}));//6
		tileArr.Add(new List<int>(new int[]{0,0,0,0,0,0,0,9,9,9,9,9,0,0,0,0,0,0,0,0}));//7
		tileArr.Add(new List<int>(new int[]{0,0,0,0,0,0,0,4,4,0,4,4,0,0,0,5,0,5,0,0}));//8
		tileArr.Add(new List<int>(new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}));//9
		tileArr.Add(new List<int>(new int[]{0,6,6,6,6,0,7,9,7,9,7,9,7,0,0,8,8,8,8,0}));//10
		tileArr.Add(new List<int>(new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,0}));//11
		
	}
	
	
	
	public void findPosition(GameObject tweenObject, float AISpeed,int endY, int endX)
	{
		if(tweenObject != null && Main.MyPlayer.MapObj != null)
		{
			//convert current position to current tile
			int startY = Math.Abs((int)(tweenObject.transform.localPosition.y - Res.DefaultHeight() /2) /tileHeight);
			int startX = Math.Abs((int)(tweenObject.transform.localPosition.x + Res.DefaultWidth() / 2) /tileWidth);
			
			List<List<int>> FPath = AStar.FindPath(tileArr, startY, startX, endY, endX);
			FPath.Reverse();
			TotalPath = FPath.Count;
	//		print ("TOTAL PATH"+TotalPath);
			
			Hashtable completeParams = new Hashtable();
			completeParams.Add ("tweenObject", tweenObject);
			completeParams.Add ("FPath", FPath);
			completeParams.Add ("AISpeed", AISpeed);
			
			loopTween (completeParams);
		}
	}
	
	private void BuildTopUI()
	{
	
		TopUIGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(TopUIGO);
		TopUIGO.name = "TopUI";
		TopUIGO.transform.localPosition = new Vector3(0,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-40);
		TopUIGO.transform.localScale = new Vector3(Res.DefaultWidth()/Main.SizeFactor,1, 45/Main.SizeFactor);
		TopUIGO.transform.Rotate (90, -180, 0);
		TopUIBmp = (Material)Resources.Load ("PlanAndManage/Materials/TopUIBar");
		TopUIGO.renderer.material = TopUIBmp;
		
		TopCoinGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(TopCoinGO);
		TopCoinGO.name = "TopCoin";
		TopCoinGO.transform.localPosition = new Vector3(280,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
		TopCoinGO.transform.localScale = new Vector3(235/Main.SizeFactor,1, 37/Main.SizeFactor);
		TopCoinGO.transform.Rotate (90, -180, 0);
		TopCoinBmp = (Material)Resources.Load ("PlanAndManage/Materials/TopCoinBar");
		TopCoinGO.renderer.material = TopCoinBmp;
					
		HotelStarGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(HotelStarGO);
		HotelStarGO.name = "TopCoin";
		HotelStarGO.transform.localPosition = new Vector3(-270,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
		HotelStarGO.transform.localScale = new Vector3(248/Main.SizeFactor,1, 36/Main.SizeFactor);
		HotelStarGO.transform.Rotate (90, -180, 0);
		HotelStarBmp = (Material)Resources.Load ("PlanAndManage/Materials/HotelStar");
		HotelStarGO.renderer.material = HotelStarBmp;
					
		DayPanelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(DayPanelGO);
		DayPanelGO.name = "DayPanel";
		DayPanelGO.transform.localPosition = new Vector3(-90,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
		DayPanelGO.transform.localScale = new Vector3(97/Main.SizeFactor,1, 31/Main.SizeFactor);
		DayPanelGO.transform.Rotate (90, -180, 0);
		DayPanelBmp = (Material)Resources.Load ("PlanAndManage/Materials/DayPanel");
		DayPanelGO.renderer.material = DayPanelBmp;
					
		TimePanelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(TimePanelGO);
		TimePanelGO.name = "TimePanel";
		TimePanelGO.transform.localPosition = new Vector3(10,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
		TimePanelGO.transform.localScale = new Vector3(97/Main.SizeFactor,1, 31/Main.SizeFactor);
		TimePanelGO.transform.Rotate (90, -180, 0);
		TimePanelBmp = (Material)Resources.Load ("PlanAndManage/Materials/TimePanel");
		TimePanelGO.renderer.material = TimePanelBmp;
					
		LikePanelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(LikePanelGO);
		LikePanelGO.name = "LikePanel";
		LikePanelGO.transform.localPosition = new Vector3(110,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
		LikePanelGO.transform.localScale = new Vector3(97/Main.SizeFactor,1, 31/Main.SizeFactor);
		LikePanelGO.transform.Rotate (90, -180, 0);
		LikePanelBmp = (Material)Resources.Load ("PlanAndManage/Materials/LikePanel");
		LikePanelGO.renderer.material = LikePanelBmp;
					
		DayText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
		Main.AddParent(DayText);
		DayText.name = "DayText";
		DayText.transform.localPosition = new Vector3(-100, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
		DayText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
		DayText.transform.Rotate (0,-180,0);
		DayText.renderer.material.color = Color.black;
					
					
		TimeText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
		Main.AddParent(TimeText);
		TimeText.name = "TimeText";
		TimeText.transform.localPosition = new Vector3(-5, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
		TimeText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
		TimeText.transform.Rotate (0,-180,0);
		TimeText.renderer.material.color = Color.black;
					
					
		LikeText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
		Main.AddParent(LikeText);
		LikeText.name = "LikeText";
		LikeText.transform.localPosition = new Vector3(100, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
		LikeText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
		LikeText.transform.Rotate (0,-180,0);
		LikeText.renderer.material.color = Color.black;
					
					
		CoinText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
		Main.AddParent(CoinText);
		CoinText.name = "CoinText";
		CoinText.transform.localPosition = new Vector3(210, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
		CoinText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
		CoinText.transform.Rotate (0,-180,0);
		CoinText.renderer.material.color = Color.black;
					
					
		StarGOList = new List<GameObject>();
		StarBmpList = new List<Material>();
		for(int a = 0;a<Main.MyPlayerAtr.ReturnHotelRank();a++)
		{
			GameObject MySprite = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MySprite);
			MySprite.name = "StarIcon"+a;
			MySprite.transform.localPosition = new Vector3((103+(a*26) - (0/2))/Main.PostFactor - Res.DefaultWidth()/2, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
			MySprite.transform.localScale = new Vector3(24/Main.SizeFactor,1, 24/Main.SizeFactor);
			MySprite.transform.Rotate (90, -180, 0);
			Material MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/StarIcon");
			MySprite.renderer.material = MyBmp;
			StarGOList.Add (MySprite);
			StarBmpList.Add(MyBmp);
			MySprite = null;
			MyBmp = null;
		}
		InvokeRepeating("UpdateUIText", 0f, 0.02f);
		TotalTime = 1240;
		InvokeRepeating("UpdateTimeText", 0f, 0.2f);
		//UpdateUIText();
	}
	private void UpdateTimeText()
	{
		TotalTime++;
		Hour = (int)(TotalTime /60);
		Minutes = (int)(TotalTime % 60);
		string TemString = ""+Hour+":"+Minutes;
		if(Minutes <=9)
		{
			TemString = ""+Hour+":0"+Minutes;	
		}
		((TextMesh)TimeText.GetComponent("TextMesh")).text = TemString;
		if(TotalTime >= 1260)
		{
			((TextMesh)TimeText.GetComponent("TextMesh")).text = "Closed";	
			Main.MyCustomer.CancelInvoke("SpawnCustEnterFrame");
			if(Main.MyCustomer.GetCustomerCount() == 0)
			{
				ResultScreen MyRS = (ResultScreen)this.gameObject.AddComponent("ResultScreen");
				MyRS.Init (Parent);
				CancelInvoke("UpdateUIText");
				CancelInvoke ("UpdateTimeText");
			}
		}
		
				if(isLose == true)
				{		
					ResultScreen MyRS = (ResultScreen)this.gameObject.AddComponent("ResultScreen");
					MyRS.InitLose(Parent);
					CancelInvoke("UpdateUIText");
					CancelInvoke("UpdateTimeText");
				}
	}
	private void UpdateUIText()
	{
		((TextMesh)DayText.GetComponent("TextMesh")).text = ""+Main.MyPlayerAtr.ReturnDay ().ToString ();
		
		//((TextMesh)TimeText.GetComponent("TextMesh")).text = "9:00";
		
		((TextMesh)LikeText.GetComponent("TextMesh")).text = ""+(Main.MyPlayerAtr.ReturnLike()+Main.MyResultCal.ReturnLike());
		
		((TextMesh)CoinText.GetComponent("TextMesh")).text = ""+(Main.MyPlayerAtr.ReturnCoin()+Main.MyResultCal.ReturnCoin());
	}
	
	private void ClearTopUI()
	{
		if(StarGOList != null)
		{
			for(int a = 0;a<StarGOList.Count;a++)
			{
				StarBmpList[a] = null;
				Destroy (StarGOList[a]);
				StarGOList[a] = null;
			}
			StarBmpList = null;
			StarGOList = null;
		}
		if(TopUIGO != null)
		{
			TopUIBmp = null;
			Destroy (TopUIGO);
			TopUIGO = null;
		}
		if(TopCoinGO != null)
		{
			TopCoinBmp = null;
			Destroy (TopCoinGO);
			TopCoinGO = null;
		}
		if(HotelStarGO != null)
		{
			HotelStarBmp = null;
			Destroy (HotelStarGO);
			HotelStarGO = null;
		}
		if(DayPanelGO != null)
		{
			DayPanelBmp = null;
			Destroy (DayPanelGO);
			DayPanelGO = null;
		}
		if(TimePanelGO != null)
		{
			TimePanelBmp = null;
			Destroy (TimePanelGO);
			TimePanelGO = null;
		}
		if(LikePanelGO != null)
		{
			LikePanelBmp = null;
			Destroy (LikePanelGO);
			LikePanelGO = null;
		}
		if(DayText != null)
		{
			Destroy (DayText);
			DayText = null;
		}
		if(TimeText != null)
		{
			Destroy (TimeText);
			TimeText = null;
		}
		if(LikeText != null)
		{
			Destroy (LikeText);
			LikeText = null;
		}
		if(CoinText != null)
		{
			Destroy (CoinText);
			CoinText = null;
		}
	}
	
	void loopTween(object values){
		Hashtable ht = (Hashtable)values;
	
		List<List<int>> FPath = (List<List<int>>) ht["FPath"];
		GameObject tweenObject = (GameObject)ht["tweenObject"];
		float AISpeed = (float)ht["AISpeed"];
		//remove tiles that has been used
		if(FPath.Count>1){
			Hashtable completeParams = new Hashtable();
			completeParams.Add ("tweenObject", tweenObject);
			completeParams.Add ("FPath", FPath);
			completeParams.Add ("AISpeed", AISpeed);
			
			tweenY(completeParams);
			
		} else {
			//Player
			if(tweenObject.name == "Player")
			{
				//Main.MyControl.isPlayerComplete = false;
			}
			//Customer
			for(int i=0;i<Main.MyCustomer.customerList.Count;i++)
			{
				if(tweenObject == Main.MyCustomer.customerList[i])
				{
					Main.MyCustomer.checkAction(i);
					break;
				}
			}
		}
	}
			
}