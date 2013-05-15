using UnityEngine;
using System.Collections;

public class EmoticonClass : MonoBehaviour {

	// Use this for initialization
	private int offsetY;
	private int offsetX;
	
	void Start () {
		offsetY = 10;
		offsetX = 10;
	}
	
	public void SpawnEmoticon(GameObject MyObj)
	{
		GameObject EmoticonObj;
		
		EmoticonObj =  (GameObject)Instantiate ((GameObject)Resources.Load ("Prefabs/EmoticonPrefab"));
		Main.AddParent(EmoticonObj);
		
		
		Vector3 emmoticonPos = new Vector3(MyObj.transform.localPosition.x + offsetX, MyObj.transform.localPosition.y + offsetY, 0);
		//MyPos = Vector3((MyPos.gameIbject.x + offsetX), (MyPos.y + offsetY), 0);
		
		EmoticonObj.transform.localPosition = emmoticonPos;
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
