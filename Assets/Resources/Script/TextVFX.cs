using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer
public class TextVFX : MonoBehaviour 
{
	private int Timer = 0;
	//@ Kaizer: VFX Behavior
	private void Update()
	{
		Timer++;
		this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+1, this.gameObject.transform.position.z);
		if(Timer == 50)
		{
			Clear ();	
		}
	}
	public void Clear()
	{
		Destroy (this.gameObject.GetComponent("TextVFX"));
		Destroy (this.gameObject);
	}
}
