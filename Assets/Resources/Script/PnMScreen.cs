using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer
public class PnMScreen : MonoBehaviour 
{
	//@ Kaizer: Data
	//private int TileSize = 40;
	private int TileWidth = 50;
	private int TileHeight = 64;

	public Main Parent = null;
	private int VFXTimer = 0;
	private List<string> MListenerList = null;
	private List<string> TabMListenerList = null;
	private string ButtonSelection = "";
	private string TabSelection = "";
	private List<string> TabList = null;
	private List<List<int>> MapTile = null;
	
	private ConfirmationScreen MyCS = null;
	
	private Vector3 TextPost;
	public bool Upgraded = false;
	
	//@ Kaizer: UI Component
	private GameObject MyMap = null;
	private Material MyMapBmp = null;
	
	private GameObject MyMapWindow = null;
	private Material MyMapWindowBmp = null;
	
	private GameObject MyRoad = null;
	private Material MyRoadBmp = null;
	

	
	private GameObject CharGO = null;
	private Material CharBmp = null;
	
	private List<GameObject> HelperGOList = null;
	private List<Material> HelperBmpList = null;
	
	private List<GameObject> QueueUpGOList = null;
	private List<Material> QueueUpBmpList = null;
	
	private List<GameObject> FoodGOList = null;
	private List<Material> FoodBmpList = null;
	
	private List<GameObject> TDisplayGOList = null;
	private List<Material> TDisplayBmpList = null;
	
	private List<GameObject> BarGOList = null;
	private List<Material> BarBmpList = null;
	
	private GameObject CashierGO = null;
	private Material CashierBmp = null;
	
	private GameObject DecoGO = null;
	private Material DecoBmp = null;
	
	private GameObject PianoGO = null;
	private Material PianoBmp = null;
	
	private GameObject BarTableGO = null;
	private Material BarTableBmp = null;
	
	private List<GameObject> IconGOList = null;
	private List<Material> IconBmpList = null;
	
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
	
	private List<GameObject> TabGOList = null;
	private List<Material> TabBmpList = null;
	
	private GameObject NextGO = null;
	private Material NextBmp = null;
	
	
	
	private void Start()
	{
			
	}	
	public void Init(Main MyMain)
	{
		Parent = MyMain;
		/*
		Empty 		= 0
		Queue Up	= 1
		TDisplay	= 2
		Food		= 3
		Bar 		= 4
		Cashier		= 5
		ExtraDeco	= 6
		Character 	= 7
		Helper		= 8
		Uncrossable = 9
		*/
		List<List<int>> tileArr = new List<List<int>>();
		tileArr.Add(new List<int>(new int[]{9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}));//row 0
		tileArr.Add(new List<int>(new int[]{9,9,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,9}));//1
		tileArr.Add(new List<int>(new int[]{9,9,9,0,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}));//2
		tileArr.Add(new List<int>(new int[]{9,0,0,0,9,9,9,1,9,1,9,1,9,1,9,1,0,0,0,0}));//3
		tileArr.Add(new List<int>(new int[]{9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}));//4
		tileArr.Add(new List<int>(new int[]{9,0,0,0,0,0,0,9,9,9,9,9,9,0,0,0,0,0,0,0}));//5
		tileArr.Add(new List<int>(new int[]{9,0,8,8,0,0,0,9,0,3,0,3,0,0,0,0,2,0,2,0}));//6
		tileArr.Add(new List<int>(new int[]{9,0,8,8,8,0,9,9,0,0,0,0,0,0,0,0,0,0,0,0}));//7
		tileArr.Add(new List<int>(new int[]{9,0,7,8,8,0,9,9,0,3,0,3,0,0,0,0,2,0,2,0}));//8
		tileArr.Add(new List<int>(new int[]{9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}));//9
		tileArr.Add(new List<int>(new int[]{9,6,6,6,6,0,0,0,4,4,0,4,4,0,0,0,0,0,0,0}));//10
		tileArr.Add(new List<int>(new int[]{9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}));//11
	
		MapTile = tileArr;
		
		MListenerList = new List<string>();
		TabMListenerList = new List<string>();
		TabList = new List<string>(new string[]{"Employee","Tool"});
		TabSelection = TabList[0];
		BuildScreen();
		VFX_1();
	}
	//@ Kaizer: VFX List
	private void Update()
	{
		//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		if (Input.GetMouseButtonDown(0))
		{
        	RaycastHit hit;
       		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			if(Physics.Raycast(ray, out hit))
			{
				if(MListenerList != null && TabMListenerList != null)
				{
					bool Check = false;
					bool TabCheck = false;
					for(int a =0;a<MListenerList.Count;a++)
					{
						if(MListenerList[a] == hit.transform.gameObject.name)
						{
							Check = true;	
							Main.MySE.PlaySFX("Select");
						}
					}
					if(Check == false)
					{
						for(int b = 0;b<TabMListenerList.Count;b++)
						{
							if(TabMListenerList[b] == hit.transform.gameObject.name)
							{
								TabCheck = true;
								if(b > TabList.Count-1)
								{
									TabSelection = hit.transform.gameObject.name;	
								}
								else
								{
									TabSelection = TabList[b];	
								}
								Main.MySE.PlaySFX ("Select");
							}
						}	
					}
					else
					{
						ButtonSelection = hit.transform.gameObject.name;
						switch(TabSelection)
						{
							case "Employee":SelectChar();break;
							case "Tool":SelectTool();break;
						}
						//hit.transform.gameObject.transform.localScale = new Vector3(hit.transform.gameObject.transform.localScale.x*1.1f,1.0f,hit.transform.gameObject.transform.localScale.z*1.1f);	
					}
					if(TabCheck == true)
					{
						if(TabSelection == "NextIcon")
						{
							ReadyToClear();
						}
						else
						{
							UpdateTabIcon();
							SelectTab(TabSelection);	
						}
						
					}
				}
			}
		}
	}
	private void VFX_1()
	{
		VFXTimer = 0;
		InvokeRepeating("UpdateVFX_1", 0, (float)(1f/(float)Main.FPS));	
		
	}
	private void StopVFX_1()
	{
		VFXTimer = 0;
		CancelInvoke("UpdateVFX_1");
	}
	private void UpdateVFX_1()
	{
		VFXTimer++;
		if(VFXTimer == 50)
		{
			MUpListenerOnTab();
			MUpListenerOnAssets();
			SelectTab(TabSelection);
			StopVFX_1();
		}
	}
	//@ Kaizer: Listener
	private void MUpListenerOnAssets()
	{
		RemoveMUpListenerOnAssets();
		switch(TabSelection)
		{
			case "Employee":MUpListenerOnEmployee();break;
			case "Tool":MUpListenerOnTool();break;
			case "Deco":;break;
			case "Theme":;break;
		}
	}
	private void MUpListenerOnEmployee()
	{
		if(MListenerList != null)
		{
			bool CheckForChar = true;
			Hashtable MyHash = Main.MyReqCheck.GetASPDReqByLevel(Main.MyPlayerAtr.ReturnActionSpeedLevel()+1);
			if(MyHash.Count <= 0)
			{
				CheckForChar = false;	
			}
			if(!MListenerList.Contains (CharGO.name) && CheckForChar == true)
			{
				MListenerList.Add (CharGO.name);	
			}
			List<int> MyHelperLevelList = Main.MyPlayerAtr.ReturnHelperFull();
			for(int a = 0;a<HelperGOList.Count;a++)
			{
				if(!MListenerList.Contains (HelperGOList[a].name) && MyHelperLevelList[a] == 0)
				{
					MListenerList.Add (HelperGOList[a].name);	
				}
				Hashtable MyHashs = Main.MyReqCheck.GetHelperLevelReqByLevel(Main.MyPlayerAtr.GetHelperLevel(a));
				if(MyHashs.Count > 0)
				{
					MListenerList.Add(HelperGOList[a].name);
				}
			}
		}
	}
	private void MUpListenerOnTool()
	{
		if(MListenerList != null)
		{
			List<int> MyQueueUpLevelList = Main.MyPlayerAtr.ReturnQueueUpLevelFull();
			List<int> MyFoodLevelList = Main.MyPlayerAtr.ReturnFoodLevelFull();
			List<int> MyTDisplayLevelList = Main.MyPlayerAtr.ReturnTDisplayLevelFull();
			List<int> MyBarLevelList = Main.MyPlayerAtr.ReturnBarLevelFull();
			bool QueueUpCheck = false;
			bool FoodCheck = false;
			bool TDisplayCheck = false;
			bool BarCheck = false;
			
			for(int a = 0;a<QueueUpGOList.Count;a++)
			{
				bool Check = true;
				Hashtable MyHash = Main.MyStatCheck.GetQueueUpStatByLevel(MyQueueUpLevelList[a]+1);
				if(MyHash.Count<=0)
				{
					Check = false;	
				}
				if(!MListenerList.Contains (QueueUpGOList[a].name) && QueueUpCheck == false && Check == true)
				{
					MListenerList.Add (QueueUpGOList[a].name);
				}
				if(MyQueueUpLevelList[a] == 0)
				{
					QueueUpCheck = true;	
				}
			}
			for(int b = 0;b<FoodGOList.Count;b++)
			{
				bool Check = true;
				Hashtable MyHash = Main.MyStatCheck.GetFoodStatByLevel(MyFoodLevelList[b]+1);
				if(MyHash.Count<=0)
				{
					Check = false;	
				}
				if(!MListenerList.Contains (FoodGOList[b].name) && FoodCheck == false && Check == true)
				{
					MListenerList.Add (FoodGOList[b].name);
				}
				if(MyFoodLevelList[b] == 0)
				{
					FoodCheck = true;	
				}
			}
			for(int c = 0;c<TDisplayGOList.Count;c++)
			{
				bool Check = true;
				Hashtable MyHash = Main.MyStatCheck.GetTDisplayStatByLevel(MyTDisplayLevelList[c]+1);
				if(MyHash.Count<=0)
				{
					Check = false;	
				}
				if(!MListenerList.Contains (TDisplayGOList[c].name) && TDisplayCheck == false && Check == true)
				{
					MListenerList.Add (TDisplayGOList[c].name);
				}
				if(MyTDisplayLevelList[c] == 0)
				{
					TDisplayCheck = true;	
				}
			}
			for(int d = 0;d<BarGOList.Count;d++)
			{
				bool Check = true;
				Hashtable MyHash = Main.MyStatCheck.GetBarStatByLevel(MyBarLevelList[d]+1);
				if(MyHash.Count<=0)
				{
					Check = false;	
				}
				if(!MListenerList.Contains (BarGOList[d].name) && BarCheck == false && Check == true)
				{
					MListenerList.Add (BarGOList[d].name);
				}
				if(MyBarLevelList[d] == 0)
				{
					BarCheck = true;	
				}
			}
			bool CheckForCashier = true;
			Hashtable MyCashierHash = Main.MyStatCheck.GetCashierStatByLevel(Main.MyPlayerAtr.ReturnCashierLevel()+1);
			if(MyCashierHash.Count <= 0)
			{
				CheckForCashier = false;	
			}
			if(!MListenerList.Contains (CashierGO.name) && CheckForCashier == true)
			{
				MListenerList.Add (CashierGO.name);	
			}
			
			bool CheckForDeco = true;
			Hashtable MyDecoHash = Main.MyStatCheck.GetDecoStatByID(Main.MyPlayerAtr.ReturnExtraDeco()+1);
			if(MyDecoHash.Count<=0)
			{
				CheckForDeco = false;	
			}
			if(!MListenerList.Contains (DecoGO.name) && CheckForDeco == true)
			{
				MListenerList.Add (DecoGO.name);	
			}
		}
	}
	private void RemoveMUpListenerOnAssets()
	{
		if(MListenerList != null)
		{
			MListenerList = null;
			MListenerList = new List<string>();
		}
	}
	private void MUpListenerOnTab()
	{
		RemoveMUpListenerOnTab();
		if(TabMListenerList != null)
		{
			for(int a = 0;a<TabGOList.Count;a++)
			{
				if(!TabMListenerList.Contains(TabGOList[a].name))
				{
					TabMListenerList.Add (TabGOList[a].name);	
				}
			}
		}
		if(!TabMListenerList.Contains (NextGO.name))
		{
			TabMListenerList.Add (NextGO.name);	
		}
	}
	private void RemoveMUpListenerOnTab()
	{
		if(TabMListenerList != null)
		{
			TabMListenerList.Clear ();
			TabMListenerList = new List<string>();	
		}
	}
	
	//@ Kaizer: Features
	private void ReadyToClear()
	{
		GameObject mainCamera = GameObject.Find("Main Camera");
		Main myMain = mainCamera.GetComponent<Main>();
		Main.MyPlayerAtr.AddDay (1);
		Clear ();	
	}
	public void UpdatePnM()
	{
		ClearScreen ();
		BuildScreen ();
		SelectTab (TabSelection);	
	}
	private void SelectChar()
	{
		int TemSlot = 0;
		string TemType = "";
		TextPost = new Vector3(0,0,0);
		if(ButtonSelection == CharGO.name)
		{
			TemType = "Char";
			TemSlot = 0;
			TextPost = new Vector3(CharGO.transform.localPosition.x, CharGO.transform.localPosition.y-10, -60);
		}
		if(TemType == "")
		{
			for(int a= 0;a<HelperGOList.Count;a++)
			{
				if(ButtonSelection == HelperGOList[a].name)
				{
					TemType = "Helper";
					TemSlot = a;
					TextPost = new Vector3(HelperGOList[a].transform.localPosition.x, HelperGOList[a].transform.localPosition.y-10, -60);
				}
			}
		}
		BuildCS (TemType, TemSlot);
	}
	private void SelectTool()
	{
		int TemSlot = 0;
		string TemType = "";
		TextPost = new Vector3(0,0,0);
		for(int a = 0;a<QueueUpGOList.Count;a++)
		{
			if(ButtonSelection == QueueUpGOList[a].name)
			{
				TemType = "QueueUp";
				TemSlot = a;
				TextPost = new Vector3(QueueUpGOList[a].transform.position.x, QueueUpGOList[a].transform.position.y - 10, -60);
			}
		}
		for(int b = 0;b<FoodGOList.Count;b++)
		{
			if(ButtonSelection == FoodGOList[b].name)
			{
				TemType = "Food";
				TemSlot = b;
				TextPost = new Vector3(FoodGOList[b].transform.position.x, FoodGOList[b].transform.position.y -10, -60);
			}
		}
		for(int c = 0;c<TDisplayGOList.Count;c++)
		{
			if(ButtonSelection == TDisplayGOList[c].name)
			{
				TemType = "TDisplay";
				TemSlot = c;
				TextPost = new Vector3(TDisplayGOList[c].transform.position.x, TDisplayGOList[c].transform.position.y -10, -60);
			}
		}
		for(int d = 0;d<BarGOList.Count;d++)
		{
			if(ButtonSelection == BarGOList[d].name)
			{
				TemType = "Bar";
				TemSlot = d;
				TextPost = new Vector3(BarGOList[d].transform.position.x, BarGOList[d].transform.position.y -10, -60);
			}
		}
		if(ButtonSelection == CashierGO.name)
		{
			TemType = "Cashier";
			TemSlot = 0;
			TextPost = new Vector3(CashierGO.transform.position.x, CashierGO.transform.position.y -10, -60);
		}
		if(ButtonSelection == DecoGO.name)
		{
			TemType = "Deco";
			TemSlot = 0;
			TextPost = new Vector3(DecoGO.transform.position.x,DecoGO.transform.position.y -10, -60);
		}
		BuildCS (TemType, TemSlot);
	}
	
	private void UpdateTabIcon()
	{
		for(int a = 0;a<TabList.Count;a++)
		{
			TabBmpList[a] = (Material)Resources.Load ("PlanAndManage/Materials/"+TabList[a]+"1");
			TabGOList[a].renderer.material = TabBmpList[a];	
			if(TabSelection == TabList[a])
			{
				TabBmpList[a] = (Material)Resources.Load ("PlanAndManage/Materials/"+TabSelection+"2");
				TabGOList[a].renderer.material = TabBmpList[a];	
			}
		}
	}
	private void UpdateUIText()
	{
		((TextMesh)DayText.GetComponent("TextMesh")).text = ""+Main.MyPlayerAtr.ReturnDay ().ToString ();

		((TextMesh)TimeText.GetComponent("TextMesh")).text = "Closed";

		((TextMesh)LikeText.GetComponent("TextMesh")).text = ""+Main.MyPlayerAtr.ReturnLike().ToString ();

		((TextMesh)CoinText.GetComponent("TextMesh")).text = ""+Main.MyPlayerAtr.ReturnCoin().ToString ();	
	}
	private void SelectTab(string Tab)
	{
		ClearAllIcon();
		string GetTab = Tab;
		switch(GetTab)
		{
			case "Employee":BuildIconForEmployee();break;
			case "Tool":BuildIconForTool ();break;
			case "Deco":;break;
			case "Theme":;break;
		}
		MUpListenerOnAssets();
	}
	//@ Kaizer: Tween List
	//@ Kaizer: Build UI Component
	private void SpawnText(string PassString, Vector3 Post)
	{
		 GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite"));
		Main.AddParent(MySprite);
		 MySprite.name = "SpawnText";
		 MySprite.transform.localPosition = Post;
		 MySprite.transform.localScale = new Vector3(1.8f*Main.FontFactor, 1.8f*Main.FontFactor, 1.8f*Main.FontFactor);
		 MySprite.transform.Rotate(0,-180,0);
		 MySprite.renderer.material.color = Color.black;
		 ((TextMesh)MySprite.GetComponent("TextMesh")).text = PassString;
		 MySprite.AddComponent("TextVFX");
		 MySprite = null;
	}
	private void BuildCS(string Type, int Slot)
	{
		if(MyCS == null)
		{
			MyCS = (ConfirmationScreen)this.gameObject.AddComponent("ConfirmationScreen");
			MyCS.Init (this, Type, Slot);
		}
	}
	
	private void BuildScreen()
	{
		BuildMap ();
		BuildMapComponent();
		BuildTools();
		BuildChar();
		BuildTopUI();
		BuildTab();
		//SelectTab (TabSelection);
	}
	private void BuildMap()
	{
		if(MyMap == null)
		{
			MyMap = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyMap.name = "Map";
			Main.AddParent (MyMap);
			MyMap.transform.localPosition = new Vector3(0,0,-20);
			MyMap.transform.localScale = new Vector3(1024/Main.SizeFactor, 1,768/Main.SizeFactor);
			MyMap.transform.Rotate (90,-180,0);
			MyMapBmp = (Material)Resources.Load ("PlanAndManage/Materials/FloorBG");// + Main.randomTheme);
			MyMap.renderer.material = MyMapBmp;
			
			MyMapWindow = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyMapWindow.name = "MapWindow";
			Main.AddParent(MyMapWindow);
			MyMapWindow.transform.localPosition = new Vector3(50, 280,-20);
			MyMapWindow.transform.localScale = new Vector3(50, 1, 20);
			MyMapWindow.transform.Rotate (90, -180, 0);
			MyMapWindowBmp = (Material)Resources.Load ("PlanAndManage/Materials/FloorBGWindow");
			MyMapWindow.renderer.material = MyMapWindowBmp;
			
			MyRoad = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyRoad.name = "Road";
			Main.AddParent(MyRoad);
			MyRoad.transform.localPosition = new Vector3(15,280,-18);
			MyRoad.transform.localScale = new Vector3(90,1,18);
			MyRoad.transform.Rotate(90, -180,0);
			MyRoadBmp  = (Material) Resources.Load("PlanAndManage/Materials/Road");
			MyRoad.renderer.material = MyRoadBmp;
			
			
		}
	}
	private void BuildTools()
	{
		BuildQueueUpTools();
		BuildFoodTools();
		BuildTDisplayTools();
		BuildBarTools();
		BuildCashier();
		BuildDeco();
	}
	private void BuildQueueUpTools()
	{
		if(QueueUpGOList == null)
		{
			QueueUpGOList = new List<GameObject>();
			QueueUpBmpList = new List<Material>();
			List<int> MyQueueUpLevelList = Main.MyPlayerAtr.ReturnQueueUpLevelFull();
			List<Vector2> QueueUpPost = new List<Vector2>();
			for(int a = 0;a<MapTile.Count;a++)
			{
				for(int b = 0;b<MapTile[a].Count;b++)
				{
					if(MapTile[a][b] == 1)
					{
						QueueUpPost.Add (new Vector2(b,a));	
					}
				}
			}
			for(int c = 0;c<MyQueueUpLevelList.Count;c++)
			{
				GameObject MySprite =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/QueueUpPrefab"));
				MySprite.name = "QueueUpSlot"+c.ToString();
				Main.AddParent(MySprite);
				
				MySprite.transform.localPosition = this.convertTileToPos(new Vector3(QueueUpPost[c].x, QueueUpPost[c].y, -24f));
				MySprite.transform.localScale = new Vector3(50, 64, 0.1f);

				Material MyBmp = null;
				if(MyQueueUpLevelList[c] >0)
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/QueueUpLv"+MyQueueUpLevelList[c].ToString ());	
				}
				else
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/QueueUpLv1");
					iTween.FadeTo (MySprite,iTween.Hash("alpha",0.7f,"time",0f, "easetype",iTween.EaseType.linear));
				}
				
				foreach(Transform child in MySprite.transform)
				{
					child.renderer.material = MyBmp;
				}
				MySprite.renderer.material = MyBmp;
				if(MyQueueUpLevelList[c]==0)
				{
					MySprite.renderer.material.color = Color.black;	
				}
				QueueUpGOList.Add (MySprite);
				QueueUpBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;	
				
			}
		}
	}
	private void BuildFoodTools()
	{
		if(FoodGOList == null)
		{
			FoodGOList = new List<GameObject>();
			FoodBmpList = new List<Material>();
			List<int> MyFoodLevelList = Main.MyPlayerAtr.ReturnFoodLevelFull();
			List<Vector2> FoodPost = new List<Vector2>();
			for(int a = 0;a<MapTile.Count;a++)
			{
				for(int b = 0;b<MapTile[a].Count;b++)
				{
					if(MapTile[a][b] == 3)
					{
						FoodPost.Add (new Vector2(b,a));	
					}
				}
			}
			for(int c = 0;c<MyFoodLevelList.Count;c++)
			{
				GameObject MySprite =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/FoodPrefab"));
				MySprite.name = "FoodSlot"+c.ToString();
				Main.AddParent(MySprite);
				MySprite.transform.localPosition = this.convertTileToPos(new Vector3(FoodPost[c].x, FoodPost[c].y, -24f));
				MySprite.transform.localScale = new Vector3(50, 64, 0.1f);

				Material MyBmp = null;
				if(MyFoodLevelList[c] >0)
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/FoodLv"+MyFoodLevelList[c].ToString ());
				}
				else
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/FoodLv1");
					iTween.FadeTo (MySprite,iTween.Hash("alpha",0.7f,"time",0f, "easetype",iTween.EaseType.linear));
				}

				foreach(Transform child in MySprite.transform)
				{
					child.renderer.material = MyBmp;
				}
				MySprite.renderer.material = MyBmp;
				if(MyFoodLevelList[c] == 0)
				{
					MySprite.renderer.material.color = Color.black;	
				}
				FoodGOList.Add (MySprite);
				FoodBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;
			}
		}	
	}
	private void BuildTDisplayTools()
	{
		if(TDisplayGOList == null)
		{
			TDisplayGOList = new List<GameObject>();
			TDisplayBmpList = new List<Material>();
			List<int> MyTDisplayLevelList = Main.MyPlayerAtr.ReturnTDisplayLevelFull();
			List<Vector2> TDisplayPost = new List<Vector2>();
			for(int a = 0;a<MapTile.Count;a++)
			{
				for(int b = 0;b<MapTile[a].Count;b++)
				{
					if(MapTile[a][b] == 2)
					{
						TDisplayPost.Add (new Vector2(b,a));	
					}
				}
			}
			for(int c = 0;c<MyTDisplayLevelList.Count;c++)
			{
				GameObject MySprite =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/TDisplayPrefab"));
				MySprite.name = "TDisplaySlot"+c.ToString();
				Main.AddParent(MySprite);
				
				MySprite.transform.localPosition = this.convertTileToPos(new Vector3(TDisplayPost[c].x, TDisplayPost[c].y, -24f));
				MySprite.transform.localScale = new Vector3(50, 64, 0.1f);
				
				Material MyBmp = null;
				if(MyTDisplayLevelList[c] >0)
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/TDisplayLv"+MyTDisplayLevelList[c].ToString ());
				}
				else
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/TDisplayLv1");
					iTween.FadeTo (MySprite,iTween.Hash("alpha",0.7f,"time",0f, "easetype",iTween.EaseType.linear));
				}
				foreach(Transform child in MySprite.transform)
				{
					child.renderer.material = MyBmp;
				}
				
				MySprite.renderer.material = MyBmp;
				if(MyTDisplayLevelList[c] == 0)
				{
					MySprite.renderer.material.color = Color.black;	
				}
				TDisplayGOList.Add (MySprite);
				TDisplayBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;
			}
		}		
	}

	private Vector3 convertTileToPos(Vector3 tilePos)
	{
		float posX = tilePos.x * TileArray.tileWidth + (TileArray.tileWidth/2) - Res.DefaultWidth()/2;
		float posY = -tilePos.y * TileArray.tileHeight - (TileArray.tileHeight/2) + Res.DefaultHeight()/2;
		float posZ = tilePos.z;
		
		Vector3 currentPosition = new Vector3(posX, posY, posZ);
		return currentPosition;
	}

	private void BuildBarTools()
	{
		if(BarGOList == null)
		{
			BarGOList = new List<GameObject>();
			BarBmpList = new List<Material>();
			List<int> MyBarLevelList = Main.MyPlayerAtr.ReturnBarLevelFull();
			List<Vector2> BarPost = new List<Vector2>();
			for(int a = 0;a<MapTile.Count;a++)
			{
				for(int b = 0;b<MapTile[a].Count;b++)
				{
					if(MapTile[a][b] == 4)
					{
						BarPost.Add (new Vector2(b,a));	
					}
				}
			}

			for(int c = 0;c<MyBarLevelList.Count;c++)
			{
				GameObject MySprite =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/BarPrefab"));
				MySprite.name = "BarSlot"+c.ToString();
				Main.AddParent(MySprite);

				MySprite.transform.localPosition = this.convertTileToPos(new Vector3(BarPost[c].x, BarPost[c].y, -24f));
				MySprite.transform.localScale = new Vector3(50, 64, 0.1f);
				Material MyBmp = null;
				if(MyBarLevelList[c] >0)
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/BarLv"+MyBarLevelList[c].ToString ());
				}
				else
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/BarLv1");
					iTween.FadeTo (MySprite,iTween.Hash("alpha",0.7f,"time",0f, "easetype",iTween.EaseType.linear));
				}

				foreach(Transform child in MySprite.transform)
				{
					child.renderer.material = MyBmp;
				}

				MySprite.renderer.material = MyBmp;
				if(MyBarLevelList[c] == 0)
				{
					MySprite.renderer.material.color = Color.black;	
				}
				BarGOList.Add (MySprite);
				BarBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;
			}
		}			
	}
	private void BuildCashier()
	{
		if(CashierGO == null)
		{
			CashierGO = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/CashierObj"));
			CashierGO.name = "Cashier";
			Main.AddParent(CashierGO);
			CashierGO.transform.localPosition =  new Vector3(-400, -285, -24f);
			CashierGO.transform.localScale = new Vector3(200,140,0.1f);
			//CashierGO.transform.localScale = new Vector3(200f, 0.1f, 140f);
			//CashierGO.transform.Rotate (90,-180,0);
			//CashierBmp = (Material)Resources.Load ("PlanAndManage/Materials/Cashier");
			//CashierGO.renderer.material = CashierBmp;
		}
	}
	private void BuildDeco()
	{
		if(DecoGO == null)
		{
			DecoGO = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/PianoObj"));
			DecoGO.name = "Deco";
			Main.AddParent(DecoGO);
			DecoGO.transform.localPosition = new Vector3(420, -300f, -28f);
			DecoGO.transform.localScale = new Vector3(150, 150, 0.1f);
		}	
	}
	private void BuildMapComponent()
	{
		BuildPiano();
		BuildBarTable();
	}
	private void BuildPiano()
	{
		if(PianoGO == null)
		{
			PianoGO = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/PianoObj"));
			PianoGO.name = "Piano";
			Main.AddParent(PianoGO);
			PianoGO.transform.localPosition = new Vector3(420, -300f, -28f);
			PianoGO.transform.localScale = new Vector3(150, 150, 0.1f);

			/*
			PianoGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			PianoGO.name = "Piano";
			PianoGO.transform.position = new Vector3(-20+400, -16-240,-28);
			PianoGO.transform.localScale = new Vector3(204/Main.SizeFactor, 1, 133/Main.SizeFactor);
			PianoGO.transform.Rotate (90,-180,0);
			PianoBmp = (Material)Resources.Load ("PlanAndManage/Materials/Piano");
			PianoGO.renderer.material = PianoBmp;
			*/
		}
	}
	private void BuildBarTable()
	{
		if(BarTableGO == null)
		{
			BarTableGO = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/BarObj"));
			BarTableGO.name = "BarTable";
			Main.AddParent(BarTableGO);
			BarTableGO.transform.localPosition = new Vector3(10, -350, -25);
			BarTableGO.transform.localScale = new Vector3(280,60, 0.1f);
			/*
			BarTableGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			BarTableGO.name = "BarTable";
			BarTableGO.transform.position = new Vector3(-25+400, -228-240,-30);
			BarTableGO.transform.localScale = new Vector3(277/Main.SizeFactor, 1, 63/Main.SizeFactor);
			BarTableGO.transform.Rotate (90,-180,0);
			BarTableBmp = (Material)Resources.Load ("PlanAndManage/Materials/BarTable");
			BarTableGO.renderer.material = BarTableBmp;	
			*/
		}	
	}
	
	private void BuildIconForTool()
	{
		ClearAllIcon ();
		if(IconGOList == null)
		{
			IconGOList = new List<GameObject>();
			IconBmpList = new List<Material>();
			BuildIconForQueueUp();
			BuildIconForFood ();
			BuildIconForTDisplay ();
			BuildIconForBar ();
			BuildIconForCashier ();
			BuildIconForDeco();
		}
	}
	private void BuildIconForQueueUp()
	{
		bool Check = false;
		List<int> TemQueueUpLevelList = Main.MyPlayerAtr.ReturnQueueUpLevelFull();
		for(int a = 0;a<QueueUpGOList.Count;a++)
		{
			bool Upgradable = true;
			Hashtable MyHash = Main.MyStatCheck.GetQueueUpStatByLevel(TemQueueUpLevelList[a]+1);
			if(MyHash.Count <=0)
			{
				Upgradable = false;
			}
			if(Check == false && Upgradable == true)
			{
				GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
				Main.AddParent(MySprite);
				MySprite.name = QueueUpGOList[a].name;
				MySprite.transform.localPosition = new Vector3(QueueUpGOList[a].transform.localPosition.x, QueueUpGOList[a].transform.localPosition.y +35,-40);
				MySprite.transform.localScale = new Vector3(40,40,0.1f);
				MySprite.transform.Rotate (0,0,-180);
				Material MyBmp = null;
				if(TemQueueUpLevelList[a] == 0)
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/PurchaseIcon");
					Check = true;
				}
				else
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/UpgradeIcon");	
				}
				MySprite.renderer.material = MyBmp;
				MySprite.AddComponent("IconVFX");
				IconGOList.Add (MySprite);
				IconBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;	
			}
		}	
	}
	private void BuildIconForFood()
	{
		bool Check = false;
		List<int> TemFoodLevelList = Main.MyPlayerAtr.ReturnFoodLevelFull();
		for(int a = 0;a<FoodGOList.Count;a++)
		{
			bool Upgradable = true;
			Hashtable MyHash = Main.MyStatCheck.GetFoodStatByLevel(TemFoodLevelList[a]+1);
			if(MyHash.Count <=0)
			{
				Upgradable = false;
			}
			if(Check == false && Upgradable == true)
			{
				GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
				Main.AddParent(MySprite);
				MySprite.name = FoodGOList[a].name;
				MySprite.transform.localPosition = new Vector3(FoodGOList[a].transform.localPosition.x, FoodGOList[a].transform.localPosition.y +35,-40);
				MySprite.transform.localScale = new Vector3(40,40,0.1f);
				MySprite.transform.Rotate (0,0,-180);
				Material MyBmp = null;
				if(TemFoodLevelList[a] == 0)
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/PurchaseIcon");
					Check = true;
				}
				else
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/UpgradeIcon");	
				}
				MySprite.renderer.material = MyBmp;
				MySprite.AddComponent("IconVFX");
				IconGOList.Add (MySprite);
				IconBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;	
			}
			
		}	
	}
	private void BuildIconForTDisplay()
	{
		bool Check = false;
		List<int> TemTDisplayLevelList = Main.MyPlayerAtr.ReturnTDisplayLevelFull();
		for(int a = 0;a<TDisplayGOList.Count;a++)
		{
			bool Upgradable = true;
			Hashtable MyHash = Main.MyStatCheck.GetTDisplayStatByLevel(TemTDisplayLevelList[a]+1);
			if(MyHash.Count <=0)
			{
				Upgradable = false;
			}
			if(Check == false && Upgradable == true)
			{
				GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
				Main.AddParent(MySprite);
				MySprite.name = TDisplayGOList[a].name;
				MySprite.transform.localPosition = new Vector3(TDisplayGOList[a].transform.localPosition.x, TDisplayGOList[a].transform.localPosition.y +45,-40);
				MySprite.transform.localScale = new Vector3(40,40,0.1f);
				MySprite.transform.Rotate (0,0,-180);
				Material MyBmp = null;
				if(TemTDisplayLevelList[a] == 0)
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/PurchaseIcon");
					Check = true;
				}
				else
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/UpgradeIcon");	
				}
				MySprite.renderer.material = MyBmp;
				MySprite.AddComponent("IconVFX");
				IconGOList.Add (MySprite);
				IconBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;	
			}
			
		}	
	}
	private void BuildIconForBar()
	{
		bool Check = false;
		List<int> TemBarLevelList = Main.MyPlayerAtr.ReturnBarLevelFull();
		for(int a = 0;a<BarGOList.Count;a++)
		{
			bool Upgradable = true;
			Hashtable MyHash = Main.MyStatCheck.GetBarStatByLevel(TemBarLevelList[a]+1);
			if(MyHash.Count <=0)
			{
				Upgradable = false;
			}
			if(Check == false && Upgradable == true)
			{
				GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
				Main.AddParent(MySprite);
				MySprite.name = BarGOList[a].name;
				MySprite.transform.localPosition = new Vector3(BarGOList[a].transform.localPosition.x, BarGOList[a].transform.localPosition.y +50,-40);
				MySprite.transform.localScale = new Vector3(40,40,0.1f);
				MySprite.transform.Rotate (0,0,-180);
				Material MyBmp = null;
				if(TemBarLevelList[a] == 0)
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/PurchaseIcon");
					Check = true;
				}
				else
				{
					MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/UpgradeIcon");	
				}
				MySprite.renderer.material = MyBmp;
				MySprite.AddComponent("IconVFX");
				IconGOList.Add (MySprite);
				IconBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;	
			}
			
		}	
	}
	private void BuildIconForCashier()
	{
		bool Upgradable = true;
		Hashtable MyHash = Main.MyStatCheck.GetCashierStatByLevel(Main.MyPlayerAtr.ReturnCashierLevel()+1);
		if(MyHash.Count <=0)
		{
			Upgradable = false;
		}
		if(Upgradable == true)
		{
			GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
			Main.AddParent(MySprite);
			MySprite.name = CashierGO.name;
			MySprite.transform.localPosition = new Vector3(CashierGO.transform.localPosition.x, CashierGO.transform.localPosition.y +45,-40);
			MySprite.transform.localScale = new Vector3(40,40,0.1f);
			MySprite.transform.Rotate (0,0,-180);
			Material MyBmp = null;
			MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/UpgradeIcon");
			MySprite.renderer.material = MyBmp;
			MySprite.AddComponent("IconVFX");
			IconGOList.Add (MySprite);
			IconBmpList.Add (MyBmp);
			MySprite = null;
			MyBmp = null;		
		}	
	}
	private void BuildIconForDeco()
	{
		bool Upgradable = true;
		Hashtable MyHash = Main.MyStatCheck.GetDecoStatByID(Main.MyPlayerAtr.ReturnExtraDeco()+1);
		if(MyHash.Count <=0)
		{
			Upgradable = false;
		}
		if(Upgradable == true)
		{
			GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
			Main.AddParent(MySprite);
			MySprite.name = DecoGO.name;
			MySprite.transform.localPosition = new Vector3(DecoGO.transform.localPosition.x, DecoGO.transform.localPosition.y +45,-40);
			MySprite.transform.localScale = new Vector3(40,40,0.1f);
			MySprite.transform.Rotate (0,0,-180);
			Material MyBmp = null;
			MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/UpgradeIcon");
			MySprite.renderer.material = MyBmp;
			MySprite.AddComponent("IconVFX");
			IconGOList.Add (MySprite);
			IconBmpList.Add (MyBmp);
			MySprite = null;
			MyBmp = null;		
		}		
	}
	
	private void BuildChar()
	{
		BuildMainChar();
		BuildHelper();
	}
	private void BuildMainChar()
	{
		if(CharGO == null)
		{
			Vector2 CharPost = new Vector2(0,0);
			for(int a = 0;a<MapTile.Count;a++)
			{
				for(int b = 0;b<MapTile[a].Count;b++)
				{
					if(MapTile[a][b] == 7)
					{
						CharPost = new Vector2(b, a);
					}
				}
			}
			
			CharGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			CharGO.name = "MainChar";
			Main.AddParent(CharGO);
			CharGO.transform.localPosition = new Vector3((CharPost.x * TileWidth)/Main.PostFactor +(TileWidth/2) -(0/2) - Res.DefaultWidth()/2 , (0/2) - (CharPost.y * TileHeight)/Main.PostFactor - (TileHeight/2) + 10 + Res.DefaultHeight()/2, -32);
			CharGO.transform.localScale = new Vector3(67/Main.SizeFactor, 1, 67/Main.SizeFactor);
			CharGO.transform.Rotate (90,-180,0);
			CharBmp = (Material)Resources.Load ("PlanAndManage/Materials/MainChar");
			CharGO.renderer.material = CharBmp;		
		}
	}
	private void BuildHelper()
	{
		if(HelperGOList == null)
		{
			HelperGOList = new List<GameObject>();
			HelperBmpList = new List<Material>();
			List<int> MyHelperLevelList = Main.MyPlayerAtr.ReturnHelperFull();
			List<Vector2> HelperPost = new List<Vector2>();
			for(int a = 0;a<MapTile.Count;a++)
			{
				for(int b = 0;b<MapTile[a].Count;b++)
				{
					if(MapTile[a][b] == 8)
					{
						HelperPost.Add (new Vector2(b,a));	
					}
				}	
			}
			for(int c = 0;c<MyHelperLevelList.Count;c++)
			{
				GameObject MySprite = GameObject.CreatePrimitive(PrimitiveType.Plane);
				MySprite.name = "Helper"+(c+1).ToString();
				Main.AddParent(MySprite);
				MySprite.transform.localPosition = new Vector3((HelperPost[c].x*TileWidth)/Main.PostFactor-(0/2)+(TileWidth/2) - Res.DefaultWidth()/2, ((0/2)-(HelperPost[c].y*TileHeight)/Main.PostFactor) -(TileHeight/2) + 10 + Res.DefaultHeight()/2,-34);
				MySprite.transform.localScale = new Vector3(67/Main.SizeFactor, 1 , 67/Main.SizeFactor);
				MySprite.transform.Rotate(90, -180, 0);
				Material MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/Helper"+(c+1).ToString()+"Icon");
				MySprite.renderer.material = MyBmp;
				if(MyHelperLevelList[c] == 0)
				{
					iTween.FadeTo (MySprite,iTween.Hash("alpha",0.7f,"time",0f, "easetype",iTween.EaseType.linear));
					MySprite.renderer.material.color = Color.black;	
				}
				HelperGOList.Add (MySprite);
				HelperBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;
			}
		}
	}
	private void BuildIconForEmployee()
	{
		ClearAllIcon();	
		if(IconGOList == null)
		{
			IconGOList = new List<GameObject>();
			IconBmpList = new List<Material>();	
			BuildIconForMainChar();
			BuildIconForHelper();
		}
		
	}
	private void BuildIconForMainChar()
	{
		bool Upgradable = true;
		Hashtable MyHash = Main.MyReqCheck.GetASPDReqByLevel(Main.MyPlayerAtr.ReturnActionSpeedLevel()+1);
		if(MyHash.Count <=0)
		{
			Upgradable = false;
		}
		if(Upgradable == true)
		{
			GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
			Main.AddParent(MySprite);
			MySprite.name = CharGO.name;
			MySprite.transform.localPosition = new Vector3(CharGO.transform.localPosition.x, CharGO.transform.localPosition.y +35,-40);
			MySprite.transform.Rotate (0,0,-180);
			MySprite.transform.localScale = new Vector3(40,40,0.1f);
			Material MyBmp = null;
			MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/UpgradeIcon");
			MySprite.renderer.material = MyBmp;
			MySprite.AddComponent("IconVFX");
			IconGOList.Add (MySprite);
			IconBmpList.Add (MyBmp);
			MySprite = null;
			MyBmp = null;		
		}
			
	}
	private void BuildIconForHelper()
	{
		List<int> MyHelperList = Main.MyPlayerAtr.ReturnHelperFull();
		List<int> MyHelperLevelList = Main.MyPlayerAtr.ReturnHelperLevel();
		
		for(int a = 0;a<MyHelperList.Count;a++)
		{	
			Hashtable MyHash = Main.MyReqCheck.GetHelperLevelReqByLevel(Main.MyPlayerAtr.GetHelperLevel(a));
			if(MyHelperList[a] == 0)
			{
				GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
				Main.AddParent(MySprite);
				MySprite.name = HelperGOList[a].name;
				MySprite.transform.localPosition = new Vector3(HelperGOList[a].transform.localPosition.x, HelperGOList[a].transform.localPosition.y +35,-40);
				MySprite.transform.Rotate (0,0,-180);
				MySprite.transform.localScale = new Vector3(40,40,0.1f);
				Material MyBmp = null;
				MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/PurchaseIcon");
				MySprite.renderer.material = MyBmp;
				MySprite.AddComponent("IconVFX");
				IconGOList.Add (MySprite);
				IconBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;
			}			
			else if(MyHelperList[a] > 0 && MyHelperLevelList[a] < 5)
			{
				GameObject MySprite = (GameObject)Instantiate((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
				Main.AddParent(MySprite);
				MySprite.name = HelperGOList[a].name;
				MySprite.transform.localPosition = new Vector3(HelperGOList[a].transform.localPosition.x, HelperGOList[a].transform.localPosition.y +35,-40);
				MySprite.transform.Rotate (0,0,-180);
				MySprite.transform.localScale = new Vector3(40,40,0.1f);
				Material MyBmp = null;
				MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/UpgradeIcon");					
				MySprite.renderer.material = MyBmp;
				MySprite.AddComponent("IconVFX");
				IconGOList.Add (MySprite);
				IconBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;
			}
		}
	}
	private void BuildTopUI()
	{
		if(TopUIGO == null)
		{
			TopUIGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			TopUIGO.name = "TopUI";
			Main.AddParent(TopUIGO);
			TopUIGO.transform.localPosition = new Vector3(0+400 - Res.DefaultWidth()/2 ,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-40);
			TopUIGO.transform.localScale = new Vector3(800/Main.SizeFactor,1, 45/Main.SizeFactor);
			TopUIGO.transform.Rotate (90, -180, 0);
			TopUIBmp = (Material)Resources.Load ("PlanAndManage/Materials/TopUIBar");
			TopUIGO.renderer.material = TopUIBmp;
			
			TopCoinGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			TopCoinGO.name = "TopCoin";
			Main.AddParent(TopCoinGO);
			TopCoinGO.transform.localPosition = new Vector3(280+400 - Res.DefaultWidth()/2,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
			TopCoinGO.transform.localScale = new Vector3(235/Main.SizeFactor,1, 37/Main.SizeFactor);
			TopCoinGO.transform.Rotate (90, -180, 0);
			TopCoinBmp = (Material)Resources.Load ("PlanAndManage/Materials/TopCoinBar");
			TopCoinGO.renderer.material = TopCoinBmp;
			
			HotelStarGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			HotelStarGO.name = "TopCoin";
			Main.AddParent(HotelStarGO);
			HotelStarGO.transform.localPosition = new Vector3(-270+400 - Res.DefaultWidth()/2,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
			HotelStarGO.transform.localScale = new Vector3(248/Main.SizeFactor,1, 36/Main.SizeFactor);
			HotelStarGO.transform.Rotate (90, -180, 0);
			HotelStarBmp = (Material)Resources.Load ("PlanAndManage/Materials/HotelStar");
			HotelStarGO.renderer.material = HotelStarBmp;
			
			DayPanelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			DayPanelGO.name = "DayPanel";
			Main.AddParent(DayPanelGO);
			DayPanelGO.transform.localPosition = new Vector3(-90+400 - Res.DefaultWidth()/2,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
			DayPanelGO.transform.localScale = new Vector3(97/Main.SizeFactor,1, 31/Main.SizeFactor);
			DayPanelGO.transform.Rotate (90, -180, 0);
			DayPanelBmp = (Material)Resources.Load ("PlanAndManage/Materials/DayPanel");
			DayPanelGO.renderer.material = DayPanelBmp;
			
			TimePanelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			TimePanelGO.name = "TimePanel";
			Main.AddParent(TimePanelGO);
			TimePanelGO.transform.localPosition = new Vector3(10+400 - Res.DefaultWidth()/2,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
			TimePanelGO.transform.localScale = new Vector3(97/Main.SizeFactor,1, 31/Main.SizeFactor);
			TimePanelGO.transform.Rotate (90, -180, 0);
			TimePanelBmp = (Material)Resources.Load ("PlanAndManage/Materials/TimePanel");
			TimePanelGO.renderer.material = TimePanelBmp;
			
			LikePanelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			LikePanelGO.name = "LikePanel";
			Main.AddParent(LikePanelGO);
			LikePanelGO.transform.localPosition = new Vector3(110+400 - Res.DefaultWidth()/2,((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2,-42);
			LikePanelGO.transform.localScale = new Vector3(97/Main.SizeFactor,1, 31/Main.SizeFactor);
			LikePanelGO.transform.Rotate (90, -180, 0);
			LikePanelBmp = (Material)Resources.Load ("PlanAndManage/Materials/LikePanel");
			LikePanelGO.renderer.material = LikePanelBmp;
			
			DayText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			DayText.name = "DayText";
			Main.AddParent(DayText);
			DayText.transform.localPosition = new Vector3(-100+400 - Res.DefaultWidth()/2, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
			DayText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			DayText.transform.Rotate (0,-180,0);
			DayText.renderer.material.color = Color.black;
			
			
			TimeText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			TimeText.name = "TimeText";
			Main.AddParent(TimeText);
			TimeText.transform.localPosition = new Vector3(-5+400 - Res.DefaultWidth()/2, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
			TimeText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			TimeText.transform.Rotate (0,-180,0);
			TimeText.renderer.material.color = Color.black;
			
			
			LikeText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			LikeText.name = "LikeText";
			Main.AddParent(LikeText);
			LikeText.transform.localPosition = new Vector3(100+400 - Res.DefaultWidth()/2, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
			LikeText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			LikeText.transform.Rotate (0,-180,0);
			LikeText.renderer.material.color = Color.black;
			
			
			CoinText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			CoinText.name = "CoinText";
			Main.AddParent(CoinText);
			CoinText.transform.localPosition = new Vector3(210+400 - Res.DefaultWidth()/2, ((0/2) - 17.5f)/Main.PostFactor + Res.DefaultHeight()/2, -44);
			CoinText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			CoinText.transform.Rotate (0,-180,0);
			CoinText.renderer.material.color = Color.black;
			
			
			StarGOList = new List<GameObject>();
			StarBmpList = new List<Material>();
			for(int a = 0;a<Main.MyPlayerAtr.ReturnHotelRank();a++)
			{
				GameObject MySprite = GameObject.CreatePrimitive(PrimitiveType.Plane);
				MySprite.name = "StarIcon"+a;
				Main.AddParent(MySprite);
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
			
			UpdateUIText();
		}
	}
	private void BuildTab()
	{
		if(TabGOList == null)
		{
			TabGOList = new List<GameObject>();
			TabBmpList = new List<Material>();
			for(int a = 0;a<TabList.Count;a++)
			{
				GameObject MySprite = GameObject.CreatePrimitive(PrimitiveType.Plane);
				Main.AddParent(MySprite);
				MySprite.name = TabList[a]+"Icon";
				MySprite.transform.localPosition = new Vector3((45+(a*58) - (0/2))/Main.PostFactor - Res.DefaultWidth()/2, ((0/2) - 60f)/Main.PostFactor + Res.DefaultHeight()/2, -38);
				MySprite.transform.localScale = new Vector3(52/Main.SizeFactor, 1, 43/Main.SizeFactor);
				MySprite.transform.Rotate (90, -180, 0);
				Material MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/"+TabList[a]+"1");
				MySprite.renderer.material = MyBmp;
				TabGOList.Add (MySprite);
				TabBmpList.Add (MyBmp);
				MySprite = null;
				MyBmp = null;
			}
			UpdateTabIcon();
		}
		if(NextGO == null)
		{
			NextGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(NextGO);
			NextGO.name = "NextIcon";
			NextGO.transform.localPosition = new Vector3((700 - (0/2))/Main.PostFactor - Res.DefaultWidth()/2, ((0/2)-70)/Main.PostFactor + Res.DefaultHeight()/2, -38);
			NextGO.transform.localScale = new Vector3((166/Main.SizeFactor), 1, (38/Main.SizeFactor));
			NextGO.transform.Rotate (90,-180,0);
			NextBmp = (Material)Resources.Load ("PlanAndManage/Materials/NextIcon");
			NextGO.renderer.material = NextBmp;
		}
	}
	//@ Kaizer: Clearance
	public void ClearCS()
	{
		if(MyCS != null)
		{
			MyCS.Clear ();
			MyCS = null;
			if(Upgraded == true)
			{
				SpawnText ("Upgraded!", TextPost);	
				Main.MySE.PlaySFX("Purchase");
			}
		}
	}
	private void ClearTab()
	{
		if(TabGOList != null)
		{
			for(int a = 0;a< TabGOList.Count;a++)
			{
				TabBmpList[a] = null;
				Destroy (TabGOList[a]);
				TabGOList[a] = null;
			}
			TabBmpList = null;
			TabGOList = null;
		}
		if(NextGO != null)
		{
			NextBmp = null;
			Destroy (NextGO);
			NextGO = null;
		}
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
	private void ClearHelper()
	{
		if(HelperGOList != null)
		{
			for(int a = 0;a<HelperGOList.Count;a++)
			{
				HelperBmpList[a] = null;
				Destroy (HelperGOList[a]);
				HelperGOList[a] = null;
			}
			HelperGOList = null;
			HelperBmpList = null;
		}
	}
	private void ClearMainChar()
	{
		if(CharGO != null)
		{
			CharBmp = null;
			Destroy (CharGO);
			CharGO = null;
		}
	}
	private void ClearChar()
	{
		ClearHelper();
		ClearMainChar();
	}
	private void ClearAllIcon()
	{
		if(IconGOList != null)
		{
			for(int a = 0;a<IconGOList.Count;a++)
			{
				IconBmpList[a] = null;
				Destroy (IconGOList[a].GetComponent("IconVFX"));
				Destroy (IconGOList[a]);
				IconGOList[a] = null;
			}
			IconBmpList = null;
			IconGOList = null;
		}
	}
	private void ClearBarTable()
	{
		if(BarTableGO != null)
		{
			BarTableBmp = null;
			Destroy (BarTableGO);
			BarTableGO = null;
		}	
	}
	private void ClearPiano()
	{
		if(PianoGO != null)
		{
			PianoBmp = null;
			Destroy (PianoGO);
			PianoGO = null;
		}
	}
	private void ClearMapComponent()
	{
		ClearBarTable();
		ClearPiano();
	}
	private void ClearDeco()
	{
		if(DecoGO != null)
		{
			DecoBmp = null;
			Destroy (DecoGO);
			DecoGO = null;
		}
	}
	private void ClearCashier()
	{
		if(CashierGO != null)
		{
			CashierBmp = null;
			Destroy (CashierGO);
			CashierGO = null;
		}
	}
	private void ClearBarTools()
	{
		if(BarGOList != null)
		{
			for(int a = 0;a<BarGOList.Count;a++)
			{
				BarBmpList[a] = null;
				Destroy (BarGOList[a]);
				BarGOList[a] = null;
			}
			BarBmpList = null;
			BarGOList = null;
		}		
	}
	private void ClearTDisplayTools()
	{
		if(TDisplayGOList != null)
		{
			for(int a = 0;a<TDisplayGOList.Count;a++)
			{
				TDisplayBmpList[a] = null;
				Destroy (TDisplayGOList[a]);
				TDisplayGOList[a] = null;
			}
			TDisplayBmpList = null;
			TDisplayGOList = null;
		}		
	}
	private void ClearFoodTools()
	{
		if(FoodGOList != null)
		{
			for(int a = 0;a<FoodGOList.Count;a++)
			{
				FoodBmpList[a] = null;
				Destroy (FoodGOList[a]);
				FoodGOList[a] = null;
			}
			FoodBmpList = null;
			FoodGOList = null;
		}	
	}
	private void ClearQueueUpTools()
	{
		if(QueueUpGOList != null)
		{
			for(int a = 0;a<QueueUpGOList.Count;a++)
			{
				QueueUpBmpList[a] = null;
				Destroy (QueueUpGOList[a]);
				QueueUpGOList[a] = null;
			}
			QueueUpBmpList = null;
			QueueUpGOList = null;
		}
	}
	private void ClearTools()
	{
		ClearDeco();
		ClearCashier();
		ClearBarTools();
		ClearTDisplayTools();
		ClearFoodTools();
		ClearQueueUpTools();
	}
	
	private void ClearMap()
	{
		if(MyMapWindow != null)
		{
			MyMapWindowBmp = null;
			Destroy (MyMapWindow);
			MyMapWindow = null;
		}
		if(MyMap != null)
		{
			MyMapBmp = null;
			Destroy(MyMap);	
			MyMap = null;
		}
		if(MyRoad != null)
		{
			MyRoadBmp = null;
			Destroy(MyRoad);
			MyRoad = null;
		}
	}
	private void ClearScreen()
	{
		ClearTab();
		ClearTopUI();
		ClearChar ();
		ClearTools ();
		ClearMapComponent();
		ClearMap ();	
	}
	private void ClearAllVFX()
	{
		StopVFX_1 ();
	}
	private void ClearAllListener()
	{
		RemoveMUpListenerOnTab();
		RemoveMUpListenerOnAssets();
	}
	private void ClearAllComponent()
	{
		ClearAllIcon ();
		ClearScreen ();	
	}
	public void Clear()
	{
		MapTile = null;
		MListenerList = null;
		TabMListenerList = null;
		ClearAllVFX();
		ClearAllListener();
		ClearAllComponent();
		Parent.ClearPnMScreen();
		Parent.ShowGameScreen();
		print ("SHOW GAME SCREEN");
		Parent = null;
	}
}
