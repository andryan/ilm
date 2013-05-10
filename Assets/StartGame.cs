using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class StartGame : MonoBehaviour 
{
	private List<List<int>> map = null;
	/*
	 * var map:Array = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0],
				 [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
				 [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0]];
	 */
	// Use this for initialization
	private void Start () 
	{
		map = new List<List<int>>();
		map.Add (new List<int>(new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}));
		map.Add (new List<int>(new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}));
		
		List<List<int>> FPath = AStar.FindPath(map, 7,3,11,14);
		for(int i = 0; i<FPath.Count;i++)
		{
			Debug.Log (FPath[i][0]+","+FPath[i][1]);	
		}
		
		
	}
}
