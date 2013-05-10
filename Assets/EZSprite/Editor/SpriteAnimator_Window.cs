using UnityEngine;
using System.Collections;
using UnityEditor;

public class SpriteAnimator_Window : EditorWindow {
	
	
	Vector2 scrollPos, animScrollPos;
	
	bool bShow = true;
	
	int iGraphMax = 26;
	char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
	Vector2 vSavedCoord = new Vector2();
	
	int iAnimIndex = 0;
	
	bool bPlaying, bPaused;
	
	double clickTime, doubleClickTime = 0.5;
	Vector2 buttonID;
	
	double frameTime;
	bool pong;
	
	public SpriteAnimator animToChange;
	Texture2D lastTex;
	
	void OnGUI()
	{
		if (!animToChange) return;
		
		float iWidth = Mathf.Clamp(Screen.width, Screen.width, 300);
		
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Atlas Material");
		animToChange.matAtlas = (Material)EditorGUI.ObjectField(new Rect(90, 3, iWidth-100, 16) ,animToChange.matAtlas, typeof(Material), false);
		EditorGUILayout.EndHorizontal();
		
		if (!animToChange.matAtlas && animToChange.GetComponent<Renderer>().sharedMaterial) animToChange.matAtlas = animToChange.GetComponent<Renderer>().sharedMaterial;
		else animToChange.GetComponent<Renderer>().sharedMaterial = animToChange.matAtlas;
		
		
		//ONLY DISPLAY THE GOODS IF A MATERIAL HAS BEEN SELECTED
		//ONCE A MATERIAL HAS BEEN SELECTED THE MATERIAL CAN NEVER BE SET TO NONE
		if (animToChange.matAtlas)
		{
			Color guiColor = GUI.color;
			if (animToChange.animList == null) animToChange.AddAnimation();
			
			//GRID SETTINGS
			bShow = EditorGUILayout.Foldout(bShow, "Grid");
			
			if(bShow)
			{
				EditorGUI.indentLevel = 3;
				animToChange.cGridColor = EditorGUI.ColorField(new Rect(275,48,iWidth-155/*155*/, 16), "Grid Color", animToChange.cGridColor); 
				EditorGUI.indentLevel = 0;
				
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.PrefixLabel("Horizontal");
				animToChange.graphSize.y = EditorGUI.IntSlider(new Rect(90, 38, iWidth-100, 16), (int)animToChange.graphSize.y, 1, iGraphMax);
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.PrefixLabel("Vertical");
				animToChange.graphSize.x = EditorGUI.IntSlider(new Rect(90, 59, iWidth-100, 16), (int)animToChange.graphSize.x, 1, iGraphMax);
				EditorGUILayout.EndHorizontal();
			}
		
			//TEXTURE DISPLAY
			EditorGUILayout.BeginVertical();
			scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false, GUILayout.Height(330/*330*/));
			
			float fRatio = 1;
			Vector2 vTiling = new Vector2(1/animToChange.graphSize.x, 1/animToChange.graphSize.y);
			
			Texture2D texAtlas = (Texture2D)animToChange.matAtlas.mainTexture;
			fRatio = Mathf.Clamp((float)texAtlas.height/texAtlas.width, 0, 1);
			GUI.Box(new Rect(20, 3, iWidth-6, (iWidth-6)*fRatio), "");
			GUI.DrawTexture(new Rect(21, 4, iWidth-8, (iWidth-8)*fRatio), texAtlas);
			animToChange.matAtlas.mainTextureScale = vTiling;
			
			if (lastTex != texAtlas)
			{
				position = new Rect(position.x, position.y, 600, fRatio == 1 ? 400 : 250);
				lastTex = texAtlas;
			}
			
			//DRAW THE GRID
			GUI.color = animToChange.cGridColor;
			for (int i = 0; i < animToChange.graphSize.x; i++)
			{
				if (i>0)GUI.DrawTexture(new Rect(21 + (((iWidth-8)/animToChange.graphSize.x)*i) ,4, 1, (iWidth-8)*fRatio), EditorGUIUtility.whiteTexture);
				GUI.Label(new Rect(21 + (((iWidth-8)/animToChange.graphSize.x)*i), (iWidth-3)*fRatio, 20, 20), ""+alpha[i]);	
			}
			for (int i = 0; i < animToChange.graphSize.y; i++)
			{
				if (i>0)GUI.DrawTexture(new Rect(21, 4 + ((((iWidth-8)*fRatio)/animToChange.graphSize.y)*i), iWidth-8, 1), EditorGUIUtility.whiteTexture);
				GUI.Label(new Rect(3, ((iWidth-18)*fRatio) - ((((iWidth-8)*fRatio)/animToChange.graphSize.y)*i), 20, 20), i.ToString());	
			}
			GUI.color = guiColor;
			
			//DRAW THE SEMI-INVISIBLE BUTTONS
			//FIRST CLICK CHANGES GAME OBJECTS COORDS
			//SECOND CLICK ADDS COORDS TO LIST
			GUI.color = new Color(1,1,1,0.1f);
			for (int i = 0; i < animToChange.graphSize.x; i++)
			{
				for (int t = 0; t < animToChange.graphSize.y; t++)
				{
					if (GUI.Button(new Rect(
		                    21 + (((iWidth-8)/animToChange.graphSize.x)*i),
		                    4 + ((((iWidth-8)*fRatio)/animToChange.graphSize.y)*t),
		                    (iWidth-8)/animToChange.graphSize.x,
		                    ((iWidth-8)*fRatio)/animToChange.graphSize.y),
			               	EditorGUIUtility.whiteTexture))
					{
						vSavedCoord = new Vector2(vTiling.x*i, vTiling.y*(animToChange.graphSize.y-t-1));
						animToChange.matAtlas.mainTextureOffset = vSavedCoord;
						if ((EditorApplication.timeSinceStartup - clickTime) < doubleClickTime && buttonID == new Vector2(i,t))
						{
				        	animToChange.AddCoords(new Vector2 (i, animToChange.graphSize.y-t-1), iAnimIndex);
						}
				
				       	clickTime = EditorApplication.timeSinceStartup;
						buttonID = new Vector2(i,t);
					}
				}
			}
			GUI.color = guiColor;
			
			//ADD NEW ANIMATION AND NAME IT... "NEW ANIMATION"
			if (GUI.Button(new Rect(485, 3, 15, 15), ""))
			{
				bPlaying = false;
				animToChange.AddAnimation();
				iAnimIndex = animToChange.animList.Length - 1;
			}
			GUI.Label(new Rect(485, 2, 20, 20), "+");
			//REMOVE ANIMATION AND NAME IT...
			if (GUI.Button(new Rect(465, 3, 15, 15), ""))
			{
				if (animToChange.animList.Length > 1)
				{
					Undo.RegisterUndo(animToChange, "Remove Animation");
					animToChange.RemoveAnimation(ref iAnimIndex);
				}
			}
			GUI.Label(new Rect(467, 2, 20, 20), "-");
			
			iAnimIndex = EditorGUI.Popup(new Rect(330/*230*/,3,130/*230*/, 18), "", iAnimIndex, animToChange.options);
			
			GUI.Label(new Rect(330, 26, 100, 20), "Name");
			animToChange.animList[iAnimIndex].animName = EditorGUI.TextField(new Rect(370, 26, 130, 20), animToChange.animList[iAnimIndex].animName);
			
			if (animToChange.options[iAnimIndex] != animToChange.animList[iAnimIndex].animName) animToChange.UpdateOptions();
			
			
			//DIPLAY ANIMATION CONTROLS
			GUI.Box(new Rect(330, 50, 171, fRatio == 0.5f ? 100 : 247), animToChange.animList[iAnimIndex].spriteCoords.Length == 0 ? "\n\nDouble-click a grid cell to add a frame." : "");
			GUI.Box(new Rect(330, 50, 29, 18), "fps");
			GUI.Box(new Rect(359, 50, 30, 18), "", "textField");
			animToChange.animList[iAnimIndex].fps = EditorGUI.IntField(new Rect(361, 52, 27, 30), animToChange.animList[iAnimIndex].fps, GUIStyle.none);
			
			animToChange.animList[iAnimIndex].fps = Mathf.Clamp(animToChange.animList[iAnimIndex].fps, 0, 999);
			
			
			GUI.Box(new Rect(389, 50, 58, 17), "pos");
			animToChange.animList[iAnimIndex].wrapMode = (WrapMode)EditorGUI.EnumPopup(new Rect(389, 51, 58, 18), animToChange.animList[iAnimIndex].wrapMode);
			
			//FANCY UNITY CONTROLS RIPOFF
			GUI.color = bPlaying ? Color.gray : guiColor;
			if (GUI.Button(new Rect(447, 50, 18, 18), "", new GUIStyle(EditorStyles.miniButtonLeft)) && animToChange.animList[iAnimIndex].spriteCoords.Length > 0)  //PLAY
			{
				bPlaying = !bPlaying;
				if (bPlaying == false) 
				{
					bPaused = false;
					animToChange.Stop();
					animToChange.matAtlas.mainTextureOffset = vSavedCoord;	
					pong = false;
				}
				else 
				{
					animToChange.EditorPlay(iAnimIndex);
					frameTime = EditorApplication.timeSinceStartup;
				}
			}
			GUI.color = bPaused && bPlaying ? Color.gray : guiColor;
			if (GUI.Button(new Rect(465, 50, 18, 18), "", new GUIStyle(EditorStyles.miniButtonMid)) && bPlaying) bPaused = !bPaused; //PAUSE
			GUI.color = guiColor;
			if (GUI.Button(new Rect(483, 50, 18, 18), "", new GUIStyle(EditorStyles.miniButtonRight)) && bPlaying) //STEP
			{
				bPaused = true;
				animToChange.EditorPlay(iAnimIndex);
			}
			
			GUI.color = bPlaying ? new Color (0.2f, 0.7f, 1) : Color.black;
			GUI.DrawTexture(new Rect(451, 54, 10, 10), (Texture2D)Resources.Load("button_play"));
			GUI.DrawTexture(new Rect(469, 54, 10, 10), (Texture2D)Resources.Load("button_pause"));
			GUI.DrawTexture(new Rect(487, 54, 10, 10), (Texture2D)Resources.Load("button_step"));
			GUI.color = guiColor;
		
			
			//LIST THE ANIMATION SPRITES AND DISPLAY A PREVIEW
			int animSpacing = 45;
			animScrollPos = GUI.BeginScrollView(new Rect(330, 68, 170, fRatio == 0.5f ?  81 : 228), animScrollPos, new Rect(0,0, 150, 3 + animSpacing*animToChange.animList[iAnimIndex].spriteCoords.Length));
			for (int i = 0; i < animToChange.animList[iAnimIndex].spriteCoords.Length; i++)
			{
				GUI.Label(new Rect(45, 3 + (animSpacing*i), 60, 18), "(" + alpha[(int)animToChange.animList[iAnimIndex].spriteCoords[i].x] + ", " + animToChange.animList[iAnimIndex].spriteCoords[i].y.ToString() + ")");
				GUI.Label(new Rect(87, 3 + (animSpacing*i), 60, 18), i.ToString());
				
				
				DrawTextureClipped (texAtlas, (int)animToChange.animList[iAnimIndex].spriteCoords[i].x, (int)((animToChange.graphSize.y-1)-animToChange.animList[iAnimIndex].spriteCoords[i].y), 3, 2 + (animSpacing*i));
				
				GUI.color = new Color(1, 0.3f, 0.3f);
				if (GUI.Button(new Rect(3, 1 + (animSpacing*i), 16, 16), new GUIContent("", "Delete Frame " + i.ToString() + "."), new GUIStyle(EditorStyles.radioButton)))
				{
					Undo.RegisterUndo(animToChange, "Remove Frame");
					int j = i;
					SpriteAnimator.RemoveAt<Vector2>(ref animToChange.animList[iAnimIndex].spriteCoords, ref j);
					Repaint();
				}
				GUI.color = guiColor;
				GUI.Label(new Rect(5, (animSpacing*i), 16, 16), "x", new GUIStyle(EditorStyles.whiteBoldLabel));
				
				if (i > 0)
				{
					if (GUI.Button(new Rect(118, 5 + (animSpacing*i), 16, 16), new GUIContent ("", "Move Frame " + i.ToString() + " to " + (i-1).ToString() + "."), new GUIStyle(EditorStyles.miniButton)))
					{
						animToChange.Shift(iAnimIndex, i, true);
						Repaint();
					}
					GUI.color = Color.black;
					GUI.DrawTexture(new Rect(121, 8 + (animSpacing*i), 10, 10), (Texture2D)Resources.Load("button_up"));
					GUI.color = guiColor;
				}
				if (i < animToChange.animList[iAnimIndex].spriteCoords.Length-1)
				{
					if (GUI.Button(new Rect(137, 5 + (animSpacing*i), 16, 16), new GUIContent ("", "Move Frame " + i.ToString() + " to " + (i+1).ToString() + "."), new GUIStyle(EditorStyles.miniButton)))
					{
						animToChange.Shift(iAnimIndex, i, false);
						Repaint();
					}	
					GUI.color = Color.black;
					GUI.DrawTexture(new Rect(140, 8 + (animSpacing*i), 10, 10), (Texture2D)Resources.Load("button_down"));
					GUI.color = guiColor;
				}
			}
			GUI.EndScrollView();
			
			EditorGUILayout.EndScrollView();
			EditorGUILayout.EndVertical();
			
		}
		
	}
	
	//IN-EDITOR PLAY SYSTEM
	void Update()
	{
		if (bPlaying)
		{
			if (EditorApplication.timeSinceStartup - frameTime >= (float)1/animToChange.animList[iAnimIndex].fps)
			{
				WrapMode wrap = animToChange.animList[iAnimIndex].wrapMode == WrapMode.Default ? animToChange.defaultWrapMode : animToChange.animList[iAnimIndex].wrapMode;
				bool playNext = true;
				
				if (!pong ? animToChange.iFrame >= animToChange.animList[iAnimIndex].spriteCoords.Length : animToChange.iFrame <= -1)
				{
					switch(wrap)
					{
					case WrapMode.Clamp:
					case WrapMode.ClampForever:
					//case WrapMode.Once:
					case WrapMode.Default:
						animToChange.iFrame = animToChange.animList[iAnimIndex].spriteCoords.Length - 1;
						playNext = false;
						break;
					case WrapMode.Loop:
						animToChange.iFrame = 0;
						break;
					case WrapMode.PingPong:
						if (!pong)
						{
							animToChange.iFrame = animToChange.animList[iAnimIndex].spriteCoords.Length > 1 ? animToChange.animList[iAnimIndex].spriteCoords.Length - 2 : animToChange.animList[iAnimIndex].spriteCoords.Length - 1;
							pong = true;
						}
						else
						{
							animToChange.iFrame = animToChange.animList[iAnimIndex].spriteCoords.Length > 1 ? 1 : 0;
							pong = false;
						}
						break;
					}
				}
				
				if (playNext)
				{
					animToChange.EditorPlay(iAnimIndex);
					frameTime = EditorApplication.timeSinceStartup;
				}
			}
		}
		if (bPaused) frameTime = EditorApplication.timeSinceStartup;
		
		if (Application.isPlaying) Close();
	}
	
	//DRAW SCALED IMAGE OF SPRITE PREVIEW
	void DrawTextureClipped(Texture2D textureToDraw, int u, int v, float x, float y)
	{
		
		float widthRatio = Mathf.Clamp((animToChange.graphSize.y/animToChange.graphSize.x), 0, 1);
		float heightRatio = Mathf.Clamp((animToChange.graphSize.x/animToChange.graphSize.y), 0, 1);
		float size = 40.0f;
		float xMod = (widthRatio < heightRatio ? widthRatio : 1);
		float yMod = (heightRatio < widthRatio ? heightRatio : 1);
		float wR = size/textureToDraw.width * xMod;
		float hR = size/textureToDraw.height * yMod;
		GUI.BeginGroup (new Rect(x+(size-(size*xMod)), y+(size-(size*yMod)), size*xMod, size*yMod));
		GUI.Box(new Rect(0, 0, size*xMod, size*yMod), "");
		GUI.DrawTexture (new Rect(-u*size*xMod, -v*size*yMod, textureToDraw.width*wR*animToChange.graphSize.x, textureToDraw.height*hR*animToChange.graphSize.y), textureToDraw);
		GUI.EndGroup ();
	}
}
