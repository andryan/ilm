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
	private List<Vector3> StartScreenObjScale = null;
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
		StartScreenObj = new GameObject();
		TapStartObj = new GameObject();
		StartScreenBtnArr = new List<GameObject>();
		StartScreenObjScale = new List<Vector3>();
		
		StartScreenObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/StartScreenObj"));
		TapStartObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/TapStartObj"));
		StartScreenObj.transform.position = new Vector3(400, -240, 0);
		TapStartObj.transform.position = new Vector3(400, - 460, -2);
		
		InvokeRepeating("TapObjEnterFrame", 0f, 1f);
	}
	
	private void EnterStartScreen()
	{
		NewGameObj = new GameObject();
		ResumeObj = new GameObject();
		MoreGameObj = new GameObject();
		MoreDiamondObj = new GameObject();
		TotalDiamondObj = new GameObject();
		SoundObj = new GameObject();
		MusicObj = new GameObject();
		
		NewGameObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/NewGameObj"));
		ResumeObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/ResumeObj"));
		MoreGameObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MoreGameObj"));
		MoreDiamondObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MoreDiamondObj"));
		TotalDiamondObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/TotalDiamondObj"));
		SoundObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/SoundObj"));
		MusicObj = (GameObject)Instantiate ((GameObject)Resources.Load ("GameObjects/MusicObj"));
		
		NewGameObj.transform.position = new Vector3(200, -180, -2);
		ResumeObj.transform.position = new Vector3(600, -180, -2);
		MoreGameObj.transform.position = new Vector3(200, -300, -2);
		MoreDiamondObj.transform.position = new Vector3(600, -300, -2);
		TotalDiamondObj.transform.position = new Vector3(400, -360, -2);
		SoundObj.transform.position = new Vector3(740, -450, -2);
		MusicObj.transform.position = new Vector3(680, -450, -2);
		
		StartScreenBtnArr.Add(NewGameObj);
		StartScreenBtnArr.Add(ResumeObj);
		StartScreenBtnArr.Add(MoreGameObj);
		StartScreenBtnArr.Add(MoreDiamondObj);
		StartScreenBtnArr.Add(TotalDiamondObj);
		StartScreenBtnArr.Add(SoundObj);
		StartScreenBtnArr.Add(MusicObj);
		
		StartScreenObjScale.Add (NewGameObj.transform.localScale);
		StartScreenObjScale.Add (ResumeObj.transform.localScale);
		StartScreenObjScale.Add (MoreGameObj.transform.localScale);
		StartScreenObjScale.Add (MoreDiamondObj.transform.localScale);
		StartScreenObjScale.Add (TotalDiamondObj.transform.localScale);
		StartScreenObjScale.Add (SoundObj.transform.localScale);
		StartScreenObjScale.Add (MusicObj.transform.localScale);
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
			
			for(int i = 0;i<StartScreenBtnArr.Count; i++)
			{
				StartScreenBtnArr[i].transform.localScale = new Vector3(StartScreenObjScale[i].x, StartScreenObjScale[i].y, StartScreenObjScale[i].z);
			}
		
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
		StartScreenObjScale = null;
		
	}
}
