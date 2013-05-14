using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer & Aaron

public class Main : MonoBehaviour 
{
	public static void AddParent(GameObject go)
	{
		GameObject world = GameObject.Find("World");	
		go.transform.parent = world.transform;
	}
	
	
	//static vars
	public static int GameWidth = 1024;
	public static int GameHeight = 768;
	public static int FPS = 50;
	public static int SizeFactor = 10;
	public static int PostFactor = 1;
	public static float FontFactor = 9.0f;
	public static bool DEBUG = true;
	
	//classes
	public static StatCheck MyStatCheck = null;
	public static ReqCheck MyReqCheck = null;
	public static PlayerAtr MyPlayerAtr = null;
	public static SoundEngine MySE = null;
	public static TileArray MyTile = null;
	public static ModuleData MyModule = null;
	public static ModuleClass MyModuleClass = null;
	public static PlayerClass MyPlayer = null;
	public static CustomerClass MyCustomer = null;
	public static HelperClass MyHelper = null;
	public static Controls MyControl = null;
	public static SaveSystem MySaveSystem = null;
	public static ResultCal MyResultCal = null;
	public static DragDrop MyDragDrop = null;
	public static CustomerBehaviour MyCustomerBehaviour = null;
	public static Achievement MyAchievement = null;
	public StartScreen MyStartScreen = null;
	private PnMScreen MyPnMScreen = null;
	
	private void Start()
	{
		Init();
	}
	private void Init()
	{
		randomTheme = Random.Range(1,4);
		
	
		Res.AdjustCameraSize(this.gameObject);
		Res.AdjustWorldSize(GameObject.Find("World"));
		
		if(DEBUG == true)
		{
			FontFactor = 1f;	
		}
		MySaveSystem = (SaveSystem) this.gameObject.AddComponent("SaveSystem");
		MySE = (SoundEngine)this.gameObject.AddComponent("SoundEngine");
		MyStatCheck = (StatCheck)this.gameObject.AddComponent("StatCheck");
		MyReqCheck = (ReqCheck)this.gameObject.AddComponent ("ReqCheck");
		MyPlayerAtr = (PlayerAtr)this.gameObject.AddComponent("PlayerAtr");
		MyAchievement = (Achievement)this.gameObject.AddComponent("Achievement");
		Show ();
		
	}
	private void Show()
	{
		ShowStartScreen();
		//ShowGameScreen();
		//ShowPnMScreen();
		//Invoke("ShowPnMScreen",1);
	}
	public void ShowStartScreen()
	{
		MySE.PlayBGM("Title");
		CameraFade.StartAlphaFade(Color.black, true,2.0f,0f);
		MyStartScreen = (StartScreen)this.gameObject.AddComponent("StartScreen");
		MyStartScreen.GetType().GetField ("Parent").SetValue(MyStartScreen, this);
		MyStartScreen.Init();
		//Invoke ("ShowGameScreen", 1);	
	}
	public void ClearStartScreen()
	{
		if(MyStartScreen != null)
		{
			Destroy(MyStartScreen);
			MyStartScreen = null;	
		}
	}
	
	public static int randomTheme;
	
	public void ShowGameScreen()
	{
		
		ClearStartScreen();
		
		StartResultCal();
		MySE.PlayBGM("Game");
		CameraFade.StartAlphaFade(Color.black, true,2.0f,0f);
		MyPlayer = (PlayerClass)this.gameObject.AddComponent("PlayerClass");
		MyTile = (TileArray)this.gameObject.AddComponent("TileArray");
		MyModule = (ModuleData)this.gameObject.AddComponent("ModuleData");
		MyModuleClass = (ModuleClass)this.gameObject.AddComponent("ModuleClass");
		MyCustomer = (CustomerClass)this.gameObject.AddComponent("CustomerClass");
		MyHelper = (HelperClass)this.gameObject.AddComponent("HelperClass");
		MyControl = (Controls)this.gameObject.AddComponent("Controls");
		MyDragDrop = (DragDrop)this.gameObject.AddComponent("DragDrop");
		
		MyPlayer.Init();
		MyModule.Init ();
		MyModuleClass.Init();
		MyCustomer.Init();
		MyHelper.Init();
		MyTile.Init();
		MyTile.GetType().GetField ("Parent").SetValue(MyTile, this);
		
		
	}
	public void ClearGameScreen()
	{
		if(MyPlayer != null)
		{
			MyPlayer.Reset();
			Destroy (MyPlayer);
			MyPlayer = null;
		}
		if(MyTile != null)
		{
			MyTile.Reset();
			Destroy(MyTile);
			MyTile = null;
		}
		if(MyModule != null)
		{
			Destroy (MyModule);
			MyModule = null;
		}
		if(MyModuleClass != null)
		{
			MyModuleClass.Reset();
			Destroy(MyModuleClass);
			MyModuleClass = null;
		}
		if(MyCustomer != null)
		{
			MyCustomer.Reset();
			Destroy(MyCustomer);
			MyCustomer = null;
		}
		if(MyHelper != null)
		{
			MyHelper.Reset();
			Destroy(MyHelper);
			MyHelper = null;
		}
		if(MyControl != null)
		{
			MyControl.Reset();
			Destroy(MyControl);
			MyControl = null;
		}
		if(MyDragDrop != null)
		{
			MyDragDrop.Reset();
			Destroy(MyDragDrop);
			MyDragDrop = null;
		}
	}
	public void ShowPnMScreen()
	{
		if(MyPnMScreen == null)
		{
			ClearStartScreen();
			ClearGameScreen();	
			
			MySE.PlayBGM("PnM");
			CameraFade.StartAlphaFade(Color.black, true,1.0f,0f);
			MyPnMScreen = (PnMScreen)this.gameObject.AddComponent("PnMScreen");
			//MyPnMScreen.GetType ().GetField ("Parent").SetValue(MyPnMScreen, this);
			MyPnMScreen.Init (this);
		}
	}
	public void ClearPnMScreen()
	{
		if(MyPnMScreen != null)
		{
			CameraFade.StartAlphaFade(Color.black, true,1.0f,0f);
			Destroy (this.gameObject.GetComponent("PnMScreen"));
			MyPnMScreen = null;
		}
	}
	public void StartResultCal()
	{
		if(MyResultCal != null)
		{
			Destroy (this.gameObject.GetComponent("ResultCal"));
			MyResultCal = null;
		}
		MyResultCal = (ResultCal)this.gameObject.AddComponent("ResultCal");	
	}
	
	private void Update()
	{
			
		if (Application.platform == RuntimePlatform.Android)
        {
			//if (Input.GetKey(KeyCode.Escape) && MyStartScreen != null)
			if (Input.GetKey(KeyCode.Escape) && MyStartScreen != null)
			{
				Application.Quit();

            } 
			else if (Input.GetKey(KeyCode.Escape) && MyStartScreen == null){
				ClearPnMScreen();
				ClearGameScreen();
				ShowStartScreen();
			}
		}
	}
}
