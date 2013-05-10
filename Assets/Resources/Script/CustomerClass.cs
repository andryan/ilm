using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//@ Author: Blooded
//this class this to be change to using hashtags instead of many listArrays and convert the data into customer behaviour class instead of for looping to control
public class CustomerClass : MonoBehaviour {
	
	public List<GameObject> customerList = null; //customer's game objects
	public List<GameObject> customerObjReference = null; //customer's targeted gameobject
	public List<int> customerObjReferenceID = null; //customer's targeted object id
	public List<int> customerReferenceID = null; //customer's individual id number
	public List<int> customerStatus = null; //check if customer request is completed
	
	private float customerWalkingSpeed = 0.0f;
	
	//cashier
	private int totalCustomerAtCashier = 0;
	private List<GameObject> cashierCustomerArr = null;
	private int cashierQueueTileY = 0;
	private int cashierQueueTileX = 0;
	
	private float SpawnSpeed = 0.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	public void Reset()
	{
		CancelInvoke("SpawnCustEnterFrame");
		for(int i=0;i<customerList.Count;i++)
		{
			CustomerAtr MyCA = (CustomerAtr)customerList[i].GetComponent("CustomerAtr");
			MyCA.Clear ();
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
		cashierQueueTileX = 0;
		
	}
	public void Init()
	{
		customerList = new List<GameObject>();
		customerObjReference = new List<GameObject>();
		customerObjReferenceID = new List<int>();
		customerReferenceID = new List<int>();
		customerStatus = new List<int>();
		
		customerWalkingSpeed = 0.3F;
		
		//cashier
		cashierCustomerArr = new List<GameObject>();
		cashierQueueTileY = 9;
		cashierQueueTileX = 3;
		
		SpawnSpeed = 10 - 1.17f*Main.MyPlayerAtr.ReturnHotelRank();
		
		InvokeRepeating("SpawnCustEnterFrame",0f,SpawnSpeed);
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
	
	private void SetCustomerSpawnTime()
	{
		
	}
	
	private void spawnCustomer()
	{
		GameObject CustomerObject;
		
		CustomerObject =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/CustomerPrefab"));
		CustomerObject.name = "Customer"+customerReferenceID.Count;
		//0, 17
		CustomerObject.AddComponent("CustomerAtr");
		CustomerObject.AddComponent("CustomerBehaviour");
		
		//CustomerObject.transform.Rotate(0,0,180);
		CustomerObject.transform.position = new Vector3(680, -60 ,0);
		customerList.Add (CustomerObject);
		customerReferenceID.Add (customerReferenceID.Count);
		customerStatus.Add (0);
	
		Transform SpriteAnim = CustomerObject.transform.Find("SpriteAnim");
		int Rand = Random.Range(1, 4);
		print ("texture "+Rand);
		//print ("Materials/Clients/Customer "+Rand.ToString()/Customer "+Rand.ToString());
		Material MyBmp = (Material)Resources.Load ("Materials/Client/Customer2/Customer2");
		SpriteAnim.renderer.material = MyBmp;
		
		//moveCustomerToCashier(CustomerObject);
		print ("CustomerObject.name "+CustomerObject.name);
		moveCustomerToQueue(CustomerObject);
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
			if(customerList[i].transform.position.x == customerPost.x && customerList[i].transform.position.y == customerPost.y)
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
		Main.MyTile.findPosition(CustomerObject, customerWalkingSpeed, cashierQueueTileY-cashierCustomerArr.Count, cashierQueueTileX);
		//SetCustomerStatus(
		cashierCustomerArr.Add (CustomerObject);
		Main.MyModuleClass.SetOccupy("nC", 0 , "+");
		
		CustomerBehaviour MyCB = (CustomerBehaviour)CustomerObject.GetComponent("CustomerBehaviour");
		MyCB.ActionType = "Cashier";
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
				customerList[customerId].transform.position = new Vector3(customerObjReference[customerId].transform.position.x, customerObjReference[customerId].transform.position.y, customerObjReference[customerId].transform.position.z - 1);
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
	private float timeToReach()
	{
		float tileWalkingTime = customerWalkingSpeed * Main.MyTile.TotalPath;
		
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
	
	//private void Reset()
	//{
	//	customerList = null;
	//	customerObjReference = null;
	//}
	// Update is called once per frame
	void Update () {
		
	}
}
