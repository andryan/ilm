using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class ResultScreen : MonoBehaviour 
{
	//@ Kaizer: Data
	public Main Parent = null;
	private int VFXTimer = 0;
	private List<string> MListenerList = null;
	private string ButtonSelection = "";
	
	//@ Kaizer: UI Component
	
	private GameObject MyInfoPanelBG = null;
	
	private GameObject MyInfoPanelGO = null;
	private Material MyInfoPanelBmp = null;
	
	private GameObject MyInfoPanelPictureBarGO = null;
	private Material MyInfoPanelPictureBarBmp = null;
	
	private GameObject MyInfoPanelPictureBar2GO = null;
	private Material MyInfoPanelPictureBar2Bmp = null;
	
	private GameObject MyInfoPanelNextGO = null;
	private Material MyInfoPanelNextBmp = null;
	
	private GameObject MyInfoPanelBackGO = null;
	private Material MyInfoPanelBackBmp = null;
	
	private GameObject EarningText = null;
	private GameObject STText = null;
	
	private GameObject MyInfoPanelPotraitGO = null;
	private Material MyInfoPanelPotraitBmp = null;
	
	private GameObject CoinText = null;
	private GameObject LikeText = null;
	private GameObject RunawayText = null;
	
	private GameObject ST3StarText = null;
	private GameObject ST5StarText = null;
	private GameObject ST4StarText = null;
	private GameObject ST6StarText = null;
	
	private GameObject GameOverText = null;
	private GameObject GameOverTextShadow = null;
	
	public void Init(Main PassParent)
	{
		Main.MySE.StopBGM ();
		Main.MySE.PlaySFX("Clear");
		Parent = PassParent;
		MListenerList = new List<string>();
		BuildScreen ();
		VFX_1 ();
	}
	
	
	public void InitLose(Main PassParent)
	{
		Main.MySE.StopBGM();
		Main.MySE.PlaySFX("Clear");
		Parent = PassParent;
		MListenerList = new List<string>();
		BuildLoseScreen();
		VFX_2 ();
	}
	
	
	//@ Kaizer: VFX List
	private void Update()
	{
		Debug.Log("VFX timer : " + VFXTimer);
		if (Input.GetMouseButtonDown(0))
		{
        	RaycastHit hit;
       		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				if(MListenerList != null)
				{
					/*bool Check = false;
					for(int a =0;a<MListenerList.Count;a++)
					{
						if(MListenerList[a] == hit.transform.gameObject.name)
						{
							Check = true;	
						}
					}*/
					//if(Check == true)
					{
						ButtonSelection = hit.transform.gameObject.name;
						
						if(Main.MyTile != null)
						{
							if(Main.MyTile.isLose == false)
							{
								SelectButton();
							}
							else
							{
								ToMainMenuButton();
							}
						}
						//hit.transform.gameObject.transform.localScale = new Vector3(hit.transform.gameObject.transform.localScale.x*1.1f,1.0f,hit.transform.gameObject.transform.localScale.z*1.1f);	
					}
				}
			}
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
			iTween.ScaleTo (MyInfoPanelGO,iTween.Hash("x",(float)(787/Main.SizeFactor)/1.5f,"z",(float)(474/Main.SizeFactor)/1.5f,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			
		}
		if(VFXTimer == 40)
		{
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelPictureBarGO.renderer.enabled = true;
			iTween.FadeTo (MyInfoPanelPictureBar2GO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelPictureBar2GO.renderer.enabled = true;
			iTween.FadeTo (MyInfoPanelNextGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelNextGO.renderer.enabled = true;
			
			BuildAllText();
		}
		
		if(VFXTimer == 50)
		{
			//MUpOnButtons();
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
			ClearAllText();
			iTween.FadeTo (MyInfoPanelBG,iTween.Hash("alpha",0f,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.ScaleTo (MyInfoPanelGO,iTween.Hash("x",0.000001f,"z",0.000001,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelPictureBar2GO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelNextGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
		}
		if(VFXTimer == 25)
		{
			Clear ();	
			//Parent.ClearCS ();
		}
	}
	
	private void VFX_2()
	{
		VFXTimer = 0;
		InvokeRepeating("UpdateVFX_2", 0, (float)(1f/(float)Main.FPS));
	}
	
	private void StopVFX_2()
	{
		VFXTimer = 0;
		CancelInvoke("UpdateVFX_2");
	}
	
		
	
	private void UpdateVFX_2()
	{
		VFXTimer++;
		if(VFXTimer == 10)
		{
			iTween.FadeTo (MyInfoPanelBG,iTween.Hash("alpha",0.5f,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelBG.renderer.enabled = true;
			iTween.ScaleTo (MyInfoPanelGO,iTween.Hash("x",(float)(787/Main.SizeFactor)/1.5f,"z",(float)(474/Main.SizeFactor)/1.5f,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			
		}
		if(VFXTimer == 40)
		{
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelPictureBarGO.renderer.enabled = true;
			iTween.FadeTo (MyInfoPanelPictureBar2GO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelPictureBar2GO.renderer.enabled = true;
			iTween.FadeTo (MyInfoPanelBackGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelBackGO.renderer.enabled = true;
			
			BuildLoseText();
			UpdatePotrait();
		}
		
		if(VFXTimer == 50)
		{
			//MUpOnButtons();
			StopVFX_2();
		}
	}
	
	private void EndVFX2()
	{
		VFXTimer = 0;
		InvokeRepeating("UpdateEndVFX2", 0, (float)(1f/(float)Main.FPS));	

	}
	private void StopEndVFX2()
	{
		VFXTimer = 0;
		CancelInvoke("UpdateEndVFX2");
	}
	
	private void UpdateEndVFX2()
	{
		VFXTimer++;
		if(VFXTimer == 1)
		{
			ClearAllText();
			iTween.FadeTo (MyInfoPanelPotraitGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelBG,iTween.Hash("alpha",0f,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.ScaleTo (MyInfoPanelGO,iTween.Hash("x",0.000001f,"z",0.000001,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelPictureBar2GO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelBackGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
		}
		if(VFXTimer == 25)
		{
			ClearToMainMenu ();	
			//Parent.ClearCS ();
		}
	}
	
	//@ Kaizer: Listener
	//@ Kaizer: Tween List
	//@ Kaizer: Features
	private void SelectButton()
	{
		Main.MySE.PlaySFX("Select");
		EndVFX();
	}
	
	private void ToMainMenuButton()
	{
		Main.MySE.PlaySFX("Select");
		EndVFX2();
		Main.MyCustomer.destroyAllCustomer();
		for(int i=0;i<Main.MyCustomer.customerList.Count;i++)
		{
			CustomerAtr MyCA = (CustomerAtr)Main.MyCustomer.customerList[i].GetComponent("CustomerAtr");
			
			MyCA.ActionList = null;
			MyCA.ActionCount = null;
			MyCA.TypeList = null;
			MyCA.TypeRate = null;
			MyCA.TipsList = null;
			MyCA.CoinList = null;
			MyCA.ActionTypeList = null;
			MyCA.STList = null;
			MyCA.WTList = null;
			MyCA.LRList = null;
			MyCA.STRateList = null;
			MyCA.STEffectList = null;
			MyCA.DestroyIcon ();
		}
	}
	
	private void UpdateAllText()
	{
		((TextMesh)EarningText.GetComponent("TextMesh")).text = "Today's Record";
		((TextMesh)STText.GetComponent("TextMesh")).text = "Satisfaction";
		
		((TextMesh)CoinText.GetComponent("TextMesh")).text = "Income: "+Main.MyResultCal.ReturnCoin();
		((TextMesh)LikeText.GetComponent("TextMesh")).text = "Like: "+Main.MyResultCal.ReturnLike ();
		((TextMesh)RunawayText.GetComponent("TextMesh")).text = "Runaway: "+Main.MyResultCal.ReturnRunawayCount();
		
		((TextMesh)ST3StarText.GetComponent("TextMesh")).text = "3 Stars: "+Main.MyResultCal.ReturnCountOf3Star();
		((TextMesh)ST4StarText.GetComponent("TextMesh")).text = "4 Stars: "+Main.MyResultCal.ReturnCountOf4Star();
		((TextMesh)ST5StarText.GetComponent("TextMesh")).text = "5 Stars: "+Main.MyResultCal.ReturnCountOf5Star();
		((TextMesh)ST6StarText.GetComponent("TextMesh")).text = "6 Stars: "+Main.MyResultCal.ReturnCountOf6Star();
	}
	
	private void UpdateLoseText()
	{
		((TextMesh)CoinText.GetComponent("TextMesh")).text = "Income: "+Main.MyResultCal.ReturnCoin();
		((TextMesh)GameOverText.GetComponent("TextMesh")).text = "Game Over";
		((TextMesh)GameOverTextShadow.GetComponent("TextMesh")).text = "Game Over";
	}
	
	
	//@ Kaizer: Build UI Component
	private void BuildScreen()
	{
		BuildBG();	
		BuildInfoPanel();
		BuildInfoPanelPictureBar();
		BuildInfoPanelNext();
	}
	
	private void BuildLoseScreen()
	{
		BuildBG ();
		BuildInfoPanel();
		BuildInfoPanelPictureBar();
		BuildInfoPanelBack();
	}
	
	private void BuildBG()
	{
		if(MyInfoPanelBG == null)
		{
			MyInfoPanelBG = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelBG);
			MyInfoPanelBG.name = "InfoPanelBG";
			MyInfoPanelBG.transform.localPosition = new Vector3(512 - Res.DefaultWidth()/2,-384 + Res.DefaultHeight()/2,-46);
			MyInfoPanelBG.transform.localScale = new Vector3(800/Main.SizeFactor, 1, 480/Main.SizeFactor);
			MyInfoPanelBG.transform.Rotate (90, -180, 0);
			MyInfoPanelBG.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelBG,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelBG.renderer.material = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanel");
			MyInfoPanelBG.renderer.material.color = Color.black;
		}
	}
	private void BuildInfoPanel()
	{
		if(MyInfoPanelGO == null)
		{
			MyInfoPanelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelGO);
			MyInfoPanelGO.name = "InfoPanel";
			MyInfoPanelGO.transform.localPosition = new Vector3(512 - Res.DefaultWidth()/2,-384 + Res.DefaultHeight()/2,-48);
			MyInfoPanelGO.transform.localScale = new Vector3(0.001f, 1, 0.001f);
			MyInfoPanelGO.transform.Rotate (90,-180,0);
			MyInfoPanelBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanel");
			MyInfoPanelGO.renderer.material = MyInfoPanelBmp;
		}
	}
	
	private void BuildInfoPanelPictureBar()
	{
		if(MyInfoPanelPictureBarGO == null)
		{
			MyInfoPanelPictureBarGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelPictureBarGO);
			MyInfoPanelPictureBarGO.name = "InfoPanelPictureBar";
			MyInfoPanelPictureBarGO.transform.localPosition = new Vector3(-130,0,-50);
			MyInfoPanelPictureBarGO.transform.localScale = new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f);
			MyInfoPanelPictureBarGO.transform.Rotate (90,-180,0);
			MyInfoPanelPictureBarGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelPictureBarBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelPictureBar");
			MyInfoPanelPictureBarGO.renderer.material = MyInfoPanelPictureBarBmp;	
			
			MyInfoPanelPictureBar2GO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelPictureBar2GO);
			MyInfoPanelPictureBar2GO.name = "InfoPanelPictureBar2";
			MyInfoPanelPictureBar2GO.transform.localPosition = new Vector3(130,0,-50);
			MyInfoPanelPictureBar2GO.transform.localScale = new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f);
			MyInfoPanelPictureBar2GO.transform.Rotate (90,-180,0);
			MyInfoPanelPictureBar2GO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelPictureBar2GO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelPictureBar2Bmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelPictureBar");
			MyInfoPanelPictureBar2GO.renderer.material = MyInfoPanelPictureBar2Bmp;	
			
			MyInfoPanelPotraitGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelPotraitGO);
			MyInfoPanelPotraitGO.name = "InfoPanelPictureBar";
			//MyInfoPanelPotraitGO.transform.localPosition = new Vector3((350-(0/2))/Main.PostFactor - Res.DefaultWidth()/2,((0/2) - 375)/Main.PostFactor + Res.DefaultHeight()/2,-50);
			MyInfoPanelPotraitGO.transform.localPosition = new Vector3(-130,0,-50);
			MyInfoPanelPotraitGO.transform.localScale = new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f);
			MyInfoPanelPotraitGO.transform.Rotate (90,-180,0);
			MyInfoPanelPotraitGO.renderer.enabled = false;
		}
	}
	
	private void BuildInfoPanelNext()
	{
		if(MyInfoPanelNextGO == null)
		{
			MyInfoPanelNextGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelNextGO);
			MyInfoPanelNextGO.name = "NextGO";
			MyInfoPanelNextGO.transform.localPosition = new Vector3(0, -115,-60);
			MyInfoPanelNextGO.transform.localScale = new Vector3((166/Main.SizeFactor), 1, (38/Main.SizeFactor));
			MyInfoPanelNextGO.transform.Rotate (90, -180, 0);
			MyInfoPanelNextGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelNextGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelNextBmp = (Material)Resources.Load ("PlanAndManage/Materials/NextIcon");
			MyInfoPanelNextGO.renderer.material = MyInfoPanelNextBmp;	
		}
	}
	
	private void BuildInfoPanelBack()
	{
		if(MyInfoPanelBackGO == null)
		{
			MyInfoPanelBackGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelBackGO);
			MyInfoPanelBackGO.name = "BackGO";
			MyInfoPanelBackGO.transform.localPosition = new Vector3(0,-115,-50);
			MyInfoPanelBackGO.transform.localScale = new Vector3((166/Main.SizeFactor), 1, (38/Main.SizeFactor));
			MyInfoPanelBackGO.transform.Rotate(90, -180, 0);
			MyInfoPanelBackGO.renderer.enabled = false;
			iTween.FadeTo(MyInfoPanelBackGO, iTween.Hash("alpha", 0f, "time",0f, "easetype", iTween.EaseType.linear));
			MyInfoPanelBackBmp = (Material)Resources.Load("PlanAndManage/Materials/MainMenuIcon");
			MyInfoPanelBackGO.renderer.material = MyInfoPanelBackBmp;
		}
	}
	
	private void UpdatePotrait()
	{
		//MyInfoPanelPotraitGO.transform.localScale = (new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f));
		MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/Helper6Potrait");
		MyInfoPanelPotraitGO.renderer.material = MyInfoPanelPotraitBmp;
		MyInfoPanelPotraitGO.renderer.enabled = true;
	}
	
	private void BuildAllText()
	{
		if(EarningText == null)
		{
			EarningText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite"));
			Main.AddParent(EarningText);
			EarningText.name = "InfoPanelEarningText";
			EarningText.transform.localPosition = new Vector3(-100,65, -52);
			EarningText.transform.localScale = new Vector3(2f*Main.FontFactor, 2f*Main.FontFactor, 2f*Main.FontFactor);
			EarningText.transform.Rotate (0,-180,0);
			EarningText.renderer.material.color = Color.black;		
		}
		if(STText == null)
		{
			STText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite"));
			Main.AddParent(STText);
			STText.name = "InfoPanelSTText";
			STText.transform.localPosition = new Vector3(100,65, -52);
			STText.transform.localScale = new Vector3(2f*Main.FontFactor, 2f*Main.FontFactor, 2f*Main.FontFactor);
			STText.transform.Rotate (0,-180,0);
			STText.renderer.material.color = Color.black;		
		}
		if(CoinText == null)
		{
			CoinText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(CoinText);
			CoinText.name = "InfoPanelCoinText";
			CoinText.transform.localPosition = new Vector3(-170,30,-52);
			CoinText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			CoinText.transform.Rotate (0,-180,0);
			CoinText.renderer.material.color = Color.black;	
		}
		if(LikeText == null)
		{
			LikeText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(LikeText);
			LikeText.name = "InfoPanelLikeText";
			LikeText.transform.localPosition = new Vector3(-170,0 ,-52);
			LikeText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			LikeText.transform.Rotate (0,-180,0);
			LikeText.renderer.material.color = Color.black;	
		}
		if(RunawayText == null)
		{
			RunawayText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(RunawayText);
			RunawayText.name = "InfoPanelRunawayText";
			RunawayText.transform.localPosition = new Vector3(-170, -30, -52);
			RunawayText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			RunawayText.transform.Rotate (0,-180,0);
			RunawayText.renderer.material.color = Color.black;		
		}
		
		if(ST3StarText == null)
		{
			ST3StarText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(ST3StarText);
			ST3StarText.name = "InfoPanelST3StarText";
			ST3StarText.transform.localPosition = new Vector3(40,30, -52);
			ST3StarText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			ST3StarText.transform.Rotate (0,-180,0);
			ST3StarText.renderer.material.color = Color.black;		
		}
		if(ST4StarText == null)
		{
			ST4StarText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(ST4StarText);
			ST4StarText.name = "InfoPanelST4StarText";
			ST4StarText.transform.localPosition = new Vector3(40, 0, -52);
			ST4StarText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			ST4StarText.transform.Rotate (0,-180,0);
			ST4StarText.renderer.material.color = Color.black;	
		}
		if(ST5StarText == null)
		{
			ST5StarText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(ST5StarText);
			ST5StarText.name = "InfoPanelST5StarText";
			ST5StarText.transform.localPosition = new Vector3(40, -30, -52);
			ST5StarText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			ST5StarText.transform.Rotate (0,-180,0);
			ST5StarText.renderer.material.color = Color.black;	
		}
		if(ST6StarText == null)
		{
			ST6StarText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(ST6StarText);
			ST6StarText.name = "InfoPanelST6StarText";
			ST6StarText.transform.localPosition = new Vector3(40, -60, -52);
			ST6StarText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			ST6StarText.transform.Rotate (0,-180,0);
			ST6StarText.renderer.material.color = Color.black;	
		}
		UpdateAllText();
	}
	private void BuildLoseText()
	{
		if(CoinText == null)
		{
			CoinText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(CoinText);
			CoinText.name = "InfoPanelCoinText";
			CoinText.transform.localPosition = new Vector3(75, ((0/2) +10)/Main.PostFactor, -52);
			CoinText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			CoinText.transform.Rotate (0,-180,0);
			CoinText.renderer.material.color = Color.black;	
		}
		if(GameOverText == null)
		{
			GameOverText = (GameObject)Instantiate((GameObject)Resources.Load("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(GameOverText);
			GameOverText.name = "InfoPanelGameOverText";
			GameOverText.transform.localPosition = new Vector3(-100, ((0/2) + 130)/Main.PostFactor, -53);
			GameOverText.transform.localScale = new Vector3(2*Main.FontFactor, 2*Main.FontFactor, 2*Main.FontFactor);
			GameOverText.transform.Rotate (0,-180,0);
			GameOverText.renderer.material.color = Color.red;	
		}
		if(GameOverTextShadow == null)
		{
			GameOverTextShadow = (GameObject)Instantiate((GameObject)Resources.Load("PlanAndManage/Prefabs/TextSprite_Left"));
			Main.AddParent(GameOverTextShadow);
			GameOverTextShadow.name = "InfoPanelGameOverTextShadow";
			GameOverTextShadow.transform.localPosition = new Vector3(-98, ((0/2) + 128)/Main.PostFactor, -52);
			GameOverTextShadow.transform.localScale = new Vector3(2*Main.FontFactor, 2*Main.FontFactor, 2*Main.FontFactor);
			GameOverTextShadow.transform.Rotate (0,-180,0);
			GameOverTextShadow.renderer.material.color = Color.black;
		}
		if(MyInfoPanelPotraitGO == null)
		{
			MyInfoPanelPotraitGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Main.AddParent(MyInfoPanelPotraitGO);
			MyInfoPanelPotraitGO.name = "InfoPanelPotraitBar";
			//MyInfoPanelPotraitGO.transform.localPosition = new Vector3((350-(0/2))/Main.PostFactor - Res.DefaultWidth()/2,((0/2) - 375)/Main.PostFactor + Res.DefaultHeight()/2,-50);
			MyInfoPanelPotraitGO.transform.localPosition = new Vector3(-130,0,-50);
			MyInfoPanelPotraitGO.transform.localScale = new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f);
			MyInfoPanelPotraitGO.transform.Rotate (90,-180,0);
			MyInfoPanelPotraitGO.renderer.enabled = false;
		}
		UpdateLoseText();
	}
	
	//@ Kaizer: Clearance
	private void ClearAllText()
	{
		if(ST6StarText != null)
		{
			Destroy(ST6StarText);
			ST6StarText = null;
		}
		if(ST4StarText != null)
		{
			Destroy (ST4StarText);
			ST4StarText = null;
		}
		if(ST5StarText != null)
		{
			Destroy (ST5StarText);
			ST5StarText = null;
		}
		if(ST3StarText != null)
		{
			Destroy (ST3StarText);
			ST3StarText = null;
		}
		if(RunawayText != null)
		{
			Destroy (RunawayText);
			RunawayText = null;
		}
		if(LikeText != null)
		{
			Destroy (LikeText);
			LikeText = null;
		}
		if(CoinText != null)
		{
			Destroy (CoinText);
			CoinText = null;
		}
		if(STText != null)
		{
			Destroy (STText);
			STText = null;
		}
		if(EarningText != null)
		{
			Destroy (EarningText);
			EarningText = null;
		}
		if(GameOverText != null)
		{
			Destroy(GameOverText);
			GameOverText = null;
		}
		if(GameOverTextShadow != null)
		{
			Destroy(GameOverTextShadow);
			GameOverTextShadow = null;
		}
	}
	private void ClearInfoPanelNext()
	{
		if(MyInfoPanelNextGO != null)
		{
			MyInfoPanelNextBmp = null;
			Destroy (MyInfoPanelNextGO);
			MyInfoPanelNextGO = null;
		}
	}
	
	private void ClearInfoPanelBack()
	{
		if(MyInfoPanelBackGO != null)
		{
			MyInfoPanelBackBmp = null;
			Destroy (MyInfoPanelBackGO);
			MyInfoPanelBackGO = null;
		}
	}
	
	private void ClearInfoPanelPictureBar()
	{
		if(MyInfoPanelPotraitGO != null)
		{
			MyInfoPanelPotraitBmp = null;
			Destroy (MyInfoPanelPotraitGO);
			MyInfoPanelPotraitGO = null;	
		}
		if(MyInfoPanelPictureBarGO != null)
		{
			MyInfoPanelPictureBarBmp = null;
			Destroy (MyInfoPanelPictureBarGO);
			MyInfoPanelPictureBarGO = null;
		}
		if(MyInfoPanelPictureBar2GO != null)
		{
			MyInfoPanelPictureBar2Bmp = null;
			Destroy (MyInfoPanelPictureBar2GO);
			MyInfoPanelPictureBar2GO = null;
		}
	}
	
	private void ClearInfoPanel()
	{
		if(MyInfoPanelGO != null)
		{
			MyInfoPanelBmp = null;
			Destroy (MyInfoPanelGO);
			MyInfoPanelGO = null;
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
		ClearAllText();
		ClearInfoPanelNext();
		ClearInfoPanelBack();
		ClearInfoPanelPictureBar();
		ClearInfoPanel();
		ClearBG();
	}
	private void ClearAllVFX()
	{
		StopEndVFX();
		StopVFX_1();
		StopEndVFX2();
		StopVFX_2();
	}
	
	private void ClearAllListener()
	{
		//RemoveMUpOnButtons();
	}
	private void ClearAllComponent()
	{
		ClearScreen ();
	}
	public void Clear()
	{	
		MListenerList = null;
		ClearAllVFX();
		ClearAllListener();
		ClearAllComponent();
		Main.MyResultCal.UpdatePlayerAtr();
		Parent.ClearGameScreen();
		Parent.ShowGameScreen();
		Main.MyPlayerAtr.AddDay (1);
		//Parent.ShowPnMScreen();
		Parent = null;
		Destroy (this.gameObject.GetComponent("ResultScreen"));
		
		Main.MySpawn.normalCount = 0;
		Main.MySpawn.vipCount = 0;
		Main.MySpawn.shortTCount = 0;
		Main.MySpawn.casualCount = 0;
		
		Main.MySpawn.myNormalCount = 0;
		Main.MySpawn.myVipCount = 0;
		Main.MySpawn.myShortTCount = 0;
		Main.MySpawn.myCasualCount = 0;
		
		Main.MySpawn.totalCustomer = 0;
		Main.MySpawn.tempTotalCust = 0;
	}
	
	public void ClearToMainMenu()
	{
		MListenerList = null;
		ClearAllVFX();
		ClearAllListener();
		ClearAllComponent();
		Main.MyResultCal.UpdatePlayerAtr();	
		Parent.ClearGameScreen();
		Parent.ClearPnMScreen();
		Parent.ShowStartScreen();
		Parent = null;
		Destroy (this.gameObject.GetComponent("ResultScreen"));
		
		if(Main.MyCustomer != null)
		{
			Main.MyCustomer.customerWalkingSpeed = 0.3f;
		}
		Main.MySpawn.myCustomerSpeed = 0.3f;
		
		Main.MyPlayerAtr.Day = 1;
		Main.MySpawn.myDay = 2;
		
		Main.MySpawn.normalCount = 0;
		Main.MySpawn.vipCount = 0;
		Main.MySpawn.shortTCount = 0;
		Main.MySpawn.casualCount = 0;
		
		Main.MySpawn.myNormalCount = 0;
		Main.MySpawn.myVipCount = 0;
		Main.MySpawn.myShortTCount = 0;
		Main.MySpawn.myCasualCount = 0;
		
		Main.MySpawn.totalCustomer = 0;
		Main.MySpawn.tempTotalCust = 0;
		
		Main.MySpawn.myDisappearIcon = 10.0f;
		
		Main.MySpawn.myMinusTime = 0.0f;
		
		Main.MySpawn.myCustomerSpeed = 0.3f;
		
		Main.MySpawn.daysForUpgradeCustomerSpeedCount = 0;
		Main.MySpawn.daysForUpgradeCount = 0;
		Main.MySpawn.daysForUpdateIconCustDisappearCount = 0;
		Main.MySpawn.daysForUpdateCustWaitingTimeCount = 0;
		Main.MySpawn.daysForUpdateCustomerMaxActionCount = 0;
		
		Main.MySpawn.myNormalAction = 4;
		Main.MySpawn.myVIPAction = 6;
		Main.MySpawn.myShortTAction = 4;
		Main.MySpawn.myCasualAction = 3;
	}
}
