using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//@ Author: Blooded

public class ModuleData : MonoBehaviour {
	
	private List<Hashtable> ModuleArray = null;

	private List<Hashtable> ModuleArea = null;
	// Use this for initialization
	void Start () {
		//Init();
	}
	public void Reset()
	{
		ModuleArray = null;
	}
	public void Init(){
		ModuleDataArr();
		generateArea();
	}

	private void generateArea()
	{
		ModuleArea = new List<Hashtable>();
		ModuleArea.Add(HashObject.Hash("AreaType", "nTD", "y1", 6, "x1", 7, "y2", 8, "x2", 11)); 
		ModuleArea.Add(HashObject.Hash("AreaType", "nF", "y1", 5, "x1", 15, "y2", 8, "x2", 17)); 
		ModuleArea.Add(HashObject.Hash("AreaType", "nB", "y1", 10, "x1", 7, "y2", 12, "x2", 11));
	}

	private void ModuleDataArr()
	{
		ModuleArray = new List<Hashtable>();
		//nodeQueue
		ModuleArray.Add (HashObject.Hash ("Name", "nQ_0", "Type", "nQ", "ID", 0, "primaryY", 3, "primaryX", 6, "primaryZ", -6, "secondaryY", 4, "secondaryX", 6));
		ModuleArray.Add (HashObject.Hash ("Name", "nQ_1", "Type", "nQ", "ID", 1, "primaryY", 3, "primaryX", 8, "primaryZ", -6, "secondaryY", 4, "secondaryX", 8));
		ModuleArray.Add (HashObject.Hash ("Name", "nQ_2", "Type", "nQ", "ID", 2, "primaryY", 3, "primaryX", 10, "primaryZ", -6, "secondaryY", 4, "secondaryX", 10));
		ModuleArray.Add (HashObject.Hash ("Name", "nQ_3", "Type", "nQ", "ID", 3, "primaryY", 3, "primaryX", 12, "primaryZ", -6, "secondaryY", 4, "secondaryX", 12));
		ModuleArray.Add (HashObject.Hash ("Name", "nQ_4", "Type", "nQ", "ID", 4, "primaryY", 3, "primaryX", 14, "primaryZ", -6, "secondaryY", 4, "secondaryX", 14));
		//ModuleArray.Add (HashObject.Hash ("Name", "nQ_5", "posY", 3, "posX", 14));
		//nodeTalentDisplay
		ModuleArray.Add (HashObject.Hash ("Name", "nTD_0", "Type", "nTD", "ID", 0, "primaryY", 8, "primaryX", 7, "primaryZ", -16, "secondaryY", 9, "secondaryX", 7));
		ModuleArray.Add (HashObject.Hash ("Name", "nTD_1", "Type", "nTD", "ID", 1, "primaryY", 8, "primaryX", 8, "primaryZ", -16, "secondaryY", 9, "secondaryX", 8));
		ModuleArray.Add (HashObject.Hash ("Name", "nTD_2", "Type", "nTD", "ID", 2, "primaryY", 8, "primaryX", 10, "primaryZ", -16, "secondaryY", 9, "secondaryX", 10));
		ModuleArray.Add (HashObject.Hash ("Name", "nTD_3", "Type", "nTD", "ID", 3, "primaryY", 8, "primaryX", 11, "primaryZ", -16, "secondaryY", 9, "secondaryX", 11));
		//nodeFood
		ModuleArray.Add (HashObject.Hash ("Name", "nF_0", "Type", "nF", "ID", 0, "primaryY", 5, "primaryX", 15, "primaryZ", -12, "secondaryY", 6, "secondaryX", 15));
		ModuleArray.Add (HashObject.Hash ("Name", "nF_1", "Type", "nF", "ID", 1, "primaryY", 5, "primaryX", 17, "primaryZ", -12, "secondaryY", 6, "secondaryX", 17));
		ModuleArray.Add (HashObject.Hash ("Name", "nF_2", "Type", "nF", "ID", 2, "primaryY", 8, "primaryX", 15, "primaryZ", -18, "secondaryY", 9, "secondaryX", 15));
		ModuleArray.Add (HashObject.Hash ("Name", "nF_3", "Type", "nF", "ID", 3, "primaryY", 8, "primaryX", 17, "primaryZ", -18, "secondaryY", 9, "secondaryX", 17));
		//nodeBar
		ModuleArray.Add (HashObject.Hash ("Name", "nB_0", "Type", "nB", "ID", 0, "primaryY", 10, "primaryX", 7, "primaryZ", -6, "secondaryY", 11, "secondaryX", 7));
		ModuleArray.Add (HashObject.Hash ("Name", "nB_1", "Type", "nB", "ID", 1, "primaryY", 10, "primaryX", 8, "primaryZ", -6, "secondaryY", 11, "secondaryX", 8));
		ModuleArray.Add (HashObject.Hash ("Name", "nB_2", "Type", "nB", "ID", 2, "primaryY", 10, "primaryX", 10, "primaryZ", -6, "secondaryY", 11, "secondaryX", 10));
		ModuleArray.Add (HashObject.Hash ("Name", "nB_3", "Type", "nB", "ID", 3, "primaryY", 10, "primaryX", 11, "primaryZ", -6, "secondaryY", 11, "secondaryX", 11));
		//nodeCashier
		ModuleArray.Add (HashObject.Hash ("Name", "nC_0", "Type", "nC", "ID", 0, "primaryY", 9, "primaryX", 3, "secondaryY", 11, "secondaryX", 3));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//getter setter
	public Hashtable GetDataByIDAndType(int ID, string TYPE)
	{
		Hashtable MyHash = new Hashtable();
		for(int i=0;i<ModuleArray.Count;i++)
		{
			if((string)ModuleArray[i]["Type"] == TYPE)
			{
				if((int)ModuleArray[i]["ID"] == ID)
				{
					MyHash = ModuleArray[i];
				}
			}
		}
		return MyHash;
	}
	//Warning Mostly hardcode
	public Hashtable GetDataByCoverageArea(int tileY, int tileX)
	{
		Hashtable MyHash = new Hashtable();
		for(int i = 0; i < ModuleArea.Count; i++)
		{
			if(tileY > (int) ModuleArea[i]["y1"] && tileY < (int) ModuleArea[i]["y2"] && tileX > (int) ModuleArea[i]["x1"] && tileX < (int) ModuleArea[i]["x2"])
			{
				string areaName = ModuleArea[i]["AreaType"].ToString();
				for(int j = 0; j < ModuleArray.Count; j++)
				{
					if(ModuleArray[j]["Type"].Equals(areaName))
					{
						//Checking occupy status
						if(!Main.MyModuleClass.isOccupied(ModuleArray[j]["Type"].ToString(), (int) ModuleArray[j]["ID"]))
						{
							MyHash = (Hashtable) ModuleArray[j].Clone();
							return MyHash;
						}
					}
				}
			}
		}
		return MyHash;
	}

	public Hashtable GetDataByPrimaryPos(int tileY, int tileX)
	{
		Hashtable MyHash = new Hashtable();
		for(int b=0;b<ModuleArray.Count;b++)
		{
			if((int)ModuleArray[b]["primaryY"]== tileY && (int)ModuleArray[b]["primaryX"]== tileX)
			{
				MyHash = (Hashtable)ModuleArray[b].Clone ();
				break;
			} 
		}
		return MyHash;
	}
	
	public Hashtable GetDataBySecondaryPos(int tileY, int tileX)
	{
		Hashtable MyHash = new Hashtable();
		for(int b=0;b<ModuleArray.Count;b++)
		{
			if((int)ModuleArray[b]["secondaryY"]== tileY && (int)ModuleArray[b]["secondaryX"]== tileX)
			{
				MyHash = (Hashtable)ModuleArray[b].Clone ();
				break;
			} 
		}
		return MyHash;
	}
	
	public Hashtable GetPosByName(string stringName)
	{
		Hashtable MyHash = new Hashtable();
		for(int a=0;a<ModuleArray.Count;a++)
		{
			if((string)ModuleArray[a]["Name"]== stringName)
			{
				MyHash = (Hashtable)ModuleArray[a].Clone ();
			} 
		}
		return MyHash;
	}
	
	public Hashtable GetModuleDataHash(GameObject referenceObj)
	{
		float tempY = (referenceObj.gameObject.transform.localPosition.y - Res.DefaultHeight()/2)/TileArray.tileHeight;
		float tempX = (referenceObj.gameObject.transform.localPosition.x + Res.DefaultWidth()/2)/TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
		print (tileY+","+ tileX);
		
		Hashtable moduleDataHash = GetDataByPrimaryPos(tileY, tileX);
		
		
		return moduleDataHash;
	}
	
	public Vector3 GetPrimaryBySecondaryPost(int secondaryX, int secondaryY)
	{
		Vector3 tempPrimaryPost = new Vector3();
		for(int i = 0;i<ModuleArray.Count;i++)
		{
			if((int)ModuleArray[i]["secondaryY"] == secondaryY && (int)ModuleArray[i]["secondaryX"] == secondaryX)
			{
				tempPrimaryPost = new Vector3((int)ModuleArray[i]["primaryX"], (int)ModuleArray[i]["primaryY"], 0);
				break;
			}
		}
		return tempPrimaryPost;
	}
	
	public List<Hashtable> GetModuleList()
	{
		return ModuleArray;	
	}
}
