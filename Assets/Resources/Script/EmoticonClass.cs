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
		
		
		Vector3 emmoticonPos = new Vector3(MyObj.transform.position.x + offsetX, MyObj.transform.position.y + offsetY, 0);
		//MyPos = Vector3((MyPos.gameIbject.x + offsetX), (MyPos.y + offsetY), 0);
		
		EmoticonObj.transform.position = emmoticonPos;
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
