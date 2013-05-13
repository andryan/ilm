using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Renderer))]
public class SpriteAnimator : MonoBehaviour {
	
	[System.Serializable]
	public class SpriteAnimation
	{
		public string animName;
		public Vector2[] spriteCoords;
		public WrapMode wrapMode;
		public int fps;
	}
	
	public string[] options;
	
	public WrapMode defaultWrapMode;
	public bool bPlayOnStart = true;
	public int iPlayOnStartIndex = 0;
	
	public Material matAtlas;
	public Vector2 graphSize;
	
	public SpriteAnimation[] animList;
	
	public Color cGridColor = Color.green;
	
	public int iFrame = 0;
	bool bPlaying, bPaused;
	bool bChangingFrame;
	int iLastAnimation;
	
	bool pong;
	
	void Start()
	{
//		if (bPlayOnStart) Play(iPlayOnStartIndex);	
	}
	
	//ADD & REMOVING ELEMENTS
	public void AddAnimation()
	{
		if (animList == null) animList = new SpriteAnimation[0];
		animList.CopyTo(animList = new SpriteAnimation[animList.Length + 1], 0);
		
		SpriteAnimation tempSprite = new SpriteAnimation();
		tempSprite.animName = "New Animation";
		tempSprite.spriteCoords = new Vector2[0];
		tempSprite.wrapMode = WrapMode.Default;
		tempSprite.fps = 30;
		
		animList[animList.Length-1] = tempSprite;
		UpdateOptions();
	}
	
	public void RemoveAnimation(ref int index)
	{
		RemoveAt<SpriteAnimation>(ref animList, ref index);
		UpdateOptions();
	}
	
	public void UpdateOptions()
	{
		options = new string[animList.Length];
		for (int i = 0; i < animList.Length; i++)
		{
			if (animList[i].animName == null || animList[i].animName == "") animList[i].animName = "New Animation";
			options[i] = i.ToString() + ": " + animList[i].animName;
		}
	}
	
	public void AddCoords(Vector2 coords, int index)
	{
		animList[index].spriteCoords.CopyTo(animList[index].spriteCoords = new Vector2[animList[index].spriteCoords.Length + 1], 0);
		animList[index].spriteCoords[animList[index].spriteCoords.Length-1] = coords;				
	}
	
	
	//PLAYS
	public void Play()
	{
		PerformPlay(0);
	}
	public void Play(string anim)
	{
		for(int i = 0; i < animList.Length; i++) 
		if (animList[i].animName == anim)
		{
			PerformPlay(i);
			break;
		}
	}
	//public void Play(int animIndex)
	//{
		//PerformPlay(animIndex);
	//}
	
	public void JPlay(string anim)
	{
		for(int i = 0; i < animList.Length; i++) 
		if (animList[i].animName == anim)
		{
			PerformPlay(i);
			break;
		}
	}
	
	void PerformPlay(int animIndex)
	{
		if (animIndex != iLastAnimation || bPaused || !bPlaying)
		{
			StopAllCoroutines();
			StartCoroutine(ChangeSprite(animIndex));	
		}
	}
	
	public void EditorPlay(int animIndex)
	{
		SpriteAnimation spriteAnim = animList[animIndex];
		
		if (animIndex != iLastAnimation) 
		{
			iLastAnimation = animIndex;
			bChangingFrame = false;
			iFrame = 0;
		}
		
		if (!bChangingFrame)
		{
			//StopAllCoroutines();
			bChangingFrame = true;
			bPlaying = true;
			if (iFrame >= spriteAnim.spriteCoords.Length) iFrame = 0;
			matAtlas.mainTextureOffset = new Vector2(spriteAnim.spriteCoords[iFrame].x/graphSize.x, spriteAnim.spriteCoords[iFrame].y/graphSize.y);
			
			bChangingFrame = false;
			iFrame++;
		}
	}
	
	protected IEnumerator ChangeSprite(int animIndex)
	{
		SpriteAnimation spriteAnim = animList[animIndex];
		WrapMode wrap = spriteAnim.wrapMode == WrapMode.Default ? defaultWrapMode : spriteAnim.wrapMode;
		bool playNext = true;
		
		if (animIndex != iLastAnimation) 
		{
			iLastAnimation = animIndex;
			bChangingFrame = false;
			iFrame = 0;
		}
		
		if (!bChangingFrame)
		{
			//StopAllCoroutines();
			bChangingFrame = true;
			bPlaying = true;
			if (!pong ? iFrame >= spriteAnim.spriteCoords.Length : iFrame <= -1)
			{
				switch(wrap)
				{
				case WrapMode.Clamp:
				case WrapMode.ClampForever:
				//case WrapMode.Once:
				case WrapMode.Default:
					iFrame = spriteAnim.spriteCoords.Length - 1;
					playNext = false;
					break;
				case WrapMode.Loop:
					iFrame = 0;
					break;
				case WrapMode.PingPong:
					if (!pong)
					{
						iFrame = spriteAnim.spriteCoords.Length > 1 ? spriteAnim.spriteCoords.Length - 2 : spriteAnim.spriteCoords.Length - 1;
						pong = true;
					}
					else
					{
						iFrame = spriteAnim.spriteCoords.Length > 1 ? 1 : 0;
						pong = false;
					}
					break;
				}
			}
			renderer.material.mainTextureOffset = new Vector2(spriteAnim.spriteCoords[iFrame].x/graphSize.x, spriteAnim.spriteCoords[iFrame].y/graphSize.y);
			
			yield return new WaitForSeconds((float)1.0f/spriteAnim.fps);
			bChangingFrame = false;
			iFrame += pong ? -1 : 1;
			if (playNext)StartCoroutine(ChangeSprite(animIndex));
		}
	}
	
	public void Stop() 
	{
		StopAllCoroutines();
		iFrame = 0;
		bPlaying = false;
		bPaused = false;
		bChangingFrame = false;
		pong = false;
	}
	
	public void Pause()
	{
		StopAllCoroutines();
		bPlaying = false;
		bPaused = false;
		bChangingFrame = false;
		pong = false;
	}
	
	//RETURN CURRENT ANIMATION NAME
	public string Playing()
	{
		return animList[iLastAnimation].animName;
	}
	
	//RETURN TRUE IF AN ANIMATION IS RUNNING
	public bool isPlaying
	{
		get
		{
			return bPlaying;	
		}
	}
	
	//TAKE IN ANIMATION NAME, RETURN ANIMATION INDEX
	public int GetAnimationIndex(string requestedAnimationName)
	{
		for(int i = 0; i < animList.Length; i++)
		{
			if (animList[i].animName == requestedAnimationName) return i;	
		}
		Debug.LogError("No animation \"" + requestedAnimationName + "\" found.");
		return -1;
	}
	//TAKE IN ANIMATION INDEX, RETURN ANIMATION NAME
	public string GetAnimationName(int requestedAnimationIndex)
	{
		if (requestedAnimationIndex < animList.Length-1 && requestedAnimationIndex > 0) return animList[requestedAnimationIndex].animName;	
		if (requestedAnimationIndex < 0 || requestedAnimationIndex > animList.Length-1) 
		{
			Debug.LogError("Requested index is out of range");
			return "";
		}
		return "";
	}
	
	//ARRAY MANAGEMENT
	public static void RemoveAt <type> (ref type[] arrayToChange, ref int index)
	{
		type[] tempArray = new type[arrayToChange.Length - 1];
		int j = 0;
		for(int i = 0; i < arrayToChange.Length; i++)
		{
			if (i != index)
			{
				tempArray[j] = arrayToChange[i];
				j++;	
			}
		}
		if (index != 0 && index == arrayToChange.Length-1) index -= 1;
		arrayToChange = tempArray;
	}
	
	public void Shift (int animIndex, int coordIndex, bool left)
	{
		Vector2 vTempCoord = animList[animIndex].spriteCoords[coordIndex];
		animList[animIndex].spriteCoords[coordIndex] = animList[animIndex].spriteCoords[left ? coordIndex-1 : coordIndex+1];
		animList[animIndex].spriteCoords[left ? coordIndex-1 : coordIndex+1] = vTempCoord;
	}
	
}
