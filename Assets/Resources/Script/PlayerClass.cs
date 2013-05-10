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
		prevPlayerPost = Player.transform.position;
		
		sAnim = (SpriteAnimator)SpriteAnim.GetComponent("SpriteAnimator");
		
		PlayerWalkingSpeed = Main.MyPlayerAtr.ReturnMovementSpeed();
		PlayerActionSpeed = Main.MyPlayerAtr.ReturnActionSpeed();
		
		InvokeRepeating("EnterFrame", 1f,0.06f);

	}
	
	private void SpawnPlayer()
	{
		Player = new GameObject();
		Player = (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/PlayerPrefab"));
		Player.transform.position = new Vector3(140, -460, -26);
		objList.Add (Player);
	}
	
	//temporary function for in-game obj
	private void SpawnInGameObj()
	{
		MapObj = new GameObject();
		BarObj = new GameObject();
		Cashier = new GameObject();
		CashierObj = new GameObject();
		DoorObj = new GameObject();
		PianoObj = new GameObject();
		RoadObj = new GameObject();
		
		MapObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MapObj"));
		BarObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/BarObj"));
		Cashier = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/Cashier"));
		CashierObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/CashierObj"));
		DoorObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/DoorObj"));
		PianoObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/PianoObj"));
		RoadObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/RoadObj"));
		
		MapObj.transform.position = new Vector3(400, -240, -2);
		BarObj.transform.position = new Vector3(380f, -465.2831f, -22f);
		Cashier.transform.position = new Vector3(76.10322f, -388.27f, -23f);
		CashierObj.transform.position = new Vector3(120f, -431.5496f, -22f);
		DoorObj.transform.position = new Vector3(137.7853f, -98.47987f, 50f);
		PianoObj.transform.position = new Vector3(380f, -254.4137f, -16f);
		RoadObj.transform.position = new Vector3(395.477f, -67.66052f, 50f);
		
		
		objList.Add(MapObj);
		objList.Add(BarObj);
		objList.Add(Cashier);
		objList.Add(CashierObj);
		objList.Add(DoorObj);
		objList.Add(PianoObj);
		objList.Add(RoadObj);
	}
	
	//animation
	private void EnterFrame()
	{
		if(Player != null)
		{
			Vector3 currPlayerPos = convertPosToTile(Player);
			
				
			int tempZ = (int)-currPlayerPos.y*2;
			//Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, tempZ-1);
			int totalZ = tempZ - (int)Player.transform.position.z;
			//print ("totalZ "+(totalZ-1));
			//print ("tempZ "+ tempZ);
			sAnim.transform.localPosition = new Vector3(0, 0, totalZ-1);
			//prin
			
			
			if(prevPlayerPost.y > Player.transform.position.y)
			{
				sAnim.Play ("charac_walk_front");
			}
			else if(prevPlayerPost.y < Player.transform.position.y)
			{
				sAnim.Play ("charac_walk_behind");
			}
			else if(prevPlayerPost.x < Player.transform.position.x)
			{
				sAnim.Play ("charac_walk_right");
			}
			else if(prevPlayerPost.x > Player.transform.position.x)
			{
				sAnim.Play ("charac_walk_left");
			}
			else if(Serving)
			{
				sAnim.Play ("charac_serving");
			}
			else if(prevPlayerPost.y == Player.transform.position.y && prevPlayerPost.x == Player.transform.position.x)
			{
				sAnim.Play ("charac_idle");
			}
			prevPlayerPost = Player.transform.position;
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
		float tempY = currentObj.transform.position.y/TileArray.tileHeight;
		float tempX = currentObj.transform.position.x/TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
					
		Vector3 tilePos = new Vector3(tileX, tileY, 0);
		return tilePos;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
