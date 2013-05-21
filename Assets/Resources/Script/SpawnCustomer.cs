using UnityEngine;
using System.Collections;

public class SpawnCustomer : MonoBehaviour {
	
	public float spawnDelay = 10f;
	
	public int myDay = 2;
	
	public float myDisappearIcon = 10f;
	
	public float myCustomerSpeed = 0.3f;
	
	public float myMinusTime = 0.0f;
	
	public int vipCount = 0;
	public int shortTCount = 0;
	public int normalCount = 0;
	public int casualCount = 0;
	
	public int myVipCount = 0;
	public int myShortTCount = 0;
	public int myNormalCount = 0;
	public int myCasualCount = 0;
	
	public int totalCustomer = 0;
	public int tempTotalCust = 0;
	
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject mainCamera = GameObject.Find("Main Camera");
		Main myMain = mainCamera.GetComponent<Main>();
		
		totalCustomer = normalCount + vipCount + shortTCount + casualCount;
		tempTotalCust = myNormalCount + myVipCount + myShortTCount + myCasualCount;
		
		if(myDay < Main.MyPlayerAtr.Day)
		{
			myCustomerSpeed -= 0.005f;
			myDisappearIcon -= 1;
			myDay++;
			myMinusTime += 0.5f;
		}
		
		if(Main.MyPlayerAtr.Day == 5)
		{
			Main.MyCustomer.maxCustomerSize = 3;
		}
		if(Main.MyPlayerAtr.Day == 10)
		{
			Main.MyCustomer.maxCustomerSize = 4;
		}
		if(Main.MyPlayerAtr.Day == 15)
		{
			Main.MyCustomer.maxCustomerSize = 5;
		}
		if(Main.MyPlayerAtr.Day == 20)
		{
			Main.MyCustomer.maxCustomerSize = 6;
		}
		if(Main.MyPlayerAtr.Day == 25)
		{
			Main.MyCustomer.maxCustomerSize = 7;
		}
		if(Main.MyPlayerAtr.Day == 30)
		{
			Main.MyCustomer.maxCustomerSize = 8;
		}
		if(Main.MyPlayerAtr.Day == 35)
		{
			Main.MyCustomer.maxCustomerSize = 9;
		}
		if(Main.MyPlayerAtr.Day == 40)
		{
			Main.MyCustomer.maxCustomerSize = 10;
		}
		
		if(Main.MyCustomer != null)
		{
			if(Main.MyCustomer.customerWalkingSpeed > myCustomerSpeed)
			{
				if(Main.MyCustomer.customerWalkingSpeed > 0.1f)
				{
					Main.MyCustomer.customerWalkingSpeed -= 0.005f;
				}
				
				if(Main.MyCustomerAttribute != null)
				{
					if(Main.MyCustomerAttribute.disappearIcon > myDisappearIcon)
					{
						Main.MyCustomerAttribute.disappearIcon -= 1;
					}
				}
				
			}
		}
	}
	
	public void Init()
	{
		
		
	}
	
}
