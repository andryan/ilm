using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModuleClass : MonoBehaviour {

	// Use this for initialization
	//int waitingTime;
	private List<Hashtable> ModuleClassArray = null;
	private List<Hashtable> ModuleDataArray = null;
	private List<GameObject> moduleList = null;
	
	private List<int> QueueUpIntList = null;
	private List<int> FoodIntList = null;
	private List<int> TDisplayIntList = null;
	private List<int> BarIntList = null;
		
	void Start () {
	}
	public void Reset()
	{
		for(int i = 0;i<moduleList.Count;i++)
		{
			Destroy(moduleList[i]);
		}
		ModuleClassArray = null;
		ModuleDataArray = null;
		QueueUpIntList = null;
		FoodIntList = null;
		TDisplayIntList = null;
		BarIntList = null;
		moduleList = null;
	}
	public void Init()
	{
		moduleList = new List<GameObject>();
		ModuleDataArray = Main.MyModule.GetModuleList();
		ModuleClassArr();
		
		QueueUpIntList = new List<int>();
		FoodIntList = new List<int>();
		TDisplayIntList = new List<int>();
		BarIntList = new List<int>();
		
		QueueUpIntList = Main.MyPlayerAtr.ReturnQueueUpLevelFull();
		FoodIntList = Main.MyPlayerAtr.ReturnFoodLevelFull();
		TDisplayIntList = Main.MyPlayerAtr.ReturnTDisplayLevelFull();
		BarIntList = Main.MyPlayerAtr.ReturnBarLevelFull();
		
		SpawnModule(QueueUpIntList, "nQ");
		SpawnModule(FoodIntList, "nF");
		SpawnModule(BarIntList, "nB");
		SpawnModule(TDisplayIntList, "nTD");
		
	}
	private void SpawnModule(List<int> ModuleIntList, string ModuleType)
	{
		for(int i=0;i<ModuleIntList.Count;i++)
		{
			if(ModuleIntList[i] != 0)
			{
				GameObject ModuleObject = null;// = new GameObject();
				Hashtable ModuleHashData = new Hashtable();
				
				
				if(ModuleType == "nQ")
				{
					int currQueueLvl = Main.MyPlayerAtr.ReturnQueueUpLevel(i);
					ModuleHashData = Main.MyModule.GetDataByIDAndType(i, ModuleType);
					ModuleObject =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/QueueUpPrefab"));
					Transform SpriteAnimObj = ModuleObject.transform.Find("queueArt");
					//sAnim = (SpriteAnimator)SpriteAnimObj.GetComponent("SpriteAnimator");
					Material MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/QueueUpLv"+currQueueLvl);
					SpriteAnimObj.renderer.material = MyBmp;
				} 
				else if(ModuleType == "nF")
				{
					int currFoodLvl = Main.MyPlayerAtr.ReturnFoodLevel(i);
					ModuleHashData = Main.MyModule.GetDataByIDAndType(i, ModuleType);
					ModuleObject =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/FoodPrefab"));
					Transform SpriteAnimObj = ModuleObject.transform.Find("FoodArt");
					//sAnim = (SpriteAnimator)SpriteAnimObj.GetComponent("SpriteAnimator");
					Material MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/FoodLv"+currFoodLvl);
					SpriteAnimObj.renderer.material = MyBmp;
				}
				else if(ModuleType == "nB")
				{
					int currBarLvl = Main.MyPlayerAtr.ReturnBarLevel(i);
					ModuleHashData = Main.MyModule.GetDataByIDAndType(i, ModuleType);
					ModuleObject =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/BarPrefab"));
					Transform SpriteAnimObj = ModuleObject.transform.Find("BarChairArt");
					//sAnim = (SpriteAnimator)SpriteAnimObj.GetComponent("SpriteAnimator");
					Material MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/BarLv"+currBarLvl);
					SpriteAnimObj.renderer.material = MyBmp;
				}
				else if(ModuleType == "nTD")
				{
					int currTDLvl = Main.MyPlayerAtr.ReturnTDisplayLevel(i);
					ModuleHashData = Main.MyModule.GetDataByIDAndType(i, ModuleType);
					ModuleObject =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/TDisplayPrefab"));
					Transform SpriteAnimObj = ModuleObject.transform.Find("TDisplayArt");
					//sAnim = (SpriteAnimator)SpriteAnimObj.GetComponent("SpriteAnimator");
					Material MyBmp = (Material)Resources.Load ("PlanAndManage/Materials/TDisplayLv"+currTDLvl);
					SpriteAnimObj.renderer.material = MyBmp;
				}

				Main.AddParent(ModuleObject);
				Vector3 tempModulePost = convertTileToPos(new Vector3((int)ModuleHashData["primaryX"],(int)ModuleHashData["primaryY"],(int)ModuleHashData["primaryZ"]));
				ModuleObject.name = (string)ModuleHashData["Name"];
				ModuleObject.transform.localPosition = tempModulePost;
				ModuleObject.transform.localScale = new Vector3(50,64,0.1f);
				moduleList.Add (ModuleObject);
			}
		}
	}
	/*private void SpawnHelper()
	{		
		for(int i=0;i<HelperIntList.Count;i++)
		{
			if(HelperIntList[i] != 0)
			{
				GameObject HelperObject;
				Hashtable HelperHashData = Main.MyStatCheck.GetHelperStatByID(HelperIntList[i]);
				Hashtable HelperClassData = getHelperClassArrByID(HelperIntList[i]);
				
				HelperObject =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/HelperPrefab"));
				HelperObject.AddComponent("HelperBehaviour");
				
				HelperBehaviour MyHB = (HelperBehaviour)HelperObject.GetComponent("HelperBehaviour");
				MyHB.SetValue(HelperHashData);
				
				Vector3 ObjPosition = convertTileToPos((Vector3)HelperClassData["Post"]);
				HelperObject.transform.position = ObjPosition;
				
				Transform SpriteAnim = HelperObject.transform.Find("SpriteAnim");
				Material MyBmp = (Material)Resources.Load ("Materials/Helper/Helper"+HelperIntList[i].ToString()+"/Helper"+HelperIntList[i].ToString ());
				SpriteAnim.renderer.material = MyBmp;
				
				HelperClassArr[i]["HelperObj"] = HelperObject;
			}	
		}
	}*/
	private void ModuleClassArr()
	{
		ModuleClassArray = new List<Hashtable>();
		//nodeQueue
		ModuleClassArray.Add (HashObject.Hash ("Name", "nQ_0", "Type", "nQ", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nQ_1", "Type", "nQ", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nQ_2", "Type", "nQ", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nQ_3", "Type", "nQ", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nQ_4", "Type", "nQ", "Occupy", 0, "customerID", 0, "Helper", 0));
		//nodeTalentDisplay
		ModuleClassArray.Add (HashObject.Hash ("Name", "nTD_0", "Type", "nTD", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nTD_1", "Type", "nTD", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nTD_2", "Type", "nTD", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nTD_3", "Type", "nTD", "Occupy", 0, "customerID", 0, "Helper", 0));
		//nodeFood
		ModuleClassArray.Add (HashObject.Hash ("Name", "nF_0", "Type", "nF", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nF_1", "Type", "nF", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nF_2", "Type", "nF", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nF_3", "Type", "nF", "Occupy", 0, "customerID", 0, "Helper", 0));
		//nodeBar
		ModuleClassArray.Add (HashObject.Hash ("Name", "nB_0", "Type", "nB", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nB_1", "Type", "nB", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nB_2", "Type", "nB", "Occupy", 0, "customerID", 0, "Helper", 0));
		ModuleClassArray.Add (HashObject.Hash ("Name", "nB_3", "Type", "nB", "Occupy", 0, "customerID", 0, "Helper", 0));
		//nodeCashier
		ModuleClassArray.Add (HashObject.Hash ("Name", "nC_0", "Type", "nC", "Occupy", 0, "customerID", 0, "Helper", 0));
	}

	// Update is called once per frame
	void Update () {
	}
	
	//getter setter
	public Hashtable GetDataByName(string MyName)
	{
		Hashtable MyHash = new Hashtable();
		for(int b=0;b<ModuleClassArray.Count;b++)
		{
			if(MyName == (string)ModuleClassArray[b]["Name"])
			{
				MyHash = (Hashtable)ModuleClassArray[b].Clone ();
				break;
			} 
		}
		return MyHash;
	}
	
	public Hashtable GetDataByPos(int tileY, int tileX)
	{
		Hashtable MyHash = new Hashtable();
		for(int b=0;b<ModuleClassArray.Count;b++)
		{
			if((int)ModuleDataArray[b]["primaryY"]== tileY && (int)ModuleDataArray[b]["primaryX"]== tileX)
			{
				MyHash = (Hashtable)ModuleClassArray[b].Clone ();
				break;
			} 
		}
		return MyHash;
	}
	
	public void SetDataByPos(int tileY, int tileX, Hashtable MyHash)
	{
		for(int b=0;b<ModuleClassArray.Count;b++)
		{
			if((int)ModuleDataArray[b]["primaryY"]== tileY && (int)ModuleDataArray[b]["primaryX"]== tileX)
			{
				MyHash = (Hashtable)ModuleClassArray[b];
				break;
			} 
		}
	}
	
	public void SetHelperStatus(string moduleName, int statusType)
	{
		for(int b=0;b<ModuleClassArray.Count;b++)
		{
			if(moduleName == (string)ModuleClassArray[b]["Name"])
			{
				if(statusType == 1)
				{
					ModuleClassArray[b]["Helper"] = 1;
				}else {
					ModuleClassArray[b]["Helper"] = 0;
				}
				break;
			} 
		}
	}
	
	public List<Hashtable> GetModuleClassArrByType(string MyType)
	{
		List<Hashtable> tempModuleArr  = new List<Hashtable>();
		
		for(int i = 0; i<ModuleClassArray.Count; i++)
		{
			if(ModuleClassArray[i]["Type"] == MyType)
			{
				Hashtable tempArr = ModuleClassArray[i];
				tempModuleArr.Add (tempArr);
			}
		}
		return tempModuleArr;
	}
	
	public List<Hashtable> GetModuleClassArr()
	{
		return ModuleClassArray;
	}
	
	public Hashtable GetModuleClassHash(GameObject referenceObj)
	{
		float tempY = (referenceObj.gameObject.transform.localPosition.y - Res.DefaultHeight()/2)/TileArray.tileHeight;
		float tempX = (referenceObj.gameObject.transform.localPosition.x + Res.DefaultWidth()/2)/TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
		
		Hashtable moduleClassHash = GetDataByPos(tileY, tileX);
		
		return moduleClassHash;
	}
	
	public Hashtable SetAutoOccupy(string moduleType)
	{
		Hashtable MyHash = new Hashtable();
		for(int b=0;b<ModuleClassArray.Count;b++)
		{
			if((string)ModuleClassArray[b]["Type"] == moduleType)
			{
				if((int)ModuleClassArray[b]["Occupy"]== 0)
				{
					print ("OREDI SET TO OCCUPY");
					ModuleClassArray[b]["Occupy"] = 1;
					MyHash = (Hashtable)ModuleDataArray[b].Clone ();
					break;
				} 
			}
			
		}
		return MyHash;
	}

	//By : Sakti Sarjono 18 April 2013
	public bool isOccupied(string moduleType, int nodeId)
	{
		for(int i=0;i<ModuleClassArray.Count;i++)
		{
			//check for correct moduleType
			if((string)ModuleDataArray[i]["Type"] == moduleType)
			{
				//check for correct id
				if((int)ModuleDataArray[i]["ID"]== nodeId)
				{
					if((int)ModuleClassArray[i]["Occupy"] == 1)
						return true;
					else
						return false;
				} 
			}
		}
		return true;
	}

	
	public void SetOccupy( string moduleType, int nodeId, string occupyType)
	{
		Hashtable MyHash = new Hashtable();
		for(int i=0;i<ModuleClassArray.Count;i++)
		{
			//check for correct moduleType
			if((string)ModuleDataArray[i]["Type"] == moduleType)
			{
				//check for correct id
				if((int)ModuleDataArray[i]["ID"]== nodeId)
				{
					//check if module is being used
					switch(occupyType)
					{
						case "+":
							if((int)ModuleClassArray[i]["Occupy"]== 0)
							{
								ModuleClassArray[i]["Occupy"] = 1;
							//print ("OREDI TURN TO OCCUPY");
								//ModuleClassArray[i]["customerID"] = customerId;
							} 
						break;
						case "-":
							if((int)ModuleClassArray[i]["Occupy"]== 1)
							{
								ModuleClassArray[i]["Occupy"] = 0;
								//ModuleClassArray[i]["customerID"] = 0;
							} 
						break;
					}
					
				} 
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
}
