using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//@ Author: Blooded
//this class this to be change to using hashtags instead of many listArrays and convert the data into customer behaviour class instead of for looping to control
public class CustomerClass : MonoBehaviour {
	
	//GameObject CustomerObject;
	
	public List<GameObject> customerList = null; //customer's game objects
	public List<GameObject> customerObjReference = null; //customer's targeted gameobject
	public List<int> customerObjReferenceID = null; //customer's targeted object id
	public List<int> customerReferenceID = null; //customer's individual id number
	public List<int> customerStatus = null; //check if customer request is completed
	
	public float customerWalkingSpeed;
	
	public bool isFull;
	
	public int Rand;
	
	public int maxWave;
	private int waveCount;
	
	public int randWaveCust; // random customer / wave
	
	public int minCustRandom; // minimum jumlah customer
	public int maxCustRandom; // maksimum jumlah customer
	
	public float delaySpawn;
	
	//cashier
	private int totalCustomerAtCashier = 0;
	private List<GameObject> cashierCustomerArr = null;
	private int cashierQueueTileY = 0;
	private int cashierQueueTileX = 0;
	
	private float SpawnSpeed;
	
	// Use this for initialization
	void Start () {
		isFull = false;
		minCustRandom = 2;
		maxCustRandom = 10;
		maxWave = Main.MySpawn.myMaxWave;
		delaySpawn = Main.MySpawn.reduceDelaySpawn;
		waveCount = 0;
		
		randWaveCust = Random.Range(minCustRandom + 10, maxCustRandom + 10);
		
		SpawnSpeed = 9 - (Main.MyPlayerAtr.ReturnHotelRank() + delaySpawn);
		InvokeRepeating("SpawnCustEnterFrame",0.1f,SpawnSpeed);
		
	}
	public void Reset()
	{
		CancelInvoke("SpawnCustEnterFrame");
		for(int i=0;i<customerList.Count;i++)
		{
			if(customerList[i] != null)
			{
				CustomerAtr MyCA = (CustomerAtr)customerList[i].GetComponent("CustomerAtr");
				MyCA.Clear ();
			}
		}
		customerList = null;
		customerObjReference = null;
		customerObjReferenceID = null;
		customerReferenceID = null;
		customerStatus = null;
		customerWalkingSpeed = 0.0f;
		totalCustomerAtCashier = 0;
		cashierCustomerArr = null;
		cashierQueueTileY = 0;
		cashierQueueTileX = 2;
	}
	
	public void Init()
	{
		//Main.MySpawn.Init();
		customerList = new List<GameObject>();
		customerObjReference = new List<GameObject>();
		customerObjReferenceID = new List<int>();
		customerReferenceID = new List<int>();
		customerStatus = new List<int>();
		customerWalkingSpeed = Main.MySpawn.myCustomerSpeed;
				
		//cashier
		cashierCustomerArr = new List<GameObject>();
		cashierQueueTileY = 9;
		cashierQueueTileX = 2;
			
		
	}
	
	private void SpawnCustEnterFrame()
	{
		List<Hashtable> ModuleClassArr = Main.MyModuleClass.GetModuleClassArrByType("nQ");
		List<int> QueueUpIntList = Main.MyPlayerAtr.ReturnQueueUpLevelFull();
		
		for(int i = 0; i<QueueUpIntList.Count; i++)
		{
			if(QueueUpIntList[i] != 0)
			{
				print ("Name: "+(string)ModuleClassArr[i]["Name"]);
				if((int)ModuleClassArr[i]["Occupy"] == 0)
				{
					spawnCustomer();
					break;
				}
			}
		}	
	}
	
	private void SpawnNewCustEnterFrame()
	{
		List<Hashtable> ModuleClassArr = Main.MyModuleClass.GetModuleClassArrByType("nQ");
		List<int> QueueUpIntList = Main.MyPlayerAtr.ReturnQueueUpLevelFull();
		
		for(int i = 0; i<QueueUpIntList.Count; i++)
		{
			if(QueueUpIntList[i] != 0)
			{
				print ("Name: "+(string)ModuleClassArr[i]["Name"]);
				if((int)ModuleClassArr[i]["Occupy"] == 0)
				{
					spawnCustomer();
					break;
				}
			}
		}	
	}

	private void spawnCustomer()
	{
		GameObject CustomerObject;
		
		
		InvokeRepeating("MyRandom", 1.001f, 0.00002f);
		
			//CustomerObject =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/CustomerPrefab" + Rand.ToString()));
		if(Rand == 1 && Main.MySpawn.normalCount < Main.MySpawn.maxNormalCustomerSize)
		{
			CustomerObject = (GameObject)Instantiate((GameObject)Resources.Load("Prefabs/CustomerPrefab1"));
			CustomerObject.name = "Customer"+customerReferenceID.Count;
			Main.AddParent(CustomerObject);
			CustomerObject.transform.localPosition = new Vector3(680 - Res.DefaultWidth()/2, -60 + Res.DefaultHeight()/2 ,0);
			CustomerObject.transform.localScale = new Vector3(50,64,1);
			customerList.Add (CustomerObject);
			customerReferenceID.Add (customerReferenceID.Count);
			customerStatus.Add (0);
			moveCustomerToQueue(CustomerObject);
			
			Main.MySpawn.normalCount++;
			Main.MySpawn.myNormalCount++;
		}
		else if(Main.MySpawn.normalCount > Main.MySpawn.maxNormalCustomerSize-1)
		{
			InvokeRepeating("MyRandom", 0.001f, 0.00002f);
		}
		
		if(Rand == 2 && Main.MySpawn.vipCount < Main.MySpawn.maxVipCustomerSize)
		{
			CustomerObject = (GameObject)Instantiate((GameObject)Resources.Load("Prefabs/CustomerPrefab2"));
			CustomerObject.name = "Customer"+customerReferenceID.Count;
			Main.AddParent(CustomerObject);
			CustomerObject.transform.localPosition = new Vector3(680 - Res.DefaultWidth()/2, -60 + Res.DefaultHeight()/2 ,0);
			CustomerObject.transform.localScale = new Vector3(50,64,1);
			customerList.Add (CustomerObject);
			customerReferenceID.Add (customerReferenceID.Count);
			customerStatus.Add (0);
			moveCustomerToQueue(CustomerObject);
			
			Main.MySpawn.vipCount++;
			Main.MySpawn.myVipCount++;
		}
		else if(Main.MySpawn.vipCount > Main.MySpawn.maxVipCustomerSize-1)
		{
			InvokeRepeating("MyRandom", 0.001f, 0.00002f);
		}
		
		if(Rand == 3 && Main.MySpawn.shortTCount < Main.MySpawn.maxShortTCustomerSize)
		{
			CustomerObject = (GameObject)Instantiate((GameObject)Resources.Load("Prefabs/CustomerPrefab3"));
			CustomerObject.name = "Customer"+customerReferenceID.Count;
			Main.AddParent(CustomerObject);
			CustomerObject.transform.localPosition = new Vector3(680 - Res.DefaultWidth()/2, -60 + Res.DefaultHeight()/2 ,0);
			CustomerObject.transform.localScale = new Vector3(50,64,1);
			customerList.Add (CustomerObject);
			customerReferenceID.Add (customerReferenceID.Count);
			customerStatus.Add (0);
			moveCustomerToQueue(CustomerObject);
			
			Main.MySpawn.shortTCount++;
			Main.MySpawn.myShortTCount++;
		}
		else if(Main.MySpawn.shortTCount > Main.MySpawn.maxShortTCustomerSize-1)
		{
			InvokeRepeating("MyRandom", 0.001f, 0.00002f);
		}
		
		if(Rand == 4 && Main.MySpawn.casualCount < Main.MySpawn.maxCasualCustomerSize)
		{
			CustomerObject = (GameObject)Instantiate((GameObject)Resources.Load("Prefabs/CustomerPrefab4"));
			CustomerObject.name = "Customer"+customerReferenceID.Count;
			Main.AddParent(CustomerObject);
			CustomerObject.transform.localPosition = new Vector3(680 - Res.DefaultWidth()/2, -60 + Res.DefaultHeight()/2 ,0);
			CustomerObject.transform.localScale = new Vector3(50,64,1);
			customerList.Add (CustomerObject);
			customerReferenceID.Add (customerReferenceID.Count);
			customerStatus.Add (0);
			moveCustomerToQueue(CustomerObject);
			
			Main.MySpawn.casualCount++;
			Main.MySpawn.myCasualCount++;
		}
		else if(Main.MySpawn.casualCount > Main.MySpawn.maxCasualCustomerSize-1)
		{
			InvokeRepeating("MyRandom", 0.001f, 0.00002f);
		}
		
			
		
		//0, 17
		//CustomerObject.AddComponent("CustomerAtr");
		//CustomerObject.AddComponent("CusstomerBehaviour");
		
		
			
		//CustomerObject.transform.Rotate(0,0,180);
		
	
		/*
		Transform SpriteAnim = CustomerObject.transform.Find("SpriteAnim");
		int Rand = Random.Range(1, 4);
		print ("texture "+Rand);
		//print ("Materials/Clients/Customer "+Rand.ToString()/Customer "+Rand.ToString());
		Material MyBmp = (Material)Resources.Load ("Materials/Client/Customer1/Customer1.mat");
		SpriteAnim.renderer.material = MyBmp;
		*/
		//moveCustomerToCashier(CustomerObject);
		//Debug.Log("CustomerObject.name "+CustomerObject.name);
		
	}
	//public GameObject GetCustomerObjectData(GameObject customerObj)
	//{
	//	GameObject tempCustomerObj = null;
		
	//	for(int i=0;i<customerList.Count;i++)
	//	{
	//		if(customerObj == customerList[i])
	//		{
	//			tempCustomerObj = 
	//		}
	//	}
	//	return tempCustomerObj;
	//}
	public void SetCustomerWaitingTime(GameObject customerObj, float waitingTime, int completeType)
	{
		GameObject tempCustomerObj = customerObj;
		CustomerBehaviour MyCB = (CustomerBehaviour)tempCustomerObj.GetComponent("CustomerBehaviour");
		MyCB.SetCustomerTime(waitingTime, completeType);
	}
	
	public int GetCustomerCount()
	{
		int customerCount = customerList.Count;
		return customerCount;
	}
	
	public int GetCustomerObject(GameObject customerObj)
	{
		int tempCustomerStatus = 0;
		
		for(int i=0;i<customerList.Count;i++)
		{
			if(customerObj == customerList[i])
			{
				tempCustomerStatus =  customerStatus[i];
				//break;
			}
		}
		return tempCustomerStatus;
	}
	
	public GameObject GetCustomerObjByPos(Vector3 customerPost)
	{
		GameObject tempCustomerObj = null;
		
		for(int i=0;i<customerList.Count;i++)
		{
			if(customerList[i].transform.localPosition.x == customerPost.x && customerList[i].transform.localPosition.y == customerPost.y)
			{
				tempCustomerObj = customerList[i];
				break;
			}
		}
		
		return tempCustomerObj;
	}
	
	
	
	public int GetCustomerStatus(GameObject customerObj)
	{
		int tempCustomerStatus = 0;
		
		for(int i=0;i<customerList.Count;i++)
		{
			if(customerObj == customerList[i])
			{
				tempCustomerStatus =  customerStatus[i];
				break;
			}
		}
		return tempCustomerStatus;
	}
	public void SetCustomerStatus(GameObject CustomerObj, bool onCompleted)
	{
		for(int i=0;i<customerList.Count;i++)
		{
			if(CustomerObj == customerList[i])
			{
				if(onCompleted)
				{
					customerStatus[i] = 0;
				} else {
					customerStatus[i] = 1;
				}
				break;
			}
		}
	}
	//cashier functions
	public void moveCustomerToCashier(GameObject CustomerObject)
	{
		if(cashierCustomerArr.Count < 3)
		{
			isFull = false;
			Main.MyTile.findPosition(CustomerObject, customerWalkingSpeed, cashierQueueTileY-cashierCustomerArr.Count, cashierQueueTileX);
			//SetCustomerStatus(
			cashierCustomerArr.Add (CustomerObject);
			Main.MyModuleClass.SetOccupy("nC", 0 , "+");
		
		CustomerBehaviour MyCB = (CustomerBehaviour)CustomerObject.GetComponent("CustomerBehaviour");
		MyCB.ActionType = "Cashier";
		}
		else if(cashierCustomerArr.Count >=3)
		{
			isFull = true;
			Debug.LogWarning("Poll");
			//Main.MyTile.findPosition(CustomerObject, customerWalkingSpeed, cashierQueueTileY-5, cashierQueueTileX+2);
		//	Main.MyCustomerAttribute.CurrentWaitingTime = 0;
			//SetCustomerStatus(
			
		}
		
	}
	
	public void removeCustomerFromList()
	{
		
		cashierCustomerArr.RemoveAt (0);
		refreshCustomerCashierQueue();
	}
	
	private void refreshCustomerCashierQueue()
	{
		for(int i=0;i<cashierCustomerArr.Count;i++)
		{
			Main.MyTile.findPosition(cashierCustomerArr[i], customerWalkingSpeed, cashierQueueTileY-i, cashierQueueTileX);
			//Main.MyModuleClass.SetOccupy("nC", 0 , "+");
		}
	}
	//queue up functions
	private void moveCustomerToQueue(GameObject CustomerObject)
	{
		//move customer to nodeQueue when first spawn
		Hashtable moduleDataHash = Main.MyModuleClass.SetAutoOccupy("nQ");
		
		Main.MyTile.findPosition(CustomerObject, customerWalkingSpeed, (int)moduleDataHash["secondaryY"], (int)moduleDataHash["secondaryX"]);
		
		GameObject tempObjReference = GameObject.Find ((string)moduleDataHash["Name"]);
		customerObjReference.Add (tempObjReference);
		customerObjReferenceID.Add ((int)moduleDataHash["ID"]);
		
		CustomerBehaviour MyCB = (CustomerBehaviour)CustomerObject.GetComponent("CustomerBehaviour");
		MyCB.ActionType = "Queue";
		//set customer type to queue for tweenComplete param
	}
	public void checkAction(int customerId)
	{	
		CustomerAtr MyCA = (CustomerAtr)customerList[customerId].GetComponent("CustomerAtr");
		CustomerBehaviour MyCB = (CustomerBehaviour)customerList[customerId].GetComponent("CustomerBehaviour");
		switch(MyCB.ActionType)
		{
			case "Queue":
				customerList[customerId].transform.localPosition = new Vector3(customerObjReference[customerId].transform.localPosition.x, customerObjReference[customerId].transform.localPosition.y, customerObjReference[customerId].transform.localPosition.z - 1);
				refreshCustomerCashierQueue();
				MyCA.StartQueueUp(Main.MyStatCheck.GetQueueUpStatByLevel(Main.MyPlayerAtr.ReturnQueueUpLevel(customerObjReferenceID[customerId])));
			break;
			case "Cashier":
				MyCA.AssignStation("nC",Main.MyStatCheck.GetCashierStatByLevel(Main.MyPlayerAtr.ReturnCashierLevel()));
			break;
		}
		
	}
	
	//angry runaway functions
	public void runAway(GameObject runawayCustomerObj)
	{
		for(int i=0;i<customerList.Count;i++)
		{
			if(customerList[i] == runawayCustomerObj)
			{
				Main.MyTile.findPosition(customerList[i], customerWalkingSpeed, 1, 17);
				float walkingTime = timeToReach();
				CustomerAtr MyCA = (CustomerAtr)customerList[i].GetComponent("CustomerAtr");
				MyCA.SetTimeToClear(walkingTime);
				if(MyCA.ReturnRequest() != "nC")
				{
					Vector3 tilePos = convertPosToTile(customerList[i]);
					Hashtable moduleDataHash = Main.MyModule.GetDataByPrimaryPos((int)tilePos.y, (int)tilePos.x);
					Main.MyModuleClass.SetOccupy((string)moduleDataHash["Type"], (int)moduleDataHash["ID"], "-"); 
				} else {
					print ("REMOVING CUSTOMER FROM LIST");
					
					removeCustomerFromList();
				}
			}
		}
	}
	public void destroyCustomer(GameObject destroyCustomerObj)
	{
		
		for(int i=0;i<customerList.Count;i++)
		{
			if(customerList[i] == destroyCustomerObj)
			{
				Destroy (destroyCustomerObj);
				customerList.RemoveAt(i);
				customerObjReference.RemoveAt(i);
				customerObjReferenceID.RemoveAt(i);
				break;				
			}
		}
	}
	
	public void destroyAllCustomer()
	{
		for(int i = 0; i<customerList.Count;i++)
		{
				Destroy(customerList[i]);
		}
	}

	private float timeToReach()
	{
		float tileWalkingTime = customerWalkingSpeed * Main.MyTile.TotalPath;
		
		return tileWalkingTime;
	}
	
	private Vector3 convertPosToTile(GameObject currentObj)
	{		
		float tempY = (currentObj.transform.localPosition.y - Res.DefaultHeight() / 2)/TileArray.tileHeight;
		float tempX = (currentObj.transform.localPosition.x + Res.DefaultWidth() / 2 )/TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
					
		Vector3 tilePos = new Vector3(tileX, tileY, currentObj.transform.localPosition.z);
		return tilePos;
	}
	
	//private void Reset()
	//{
	//	customerList = null;
	//	customerObjReference = null;
	//}
	// Update is called once per frame
	void Update()
	{
		
		if(Main.MySpawn.normalCount >= Main.MySpawn.maxNormalCustomerSize && Main.MySpawn.vipCount >= Main.MySpawn.maxVipCustomerSize && Main.MySpawn.shortTCount >= Main.MySpawn.maxShortTCustomerSize && Main.MySpawn.casualCount >= Main.MySpawn.maxCasualCustomerSize)
		{
			CancelInvoke("SpawnCustEnterFrame");
		}	
		
		if(waveCount == maxWave)
		{
			CancelInvoke("SpawnCustEnterFrame");
		}
		
		if(Main.MySpawn.tempTotalCust >= randWaveCust)
		{
			CancelInvoke("SpawnCustEnterFrame");
			if(customerList.Count == 0)
			{
				Main.MySpawn.myNormalCount = 0;
				Main.MySpawn.myVipCount = 0;
				Main.MySpawn.myShortTCount = 0;
				Main.MySpawn.myCasualCount = 0;
				Main.MySpawn.tempTotalCust = 0;
				randWaveCust = 0;	
				InvokeRepeating("SpawnCustEnterFrame",0.1f,SpawnSpeed);
				if(randWaveCust == 0)
				{
					randWaveCust = Random.Range(minCustRandom, maxCustRandom);
					AddWaveCount(1);
				}
			}	
		}
	}
	
	private void AddWaveCount(int myAdd = 1)
	{
		waveCount += myAdd;
	}
	
	private void MyRandom()
	{
		Rand = Random.Range(1, 6);
	}
}
