using UnityEngine;
using System.Collections;

public class CustomerMetre : MonoBehaviour {
	
	public int maxCustOut = 2;
	float timer = 2f;
	
	float myWidth = 800;
	float myHeight = 480;
	
	public bool isPause;
	
	// Use this for initialization
	void Start () {
		isPause = false;	
	}
	
	 //Update is called once per frame
	void Update () {
				
	}	

	
	
	void OnGUI()
	{
		GameObject mainCamera = GameObject.Find("Main Camera");
		
		CustomerClass customClass = mainCamera.GetComponent<CustomerClass>();
		
		ResultScreen resScreen = mainCamera.GetComponent<ResultScreen>();
		

		if(Main.MyResultCal.RunawayCount >= 1)
		{
			timer -= Time.deltaTime;
			if(timer <=0)
			{
				isPause = true;
				Time.timeScale = 0;
				resScreen.BuildAllText();
			}	
		}
	}
}
