using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class AllFriendsInvite : MonoBehaviour {
	
	public Main Parent = null;

	private static List<AllFriendsInvite> friend = null;
	private static List<int> friendReferenceID = null;
	
	private static List<GameObject> name = null;
	private static List<GameObject> send = null;
	private static List<GameObject> background = null;
	private static List<string> id = null;
	
	private static int _zeroPosition;
	private static int _lastPosition;
	private static int _totalData;
	public static int _progress;
	
	private static string zero;
	private static string last;
	
	public static void ClearAll()
	{
		if (friend != null && name != null && send != null && background != null && friendReferenceID != null)
		{
			if (friend.Count > 0)
			{
				for ( int i=0; i<friend.Count; i++)
				{
					Destroy(friend[i].gameObject);
					Destroy(name[i].gameObject);
					Destroy(send[i].gameObject);
					Destroy(background[i].gameObject);
				}
			}
			friend = null;
			name = null;
			send = null;
			background = null;
			friendReferenceID = null;
			id = null;
		}
	}

	public static void Move(float _gap)
	{	
		if (_totalData == friend.Count)
		{
			if (friend[0].transform.localPosition.z != 50)
			{
				if (friend[_zeroPosition].transform.localPosition.y + _gap >= 294 &&
					friend[_lastPosition].transform.localPosition.y + _gap <= -90)
				{	
					for ( int i=0; i<friend.Count; i++)
					{
						{
							Vector3 temp1 = friend[i].transform.localPosition;
							temp1.y += _gap;
							friend[i].transform.localPosition = temp1;
							
							Vector3 temp2 = name[i].transform.localPosition;
							temp2.y += _gap;
							name[i].transform.localPosition = temp2;
	
							Vector3 temp4 = send[i].transform.localPosition;
							temp4.y += _gap;
							send[i].transform.localPosition = temp4;
							
							Vector3 temp5 = background[i].transform.localPosition;
							temp5.y += _gap;
							background[i].transform.localPosition = temp5;
						}
					}
				}
				else
				{
					_gap = 0; 
				}
			}
		}
	}
		public static void SwitchIn()
	{
		if (friend[0].transform.localPosition.z != 50)
		{
			float _gap = 100;
			for ( int i=0; i<friend.Count; i++)
			{
				{
					Vector3 temp1 = friend[i].transform.localPosition;
					temp1.z += _gap;
					friend[i].transform.localPosition = temp1;
					
					Vector3 temp2 = name[i].transform.localPosition;
					temp2.z += _gap;
					name[i].transform.localPosition = temp2;
					
					Vector3 temp4 = send[i].transform.localPosition;
					temp4.z += _gap;
					send[i].transform.localPosition = temp4;
					
					Vector3 temp5 = background[i].transform.localPosition;
					temp5.z += _gap;
					background[i].transform.localPosition = temp5;
				}
			}
		}
	}
	public static void SwitchOut()
	{
		if (friend[0].transform.localPosition.z == 50)
		{
			float _gap = -100;
			for ( int i=0; i<friend.Count; i++)
			{
				{
					Vector3 temp1 = friend[i].transform.localPosition;
					temp1.z += _gap;
					friend[i].transform.localPosition = temp1;
					
					Vector3 temp2 = name[i].transform.localPosition;
					temp2.z += _gap;
					name[i].transform.localPosition = temp2;
					
					Vector3 temp4 = send[i].transform.localPosition;
					temp4.z += _gap;
					send[i].transform.localPosition = temp4;
					
					Vector3 temp5 = background[i].transform.localPosition;
					temp5.z += _gap;
					background[i].transform.localPosition = temp5;
				}
			}
		}
	}
	
	public static string SendInvite(string _input)
	{
		for ( int i=0; i<friend.Count; i++)
		{
			if (_input == send[i].name)
				return id[i];
		}	
		string output = "";
		return output;
	}
	
	public static void Show(Texture2D _foto, string _id, string _name, int _queue, int totalData)
	{
		if ( friend == null )
			friend = new List<AllFriendsInvite>();
		if ( friendReferenceID == null )
		 	friendReferenceID = new List<int>();
		if (name == null)
			name = new List<GameObject>();
		if (send == null)
			send = new List<GameObject>();
		if (background == null)
			background = new List<GameObject>();
		if (id == null)
			id = new List<string>();
		
		float _posY = 295 - (_queue*100);
		float initZ = 100;
		
		GameObject MyFriend = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(MyFriend);
		MyFriend.name = "X Friend_id: "+_queue;
		MyFriend.transform.localPosition = new Vector3(-403,_posY,-50+initZ);
		MyFriend.transform.localScale = new Vector3 (9,1,9);
		MyFriend.transform.Rotate(90, 180, 0);
		MyFriend.renderer.enabled = true;
		Material MyFriendBmp = (Material)Resources.Load ("SocialMenu/Materials/Send");
		MyFriend.renderer.material = MyFriendBmp;
		MyFriend.renderer.material.SetTexture("_MainTex", _foto);
		AllFriendsInvite allFriendsInvite = (AllFriendsInvite)MyFriend.AddComponent(typeof(AllFriendsInvite));
		friend.Add(allFriendsInvite);
		
		GameObject HerName = (GameObject)Instantiate((GameObject)Resources.Load ("SocialMenu/Prefabs/FontSprite_Left3"));
		Main.AddParent(HerName);
		HerName.name = "X Name: " + _queue;
		HerName.transform.localPosition = new Vector3(-425, _posY, -52+initZ);
		HerName.transform.localScale = new Vector3(1, 1, 1);
		HerName.renderer.material.color = Color.black;
		if (_name.Length > 21)
			HerName.GetComponent<TextMesh>().text = _name.Substring(0,21);
		else
			HerName.GetComponent<TextMesh>().text = _name;
		name.Add(HerName);
		
		GameObject SendInvite = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(SendInvite);
		SendInvite.name = "X Invite: " + _queue;
		SendInvite.transform.localPosition = new Vector3(73, _posY, -54+initZ);
		SendInvite.transform.localScale = new Vector3 (9,1,9);
		SendInvite.transform.Rotate (90, 180, 0);
		SendInvite.renderer.enabled = true;
		SendInvite.renderer.material = (Material)Resources.Load ("SocialMenu/Materials/SendLive");
		send.Add(SendInvite);
		
		GameObject BG = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(BG);
		BG.name = "X BG: " + _queue;
		BG.transform.localPosition = new Vector3(-160, _posY, -51+initZ);
		BG.transform.localScale = new Vector3 (60,1,9);
		BG.transform.Rotate (90, 180, 0);
		BG.renderer.enabled = true;
		BG.renderer.material = (Material)Resources.Load ("SocialMenu/Materials/InvitePanel");
		background.Add(BG);
		
		id.Add(_id);
		
		_totalData = totalData;
		if (_queue == 0)
		{
			_zeroPosition = friend.Count - 1;	
			zero = _name;	
		}
		if (_queue == _totalData-1)
		{
			_lastPosition = friend.Count - 1;
			last = _name;
		}
		friendReferenceID.Add(friendReferenceID.Count);
	}
	
	private void Start()
	{
			
	}
	
	private void Update()
	{
		
	}
}
