using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Prime31;						 // using prime31 plugin ~ nandi


public class StartScreen : MonoBehaviour {
	
	public Main Parent = null;
	private GameObject StartScreenObj = null;
	private GameObject TapStartObj = null;
	private GameObject NewGameObj = null;
	private GameObject ResumeObj = null;
	private GameObject MoreGameObj = null;
	private GameObject MoreDiamondObj = null;
	private GameObject TotalDiamondObj = null;
	private GameObject SoundObj = null;
	private GameObject MusicObj = null;
	
	private List<GameObject> StartScreenBtnArr = null;
	//private List<Vector3> StartScreenObjScale = null;
	private bool TapAlphaControl = false;
	
	
	// Change Background
	private bool _startScreenStat = false;
	
	//Facebook Prime31 ~ nandi
#if UNITY_ANDROID
	
	bool _postfb = false;
	bool _readfb = false;
	bool _reauthpostfb = false;
	bool _postscore = false;
	Texture2D _foto;


	void getIdHandler( string error, object result )
	{
		Debug.LogWarning( " >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> " );
		if( error != null )
			Debug.LogWarning( error.ToString() );	
		else
		{
			Prime31.Utils.logObject( result );
			Hashtable hash = (Hashtable) result;
			Main._userIdFB = hash["id"].ToString();
			Debug.LogWarning( "1 >>>>>>>>>>> " + hash["id"].ToString() );
			Debug.LogWarning( "2 >>>>>>>>>>> " + Main._userIdFB );
		}
	}
	IEnumerator getId ()
	{
		Facebook.instance.graphRequest( "me", HTTPVerb.GET, getIdHandler );
		yield return null;
	}
	
	void getScore ( string error, object result )
	{
		if( error != null )
		{
			Debug.LogError( error );	
		}
		else
		{
			Prime31.Utils.logObject( result );
			Hashtable hash = (Hashtable) result;
			ArrayList list = (ArrayList) hash["data"];
			
			for (int i=0; i<list.Count; i++)
			{
				Hashtable morehash = (Hashtable) list[i];
				Hashtable apphash = (Hashtable) morehash["application"];
			
				if ( Main._appidFB == apphash["id"].ToString() )
				{
					//Debug.LogWarning( "1 }}}}}}}}}}} " + Main._appidFB );
					//Debug.LogWarning( "2 }}}}}}}}}}} " + apphash["id"].ToString() );
					//Debug.LogWarning( "1 wkwkwkwk "  + morehash["score"] + " -- " + morehash["score"].GetType());
					
					Main._highscoreFB = morehash["score"].ToString();
				
					//Debug.LogWarning( "2 wkwkwkwk "  + morehash["score"]);
					//Debug.LogWarning( "1 }}}}}}}}}}} " + morehash["score"].ToString() );
					//Debug.LogWarning( "2 }}}}}}}}}}} " + Main._highscoreFB );
				}
				
			}	
		}
	}
	IEnumerator gettingScore()
	{
		Facebook.instance.graphRequest( "me/scores", HTTPVerb.GET, getScore );
		yield break;
	}
	
	
#endif
	
	
	
	// Use this for initialization
	void Start () {

	}
	
	
	public void Init()
	{
		SpawnStartScreen();
	}
	
	private void SpawnStartScreen()
	{
		//StartScreenObj = new GameObject();
		//TapStartObj = new GameObject();
		StartScreenBtnArr = new List<GameObject>();
		//StartScreenObjScale = new List<Vector3>();
		
		if ( _startScreenStat == true)
			StartScreenObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/StartScreenObj"));
		else
			StartScreenObj = (GameObject)Instantiate ((GameObject)Resources.Load ("MainMenu/GameObjects/StartScreenObj2"));
		
		TapStartObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/TapStartObj"));

		Main.AddParent(StartScreenObj);
		Main.AddParent(TapStartObj);

		StartScreenObj.transform.localPosition = new Vector3(0, 0, 0);
		TapStartObj.transform.localPosition = new Vector3(0, - 330, -2);
		
		StartScreenObj.transform.localScale = new Vector3(1024, 769, 0.1f);
		TapStartObj.transform.localScale = new Vector3(300, 80, 0.1f);
		
		InvokeRepeating("TapObjEnterFrame", 0f, 1f);
	}
	
	private void EnterStartScreen()
	{
		/*
		NewGameObj = new GameObject();
		ResumeObj = new GameObject();
		MoreGameObj = new GameObject();
		MoreDiamondObj = new GameObject();
		TotalDiamondObj = new GameObject();
		SoundObj = new GameObject();
		MusicObj = new GameObject();
		*/
		
		NewGameObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/NewGameObj"));
		ResumeObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/ResumeObj"));
		/*
		MoreGameObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MoreGameObj"));
		MoreDiamondObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MoreDiamondObj"));
		TotalDiamondObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/TotalDiamondObj"));
		SoundObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/SoundObj"));
		MusicObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MusicObj"));
		*/

		Main.AddParent(NewGameObj);
		Main.AddParent(ResumeObj);
		/*
		Main.AddParent(MoreGameObj);
		Main.AddParent(MoreDiamondObj);
		Main.AddParent(TotalDiamondObj);
		Main.AddParent(SoundObj);
		Main.AddParent(MusicObj);
		*/

		//NewGameObj.transform.localPosition = new Vector3(-200, 210, -2);
		//ResumeObj.transform.localPosition = new Vector3(200, 210, -2);
		NewGameObj.transform.localPosition = new Vector3( 412, -285, -2);
		ResumeObj.transform.localPosition = new Vector3(-400, -285, -2);
		/*
		MoreGameObj.transform.localPosition = new Vector3(-200, -10, -2);
		MoreDiamondObj.transform.localPosition = new Vector3(200, -10, -2);
		TotalDiamondObj.transform.localPosition = new Vector3(0, -200, -2);
		SoundObj.transform.localPosition = new Vector3(380, -325, -2);
		MusicObj.transform.localPosition = new Vector3(460, -325, -2);
		*/
		
		//NewGameObj.transform.localScale = new Vector3(350,100,0.1f);
		//ResumeObj.transform.localScale = new Vector3(350,100,0.1f);
		NewGameObj.transform.localScale = new Vector3(200,200,0.1f);
		ResumeObj.transform.localScale = new Vector3(250,200,0.1f);
		/*
		MoreGameObj.transform.localScale = new Vector3(350,100,0.1f);
		MoreDiamondObj.transform.localScale = new Vector3(350,100,0.1f);
		TotalDiamondObj.transform.localScale = new Vector3(350,100,0.1f);
		SoundObj.transform.localScale = new Vector3(64, 90, 0.1f);
		MusicObj.transform.localScale = new Vector3(64, 90, 0.1f);
		*/

		StartScreenBtnArr.Add(NewGameObj);
		StartScreenBtnArr.Add(ResumeObj);
		/*
		StartScreenBtnArr.Add(MoreGameObj);
		StartScreenBtnArr.Add(MoreDiamondObj);
		StartScreenBtnArr.Add(TotalDiamondObj);
		StartScreenBtnArr.Add(SoundObj);
		StartScreenBtnArr.Add(MusicObj);
		*/
		
		/*
		StartScreenObjScale.Add (NewGameObj.transform.localScale);
		StartScreenObjScale.Add (ResumeObj.transform.localScale);
		StartScreenObjScale.Add (MoreGameObj.transform.localScale);
		StartScreenObjScale.Add (MoreDiamondObj.transform.localScale);
		StartScreenObjScale.Add (TotalDiamondObj.transform.localScale);
		StartScreenObjScale.Add (SoundObj.transform.localScale);
		StartScreenObjScale.Add (MusicObj.transform.localScale);
		*/
	}
	
	private void TapObjEnterFrame()
	{
		TapAlphaControl = !TapAlphaControl;
		
		if(TapAlphaControl)
		{
			iTween.FadeTo (TapStartObj,iTween.Hash("alpha",0f,"time",1f, "easetype",iTween.EaseType.linear));
		}else {
			iTween.FadeTo (TapStartObj,iTween.Hash("alpha",1f,"time",1f, "easetype",iTween.EaseType.linear));
		}
	}
	
	private void TapControl()
	{
		//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (ray, out hit)) 
			{
				for(int i = 0;i<StartScreenBtnArr.Count; i++)
				{
					if(hit.transform.gameObject == StartScreenBtnArr[i])
					{
						StartScreenBtnArr[i].transform.localScale = new Vector3(StartScreenBtnArr[i].transform.localScale.x + 20, StartScreenBtnArr[i].transform.localScale.y + 20, StartScreenBtnArr[i].transform.localScale.z);
					}
				}
				
				if(hit.transform.gameObject == NewGameObj)
				{
					//NewGameObj.transform.localScale = new Vector3(NewGameObj.transform.localScale.x + 20, NewGameObj.transform.localScale.y + 20, NewGameObj.transform.localScale.z);
					
				}
				else if(hit.transform.gameObject == ResumeObj)
				{
					
				}
				else if(hit.transform.gameObject == MoreGameObj)
				{
					
				}
				else if(hit.transform.gameObject == MoreDiamondObj)
				{
					
				}
				else if(hit.transform.gameObject == SoundObj)
				{
					
				}
				else if(hit.transform.gameObject == MusicObj)
				{
					
				}
			}
		}
		//if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
		if(Input.GetMouseButtonUp(0)) {
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			/*
			for(int i = 0;i<StartScreenBtnArr.Count; i++)
			{
				StartScreenBtnArr[i].transform.localScale = new Vector3(StartScreenObjScale[i].x, StartScreenObjScale[i].y, StartScreenObjScale[i].z);
			}
			*/
		
			if (Physics.Raycast (ray, out hit)) 
			{
				if(hit.transform.gameObject == TapStartObj || hit.transform.gameObject == StartScreenObj)
				{
					//Reset();
					StartCoroutine( getId() );
					StartCoroutine( gettingScore() );	
					
					if(TapStartObj.activeSelf)
					{
						TapStartObj.SetActive(false);
						EnterStartScreen();
					}
				}
				else if(hit.transform.gameObject == NewGameObj)
				{
					_startScreenStat = true; // changeBG
					
					//NewGameObj.transform.localScale = new Vector3(NewGameObj.transform.localScale.x - 20, NewGameObj.transform.localScale.y - 20, NewGameObj.transform.localScale.z);
					Parent.Invoke("ShowPnMScreen", 0.8f);
					Reset();
					Parent = null;
				}
				else if(hit.transform.gameObject == ResumeObj)
				{
					// Instace UI Social Menu if device is android
					#if UNITY_ANDROID
						SocialMenu MySocialMenu = (SocialMenu)this.gameObject.AddComponent("SocialMenu");  
						MySocialMenu.Init(Parent);
					#endif
				}
				else if(hit.transform.gameObject == MoreGameObj)
				{
					
				}
				else if(hit.transform.gameObject == MoreDiamondObj)
				{
					
				}
				else if(hit.transform.gameObject == SoundObj)
				{
					
				}
				else if(hit.transform.gameObject == MusicObj)
				{
					
				}
			}
			
		}
	}
	
	private void Update()
	{
		TapControl();
	}
	
	public void Reset()
	{
		
		
		CancelInvoke("TapObjEnterFrame");
		Destroy (StartScreenObj);
		Destroy (TapStartObj);
		Destroy (NewGameObj);
		Destroy (ResumeObj);
		Destroy (MoreGameObj);
		Destroy (MoreDiamondObj);
		Destroy (TotalDiamondObj);
		Destroy (SoundObj);
		Destroy (MusicObj);
		
		
		StartScreenObj = null;
		TapStartObj = null;
		NewGameObj = null;
		ResumeObj = null;
		MoreGameObj = null;
		MoreDiamondObj = null;
		TotalDiamondObj = null;
		SoundObj = null;
		MusicObj = null;
		
		StartScreenBtnArr = null;
		//StartScreenObjScale = null;
		
	}
}
