using UnityEngine;
using System.Collections;

public class GaugeLevel : MonoBehaviour {
	
	public float lastGaugeLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float curGaugeLevel = Main.FeverPoint;
		if(curGaugeLevel != lastGaugeLevel)
		{
			lastGaugeLevel = curGaugeLevel;
			this.UdpateGaugeLevel();
		}
		
		if(curGaugeLevel == 1)
		{
			
		}
	}
	
	private void UdpateGaugeLevel()
	{
		Vector3 newScale = gameObject.transform.localScale;
		Vector3 newPosition = gameObject.transform.localPosition;
		
		if(lastGaugeLevel == 0)
		{
			newScale = new Vector3(newScale.x, 1-lastGaugeLevel, newScale.z);
			newPosition = new Vector3(newPosition.x, 0, newPosition.z);
		}
		else
		{
			newScale = new Vector3(newScale.x, 1-lastGaugeLevel, newScale.z);
			newPosition = new Vector3(newPosition.x, 0.5f - (1-lastGaugeLevel)/2, newPosition.z);
		}
		
		gameObject.transform.localScale = newScale;
		gameObject.transform.localPosition = newPosition;
	}
}
