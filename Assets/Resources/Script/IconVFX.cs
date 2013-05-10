using UnityEngine;
using System.Collections;

public class IconVFX : MonoBehaviour 
{
	private int Timer = 0;
	private int Factor = 1;
	
	private void Start () 
	{
		iTween.ScaleFrom (this.gameObject,iTween.Hash("x",0f,"z", 0f,"time",0.5f, "easetype",iTween.EaseType.easeOutCubic));
		//iTween.ScaleFrom (this.gameObject,iTween.Hash("z",0f,"time",0.5f, "easetype",iTween.EaseType.easeOutCubic));
	}
	
	
	private void Update () 
	{
		if(Timer % 10 == 0)
		{
			Factor = Factor * -1;
		}
		if(Timer % 2 == 0)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + Factor, this.gameObject.transform.position.z);	
		}
		
		Timer++;
	}
}
