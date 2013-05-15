using UnityEngine;
using System.Collections;


//this class 
public class CustomerBehaviour : MonoBehaviour {
	private float WaitingTime = 0;
	private float CurrentWaitingTime = 0;
	private int CompleteType = 0;
	public Hashtable CustomerPrevData = null;
	public int CustomerStatus = 0;
	
	private Vector3 prevCustPost = new Vector3(0,0,0);
	private SpriteAnimator sAnim = null;
	private Transform SpriteAnimObj = null;
	private int tempZ = 0;
	
	public string ActionType = "";
	public Hashtable PrevReferenceHash = null;
	// Use this for initialization
	void Start () {
		Init ();
	}
	public void Reset()
	{
		WaitingTime = 0;
		CurrentWaitingTime = 0;
		CompleteType = 0;
		CustomerPrevData = null;
		prevCustPost = new Vector3(0,0,0);
		sAnim = null;
		SpriteAnimObj = null;
		tempZ = 0;
		ActionType = "";
		CustomerStatus = 0;
	}
	public void Init()
	{
		prevCustPost = this.gameObject.transform.localPosition;
		SpriteAnimObj = this.gameObject.transform.Find("SpriteAnim");
		sAnim = (SpriteAnimator)SpriteAnimObj.GetComponent("SpriteAnimator");
		InvokeRepeating ("sAnimEnterFrame",0f,0.06f);
		
		PrevReferenceHash = new Hashtable();
	}
	
	public void SetCustomerTime(float WaitingTime, int completeType)
	{
		CurrentWaitingTime = WaitingTime;
		CompleteType = completeType;
		InvokeRepeating ("EnterFrame",0f,0.02f);
	}
	
	private void sAnimEnterFrame()
	{
		Vector3 currCustomerPos = convertPosToTile(this.gameObject);
		
		//if(this.gameObject.transform.localPosition.y<= 0 + Res.DefaultHeight()/2 && this.gameObject.transform.localPosition.y >= -80 + Res.DefaultHeight()/2)
		if(this.gameObject.transform.localPosition.y > 200)
		{
			//this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
			sAnim.transform.localPosition = new Vector3(0, 0, 20);
		
		} else {
			tempZ = (int)-currCustomerPos.y*2;
			int totalZ = tempZ - (int)this.gameObject.transform.localPosition.z;
			//print ("totalZ "+(totalZ-1));
			//print ("tempZ "+ tempZ);
			sAnim.transform.localPosition = new Vector3(0, 0, totalZ-1);
		}
		
		//prin
		if(prevCustPost.y > this.gameObject.transform.localPosition.y)
		{
			sAnim.Play ("charac_walk_front");
		}
		else if(prevCustPost.y < this.gameObject.transform.localPosition.y)
		{
			sAnim.Play ("charac_walk_behind");
		}
		else if(prevCustPost.x < this.gameObject.transform.localPosition.x)
		{
			sAnim.Play ("charac_walk_right");
		}
		else if(prevCustPost.x > this.gameObject.transform.localPosition.x)
		{
			sAnim.Play ("charac_walk_left");
		}
		
		else if(prevCustPost.y == this.gameObject.transform.localPosition.y && prevCustPost.x == this.gameObject.transform.localPosition.x)
		{
			sAnim.Play ("charac_idle");
		}
		prevCustPost = this.gameObject.transform.localPosition;
	}
	
	private void EnterFrame()
	{
		
		CurrentWaitingTime -= Time.deltaTime;
		//print ("RUNNING CUSTOMER INVOKE: "+CurrentWaitingTime);
		if(CurrentWaitingTime <= 0)
		{
			CancelInvoke("EnterFrame");	
			print ("CUSTOMER COMPLETE");
			//this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, tempZ-1);
			Hashtable currentHash =  CustomerPrevData;
			
			CustomerStatus = 0;
			Main.MyModuleClass.SetHelperStatus((string)currentHash["Name"], 0);
			//.if((int)currentHash["ID"] != null)
			//{
				//Main.MyModuleClass.SetOccupy((string)currentHash["Type"],(int)currentHash["ID"], "-");
			//}
			//Main.MyModuleClass.SetHelperStatus
			
			CustomerAtr MyCA = (CustomerAtr)this.gameObject.GetComponent("CustomerAtr");
			if(CompleteType == 0)
			{
				MyCA.CompleteAction();
				
				if(MyCA.ReturnRequest() == (string)currentHash["Type"])
				{
					print ("SAME REQUESTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
					//Main.MyCustomer.SetCustomerStatus(this.gameObject, false);
					CustomerBehaviour MyCB = (CustomerBehaviour)this.gameObject.GetComponent("CustomerBehaviour");
					MyCB.CustomerStatus = 1;
					Main.MyModuleClass.SetHelperStatus((string)currentHash["Name"], 0);
					Main.MyModuleClass.SetOccupy((string)currentHash["Type"],(int)currentHash["ID"], "+");
					switch(MyCA.ReturnRequest())
					{
						case "nF":MyCA.AssignStation((string)currentHash["Type"],Main.MyStatCheck.GetFoodStatByLevel(Main.MyPlayerAtr.ReturnFoodLevel((int)currentHash["ID"])));;break;
						case "nB":MyCA.AssignStation((string)currentHash["Type"],Main.MyStatCheck.GetBarStatByLevel(Main.MyPlayerAtr.ReturnBarLevel((int)currentHash["ID"])));;break;
						case "nTD":MyCA.AssignStation((string)currentHash["Type"],Main.MyStatCheck.GetTDisplayStatByLevel(Main.MyPlayerAtr.ReturnTDisplayLevel((int)currentHash["ID"])));;break;
					}
					
				}
				
			} else {
				MyCA.CalResult();
				Main.MyCustomer.removeCustomerFromList();
			}
			//---stop play animation
			Main.MyPlayer.Serving = false;
			
			Main.MyHelper.InitHelper();
			
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	//public void SetCustomerStatus(int MyStatus)
	//{
	//	CustomerStatus = MyStatus;
	//}
	//public int GetCustomerStatus()
	//{
	//	return GetCustomerStatus;
	//}
	
	private Vector3 convertPosToTile(GameObject currentObj)
	{		
		float tempY = (currentObj.transform.localPosition.y - Res.DefaultHeight()/2) /TileArray.tileHeight;
		float tempX = (currentObj.transform.localPosition.x + Res.DefaultWidth()/2 ) /TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
					
		Vector3 tilePos = new Vector3(tileX, tileY, 0);
		return tilePos;
	}
}
