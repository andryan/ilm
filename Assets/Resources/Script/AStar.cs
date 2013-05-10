using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class AStar : MonoBehaviour 
{
	private static int HV_COST = 10;
	private static int D_COST = 14;
	private static bool ALLOW_DIAGONAL = false;
	private static bool ALLOW_DIAGONAL_CORNERING = true;
	private static int MapH = 0;
	private static int MapW = 0;
	private static List<List<Hashtable>> MapStatus = null;
	private static List<List<int>> OpenList = null;
	//private static List<List<int>> FPath = null;
	//private static int x1 = 0;
	//private static int y1 = 0;
	
	private void Start()
	{
		
	}
	
	public static List<List<int>> FindPath(List<List<int>> map, int startY, int startX, int endY, int endX)
	{
		MapH = map.Count;
		MapW = map[0].Count;
		MapStatus = new List<List<Hashtable>>();
		
		for(int i=0;i<MapH;i++)
		{
			MapStatus.Add (new List<Hashtable>());
			for(int j = 0; j<MapW;j++)
			{
				MapStatus[i].Add (null);	
			}
			//MapStatus[i] = new List<Hashtable>();	
		}
		
		OpenList = new List<List<int>>();
		OpenSquare(startY,startX,null,0);
		
		while(OpenList.Count >0 && !IsClosed (endY, endX))
		{
			int i = NearerSquare();
			int nowY = OpenList[i][0];
			int nowX = OpenList[i][1];
			CloseSquare(nowY,nowX);
			
			for(int j = nowY-1; j<nowY+2; j++)
			{
				for(int k = nowX-1; k<nowX+2; k++)
				{
					if(j>=0 && j<MapH && k>=0 && k<MapW && !(j == nowY && k == nowX) && (ALLOW_DIAGONAL || j == nowY || k == nowX) && (ALLOW_DIAGONAL_CORNERING || j == nowY || k == nowX || ((int)map[j][nowX] == 0 && CheckAvailable(map, nowY, k)==true)))
					{
						if(map[j][k] == 0)
						{
							if(!IsClosed(j,k))
							{
								int MovementCost = (int)MapStatus[nowY][nowX]["MovementCost"] + ((j==nowY || k == nowX ? HV_COST : D_COST)*map[j][k]);
								if(IsOpen (j,k))
								{
									if(MovementCost < (int)MapStatus[j][k]["MovementCost"])
									{
										OpenSquare(j,k,new List<int>(new int[]{nowY,nowX}), MovementCost, 0, true);	
									}
								}
								else
								{
									int Heuristic = (Mathf.Abs(j-endY)+Mathf.Abs(k-endX))*10;
									OpenSquare(j,k,new List<int>(new int[]{nowY,nowX}),MovementCost,Heuristic,false);
								}
								/*var MovementCost:int = MapStatus[nowY][nowX].MovementCost+((j == nowY || k == nowX ? HV_COST : D_COST)*map[j][k]);
									*/	
							}
						}
					}
				}
			}
		}
		bool PFound = IsClosed (endY,endX);
		if(PFound)
		{
			List<List<int>> ReturnPath = new List<List<int>>();
			int nowY = endY;
			int nowX = endX;
			while((nowY != startY) || (nowX != startX))
			{
				ReturnPath.Add (new List<int>(new int[2]{nowY,nowX}));
				List<int> TemList = (List<int>)MapStatus[nowY][nowX]["Parent"];
				int newY = (int)TemList[0];
				int newX = (int)TemList[1];
				nowY = newY;
				nowX = newX;
			}
			ReturnPath.Add (new List<int>(new int[2]{startY,startX}));
			//FPath = new List<List<int>>();
			//FPath = ReturnPath;
//			Debug.Log (ReturnPath.Count+" FromAStar");
			return ReturnPath;
		}
		else
		{
			Debug.Log("NO PATH");
			return null;	
		}
	}
	private static bool CheckAvailable(List<List<int>> map, int y, int x)
	{
		bool Flag = false;
		if(y < map.Count)
		{
			if(x < map[y].Count)
			{
				Flag = true;	
			}
		}
		return Flag;
	}
	private static bool IsOpen(int y, int x)
	{
		bool Flag = false;
		if(y<MapStatus.Count)
		{
			if(x<MapStatus[y].Count)
			{
				if(MapStatus[y][x] != null)
				{
					Flag = (bool)MapStatus[y][x]["Open"];	
				}
			}
		}
		return Flag;
	}
	private static bool IsClosed(int y, int x)
	{
		bool Flag = false;
		if(y<MapStatus.Count)
		{
			if(x<MapStatus[y].Count)
			{
				if(MapStatus[y][x] != null)
				{
					Flag = (bool)MapStatus[y][x]["Closed"];	
				}
			}
		}
		return Flag;
	}
	private static int NearerSquare()
	{
		int Minimum = 999999;
		int IndexFound = 0;
		int ThisF = 0;
		Hashtable ThisSquare = null;
		int i = OpenList.Count;
		
		while(i-->0)
		{
			ThisSquare = MapStatus[OpenList[i][0]][OpenList[i][1]];
			ThisF = (int)ThisSquare["Heuristic"] + (int)ThisSquare["MovementCost"];
			if(ThisF <= Minimum)
			{
				Minimum = ThisF;
				IndexFound = i;
			}
		}
		return IndexFound;
	}
	private static void CloseSquare(int y, int x)
	{
		int Len = OpenList.Count;
		for(int i =0; i<Len;i++)
		{
			if(OpenList[i][0] == y)
			{
				if(OpenList[i][1] == x)
				{
					OpenList.RemoveAt (i);
					break;
				}
			}
		}
		MapStatus[y][x]["Open"] = false;
		MapStatus[y][x]["Closed"] = true;
	}
	private static void OpenSquare(int y, int x, List<int> Parent, int MovementCost, int Heuristic =0, bool Replacing = false)
	{
		if(!Replacing)
		{
			OpenList.Add(new List<int>(new int[2]{y,x}));
			Hashtable TemHO = new Hashtable();
			TemHO["Heuristic"] = Heuristic;
			TemHO["Open"] = true;
			TemHO["Closed"] = false;
			TemHO["Parent"] = Parent;
			TemHO["MovementCost"] = MovementCost;
			MapStatus[y][x] = TemHO;
			//MapStatus[y][x] = HashObject.Hash ("Heuristic", Heuristic, "Open", true, "Closed", false, "Parent",Parent, "MovementCost", MovementCost);
		}
	}
}
