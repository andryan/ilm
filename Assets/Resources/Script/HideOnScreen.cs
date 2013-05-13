using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideOnScreen : MonoBehaviour {

	// Use this for initialization
	private List<GameObject> OnScreenObj;
	void Start () {
		
	}
	public void Init()
	{
		OnScreenObj = new List<GameObject>();
	}
	public void AddScreenObj(GameObject MyObj)
	{
		OnScreenObj.Add (MyObj);
		
	}
	public void Reset()
	{
		print ("OnScreenObj.Count: "+OnScreenObj.Count);
		for(int i=0; i<OnScreenObj.Count; i++)
		{
			print ("OnScreenObj[i]: "+OnScreenObj[i]);
			Destroy(OnScreenObj[i]);
		}
		
		OnScreenObj = null;
	}
	public void SetInGameVisible(bool alpha)
	{
		if(!alpha)
		{
			for(int i=0;i<OnScreenObj.Count;i++)
			{
				OnScreenObj[i].SetActive(false);
			}
		} else {
			for(int j=0;j<OnScreenObj.Count;j++)
			{
				OnScreenObj[j].SetActive(true);
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
