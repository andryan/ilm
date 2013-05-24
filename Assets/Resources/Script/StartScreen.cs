using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

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
		
		StartScreenObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/StartScreenObj"));
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
		MoreGameObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MoreGameObj"));
		MoreDiamondObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MoreDiamondObj"));
		TotalDiamondObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/TotalDiamondObj"));
		SoundObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/SoundObj"));
		MusicObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MusicObj"));
		

		Main.AddParent(NewGameObj);
		Main.AddParent(ResumeObj);
		Main.AddParent(MoreGameObj);
		Main.AddParent(MoreDiamondObj);
		Main.AddParent(TotalDiamondObj);
		Main.AddParent(SoundObj);
		Main.AddParent(MusicObj);


		NewGameObj.transform.localPosition = new Vector3(-200, 210, -2);
		ResumeObj.transform.localPosition = new Vector3(200, 210, -2);
		MoreGameObj.transform.localPosition = new Vector3(-200, -10, -2);
		MoreDiamondObj.transform.localPosition = new Vector3(200, -10, -2);
		TotalDiamondObj.transform.localPosition = new Vector3(0, -200, -2);
		SoundObj.transform.localPosition = new Vector3(380, -325, -2);
		MusicObj.transform.localPosition = new Vector3(460, -325, -2);
		
		NewGameObj.transform.localScale = new Vector3(350,100,0.1f);
		ResumeObj.transform.localScale = new Vector3(350,100,0.1f);
		MoreGameObj.transform.localScale = new Vector3(350,100,0.1f);
		MoreDiamondObj.transform.localScale = new Vector3(350,100,0.1f);
		TotalDiamondObj.transform.localScale = new Vector3(350,100,0.1f);
		SoundObj.transform.localScale = new Vector3(64, 90, 0.1f);
		MusicObj.transform.localScale = new Vector3(64, 90, 0.1f);
		

		StartScreenBtnArr.Add(NewGameObj);
		StartScreenBtnArr.Add(ResumeObj);
		StartScreenBtnArr.Add(MoreGameObj);
		StartScreenBtnArr.Add(MoreDiamondObj);
		StartScreenBtnArr.Add(TotalDiamondObj);
		StartScreenBtnArr.Add(SoundObj);
		StartScreenBtnArr.Add(MusicObj);
		
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
					
					if(TapStartObj.activeSelf)
					{
						TapStartObj.SetActive(false);
						EnterStartScreen();
					}
				}
				else if(hit.transform.gameObject == NewGameObj)
				{
					//NewGameObj.transform.localScale = new Vector3(NewGameObj.transform.localScale.x - 20, NewGameObj.transform.localScale.y - 20, NewGameObj.transform.localScale.z);
					Parent.Invoke("ShowPnMScreen", 0.8f);
					Reset();
					Parent = null;
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
