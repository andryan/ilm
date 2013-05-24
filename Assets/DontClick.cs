using UnityEngine;
using System.Collections;

public class DontClick : MonoBehaviour {
	public Texture2D currPic;
	
	public bool showImage = false;
	float myTimer = 3;
	// Use this for initialization
	void Start () {
		showImage = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width - 50, Screen.height - 25, 50, 25),  "Click!"))
		{
			showImage = true;
		}
		
		if(showImage == true)
		{
			Main.MySE.PlaySFX("Scream");
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), currPic);
			myTimer -= Time.deltaTime;
			if(myTimer <= 0)
			{
				showImage = false;
				myTimer = 3;
			}
		}
	}
}
