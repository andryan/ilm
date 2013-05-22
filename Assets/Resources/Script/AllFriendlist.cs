using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Prime31;

public class AllFriendlist : MonoBehaviour {
	
	public Main Parent = null;

	private static List<AllFriendlist> friend = null;
	private static List<int> friendReferenceID = null;
	
	private static List<GameObject> name = null;
	private static List<GameObject> score = null;
	private static List<GameObject> send = null;
	private static List<GameObject> background = null;
	
	private static int _zeroPosition;
	private static int _lastPosition;
	private static int _totalData;
	public static int _progress;
	
	private static string zero;
	private static string last;
	
	public static void ClearAll()
	{
		if (friend != null && name != null && score != null && send != null && background != null && friendReferenceID != null)
		{
			if (friend.Count > 0)
			{
				for ( int i=0; i<friend.Count; i++)
				{
					Destroy(friend[i].gameObject);
					Destroy(name[i].gameObject);
					Destroy(score[i].gameObject);
					Destroy(send[i].gameObject);
					Destroy(background[i].gameObject);
				}
			}
			friend = null;
			name = null;
			score = null;
			send = null;
			background = null;
			friendReferenceID = null;
		}
	}

	public static void Move(float _gap)
	{	
		if (_totalData == friend.Count)
		{
			Debug.LogWarning( "xxx " + friend[_zeroPosition].transform.localPosition.y + " ~~~ " + _zeroPosition + " ~~~ " + zero);
			Debug.LogWarning( "vvv " + friend[_lastPosition].transform.localPosition.y + " ~~~ " + _lastPosition + " ~~~ " + last);
			
			
			if (friend[_zeroPosition].transform.localPosition.y + _gap >= 226 &&
				friend[_lastPosition].transform.localPosition.y + _gap <= -270)
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
							
							Vector3 temp3 = score[i].transform.localPosition;
							temp3.y += _gap;
							score[i].transform.localPosition = temp3;
							
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
	
	//public static void Show(Texture2D _foto)
	public static void Show(Texture2D _foto, string _name, string _score, int _queue, int totalData)
	{
		if ( friend == null )
			friend = new List<AllFriendlist>();
		if ( friendReferenceID == null )
		 	friendReferenceID = new List<int>();
		if (name == null)
			name = new List<GameObject>();
		if (score == null)
			score = new List<GameObject>();
		if (send == null)
			send = new List<GameObject>();
		if (background == null)
			background = new List<GameObject>();
		
		float _posY = 225 - (_queue*100);
		
		GameObject MyFriend = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(MyFriend);
		MyFriend.name = "Friend_id: "+_queue;
		MyFriend.transform.localPosition = new Vector3(-410,_posY,-52);
		MyFriend.transform.localScale = new Vector3 (9,1,9);
		MyFriend.transform.Rotate(90, 180, 0);
		MyFriend.renderer.enabled = true;
		Material MyFriendBmp = (Material)Resources.Load ("SocialMenu/Materials/Send");
		MyFriend.renderer.material = MyFriendBmp;
		MyFriend.renderer.material.SetTexture("_MainTex", _foto);
		AllFriendlist allFriendlist = (AllFriendlist)MyFriend.AddComponent(typeof(AllFriendlist));
		friend.Add(allFriendlist);
		
		GameObject HerName = (GameObject)Instantiate((GameObject)Resources.Load ("SocialMenu/Prefabs/FontSprite_Left"));
		Main.AddParent(HerName);
		HerName.name = "Name: " + _queue;
		HerName.transform.localPosition = new Vector3(-350, _posY, -52);
		HerName.transform.localScale = new Vector3(1, 1, 1);
		HerName.renderer.material.color = Color.black;
		HerName.GetComponent<TextMesh>().text = _name;
		name.Add(HerName);
		
		GameObject HerScore = (GameObject)Instantiate((GameObject)Resources.Load ("SocialMenu/Prefabs/FontSprite_Right"));
		Main.AddParent(HerScore);
		HerScore.name = "Score: " + _queue;
		HerScore.transform.localPosition = new Vector3(100, _posY, -52);
		HerScore.renderer.material.color = Color.red;
		HerScore.GetComponent<TextMesh>().text = _score;
		score.Add(HerScore);
		
		GameObject SendInvite = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(SendInvite);
		SendInvite.name = "Invite: " + _queue;
		SendInvite.transform.localPosition = new Vector3(205, _posY, -53);
		SendInvite.transform.localScale = new Vector3 (9,1,9);
		SendInvite.transform.Rotate (90, 180, 0);
		SendInvite.renderer.enabled = true;
		SendInvite.renderer.material = (Material)Resources.Load ("SocialMenu/Materials/SendLive");
		send.Add(SendInvite);
		
		GameObject BG = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(BG);
		BG.name = "BG: " + _queue;
		BG.transform.localPosition = new Vector3(-111, _posY, -50);
		BG.transform.localScale = new Vector3 (80,1,10);
		BG.transform.Rotate (90, 180, 0);
		BG.renderer.enabled = true;
		if (_queue % 2 == 0)
			BG.renderer.material = (Material)Resources.Load ("SocialMenu/Materials/BGDark");
		else
			BG.renderer.material = (Material)Resources.Load ("SocialMenu/Materials/BGLight");
		background.Add(BG);
		
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
		Facebook.instance.debugRequests = true;	
	}
	
	private void Update()
	{
		
	}
}
