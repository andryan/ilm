using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Res : MonoBehaviour
{
	private static Res me;
	private static float defaultScreenWidth = 1024;
	private static float defaultScreenHeight = 768;

	private float defaultRatio = 4/3;
	
	private float ratio;
	private float offsetX;
	private float offsetY;
	private float myWidth;
	private float myHeight;
	private float widthRatio;
	
	
	public static void AdjustWorldSize(GameObject gameObject)
	{
		Vector3 scale = gameObject.transform.localScale;
		scale.x = Res.Ratio();
		scale.y = Res.Ratio();
		gameObject.transform.localScale = scale;
	}
	
	public static void AdjustCameraSize(GameObject gameObject)
	{
		Camera cam = (Camera) gameObject.GetComponent("Camera");
		cam.orthographicSize = Screen.height/2;
	}
	
	public static float Ratio()
	{
		return me.ratio;
	}
	
	public static float DefaultWidth()
	{
		return defaultScreenWidth;
	}
	
	public static float DefaultHeight()
	{
		return defaultScreenHeight;
	}
	
	public static float WidthRatio()
	{
		return me.widthRatio;
	}
	
	public static float Width()
	{
		return me.myWidth;
	}
	
	public static float Height()
	{
		return me.myHeight;
	}
	
	public static Rect CRect(Rect original)
	{
		return new Rect(me.offsetX+(original.x*me.ratio), me.offsetY+(original.y*me.ratio), original.width*me.ratio, original.height*me.ratio);
	}
	
	protected void Awake()
	{
		me = this;
		
		widthRatio = Screen.width/defaultScreenWidth;
		float heightRatio = Screen.height/defaultScreenHeight;
		
		if ( widthRatio <= heightRatio )
		{
			ratio = widthRatio;
			offsetY = (Screen.height - defaultScreenHeight * ratio) / 2;
		}
		else
		{
			ratio = heightRatio;
			offsetX = (Screen.width - defaultScreenWidth * ratio) / 2;
		}
		Debug.Log("widthRatio:"+widthRatio);
		Debug.Log("heightRatio:"+heightRatio);
		Debug.Log("offsetX:"+offsetX);
		myWidth = defaultScreenWidth * ratio;
		myHeight = defaultScreenHeight * ratio;
 	}
	
	protected void Start ()
	{
		
	}
}
