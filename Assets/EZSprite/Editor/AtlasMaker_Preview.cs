using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class AtlasMaker_Preview : EditorWindow {

	public Texture2D previewTexture;
	public float fRatio;
	
	public bool makeMaterial, mipMap;
	
	
	void OnGUI()
	{
		GUI.Box(new Rect(0,0,250*fRatio + 2,252), "");
		GUI.DrawTexture(new Rect(1,1,(int)(250*fRatio),250), previewTexture);
		
		if (GUI.Button(new Rect(130, 255, 120, 20), "Save"))
		{
			
			string path = EditorUtility.SaveFilePanel("Save New Atlas", Application.dataPath, "", "png");
			if (path.EndsWith(".png"))
			{
				FileStream stream = new FileStream(path, FileMode.Create);
				BinaryWriter w = new BinaryWriter(stream);
				w.Write( previewTexture.EncodeToPNG() );
				w.Close();
				stream.Close();
			
				AssetDatabase.Refresh();
				EditorUtility.DisplayDialog("Result", "Texture was saved successfully.", "Ok");
				 
				TextureImporter textureImporter = AssetImporter.GetAtPath(path.Remove(0, Application.dataPath.Length-6)) as TextureImporter;
				textureImporter.textureType = TextureImporterType.GUI;
	            textureImporter.mipmapEnabled = mipMap;
				textureImporter.anisoLevel = 0;
				textureImporter.textureFormat = TextureImporterFormat.ARGB32;
				textureImporter.filterMode = FilterMode.Point;
				
				if (makeMaterial)
				{
					string matPath = AssetDatabase.GetAssetPath(textureImporter);
					int i = matPath.Length-1;
					while (i > 0)
					{
						if (matPath[i] == '/') break;
						else i--;
					}
					matPath = matPath.Remove(i);
					
					Material matAltas = new Material(Shader.Find("Transparent/Cutout/Soft Edge Unlit"));
					matAltas.mainTexture = (Texture2D)AssetDatabase.LoadAssetAtPath(AssetDatabase.GetAssetPath(textureImporter), typeof(Texture2D));
					AssetDatabase.CreateAsset(matAltas, matPath + "/" + Path.GetFileNameWithoutExtension(path) + ".mat");
					//textureImporter.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
				}
				
	            AssetDatabase.ImportAsset(path.Remove(0, Application.dataPath.Length-6));
				
				Close();
			}
		}
		
		if (GUI.Button(new Rect(3, 255, 120, 20), "Close"))
		{
			Close();
		}
	}
}
