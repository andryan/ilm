using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Controls : MonoBehaviour {
	
	// Use this for initialization
	private List<Hashtable> moduleClassArr = null;
	
	//Player values
	Hashtable playerHash = null;
	public bool isPlayerComplete = false;
	private float playerWaitTime = 0.0f;
		
	private GameObject tempCustomerObj = null;
	
	void Start () {
		//Init ();
	}
	public void Reset()
	{
		moduleClassArr = null;
		playerHash = null;
		isPlayerComplete = false;
		playerWaitTime = 0.0f;
		tempCustomerObj = null;
	}
	public void Init()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement();
	}
	
	
	
	void PlayerMovement() {
		//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
		if(Input.GetMouseButtonDown(0)) {
			//if(Main.MyDragDrop.prevCustomerObject != null)
			//{
			//	Main.MyCustomer.SetCustomerStatus(Main.MyDragDrop.prevCustomerObject, true);
			//	Main.MyDragDrop.prevCustomerObject = null;
			//}
			
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if(isPlayerComplete)
			{
				
				if (Physics.Raycast (ray, out hit)) 
				{
					for(int i=0;i<Main.MyCustomer.customerList.Count;i++)
					{
						if(hit.transform.gameObject.name == Main.MyCustomer.customerList[i].name)
						{
							Hashtable moduleDataHash = Main.MyModule.GetModuleDataHash(Main.MyCustomer.customerList[i]);
							Hashtable moduleClassHash = Main.MyModuleClass.GetModuleClassHash(Main.MyCustomer.customerList[i]);
							
							playerHash = new Hashtable();
							playerHash.Add ("tweenObject", Main.MyPlayer.Player);
							playerHash.Add ("speed", Main.MyPlayer.PlayerWalkingSpeed);
							
							if((string)moduleClassHash["Type"] != null) //check if there is no reference object
							{
								tempCustomerObj = Main.MyCustomer.customerList[i];
								CustomerAtr MyCA = (CustomerAtr)tempCustomerObj.GetComponent("CustomerAtr");
										
								if((int)moduleClassHash["Helper"] == 0)
								{
									
									if((int)moduleClassHash["Occupy"] == 1)//check if current module is occupied
									{
										
										if((string)moduleDataHash["Type"] != "nQ" && (string)moduleDataHash["Type"] != "nC")//restrict movement if targeted modules are queue and cashier
										{
											if((string)moduleDataHash["Type"] == MyCA.ReturnRequest()) //make sure that
											{
												MyCA.Serving();
												activateMovement(playerHash, moduleDataHash, 0);//0 stand for non cashier
												Main.MySE.PlaySFX("Select");
											} else {
												print ("INCORRECT MODULE");
											}
											
										}
										else if((string)moduleClassHash["Type"] == "nC")
										{
											MyCA.Serving();
											Main.MySE.PlaySFX("GetMoney");
											activateMovement(playerHash, moduleDataHash, 1);//1 stands for cashier
										}
									}
								
									else if((string)moduleClassHash["Type"] == "nF")
									{
										
										MyCA.Serving();
										activateMovement(playerHash, moduleDataHash, 0);//1 stands for cashier
										
										
									}
								}
								else if((string)moduleClassHash["Type"] == "nC")
								{
									MyCA.Serving();
									Main.MySE.PlaySFX("GetMoney");
									activateMovement(playerHash, moduleDataHash, 1);//1 stands for cashier
								}
							}
						}
					}
				}
			}
		}
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
		//if(Input.GetMouseButtonUp(0)) {
			
		}
		
		
		if(playerWaitTime <=0)
		{
			//print ("avalaible command");
			isPlayerComplete = true;
		} else {
			//print ("no command");
			isPlayerComplete = false;
			playerWaitTime -= Time.deltaTime;
		}
	
		
	}

	void activateMovement(object objectValue, object moduleValue, int completeType)
	{
		Hashtable objectData = (Hashtable)objectValue;
		Hashtable moduleData = (Hashtable)moduleValue;
		
		//make sure targeted tile existed in ModuleData's array
		if((string)moduleData["Name"] != null)
		{
			Main.MyHelper.GetModuleInfo((int)moduleData["secondaryY"],(int)moduleData["secondaryX"]);
			//init pathfinding
			Main.MyTile.findPosition((GameObject)objectData["tweenObject"], (float)objectData["speed"],(int)moduleData["secondaryY"], (int)moduleData["secondaryX"]);
			//init player waiting time
			playerWaitTime = Main.MyPlayer.GetWaitingTime();
			
			float customerWaitTime = playerWaitTime;
			
			print("tempCustomerObj"+tempCustomerObj);
			print("customerWaitTime"+customerWaitTime);
			print ("PLAYERCLASS");
			Main.MyCustomer.SetCustomerWaitingTime(tempCustomerObj,customerWaitTime,completeType);
			tempCustomerObj = null; 
		}
	}
	
	//void 
	
	
}
