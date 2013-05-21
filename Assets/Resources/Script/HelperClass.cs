using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
//@ Author: Blooded - revised

public class HelperClass : MonoBehaviour {
	
	//temp var 
	private List<Hashtable> ModuleDataArr =  null; //temp var for moduleData info
	private List<int> HelperIntList = null; // temp var for avalaible helperList from kaizer class
	private List<int> HelperID = null;
	private List<int> HelperDistanceVal = null;
	
	//class var
	public List<Hashtable> HelperClassArr =  null;
	private List<GameObject> helperList = null;
	
	void Start () {
		//Init ();
	}
	
	public void Reset()
	{
		for(int i = 0;i<helperList.Count;i++)
		{
			Destroy(helperList[i]);
		}
		ModuleDataArr = null;
		HelperIntList = null;
		HelperID = null;
		HelperDistanceVal = null;
		HelperClassArr = null;
		helperList = null;
	}
	public void Init() {
		ModuleDataArr =  new List<Hashtable>();
		HelperIntList = new List<int>();
		helperList = new List<GameObject>();
		ModuleDataArr = Main.MyModule.GetModuleList(); //get static moduleData info
		HelperIntList = Main.MyPlayerAtr.ReturnHelperFull(); //get total of avalailable helper from kaizer's class
		HelperClassInfo(); //declare helper class hashtable info
		SpawnHelper();
	}
	
	private void SpawnHelper()
	{		
		for(int i=0;i<HelperIntList.Count;i++)
		{
			if(HelperIntList[i] != 0)
			{
				GameObject HelperObject;
				Hashtable HelperHashData = Main.MyStatCheck.GetHelperStatByID(HelperIntList[i]);
				Hashtable HelperClassData = getHelperClassArrByID(HelperIntList[i]);
				
				HelperObject =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/HelperPrefab"));
				Main.AddParent(HelperObject);
				HelperObject.AddComponent("HelperBehaviour");
				
				helperList.Add (HelperObject);
				HelperBehaviour MyHB = (HelperBehaviour)HelperObject.GetComponent("HelperBehaviour");
				MyHB.SetValue(HelperHashData);
				
				Vector3 ObjPosition = convertTileToPos((Vector3)HelperClassData["Post"]);
				HelperObject.transform.localPosition = ObjPosition;
				HelperObject.transform.localScale = new Vector3(50,64,0.1f);
				
				Transform SpriteAnim = HelperObject.transform.Find("SpriteAnim");
				print ("Materials/Helper/Helper"+HelperIntList[i].ToString()+"/Helper"+HelperIntList[i].ToString ());
				Material MyBmp = (Material)Resources.Load ("Materials/Helper/Helper"+HelperIntList[i].ToString()+"/Helper"+HelperIntList[i].ToString ());
				SpriteAnim.renderer.material = MyBmp;
				
				HelperClassArr[i]["HelperObj"] = HelperObject;
			}	
		}
	}
	
	public void InitHelper()
	{
		print ("CALLING HELPER");
		
		
		List<Vector3> tempUnservedPosition = GetTotalUnservedCustomerPosition();
		
		//test
		
		for(int b=0;b<tempUnservedPosition.Count;b++)
		{
			print("UNSERVE COOR: "+tempUnservedPosition[b]);
		}
		//------
		List<GameObject> SelectedHelperObj = null;

		for(int j=0;j<tempUnservedPosition.Count;j++)
		{
			HelperID = new List<int>();
			HelperDistanceVal = new List<int>();
			for(int i = 0; i<HelperClassArr.Count;i++)
			{
				if(HelperIntList[i] == (int)HelperClassArr[i]["ID"]) // check if helperClassData hash contains same helper id as array passed in by kaizer
				{
					GameObject currentHelperObj = (GameObject)HelperClassArr[i]["HelperObj"];
					HelperBehaviour MyHB = (HelperBehaviour)currentHelperObj.GetComponent("HelperBehaviour");
					
					Vector3  currHelperTilePost = convertPosToTile(currentHelperObj);
					
					CheckWithinRange(currentHelperObj, currHelperTilePost, (int)tempUnservedPosition[j].y, (int)tempUnservedPosition[j].x);	
				}
			}
			
			if(HelperDistanceVal.Count>0)
			{
				int min = HelperDistanceVal.Min ();
				for(int c=0;c<HelperDistanceVal.Count;c++)
				{
					print ("HelperDistanceVal[c "+HelperDistanceVal[c]);
					if(HelperDistanceVal[c] == min)
					{
						Hashtable currHelperArr = getHelperClassArrByID(HelperID[c]);
						GameObject currHelperObj = (GameObject)currHelperArr["HelperObj"];
						ActivateMovement(currHelperObj,(int)tempUnservedPosition[j].y, (int)tempUnservedPosition[j].x);
						break;
					}
				}
			}
			
			//int SelectedHelperID = GetHighestPriority(HelperID);
//			print ("SelectedHelperID SelectedHelperID SelectedHelperID "+SelectedHelperID);
			
			//if(SelectedHelperID != -1)
			//{
			////	Hashtable currHelperArr = getHelperClassArrByID(SelectedHelperID);
			//	GameObject currHelperObj = (GameObject)currHelperArr["HelperObj"];
			//	print ("helper id "+(int)currHelperArr["ID"]);
				
				//ActivateMovement(currHelperObj,(int)tempUnservedPosition[j].y, (int)tempUnservedPosition[j].x);
				
			//}
			HelperID = null;
			HelperDistanceVal = null;
		}
		tempUnservedPosition = null;
	}
	
	private void ActivateMovement(GameObject helperObj, int moduleY, int moduleX)
	{
		HelperBehaviour MyHB = (HelperBehaviour)helperObj.GetComponent("HelperBehaviour");
		
		if(MyHB.OnComplete == true)
		{
			MyHB.OnComplete  = false; //set current helper to be in use
			GetModuleInfo(moduleY, moduleX); // set current module helper status to 1
			
			Vector3 CurrentCustomerTilePost = Main.MyModule.GetPrimaryBySecondaryPost(moduleX, moduleY); //get primary tile position where the customer is situated
			Vector3 CurrentCustomerPost = convertTileToPos(CurrentCustomerTilePost); //convert primary tile position to coordinates
			
			GameObject CurrentCustomerObj = Main.MyCustomer.GetCustomerObjByPos(CurrentCustomerPost); //get current customer gameobject thru coordinates
			
			
			GameObject tempCustomerObj = Main.MyCustomer.GetCustomerObjByPos(CurrentCustomerPost);
			if(tempCustomerObj != null)
			{
				CustomerAtr MyCA = (CustomerAtr)tempCustomerObj.GetComponent("CustomerAtr");
				MyCA.Serving();
			}
				
			Main.MyTile.findPosition(helperObj, MyHB.HelperWalkingSpeed, moduleY, moduleX);
			float CustomerWaitingTime = MyHB.GetWaitingTime();
			print ("WAITING TIME : "+CustomerWaitingTime);
			print ("HELPERM CLASS");
			Main.MyCustomer.SetCustomerWaitingTime(CurrentCustomerObj,CustomerWaitingTime, 0);//init customer waiting time which disable customer dragging
			
			
		}
		
	}
	
	private void CheckWithinRange(GameObject currHelperObj, Vector3 currHelperTilePost = new Vector3(), int moduleY=0, int moduleX=0)
	{
		HelperBehaviour MyHB = (HelperBehaviour)currHelperObj.GetComponent("HelperBehaviour");
		
		if(MyHB.OnComplete == true)
		{
			for(int i = (int)currHelperTilePost.y-5; i<=(int)currHelperTilePost.y+5; i++)
			{
				for(int j = (int)currHelperTilePost.x-5; j<=(int)currHelperTilePost.x+5; j++)
				{
					if(j == moduleX && i == moduleY)
					{
						HelperID.Add (MyHB.ID);
						//21 May 2013 By Sakti Sarjono
						//Check by total Movement instead of absolute distance
						//int currDistanceVal = Mathf.Abs((int)currHelperTilePost.y - moduleY) + Mathf.Abs((int)currHelperTilePost.x - moduleX);
						int currDistanceVal = Main.MyTile.getTotalPath(currHelperObj, moduleX, moduleY);
						Debug.LogError("Total path : " + currDistanceVal);
						if(currDistanceVal == -1)
							Debug.LogError("Error total Path");
						else
							HelperDistanceVal.Add (currDistanceVal);
						break;
					}
				}
			}	
		}
	}
	
	
	private int GetHighestPriority(List<int> tempHelperPriority = null)
	{
		int highestPriorityHelperID = -1;
		
		if(tempHelperPriority != null)
		{
			if(tempHelperPriority.Count>0)
			{
			 	highestPriorityHelperID = tempHelperPriority.Max ();
			}	
		}
		
		
		
		return highestPriorityHelperID;
	}
	
	private void HelperClassInfo()
	{
		HelperClassArr = new List<Hashtable>();
		
		HelperClassArr.Add (HashObject.Hash("ID", 1, "HelperObj", null, "Post", new Vector3(15,4,0), "HelperStatus", 0));
		HelperClassArr.Add (HashObject.Hash("ID", 2, "HelperObj", null, "Post", new Vector3(5,7,0), "HelperStatus", 0));
		HelperClassArr.Add (HashObject.Hash("ID", 3, "HelperObj", null, "Post", new Vector3(6,9,0), "HelperStatus", 0));
		HelperClassArr.Add (HashObject.Hash("ID", 4, "HelperObj", null, "Post", new Vector3(9,9,0),  "HelperStatus", 0));
		HelperClassArr.Add (HashObject.Hash("ID", 5, "HelperObj", null, "Post", new Vector3(13,6,0),  "HelperStatus", 0));
		HelperClassArr.Add (HashObject.Hash("ID", 6, "HelperObj", null, "Post", new Vector3(13,8,0),  "HelperStatus", 0));
		HelperClassArr.Add (HashObject.Hash("ID", 7, "HelperObj", null, "Post", new Vector3(13,10,0),  "HelperStatus", 0));
		//HelperClassArr.Add (HashObject.Hash("ID", 8, "HelperObj", new GameObject(), "Post", new Vector3(13,8,0),  "HelperStatus", 0));
	}
//	
	
	//getter setter
	
	//Init Helper-
	//for loops moduleClassArr to check for occupied and unserved module - first step
	private List<Hashtable> GetTotalUnservedCustomer() 
	{
		List<Hashtable> TotalUnservedCustomerArr = new List<Hashtable>(); //local list hastable for current unserved customer
		List<Hashtable> ModuleClassArr = new List<Hashtable>(); //temp list hashtable for moduleClassArr
		
		ModuleClassArr = Main.MyModuleClass.GetModuleClassArr();
		for(int i=0;i<ModuleClassArr.Count;i++)
		{
			if((string)ModuleClassArr[i]["Type"] != "nQ" && (string)ModuleClassArr[i]["Type"] != "nC")
			{
				if((int)ModuleClassArr[i]["Helper"] == 0 && (int)ModuleClassArr[i]["Occupy"] == 1) //check for if module is occupied and not served by any helper
				{
					TotalUnservedCustomerArr.Add(ModuleClassArr[i]);
				}
			}
		}
		return TotalUnservedCustomerArr;
	}
	//for loops for comparing total unserved customer name with moduleDataArr to acquire secondary position - second step
	private List<Vector3> GetTotalUnservedCustomerPosition() 
	{
		//temp var
		List<Vector3> tempPosition = new List<Vector3>();
		
		//data var
		List<Hashtable> tempUnservedCustomerArr = GetTotalUnservedCustomer();
		
		for(int j = 0;j<tempUnservedCustomerArr.Count;j++)
		{
			for(int i = 0;i<ModuleDataArr.Count;i++)
			{
				if((string)tempUnservedCustomerArr[j]["Name"] == (string)ModuleDataArr[i]["Name"])
				{
					tempPosition.Add (new Vector3((int)ModuleDataArr[i]["secondaryX"], (int)ModuleDataArr[i]["secondaryY"], 0));
				}
			}
		}
		return tempPosition;
	}	
	//-----------------------------------------------------------------------
	public void GetModuleInfo(int moduleY, int moduleX)
	{
		Hashtable currentModuleData = Main.MyModule.GetDataBySecondaryPos(moduleY, moduleX);
		Main.MyModuleClass.SetHelperStatus((string)currentModuleData["Name"], 1);
	}
	
	private Hashtable getHelperClassArrByID(int ID)
	{
		Hashtable MyHash = new Hashtable();
		for(int a = 0;a<HelperClassArr.Count;a++)
		{
			if((int)HelperClassArr[a]["ID"] == ID)
			{
				MyHash = (Hashtable)HelperClassArr[a].Clone ();
				break;
			}
		}
		return MyHash;
	}
	
	//Tile Conversion-
	private Vector3 convertTileToPos(Vector3 tilePos)
	{
		float posX = tilePos.x * TileArray.tileWidth + (TileArray.tileWidth/2) - Res.DefaultWidth()/2;
		float posY = -tilePos.y * TileArray.tileHeight - (TileArray.tileHeight/2) + Res.DefaultHeight()/2;
		float posZ = 0;
		
		Vector3 currentPosition = new Vector3(posX, posY, posZ);
		return currentPosition;
	}
	
	private Vector3 convertPosToTile(GameObject currentObj)
	{		
		float tempY = (currentObj.transform.localPosition.y - Res.DefaultHeight()/2) /TileArray.tileHeight;
		float tempX = (currentObj.transform.localPosition.x + Res.DefaultWidth()/2) /TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
					
		Vector3 tilePos = new Vector3(tileX, tileY, 0);
		return tilePos;
	}
}
