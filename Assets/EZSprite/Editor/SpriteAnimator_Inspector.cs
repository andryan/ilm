using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SpriteAnimator))]
//[CustomEditor(typeof(Renderer))]
public class SpriteAnimator_Inspector : Editor {
	
	static string version = "1.0";
	
	[MenuItem ("GameObject/EZSprite Animator %l")]
	static void Init()
	{
		if (Selection.activeGameObject && Selection.activeGameObject.hideFlags != HideFlags.NotEditable)
		{
			InitOperations(Selection.activeGameObject);
		}
		else
		{
			GameObject gNewSpriteAnim = new GameObject();
			gNewSpriteAnim.name = "New Sprite Animator";
			Selection.activeGameObject = gNewSpriteAnim;
			InitOperations(gNewSpriteAnim);
		}
    }
	
	static void InitAnimEditor(SpriteAnimator anim)
	{
		if (anim.animList == null) anim.AddAnimation();
		SpriteAnimator_Window window = (SpriteAnimator_Window)EditorWindow.GetWindow (typeof (SpriteAnimator_Window), false, "Animator " + version);
		//window.position = new Rect(50, 50, 600, 400);
		window.animToChange = anim;
		anim.UpdateOptions();
	}
	
	static void InitOperations (GameObject gOperator)
	{
		if (!gOperator.GetComponent<SpriteAnimator>())
		{
			if (!gOperator.GetComponent<MeshFilter>())
			{
				MeshFilter meshFilt = gOperator.AddComponent<MeshFilter>();
				GameObject gPlane = (Resources.Load("atlasPlane") as GameObject);
				if (gPlane)
				{
					meshFilt.mesh = gPlane.GetComponent<MeshFilter>().sharedMesh;
				}
				else Debug.Log("atlasPlane not found.");
			}
			if (!gOperator.GetComponent<Renderer>())
			{
				gOperator.AddComponent<MeshRenderer>();
			}
			gOperator.AddComponent<SpriteAnimator>();
		}
		else
		{
			Debug.LogWarning("Sprite Animator is already applied.");	
		}
	}
	
	public override void OnInspectorGUI()
	{
		SpriteAnimator spriteAnim = (SpriteAnimator)target;
		
		if (GUILayout.Button(spriteAnim.animList != null ? "Edit Animations" : "Add Animations", GUILayout.Height(30))) InitAnimEditor(spriteAnim);
		GUILayout.Space(10);
		
		/*EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Atlas Material");
		GUILayout.Space(68);
		spriteAnim.matAtlas = (Material)EditorGUILayout.ObjectField(spriteAnim.matAtlas, typeof(Material));
		EditorGUILayout.EndHorizontal();
		GUILayout.Space(3);*/
		
		//GUILayout.SelectionGrid(iHold, headers, 3);
		if (spriteAnim.animList != null)
		{
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Animation Wrap Mode");
			GUILayout.Space(20);
			spriteAnim.defaultWrapMode = (WrapMode)EditorGUILayout.EnumPopup(spriteAnim.defaultWrapMode);
			EditorGUILayout.EndHorizontal();
			
			spriteAnim.bPlayOnStart = EditorGUILayout.BeginToggleGroup("Play On Start", spriteAnim.bPlayOnStart);
			GUILayout.Space(3);
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Animation To Play");
			GUILayout.Space(42);
			spriteAnim.iPlayOnStartIndex = EditorGUILayout.Popup(spriteAnim.iPlayOnStartIndex, spriteAnim.options);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.EndToggleGroup();
				
			EditorGUILayout.BeginVertical("box");
			
			EditorGUILayout.BeginHorizontal();
			GUILayout.Label("Name", GUILayout.Width(Screen.width-180));
			GUILayout.Space(10);
			GUILayout.Label("Wrap", GUILayout.Width(60));
			GUILayout.Space(10);
			GUILayout.Label("FPS", GUILayout.Width(35));
			EditorGUILayout.EndHorizontal();
			for (int i = 0; i < spriteAnim.animList.Length; i++)
			{
				
				
				GUILayout.BeginHorizontal();
				spriteAnim.animList[i].animName = GUILayout.TextField(spriteAnim.animList[i].animName, GUILayout.Width(Screen.width-180));
				GUILayout.Space(10);
				
				spriteAnim.animList[i].wrapMode = (WrapMode)EditorGUILayout.EnumPopup(spriteAnim.animList[i].wrapMode, GUILayout.Width(60));
				GUILayout.Space(10);
				
				spriteAnim.animList[i].fps = EditorGUILayout.IntField(spriteAnim.animList[i].fps, GUILayout.Width(35));
				
				if (GUILayout.Button("x", new GUIStyle(EditorStyles.miniButton), GUILayout.Width(18)) && spriteAnim.animList.Length > 1) spriteAnim.RemoveAnimation(ref spriteAnim.iPlayOnStartIndex);
				GUI.Label(new Rect(3, 3 + (20*i), 10, 24), "LOL");
				GUILayout.EndHorizontal();
			}
			GUILayout.Space(3);			
			EditorGUILayout.EndVertical();
		}
		
	}
}
