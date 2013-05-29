using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	public Main Parent = null;
	
	private static GameObject Loadingcharacter;
	private static GameObject LoadingBG;
	
	private static float _delay;
	public static bool _islive;
	
	public static void clearAll()
	{
		_islive = false;
		
		Destroy(Loadingcharacter.gameObject);
		Destroy(LoadingBG.gameObject);
	}
	
	public static void Show()
	{
		_delay = 2F;
		_islive = true;
		
		Loadingcharacter = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(Loadingcharacter);
		Loadingcharacter.name = "Joget-joget";
		Loadingcharacter.transform.localPosition = new Vector3(0,0,-201);
		Loadingcharacter.transform.localScale = new Vector3(25,1,35);
		Loadingcharacter.transform.Rotate(90,180,0);
		Loadingcharacter.renderer.enabled = true;
		Loadingcharacter.renderer.material = (Material)Resources.Load ("SocialMenu/Materials/LoadingChar");
		
		LoadingBG = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(LoadingBG);
		LoadingBG.name = "LoadingBackground";
		LoadingBG.transform.localPosition = new Vector3(0,0,-200);
		LoadingBG.transform.localScale = new Vector3(Res.DefaultWidth()/Main.SizeFactor, 1, Res.DefaultHeight()/Main.SizeFactor);
		LoadingBG.transform.Rotate(90,180,0);
		LoadingBG.renderer.enabled = true;
		LoadingBG.renderer.material = (Material)Resources.Load ("SocialMenu/Materials/LoadingBG");
	}
	
	public static void AnimateChar()
	{
		//if (_islive == true)
		if (Loadingcharacter != null && LoadingBG != null)
		{
			if(_delay <= 0)
			{
				Vector2 temp = Loadingcharacter.renderer.material.mainTextureOffset;
				temp.x+=0.125F;
				
				if (temp.x > 0.6125)
					temp.x = 0;
				
				Loadingcharacter.renderer.material.mainTextureOffset = temp;
				_delay = 2F;
			}
			_delay -= Time.deltaTime*10;
			//Debug.LogWarning("~~~ " + _delay + " ~~~");
		}
	}
}
