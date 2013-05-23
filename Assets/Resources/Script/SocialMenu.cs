using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;						 // using prime31 plugin ~ nandi

//@ Author: Kaizer

public class SocialMenu : MonoBehaviour 
{
	// starting ping to test internet connection
	Ping ping = new Ping("8.8.8.8"); 
	
	//utakatik
	private enum States {Idle, MoveUp, MoveDown}
	private bool _onPress;
	private Vector3 _onPressPosition;
	private States _state;
	
	//@ Kaizer: Data
	public Main Parent = null;
	private int VFXTimer = 0;
	private List<string> MListenerList = null;
	private string ButtonSelection = "";
	
	//@ Kaizer: UI Component
	private GameObject MyInfoPanelBG = null;
	
	private GameObject MyTopPanel = null;
	private Material MyTopPanelBmp = null;
	
	private GameObject MyBottomPanel = null;
	private Material MyBottomPanelBmp = null;
	
	private GameObject MyInfoPanelGO = null;
	private Material MyInfoPanelBmp = null;

	private GameObject MyScrollPanel = null;
	private Material MyScrollPanelBmp =null;
	
	private GameObject MyReturnButton = null;
	private Material MyReturnButtonBmp = null;
		
	private GameObject MyRequestButton = null;
	private Material MyRequestButtonBmp = null;
	

//Facebook Prime31 ~ nandi
#if UNITY_ANDROID
	
	bool _postfb = false;
	bool _readfb = false;
	bool _reauthpostfb = false;
	bool _postscore = false;
	Texture2D _foto;

	void completionHandler( string error, object result )
	{
		if( error != null )
			Debug.LogWarning( error.ToString() );	
		else
			Prime31.Utils.logObject( result );
	}
	void GamerFriend( string error, object result)
	{
		if( error != null )
		{
			Debug.LogError(error);	
		}
		else
		{
			Prime31.Utils.logObject( result );
			Hashtable hash = (Hashtable) result;
			ArrayList _thisData = (ArrayList) hash["data"];
			
			int totalData = _thisData.Count;
			for (int i=0; i < totalData;i++)
			{
				Hashtable _gamerHash = (Hashtable) _thisData[i];
				Hashtable _gamername = (Hashtable) _gamerHash["user"];
				string _id = _gamername["id"].ToString();
				string _name = _gamername["name"].ToString();
				string _score = _gamerHash["score"].ToString();
				StartCoroutine( downloadImg(_id , _name , _score, i, totalData) );
			}
		}		
	}
	void Friend( string error, object result)
	{
		if( error != null )
		{
			Debug.LogError(error);	
		}
		else
		{
			Prime31.Utils.logObject( result );
			Hashtable hash = (Hashtable) result;
			ArrayList _thisData = (ArrayList) hash["data"];
			
			int totalData = _thisData.Count;
			for (int i=0; i < totalData;i++)
			{
				Hashtable _gamername = (Hashtable) _thisData[i];
				string _id = _gamername["id"].ToString();
				string _name = _gamername["name"].ToString();
				string _score = (i+1).ToString();
				StartCoroutine( downloadImg(_id , _name , _score, i, totalData) );
			}
		}		
	}
	IEnumerator downloadImg(string id, string name, string score, int queue, int totData) 
	{
		string _url = "https://graph.facebook.com/" + id.ToString() + "/picture";
		WWW www = new WWW(_url);								
		yield return www;
		_foto = (Texture2D) www.texture;
		AllFriendlist.Show(_foto, name, score, queue, totData);
    }
	IEnumerator postFB ()
	{
		//Facebook.instance.postMessage( "im posting this from Unity: " + Time.deltaTime, completionHandler );
		var parameters = new Dictionary<string,string>
		{
			{ "link", "http://prime31.com" },
			{ "name", "link name goes here" },
			{ "picture", "http://prime31.com/assets/images/prime31logo.png" },
			{ "caption", "the caption for the image is here" }
		};
		FacebookAndroid.showDialog( "stream.publish", parameters );
		yield return _postfb = true;
	}
	IEnumerator apprequestFB ()
	{
		//Facebook.instance.postMessage( "im posting this from Unity: " + Time.deltaTime, completionHandler );
		var parameters = new Dictionary<string,string>
		{
			{ "link", "http://prime31.com" },
			{ "name", "link name goes here" },
			{ "picture", "http://prime31.com/assets/images/prime31logo.png" },
			{ "caption", "the caption for the image is here" }
		};
		FacebookAndroid.showDialog( "stream.publish", parameters );
		yield return _postfb = true;
	}
	IEnumerator readFB ()
	{
		var isSessionValid = FacebookAndroid.isSessionValid();
		var permissions = FacebookAndroid.getSessionPermissions();
		Debug.LogWarning( "~~~ isSessionValid: " + isSessionValid.ToString() + " ~~~" );
		Debug.LogWarning( "~~~ permissions: " + permissions.Count.ToString() + " ~~~" );
		//Facebook.instance.graphRequest( "me/friends?limit=20", HTTPVerb.GET, Friend );
		Facebook.instance.graphRequest( "139845789541043/scores", HTTPVerb.GET, GamerFriend );
		//Facebook.instance.graphRequest( "me?fields=id", HTTPVerb.GET, getIdHandler );
		
		yield return _readfb = true;
		Debug.LogWarning( "HELL YEAH " + _readfb.ToString()  );
	}
	IEnumerator reauthpostFB ()
	{
		FacebookAndroid.reauthorizeWithPublishPermissions( new string[] { "publish_actions" }, FacebookSessionDefaultAudience.EVERYONE );
		yield return _reauthpostfb = true;
	}
	IEnumerator postScore ()
	{
		var parameters = new Dictionary<string,object>
		{
			{ "score", "6666" }
		};
		Facebook.instance.graphRequest( "me/scores", HTTPVerb.POST, parameters, completionHandler);
		yield return _postscore = true;
	}
	
	void getIdHandler( string error, object result )
	{
		Debug.LogWarning( " >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> " );
		if( error != null )
			Debug.LogWarning( error.ToString() );	
		else
		{
			Prime31.Utils.logObject( result );
			Hashtable hash = (Hashtable) result;
			Main._userIdFB = hash["id"].ToString();
			Debug.LogWarning( " >>>>>>>>>>> " + hash["id"].ToString() );
		}
	}
	
	private void StartFB()
	{
		Debug.LogWarning("1 >>>>>>>>>>> " + ping.time .ToString() );
		float _delay = 10f;
		while (true)
		{
			if (ping.isDone || _delay < 0 )
			    break;
			
			//_delay -= Time.time/10000;
			_delay -= Time.deltaTime/10000;
		}
		Debug.LogWarning("1 >>>>>>>>>>> " + ping.time .ToString() );
		
		
		if (ping.time > 0)
		{
			Facebook.instance.debugRequests = true;
			
			var isSessionValid = FacebookAndroid.isSessionValid();
			var permissions = FacebookAndroid.getSessionPermissions();
			Debug.LogWarning( "~~~ isSessionValid: " + isSessionValid.ToString() + " ~~~" );
			Debug.LogWarning( "~~~ permissions: " + permissions.Count.ToString() + " ~~~" );
			
			//StartCoroutine( reauthpostFB() );
			//StartCoroutine(postFB());
			StartCoroutine(readFB());
		}
		else
		{
			Debug.LogWarning( " your internet is woongky, change your ISP " );				
		}
	}
	
#else
	
	private void StartFB()
	{
		Debug.LogWarning( "not an Android Platform" );	
	}
	
#endif
	
	public void Init(Main PassParent)
	{	
		StartFB();									// staring Prime31 Function
		
		Parent = PassParent;
		MListenerList = new List<string>();
		BuildScreen ();
		VFX_1 ();
	}
	
	
	//@ Kaizer: VFX List
	private void Update()
	{
		Debug.LogWarning(Main._userIdFB);
		
		
		//Debug.Log("VFX timer : " + VFXTimer);
		if ( Input.anyKey)
		{
			Vector2 inputPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
	       		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out hit))
				{
					Debug.LogWarning(hit.transform.gameObject.name);
					
					if(MListenerList != null)
					{
						bool Check = false;
						for(int a =0;a<MListenerList.Count;a++)
						{
							if(MListenerList[a] == hit.transform.gameObject.name)
							{
								Check = true;	
							}
						}
						if(Check == true)
						{
							ButtonSelection = hit.transform.gameObject.name;
							_onPressPosition = inputPosition;
							SelectButton();
							//hit.transform.gameObject.transform.localScale = new Vector3(hit.transform.gameObject.transform.localScale.x*1.1f,1.0f,hit.transform.gameObject.transform.localScale.z*1.1f);	
						}
					}
				}
			}
			if ( _onPress )
			{
				Scroll(inputPosition);
			}
		}
		else
		{
			_onPress = false;
			_state = States.Idle;
		}
	}
	private void Scroll( Vector2 _newPosition)
	{
		if (_readfb == true)
		{
			float _gap = _newPosition.y - _onPressPosition.y;
			_onPressPosition.y = _newPosition.y;
			AllFriendlist.Move(_gap);
		}
	}
	private void VFX_1()
	{
		VFXTimer = 0;
		InvokeRepeating("UpdateVFX_1", 0, (float)(1f/(float)Main.FPS));	
		
	}
	private void StopVFX_1()
	{
		VFXTimer = 0;
		CancelInvoke("UpdateVFX_1");
	}
	private void UpdateVFX_1()
	{
		VFXTimer++;
		if(VFXTimer == 10)
		{
			iTween.FadeTo (MyInfoPanelBG,iTween.Hash("alpha",0.5f,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelBG.renderer.enabled = true;
			//iTween.ScaleTo (MyInfoPanelGO,iTween.Hash("x",(Res.DefaultWidth()/Main.SizeFactor),"z",(Res.DefaultHeight()/Main.SizeFactor),"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			//iTween.ScaleTo (MyInfoPanelGO,iTween.Hash("x",(800/Main.SizeFactor),"z",(Res.DefaultHeight()/Main.SizeFactor),"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			//iTween.ScaleTo (MyTopPanel,iTween.Hash("x",(800/Main.SizeFactor),"z",(Res.DefaultHeight()/Main.SizeFactor),"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));

		}
		if(VFXTimer == 40)
		{
			iTween.FadeTo (MyReturnButton,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyReturnButton.renderer.enabled = true;
			iTween.FadeTo (MyRequestButton,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyRequestButton.renderer.enabled = true;
		}
		if(VFXTimer == 50)
		{
			MUpOnButtons();
			StopVFX_1();
		}
	}
	private void EndVFX()
	{
		VFXTimer = 0;
		InvokeRepeating("UpdateEndVFX", 0, (float)(1f/(float)Main.FPS));	
		
	}
	private void StopEndVFX()
	{
		VFXTimer = 0;
		CancelInvoke("UpdateEndVFX");
	}
	private void UpdateEndVFX()
	{
		VFXTimer++;
		if(VFXTimer == 1)
		{
			iTween.FadeTo (MyInfoPanelBG,iTween.Hash("alpha",0f,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			//iTween.ScaleTo (MyInfoPanelGO,iTween.Hash("x",0.000001f,"z",0.000001,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			//iTween.ScaleTo (MyTopPanel,iTween.Hash("x",0.000001f,"z",0.000001,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyReturnButton,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyRequestButton,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
		}
		if(VFXTimer == 25)
		{
			Clear ();	
			//Parent.ClearCS ();
		}
	}
	
	//@ Kaizer: Listener
	private void MUpOnButtons()
	{
		if(MListenerList != null)
		{
			if(MyReturnButton != null)
			{
				if(!MListenerList.Contains(MyReturnButton.name))	
				{
					MListenerList.Add (MyReturnButton.name);
				}	
			}
			if(MyRequestButton != null)
			{
				if(!MListenerList.Contains(MyRequestButton.name))	
				{
					MListenerList.Add (MyRequestButton.name);
				}	
			}
			if(MyInfoPanelGO != null)
			{
				if(!MListenerList.Contains(MyInfoPanelGO.name))
				{
					MListenerList.Add (MyInfoPanelGO.name);	
				}	
			}
			if (MyScrollPanel != null)
			{
				if (!MListenerList.Contains(MyScrollPanel.name))
				{
					MListenerList.Add (MyScrollPanel.name);	
				}
			}
			
		}	
	}
	private void RemoveMUpOnButtons()
	{
		if(MListenerList != null)
		{
			MListenerList = null;	
			MListenerList = new List<string>();
		}
	}
	
	private void SelectButton()
	{
		if (ButtonSelection == "MyScrollPanel")
		{
			_onPress = true;
		}
		if (ButtonSelection == "Return")
		{
			AllFriendlist.ClearAll();
			Main.MySE.PlaySFX("Select");
			EndVFX();
		}
		if (ButtonSelection == "Request")
		{
			Debug.LogWarning("1 >>>>>>>>>>> " + ping.time .ToString() );
			if (ping.time > 0)
				StartCoroutine(postFB());
			else
				Debug.LogWarning( " your internet is woongky, change your ISP " );				
		
		}
	}
	
	//@ Kaizer: Build UI Component
	private void BuildScreen()
	{
		BuildBG();	
		BuildInfoPanel();
		BuildInfoPanelPictureBar();
	}
	
	private void BuildBG()
	{
		if(MyInfoPanelBG == null)
		{
			MyInfoPanelBG = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelBG);
			MyInfoPanelBG.name = "InfoPanelBG";
			MyInfoPanelBG.transform.localPosition = new Vector3(0,0,-46);
			MyInfoPanelBG.transform.localScale = new Vector3(Res.DefaultWidth()/Main.SizeFactor, 1, Res.DefaultHeight()/Main.SizeFactor);
			MyInfoPanelBG.transform.Rotate (90, -180, 0);
			MyInfoPanelBG.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelBG,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelBG.renderer.material = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanel");
			MyInfoPanelBG.renderer.material.color = Color.black;
		}
	}
	private void BuildInfoPanel()
	{
		if(MyInfoPanelGO == null )
		{
			MyInfoPanelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelGO);
			MyInfoPanelGO.name = "InfoPanelGO";
			MyInfoPanelGO.transform.localPosition = new Vector3(-111,0,-48);
			MyInfoPanelGO.transform.localScale = new Vector3(80, 1, 90);
			MyInfoPanelGO.transform.Rotate (90,-180,0);
			MyInfoPanelBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanel");
			MyInfoPanelGO.renderer.material = MyInfoPanelBmp;
			
			MyTopPanel = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyTopPanel);
			MyTopPanel.name = "MyTopPanel";
			MyTopPanel.transform.localPosition = new Vector3(-111,335,-54);
			MyTopPanel.transform.localScale = new Vector3(80, 1, 10);
			MyTopPanel.transform.Rotate (90,-180,0);
			MyTopPanelBmp = (Material)Resources.Load ("SocialMenu/Materials/TopPanel");
			MyTopPanel.renderer.material = MyTopPanelBmp;
			
			MyBottomPanel = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyBottomPanel);
			MyBottomPanel.name = "MyBottomPanel";
			MyBottomPanel.transform.localPosition = new Vector3(-111,-362,-54);
			MyBottomPanel.transform.localScale = new Vector3(80, 1, 5);
			MyBottomPanel.transform.Rotate (90,-180,0);
			MyBottomPanelBmp = (Material)Resources.Load ("SocialMenu/Materials/TopPanel"); // should be bottom
			MyBottomPanel.renderer.material = MyBottomPanelBmp;
		}		
		BuildScrollPanel();
	}
	private void BuildScrollPanel()
	{
		MyScrollPanel = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Main.AddParent(MyScrollPanel);
		MyScrollPanel.name = "MyScrollPanel";
		MyScrollPanel.transform.localPosition = new Vector3(-111,0,-52);
		MyScrollPanel.transform.localScale = new Vector3(80, 1, 90);
		MyScrollPanel.transform.Rotate (90,-180,0);
		MyScrollPanelBmp = (Material)Resources.Load ("SocialMenu/Materials/BGLight");
		MyScrollPanel.renderer.material = MyScrollPanelBmp;
	}
	
	private void BuildInfoPanelPictureBar()
	{
		if(MyReturnButton == null)
		{
			MyReturnButton = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyReturnButton);
			MyReturnButton.name = "Return";
			MyReturnButton.transform.localPosition = new Vector3( 450, 325,-50);
			MyReturnButton.transform.localScale = new Vector3(10, 1, 10);
			MyReturnButton.transform.Rotate (90, -180, 0);
			MyReturnButton.renderer.enabled = true;
			//MyReturnButton.renderer.enabled = false;
			//iTween.FadeTo (MyReturnButton,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyReturnButtonBmp = (Material)Resources.Load ("SocialMenu/Materials/Return");
			MyReturnButton.renderer.material = MyReturnButtonBmp;
			
			MyRequestButton = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyRequestButton);
			MyRequestButton.name = "Request";
			MyRequestButton.transform.localPosition = new Vector3( 450, 0,-50);
			MyRequestButton.transform.localScale = new Vector3(10, 1, 10);
			MyRequestButton.transform.Rotate (90, -180, 0);
			MyRequestButton.renderer.enabled = true;
			//MyRequestButton.renderer.enabled = false;
			//iTween.FadeTo (MyRequestButton,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyRequestButtonBmp = (Material)Resources.Load ("SocialMenu/Materials/SendInvite");
			MyRequestButton.renderer.material = MyRequestButtonBmp;
		}
	}	
	private void ClearInfoPanelNext()
	{
		if(MyReturnButton != null)
		{
			MyReturnButtonBmp = null;
			Destroy (MyReturnButton);
			MyReturnButton = null;
		}
		if(MyRequestButton != null)
		{
			MyRequestButtonBmp = null;
			Destroy (MyRequestButton);
			MyRequestButton = null;
		}
	}
	private void ClearInfoPanelPictureBar()
	{

	}
	private void ClearInfoPanel()
	{
		if(MyInfoPanelGO != null)
		{
			MyInfoPanelBmp = null;
			Destroy (MyInfoPanelGO);
			MyInfoPanelGO = null;
		}
		if(MyTopPanel != null)
		{
			MyTopPanelBmp = null;
			Destroy (MyTopPanel);
			MyTopPanel = null;
		}
		if(MyBottomPanel != null)
		{
			MyBottomPanelBmp = null;
			Destroy (MyBottomPanel);
			MyBottomPanel = null;
		}
		if(MyScrollPanel != null)
		{
			MyScrollPanelBmp = null;
			Destroy(MyScrollPanel);
			MyScrollPanel = null;
		}
	}
	private void ClearBG()
	{
		if(MyInfoPanelBG != null)
		{
			Destroy (MyInfoPanelBG);
			MyInfoPanelBG = null;
		}
	}
	
	private void ClearScreen()
	{
		ClearInfoPanelNext();
		ClearInfoPanelPictureBar();
		ClearInfoPanel();
		ClearBG();
	}
	
	private void ClearAllVFX()
	{
		StopEndVFX();
		StopVFX_1();
	}
	private void ClearAllListener()
	{
		RemoveMUpOnButtons();
	}
	private void ClearAllComponent()
	{
		ClearScreen ();
	}
	
	public void Clear()
	{	
		//AllFriendlist.ClearAll();
		
		MListenerList = null;
		ClearAllVFX();
		ClearAllListener();
		ClearAllComponent();
		//Main.MyResultCal.UpdatePlayerAtr();
		//Parent.ClearGameScreen();
		print ("CLEARED SOCIAL MENU SCREEN");
		//Parent.ShowPnMScreen();
		//Parent.ClearStartScreen();
		//Parent.ShowStartScreen();
		Parent = null;
		//Destroy (this.gameObject.GetComponent("ResultScreen"));
		Destroy (this.gameObject.GetComponent("SocialMenu"));
		
	}
}
