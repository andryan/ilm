using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerClass : MonoBehaviour {
 	public GameObject Player = null;
	public GameObject MapObj = null;
	private GameObject BarObj = null;
	private GameObject Cashier = null;
	private GameObject CashierObj = null;
	private GameObject DoorObj = null;
	private GameObject PianoObj = null;
	private GameObject RoadObj = null;
	private GameObject WindowObj = null;
	
	public GameObject FeverGauge = null;
		
	
	private List<GameObject> objList = null;
	private Transform SpriteAnim = null;
	public SpriteAnimator sAnim;
	public float PlayerWalkingSpeed = 0.0f;
	public float PlayerActionSpeed = 0.0f;
	public float PlayerActionTime = 0.0f;
	public bool Serving = false;
	
	//animation
	private Vector3 prevPlayerPost;
	
	//private List<List<int>> tileArr; 
	//public float 
	
	
	// Use this for initialization
	void Start () {
		//Init();
	}
	
	public void Reset()
	{
		for(int i = 0;i<objList.Count;i++)
		{
			Destroy(objList[i]);
		}
		Player = null;
		MapObj = null;
		BarObj = null;
		Cashier = null;
		CashierObj = null;
		DoorObj = null;
		PianoObj = null;
		RoadObj = null;
		WindowObj = null;
		Player = null;
		SpriteAnim = null;
		PlayerWalkingSpeed = 0.0f;
		PlayerActionSpeed = 0.0f;
		PlayerActionTime = 0.0f;
		Serving = false;
		objList = null;
	}
	
	public void Init()
	{	
		objList = new List<GameObject>();
		SpawnPlayer();
		SpawnInGameObj();
		SpriteAnim = Player.transform.Find("SpriteAnim");
		prevPlayerPost = Player.transform.localPosition;
		
		sAnim = (SpriteAnimator)SpriteAnim.GetComponent("SpriteAnimator");
		
		PlayerWalkingSpeed = Main.MyPlayerAtr.ReturnMovementSpeed();
		PlayerActionSpeed = Main.MyPlayerAtr.ReturnActionSpeed();
		
		InvokeRepeating("EnterFrame", 1f,0.06f);

	}
	
	private void SpawnPlayer()
	{
		//Player = new GameObject();
		Player = (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/PlayerPrefab"));
		Main.AddParent(Player);
		Player.transform.localPosition = new Vector3(140 - Res.DefaultWidth()/2, -460 + Res.DefaultHeight()/2, 0);
		Player.transform.localScale = new Vector3(50,64,1);
		objList.Add (Player);
	}
	
	//temporary function for in-game obj
	private void SpawnInGameObj()
	{
		/*
		MapObj = new GameObject();
		BarObj = new GameObject();
		Cashier = new GameObject();
		CashierObj = new GameObject();
		DoorObj = new GameObject();
		PianoObj = new GameObject();
		RoadObj = new GameObject();
		*/
		
		MapObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MapObj"));
		BarObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/BarObj"));
		CashierObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/CashierObj"));
		DoorObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/DoorObj"));
		PianoObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/PianoObj"));
		RoadObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/RoadObj"));
		WindowObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/WindowObj"));
		
		Main.AddParent(MapObj);
		Main.AddParent(BarObj);
		Main.AddParent(CashierObj);
		Main.AddParent(DoorObj);
		Main.AddParent(PianoObj);
		Main.AddParent(RoadObj);
		Main.AddParent(WindowObj);
		
		/*
		MapObj.transform.position = new Vector3(512, -384, -2);
		BarObj.transform.position = new Vector3(380f, -465.2831f, -22f);
		Cashier.transform.position = new Vector3(76.10322f, -388.27f, -23f);
		CashierObj.transform.position = new Vector3(120f, -431.5496f, -22f);
		DoorObj.transform.position = new Vector3(137.7853f, -98.47987f, 50f);
		PianoObj.transform.position = new Vector3(380f, -254.4137f, -16f);
		RoadObj.transform.position = new Vector3(395.477f, -67.66052f, 50f);
		*/
		
		//New Resolution
		MapObj.transform.localPosition = new Vector3(0, 0, -4);
		MapObj.transform.localScale = new Vector3(1024,768, 0.1f);
		
		Material MyMapBmp = (Material)Resources.Load ("PlanAndManage/Materials/FloorBG");// + Main.randomTheme);
		MapObj.renderer.material = MyMapBmp;
			
		
		//BarObj.transform.localPosition = new Vector3(485 - Res.DefaultWidth()/2, -765 + Res.DefaultHeight()/2, -22f);
		//BarObj.transform.localScale = new Vector3(320, 90 , 0.1f);
		BarObj.transform.localPosition = new Vector3(10, -350, -110);
		BarObj.transform.localScale = new Vector3(280,60, 0.1f);
		
		
		
		CashierObj.transform.localPosition =  new Vector3(-400, -285, -110f);
		CashierObj.transform.localScale = new Vector3(200,140,0.1f);

		
		DoorObj.transform.localPosition = new Vector3(-335, 227, 50f);
		DoorObj.transform.localScale = new Vector3(65, 130, 0.1f);
		//PianoObj.transform.localPosition = new Vector3(480f, -400f, -16f);
		PianoObj.transform.localPosition = new Vector3(420, -300f, -28f);
		PianoObj.transform.localScale = new Vector3(150, 150, 0.1f);

		RoadObj.transform.localPosition = new Vector3(15,280,0);
		RoadObj.transform.localScale = new Vector3(900,180,0.1f);
		
		WindowObj.transform.localPosition = new Vector3(50, 280,-3);
		WindowObj.transform.localScale = new Vector3(500, 200, 0.1f);
			
		
		objList.Add(MapObj);
		objList.Add(BarObj);
		objList.Add(Cashier);
		objList.Add(CashierObj);
		objList.Add(DoorObj);
		objList.Add(PianoObj);
		objList.Add(RoadObj);
		objList.Add (WindowObj);
		
		//Fever Gauge
		FeverGauge = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/FeverGauge"));
		Main.AddParent(FeverGauge);
		FeverGauge.transform.localPosition = new Vector3(485,-15,-50);
		FeverGauge.transform.localScale = new Vector3(30,630, 0.1f);
		objList.Add(FeverGauge);
	
	}
	
	//animation
	private void EnterFrame()
	{
		if(Player != null)
		{
			Vector3 currPlayerPos = convertPosToTile(Player);
			
				
			int tempZ = (int)-currPlayerPos.y*10 - 10;
			//Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, tempZ-1);
			//int totalZ = tempZ - (int)Player.transform.localPosition.z;
			//print ("totalZ "+(totalZ-1));
			//print ("tempZ "+ tempZ);
			//sAnim.transform.localPosition = new Vector3(0, 0, totalZ-1);
			//prin
			sAnim.transform.localPosition = new Vector3(0,0, tempZ);
			
			if(prevPlayerPost.y > Player.transform.localPosition.y)
			{
				sAnim.Play ("charac_walk_front");
			}
			else if(prevPlayerPost.y < Player.transform.localPosition.y)
			{
				sAnim.Play ("charac_walk_behind");
			}
			else if(prevPlayerPost.x < Player.transform.localPosition.x)
			{
				sAnim.Play ("charac_walk_right");
			}
			else if(prevPlayerPost.x > Player.transform.localPosition.x)
			{
				sAnim.Play ("charac_walk_left");
			}
			else if(Serving)
			{
				sAnim.Play ("charac_serving");
			}
			else if(prevPlayerPost.y == Player.transform.localPosition.y && prevPlayerPost.x == Player.transform.localPosition.x)
			{
				sAnim.Play ("charac_idle");
			}
			prevPlayerPost = Player.transform.localPosition;
		}
	}
	
	public float GetWaitingTime()
	{
		float tileWalkingTime = PlayerWalkingSpeed * Main.MyTile.TotalPath;
		float totalWaitingTime = tileWalkingTime + PlayerActionSpeed;
		Serving = true;
		print ("tileWalkingTime"+tileWalkingTime);
		print ("totalWaitingTime"+totalWaitingTime);
		return totalWaitingTime;
		
	}
	public float GetWalkingTime()
	{
		float tileWalkingTime = PlayerWalkingSpeed * Main.MyTile.TotalPath;
		return tileWalkingTime;
	}
	
	private Vector3 convertPosToTile(GameObject currentObj)
	{		
		float tempY = (currentObj.transform.localPosition.y - Res.DefaultHeight()/2)/TileArray.tileHeight;
		float tempX = (currentObj.transform.localPosition.x + Res.DefaultWidth()/2)/TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
					
		Vector3 tilePos = new Vector3(tileX, tileY, 0);
		return tilePos;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
