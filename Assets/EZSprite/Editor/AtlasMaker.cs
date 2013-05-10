using UnityEngine;
using System.Collections;
using UnityEditor;

public class AtlasMaker : EditorWindow {
	
	static string version = "1.1";
	
	public Texture2D[] atlasImages = new Texture2D[0];
	public Texture2D currentTexture;
	Texture2D outTexture;
	SerializedProperty images;
	
	float timeSet;
	int clickCount = 0;
	Vector2 scrollPos, fullScroll;
	
	bool mipMap, makeMaterial;
	
	bool displayLoading = false;
	int loadingCurrent, loadingMax = 1;
	
	[MenuItem ("Window/EZSprite Atlas Maker")]
	static void Init()
	{
		AtlasMaker window = (AtlasMaker)EditorWindow.GetWindow (typeof (AtlasMaker), false, "Atlaser v" + version);
		window.position = new Rect(50, 50, 400, 500);
		//ScriptableWizard.DisplayWizard("Atlas Maker", typeof(AtlasMaker), "Create");
    }
	
	void OnGUI()
	{
		fullScroll = EditorGUILayout.BeginScrollView(fullScroll);
		AtlasMakerGUI();
		EditorGUILayout.EndScrollView();
	}
	
	void AtlasMakerGUI()
	{
		float iHeight = Mathf.Clamp(position.height, 300, position.height);
		float iWidth = Mathf.Clamp(position.width, 300, position.width);
		
		//scrollPos = GUI.BeginScrollView(new Rect(0, 0, iWidth-2, iHeight-5), scrollPos, new Rect(0, 0, 200, 400));
		
		currentTexture = (Texture2D)EditorGUI.ObjectField(new Rect(100,3,100,100), "", currentTexture, typeof(Texture2D), false);
		GUI.Label(new Rect(130, 103, 50, 20), "Preview");
		
		GUI.Label(new Rect(3, 3, 100, 20), "Mip Map");
		mipMap = GUI.Toggle(new Rect(82, 3, 98, 20), mipMap, "");
		GUI.Label(new Rect(3, 25, 100, 20), "New Material");
		makeMaterial = GUI.Toggle(new Rect(82, 25, 98, 20), makeMaterial, "");
		
		//ADD SINGLE TEXTURE
		//IF THE TEXTURE IS UNREADABLE, PROMPT TO AUTO READABLIZE (word) IT.
		if(GUI.Button(new Rect(208,3, iWidth - 210, 20),"Add Preview"))
		{
			if (currentTexture)
			{
				string path = AssetDatabase.GetAssetPath(currentTexture);
	      		TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
	        	if (textureImporter.isReadable == true)
				{
					atlasImages.CopyTo(atlasImages = new Texture2D[atlasImages.Length + 1], 0);
					atlasImages[atlasImages.Length - 1] = currentTexture;
				}
				else 
				{
					if (EditorUtility.DisplayDialog("Unreadable Texture", "Do you want to make the texture readable? (Manually changing is recommended.)", "Make Readable", "Cancel"))
					{
						MakeReadable(new Texture2D[1] {currentTexture});
	      				TextureImporter textureImporterB = AssetImporter.GetAtPath(path) as TextureImporter;
						if (textureImporterB.isReadable == true)
						{
							atlasImages.CopyTo(atlasImages = new Texture2D[atlasImages.Length + 1], 0);
							atlasImages[atlasImages.Length - 1] = currentTexture;
						}
						else EditorUtility.DisplayDialog("Result", "Could not make readable, manual change may be required.", "Okay");
					}
				}
			}
			else Debug.LogWarning("Please choose a texture to add using the asset selector.");
		}
		
		//ADD ALL SELECTED TEXTURES
		if(GUI.Button(new Rect(208,26, iWidth - 210, 20),"Add Selected"))
		{
			Texture2D[] unreadables = new Texture2D[0];
			bool bAllReadable = AddMultipleTextures(GetSelectedTextures(), ref unreadables);
			if (!bAllReadable) 
			{
				if (EditorUtility.DisplayDialog(unreadables.Length.ToString() + " Unreadable Texture(s)", "Do you want to make the texture(s) readable? (Manually changing is recommended.)", "Make Readable", "Cancel"))
				{
					MakeReadable(unreadables);
					bool b = SecondMultipleAdd(unreadables);
					if(!b) EditorUtility.DisplayDialog("Result", "Could not make readable, manual change may be required.", "Okay");
				}
			}
		}
		
		//DELETE ALL TEXTURES IN THE ARRAY
		//FIRST CLICK PROMPTS DOUBLE CLICK AND MAKES A NOTICABLE BEEP*
		if(GUI.Button(new Rect(208,49, iWidth - 210, 20),"Delete All") && atlasImages.Length != 0)
		{
			clickCount++;
			if (clickCount == 1)
			{
				EditorApplication.Beep(); //*IF THE BEEP ANNOYS YOU REMOVE THIS LINE //MIGHT MAKE A SETTING IF I REMEMBER
				timeSet = (float)EditorApplication.timeSinceStartup;
				this.ShowNotification(new GUIContent("Click again to delete all sprites."));
			}
			else if (clickCount == 2)
			{
				this.RemoveNotification();
				atlasImages = new Texture2D[0];
				clickCount = 0;
				Repaint();
			}
		}
		
		//MAKE THE SPRITE ATLAS
		//THEN OPEN PREVIEW WINDOW FOR USER APPROVAL, SWIFTLY FOLLOWED BY SAVING AND JOY
		if (GUI.Button(new Rect(208,72, iWidth - 210, 20),"New Atlas") && atlasImages.Length !=0)
		{
			TextureImporterFormat oldTexForm = new TextureImporterFormat();
			bool bAtleastOneUncompressed = false;
			for (int i = 0; i < atlasImages.Length; i++)
			{
				if (atlasImages[i].format != TextureFormat.DXT1 && atlasImages[i].format != TextureFormat.DXT5)
				{
					bAtleastOneUncompressed = true;
				}
			}
			
			if (!bAtleastOneUncompressed) MakeCompressed(ref atlasImages[0], false, ref oldTexForm);
			
			outTexture = new Texture2D(0,0, TextureFormat.ARGB32, false);
			//outTexture.PackTextures(atlasImages, 0,sizeValue[index]);
			Pack(ref outTexture, atlasImages);
			
			if (!bAtleastOneUncompressed) MakeCompressed(ref atlasImages[0], true, ref oldTexForm);
			
			AtlasMaker_Preview preview = (AtlasMaker_Preview)EditorWindow.GetWindow (typeof (AtlasMaker_Preview), true, "Atlas Preview");
			
			preview.previewTexture = outTexture;
			preview.makeMaterial = makeMaterial;
			preview.mipMap = mipMap;
			
			float fRatio = ((float)outTexture.width/outTexture.height);
			preview.position = new Rect (position.x, position.y, Mathf.Clamp((int)(250*fRatio) + 2, 250, (int)(250*fRatio) + 2) , 280);
			preview.fRatio = fRatio;
		}
		
		//LOADING BAR TO BE DISPLAYED WHENEVER SOMETHING IS WORKING
		if (displayLoading)
		{
			EditorGUI.ProgressBar(new Rect(210, 95, iWidth - 214, 20), loadingCurrent/loadingMax, "Loading...");	
		}
		
		//DRAW THE TEXTURE LIST
		//NOTE: REPEAT TEXTURES ARE DRAWN AS ONE CELL WHEN THE ATLAS IS MADE
		GUI.Box(new Rect(1, 119, iWidth-5, iHeight-126),"");
		
		scrollPos = GUI.BeginScrollView(new Rect(2, 120, iWidth-7, iHeight-128), scrollPos, new Rect(0, 0, 200, 58*atlasImages.Length));
		
		for (int i = 0; i < atlasImages.Length; i++)
		{
			GUI.Box(new Rect(37, 3 + (i*58), 52, 52),"");
			GUI.Label(new Rect(3, 15 + (i*58), 100, 25), (i+1).ToString() + ":");
			GUI.DrawTexture(new Rect(38, 4 + (i*58), 50, 50), atlasImages[i]);
			if (GUI.Button(new Rect(103, 15 + (i*58), 80, 25), "Delete"))
			{
				DeleteTexture(i);
				Repaint();
			}
			if (GUI.Button(new Rect(190, 15 + (i*58), 80, 25), "Replace"))
			{
				if (currentTexture)	atlasImages[i] = currentTexture;
				else Debug.LogWarning("Please select a texture to replace with in the Preview section.");
			}
			
			Color guiColor = GUI.color;		
			if (i > 0)
			{
				if (GUI.Button(new Rect(275, 18 + (i*58), 20, 20), new GUIContent ("", "Move Texture " + (i+1).ToString() + " to " + i.ToString() + ".")))
				{
					Shift(i, true);
					Repaint();
				}
				GUI.color = Color.black;
				GUI.DrawTexture(new Rect(279, 22 + (i*58), 13, 13), (Texture2D)Resources.Load("button_up"));
				GUI.color = guiColor;
			}
			if (i < atlasImages.Length-1)
			{
				if (GUI.Button(new Rect(300, 18 + (i*58), 20, 20), new GUIContent ("", "Move Texture " + (i+1).ToString() + " to " + (i+2).ToString() + ".")))
				{
					Shift(i, false);
					Repaint();
				}	
				GUI.color = Color.black;
				GUI.DrawTexture(new Rect(304, 22 + (i*58), 13, 13), (Texture2D)Resources.Load("button_down"));
				GUI.color = guiColor;
			}
		
		}
		
		GUI.EndScrollView();
	}
	
	void Shift(int i, bool left)
	{
		Texture2D tempTex = atlasImages[i];
		atlasImages[i] = atlasImages[left ? i-1 : i+1];
		atlasImages[left ? i-1 : i+1] = tempTex;	
	}
	
	//ONLY USED FOR DOUBLE CLICKING... WORKS, BUT RATHER DIRTY
	void Update()
	{
		if (clickCount == 1 && (EditorApplication.timeSinceStartup - timeSet) > 2f)
		{
			this.RemoveNotification();
			clickCount = 0;
			Repaint();
		}
	}
	
	void DeleteTexture(int spot)
	{
		Texture2D[] tex = new Texture2D[0];
		for (int i = 0; i < atlasImages.Length; i++)
		{
			if (i != spot)
			{
				tex.CopyTo(tex = new Texture2D[tex.Length + 1], 0);
				tex[tex.Length - 1] = atlasImages[i];
			}
		}
		atlasImages = tex;
	}
	
	static Object[] GetSelectedTextures()
    {
        return Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
    }
	
	//THIS ONLY SOMETIMES DOESN'T WORK
	//MAKE TEXTURES ADVANCED AND READABLE
	void MakeReadable(Texture2D[] texs)
	{
		loadingMax = texs.Length;
		loadingCurrent = 0;
		displayLoading = true;
		
		Undo.RegisterUndo(texs, "Make Readable");
		for(int i = 0; i < texs.Length; i++)
		{
			string path = AssetDatabase.GetAssetPath(texs[i]);
      		TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
			textureImporter.textureType = TextureImporterType.Advanced;
			textureImporter.isReadable = true;
			AssetDatabase.ImportAsset(path);
			loadingCurrent++;
			Repaint();
		}
		
		displayLoading = false;
	}
	
	void MakeCompressed(ref Texture2D tex, bool compress, ref TextureImporterFormat oldTexForm)
	{
		string path = AssetDatabase.GetAssetPath(tex);
		TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
		if (!compress) oldTexForm = textureImporter.textureFormat;
		textureImporter.textureFormat = compress ? oldTexForm : TextureImporterFormat.ARGB32;
		AssetDatabase.ImportAsset(path);
	}
	
	//ADD MULTIPLE TEXTURES
	//FIRST - SELECTED
	//SECOND - ANY TEXTURES NOT ADDED IN FIRST PASS
	bool SecondMultipleAdd(Texture2D[] texs) {return AddMultipleTextures((Object[])texs, ref texs);}
	bool AddMultipleTextures(Object[] texs, ref Texture2D[] unreadables)
	{
		loadingMax = texs.Length;
		loadingCurrent = 0;
		displayLoading = true;
		
		bool bAllReadable = true;
		foreach (Texture2D tex in texs)
		{
			string path = AssetDatabase.GetAssetPath(tex);
      		TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
        	if (textureImporter.isReadable == true)
			{
				atlasImages.CopyTo(atlasImages = new Texture2D[atlasImages.Length + 1], 0);
				atlasImages[atlasImages.Length - 1] = tex;
			}
			else 
			{
				unreadables.CopyTo(unreadables = new Texture2D[unreadables.Length + 1], 0);
				unreadables[unreadables.Length - 1] = tex;
				bAllReadable = false;
			}
			loadingCurrent++;
			Repaint();
		}
		displayLoading = false;
		return bAllReadable;
	}
	
	void OnInspectorUpdate() {
		Repaint();
	}
	
	void Pack(ref Texture2D atlas, Texture2D[] textures)
	{	
		Undo.RegisterUndo(textures, "New Atlas");
		//Remove Duplicates
		System.Collections.ArrayList temp = new System.Collections.ArrayList();
        foreach (Texture2D tex in textures)
            if (!temp.Contains(tex) && tex.width == textures[0].width && tex.height == textures[0].height)
                temp.Add(tex);
			else if (tex.width != textures[0].width || tex.height != textures[0].height) Debug.LogWarning("Textures must be the same size.");
		
		Texture2D[] distinctTex = (Texture2D[])temp.ToArray(typeof(Texture2D));
		
		//Find Array Dimensions
		int x = Mathf.CeilToInt(Mathf.Sqrt(distinctTex.Length));
		int y = x;
		
		atlas.Resize(distinctTex[0].width*x, distinctTex[0].height*y);
		
		int curTex = 0;
		int curWidth = 0;
		int curHeight = 0;
		
		for (int i = 0; i < y; i++)
		{
			for (int t = 0; t < x; t++)
			{
				if (curTex < distinctTex.Length)
				{
					Color[] cols = distinctTex[curTex].GetPixels();
					atlas.SetPixels(curWidth, curHeight, distinctTex[curTex].width, distinctTex[curTex].height, cols);
					curWidth += distinctTex[curTex].width;
					curTex++;
				}
			}
			if (curTex < distinctTex.Length)
			{
				curHeight += distinctTex[curTex].height;
				curWidth = 0;
			}
		}
		atlas.Apply();
	}
	
	
}
