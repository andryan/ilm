using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 

public class DragDrop : MonoBehaviour {

    GameObject dragObject = null;
	Vector3 prevPos = new Vector3(0,0,0);
	public Hashtable prevReferenceHash = null;
    Vector3 offSet = new Vector3(0,0,0);     
	
	//function to get current mouse position's tile data
	
	public void Reset()
	{
		dragObject = null;
		prevPos = new Vector3(0,0,0);
		prevReferenceHash = null;
		offSet = new Vector3(0,0,0);
	}
	private Hashtable getReferenceHash()
	{
		float tempY = (dragObject.transform.localPosition.y - Res.DefaultHeight()/2)/TileArray.tileHeight;
		float tempX = (dragObject.transform.localPosition.x + Res.DefaultWidth()/2)/TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
		
		Hashtable moduleDataHash = Main.MyModule.GetDataByPrimaryPos(tileY, tileX);
		
		return moduleDataHash;
	}
	
	private Hashtable getAreaReferenceHash()
	{
		float tempY = (dragObject.transform.localPosition.y - Res.DefaultHeight()/2)/TileArray.tileHeight;
		float tempX = (dragObject.transform.localPosition.x + Res.DefaultWidth()/2)/TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
		
		Hashtable moduleDataHash = Main.MyModule.GetDataByCoverageArea(tileY, tileX);
		
		return moduleDataHash;
		
	}



	private void OnMouseDown()
	{
		if(dragObject != null)
		{
			CustomerAtr MyCA = (CustomerAtr)dragObject.GetComponent("CustomerAtr");
				
			
			Hashtable referenceHash = getAreaReferenceHash();
			//testing
			CustomerBehaviour MyCB = (CustomerBehaviour)dragObject.GetComponent("CustomerBehaviour");
			MyCB.CustomerPrevData = referenceHash;
				
			GameObject referenceObject = GameObject.Find ((string)referenceHash["Name"]);
			
			Hashtable ModuleClassHash = Main.MyModuleClass.GetDataByName((string)referenceHash["Name"]);
			
			//check existance of current ref obj
			if((string)referenceHash["Type"] == MyCA.ReturnRequest() && (int)ModuleClassHash["Occupy"] == 0)
			{
				CancelInvoke("OnMouseDown");
				if(referenceObject == null)
					return;
				Vector3 temp = referenceObject.transform.localPosition;
				dragObject.transform.localPosition = new Vector3(temp.x, temp.y, 0);
				Main.MySE.PlaySFX("ReadToPay");
				Main.MyModuleClass.SetOccupy((string)prevReferenceHash["Type"], (int)prevReferenceHash["ID"], "-", dragObject.name); //set previous occupied module back to empty
				Main.MyModuleClass.SetOccupy((string)referenceHash["Type"], (int)referenceHash["ID"], "+", dragObject.name); //set current occupied module to occupied
				//print ("Y"+(int)referenceHash["primaryY"]);
				//print ("X"+(int)referenceHash["primaryX"]);
				switch(MyCA.ReturnRequest())
				{
					case "nF":MyCA.AssignStation((string)referenceHash["Type"],Main.MyStatCheck.GetFoodStatByLevel(Main.MyPlayerAtr.ReturnFoodLevel((int)referenceHash["ID"])));;break;
					case "nB":MyCA.AssignStation((string)referenceHash["Type"],Main.MyStatCheck.GetBarStatByLevel(Main.MyPlayerAtr.ReturnBarLevel((int)referenceHash["ID"])));;break;
					case "nTD":MyCA.AssignStation((string)referenceHash["Type"],Main.MyStatCheck.GetTDisplayStatByLevel(Main.MyPlayerAtr.ReturnTDisplayLevel((int)referenceHash["ID"])));;break;
				}
				//MyCA.AssignStation((string)referenceHash["Type"],Main.MyStatCheck.GetQueueUpStatByLevel(Main.MyPlayerAtr.ReturnQueueUpLevel(customerObjReferenceID[customerId])));
				Main.MyCustomer.SetCustomerStatus(dragObject, false); //set customer object reference to incomplete
				dragObject = null;     // Let go of the object.
				Main.MyHelper.InitHelper();
				
			}
		}
	}
    void Update() {
        Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));        // Gets the mouse position in the form of a ray.
		//Ray ray = new Ray(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -100), Vector3.forward);
        if (Input.GetMouseButtonDown(0)) {      // If we click the mouse...
		//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            InvokeRepeating("OnMouseDown", 0f, 0.02f);
			RaycastHit hit; 
			
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {        // Then see if an object is beneath us using raycasting.
				for(int i =0;i<Main.MyCustomer.customerList.Count;i++)
				{
					if(hit.transform.gameObject.name == Main.MyCustomer.customerList[i].name)
					{
						
						//int customerStatus = Main.MyCustomer.GetCustomerStatus(Main.MyCustomer.customerList[i]);
						CustomerBehaviour MyCB = (CustomerBehaviour)Main.MyCustomer.customerList[i].GetComponent("CustomerBehaviour");
						prevReferenceHash = null;
						
						if(MyCB.CustomerStatus == 0) //check if customer status is complete
						{
							CustomerAtr MyCA = (CustomerAtr)Main.MyCustomer.customerList[i].GetComponent("CustomerAtr");
							print ("MyCA.ReturnRequest()"+MyCA.ReturnRequest());
			               	Hashtable moduleClassHash = Main.MyModuleClass.GetModuleClassHash(Main.MyCustomer.customerList[i]);
							
							
			               	if((string)moduleClassHash["Type"] != MyCA.ReturnRequest())
							{
								if(MyCA.ReturnRequest() != "nC")
								{
									dragObject = Main.MyCustomer.customerList[i];        // If we hit an object then hold on to the object.
									prevPos = dragObject.transform.localPosition;
									Main.MySE.PlaySFX("Select");
									prevReferenceHash = getReferenceHash();
									
									offSet = dragObject.transform.position-ray.origin;       // This is so when you click on an object its center does not align with mouse position.
						
									
								}
							} 
						}
					}
				}
            }
        }
        else if (Input.GetMouseButtonUp(0)) {
		//else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
			CancelInvoke("OnMouseDown");
			
			if(dragObject != null)
			{
				Main.MyCustomer.SetCustomerStatus(dragObject, true); //reset customer status when customer obj is let go without valid object reference
				dragObject.transform.localPosition = prevPos;
				Main.MySE.PlaySFX("Cancel");
				dragObject = null;  
				Main.MyHelper.InitHelper();
			}
        }
        if (dragObject) 
		{
            dragObject.transform.position = new Vector3(ray.origin.x+offSet.x, ray.origin.y+offSet.y, 0);     // Only move the object on a 2D plane.
        }
    }
}

	
