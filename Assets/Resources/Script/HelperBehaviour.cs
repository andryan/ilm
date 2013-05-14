using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class HelperBehaviour : MonoBehaviour {

	// Use this for initialization
	public int ID = 0;
	public float HelperWalkingSpeed = 0.0f;
	public float HelperActionSpeed = 0.0f;
	
	public bool OnComplete = true;
	private float CurrentHelperWaitingTime = 0.0f;
	
	//animation
	private Vector3 prevHelperPost = new Vector3(0,0,0);
	private SpriteAnimator sAnim = null;
	private Transform SpriteAnimObj = null;
	public bool Serving = false;	
	void Start () {
		Init ();
	}
	public void Reset()
	{
		ID = 0;
		HelperWalkingSpeed = 0.0f;
		HelperActionSpeed = 0.0f;
		OnComplete = true;
		CurrentHelperWaitingTime = 0.0f;
		
		prevHelperPost = new Vector3(0,0,0);
		sAnim = null;
		SpriteAnimObj = null;
		Serving = false;
	}
	public void SetValue(Hashtable Hash = null)
	{
		ID = (int)Hash["ID"];
		List<float> moveSpeed = (List<float>) Hash["MovementSpeed"];
		List<float> actionSpeed = (List<float>) Hash["ActionSpeed"];
		HelperWalkingSpeed = moveSpeed[Main.MyPlayerAtr.GetHelperLevel(ID-1)-1];
		HelperActionSpeed = actionSpeed[Main.MyPlayerAtr.GetHelperLevel(ID-1)-1];	
	}
	private void Init()
	{
		prevHelperPost = this.gameObject.transform.position;
		SpriteAnimObj = this.gameObject.transform.Find("SpriteAnim");
		sAnim = (SpriteAnimator)SpriteAnimObj.GetComponent("SpriteAnimator");
		InvokeRepeating ("sAnimEnterFrame",0f,0.06f);
	}
	
	public float GetWaitingTime()
	{
		float tileWalkingTime = HelperWalkingSpeed * Main.MyTile.TotalPath;
		float totalWaitingTime = tileWalkingTime + HelperActionSpeed;
		Serving = true;
		CurrentHelperWaitingTime = totalWaitingTime;
		
		InvokeRepeating ("EnterFrame",0f,0.02f);
		return totalWaitingTime;
	}
	
	/*public void GetHelperValue(int moduleY, int moduleX)
	{			
		Vector3 tempHelperPost = convertPosToTile(this.gameObject);
				
		int nearestTileX = Mathf.Abs((int)tempHelperPost.x - moduleX);
		int nearestTileY = Mathf.Abs((int)tempHelperPost.y - moduleY);
				
		pathValue = nearestTileX + nearestTileY;
		//return pathValue;
		
	}*/
	
	private Vector3 convertPosToTile(GameObject currentObj)
	{		
		float tempY = currentObj.transform.position.y/TileArray.tileHeight;
		float tempX = currentObj.transform.position.x/TileArray.tileWidth;
				
		int tileY = Mathf.Abs((int)tempY);
		int tileX = Mathf.Abs((int)tempX);
					
		Vector3 tilePos = new Vector3(tileX, tileY, 0);
		return tilePos;
	}
	
	private void sAnimEnterFrame()
	{
		Vector3 currHelper = convertPosToTile(this.gameObject);
		
			
		int tempZ = (int)-currHelper.y*2;
		//this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, tempZ-1);
		
		int totalZ = tempZ - (int)this.gameObject.transform.position.z;
		//print ("totalZ "+(totalZ-1));
		//print ("tempZ "+ tempZ);
		sAnim.transform.localPosition = new Vector3(0, 0, totalZ-1);
		//prin
		if(prevHelperPost.y > this.gameObject.transform.position.y)
		{
			sAnim.Play ("charac_walk_front");
		}
		else if(prevHelperPost.y < this.gameObject.transform.position.y)
		{
			sAnim.Play ("charac_walk_behind");
		}
		else if(prevHelperPost.x < this.gameObject.transform.position.x)
		{
			sAnim.Play ("charac_walk_right");
		}
		else if(prevHelperPost.x > this.gameObject.transform.position.x)
		{
			sAnim.Play ("charac_walk_left");
		}
		else if(Serving)
		{
			sAnim.Play ("charac_serving");
		}
		else if(prevHelperPost.y == this.gameObject.transform.position.y && prevHelperPost.x == this.gameObject.transform.position.x)
		{
			sAnim.Play ("charac_idle");
		}
		prevHelperPost = this.gameObject.transform.position;
	}
	
	private void EnterFrame()
	{
		
		CurrentHelperWaitingTime -= Time.deltaTime;
		//print ("RUNNING "+","+ID);
		//print ("CurrentWaitingTime"+CurrentWaitingTime);
		if(CurrentHelperWaitingTime <= 0)
		{
			CancelInvoke("EnterFrame");
			Serving = false;
			OnComplete = true;
			Main.MyHelper.InitHelper();
		}
	}
	
	
	void Update () {
	
	}
}
