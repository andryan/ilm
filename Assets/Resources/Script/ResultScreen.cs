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
	
	private GameObject EarningText = null;
	private GameObject STText = null;
	
	private GameObject CoinText = null;
	private GameObject LikeText = null;
	private GameObject RunawayText = null;
	
	private GameObject ST3StarText = null;
	private GameObject ST5StarText = null;
	private GameObject ST4StarText = null;
	private GameObject ST6StarText = null;
	
	public void Init(Main PassParent)
	{
		Main.MySE.StopBGM ();
		Main.MySE.PlaySFX("Clear");
		Parent = PassParent;
		MListenerList = new List<string>();
		BuildScreen ();
		VFX_1 ();
	}
	
	
	//@ Kaizer: VFX List
	private void Update()
	{
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
						SelectButton();
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
	
	//@ Kaizer: Listener
	//@ Kaizer: Tween List
	//@ Kaizer: Features
	private void SelectButton()
	{
		Main.MySE.PlaySFX("Select");
		EndVFX();
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
	
	
	//@ Kaizer: Build UI Component
	private void BuildScreen()
	{
		BuildBG();	
		BuildInfoPanel();
		BuildInfoPanelPictureBar();
		BuildInfoPanelNext();
	}
	private void BuildBG()
	{
		if(MyInfoPanelBG == null)
		{
			MyInfoPanelBG = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelBG.name = "InfoPanelBG";
			MyInfoPanelBG.transform.position = new Vector3(400,-240,-46);
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
			MyInfoPanelGO.name = "InfoPanel";
			MyInfoPanelGO.transform.position = new Vector3(400,-240,-48);
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
			MyInfoPanelPictureBarGO.name = "InfoPanelPictureBar";
			MyInfoPanelPictureBarGO.transform.position = new Vector3((300-(0/2))/Main.PostFactor,((0/2) - 235)/Main.PostFactor,-50);
			MyInfoPanelPictureBarGO.transform.localScale = new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f);
			MyInfoPanelPictureBarGO.transform.Rotate (90,-180,0);
			MyInfoPanelPictureBarGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelPictureBarBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelPictureBar");
			MyInfoPanelPictureBarGO.renderer.material = MyInfoPanelPictureBarBmp;	
			
			MyInfoPanelPictureBar2GO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelPictureBar2GO.name = "InfoPanelPictureBar2";
			MyInfoPanelPictureBar2GO.transform.position = new Vector3((500-(0/2))/Main.PostFactor,((0/2) - 235)/Main.PostFactor,-50);
			MyInfoPanelPictureBar2GO.transform.localScale = new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f);
			MyInfoPanelPictureBar2GO.transform.Rotate (90,-180,0);
			MyInfoPanelPictureBar2GO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelPictureBar2GO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelPictureBar2Bmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelPictureBar");
			MyInfoPanelPictureBar2GO.renderer.material = MyInfoPanelPictureBar2Bmp;	
		}
	}
	private void BuildInfoPanelNext()
	{
		if(MyInfoPanelNextGO == null)
		{
			MyInfoPanelNextGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelNextGO.name = "NextGO";
			MyInfoPanelNextGO.transform.position = new Vector3((400-(0/2))/Main.PostFactor, ((0/2) - 352)/Main.PostFactor,-60);
			MyInfoPanelNextGO.transform.localScale = new Vector3((166/Main.SizeFactor), 1, (38/Main.SizeFactor));
			MyInfoPanelNextGO.transform.Rotate (90, -180, 0);
			MyInfoPanelNextGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelNextGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelNextBmp = (Material)Resources.Load ("PlanAndManage/Materials/NextIcon");
			MyInfoPanelNextGO.renderer.material = MyInfoPanelNextBmp;	
		}
	}
	public void BuildAllText()
	{
		if(EarningText == null)
		{
			EarningText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite"));
			EarningText.name = "InfoPanelEarningText";
			EarningText.transform.position = new Vector3((300 - (0/2))/Main.PostFactor, ((0/2) -175f)/Main.PostFactor, -52);
			EarningText.transform.localScale = new Vector3(2f*Main.FontFactor, 2f*Main.FontFactor, 2f*Main.FontFactor);
			EarningText.transform.Rotate (0,-180,0);
			EarningText.renderer.material.color = Color.black;		
		}
		if(STText == null)
		{
			STText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite"));
			STText.name = "InfoPanelSTText";
			STText.transform.position = new Vector3((500 - (0/2))/Main.PostFactor, ((0/2) -175f)/Main.PostFactor, -52);
			STText.transform.localScale = new Vector3(2f*Main.FontFactor, 2f*Main.FontFactor, 2f*Main.FontFactor);
			STText.transform.Rotate (0,-180,0);
			STText.renderer.material.color = Color.black;		
		}
		if(CoinText == null)
		{
			CoinText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			CoinText.name = "InfoPanelCoinText";
			CoinText.transform.position = new Vector3((230 - (0/2))/Main.PostFactor, ((0/2) -205f)/Main.PostFactor, -52);
			CoinText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			CoinText.transform.Rotate (0,-180,0);
			CoinText.renderer.material.color = Color.black;	
		}
		if(LikeText == null)
		{
			LikeText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			LikeText.name = "InfoPanelLikeText";
			LikeText.transform.position = new Vector3((230 - (0/2))/Main.PostFactor, ((0/2) - 235f)/Main.PostFactor, -52);
			LikeText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			LikeText.transform.Rotate (0,-180,0);
			LikeText.renderer.material.color = Color.black;	
		}
		if(RunawayText == null)
		{
			RunawayText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			RunawayText.name = "InfoPanelRunawayText";
			RunawayText.transform.position = new Vector3((230 - (0/2))/Main.PostFactor, ((0/2) - 265f)/Main.PostFactor, -52);
			RunawayText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			RunawayText.transform.Rotate (0,-180,0);
			RunawayText.renderer.material.color = Color.black;		
		}
		
		if(ST3StarText == null)
		{
			ST3StarText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			ST3StarText.name = "InfoPanelST3StarText";
			ST3StarText.transform.position = new Vector3((435 - (0/2))/Main.PostFactor, ((0/2) - 205f)/Main.PostFactor, -52);
			ST3StarText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			ST3StarText.transform.Rotate (0,-180,0);
			ST3StarText.renderer.material.color = Color.black;		
		}
		if(ST4StarText == null)
		{
			ST4StarText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			ST4StarText.name = "InfoPanelST4StarText";
			ST4StarText.transform.position = new Vector3((435 - (0/2))/Main.PostFactor, ((0/2) - 235f)/Main.PostFactor, -52);
			ST4StarText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			ST4StarText.transform.Rotate (0,-180,0);
			ST4StarText.renderer.material.color = Color.black;	
		}
		if(ST5StarText == null)
		{
			ST5StarText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			ST5StarText.name = "InfoPanelST5StarText";
			ST5StarText.transform.position = new Vector3((435 - (0/2))/Main.PostFactor, ((0/2) - 265)/Main.PostFactor, -52);
			ST5StarText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			ST5StarText.transform.Rotate (0,-180,0);
			ST5StarText.renderer.material.color = Color.black;	
		}
		if(ST6StarText == null)
		{
			ST6StarText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			ST6StarText.name = "InfoPanelST6StarText";
			ST6StarText.transform.position = new Vector3((435 - (0/2))/Main.PostFactor, ((0/2) - 295)/Main.PostFactor, -52);
			ST6StarText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			ST6StarText.transform.Rotate (0,-180,0);
			ST6StarText.renderer.material.color = Color.black;	
		}
		UpdateAllText();
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
	private void ClearInfoPanelPictureBar()
	{
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
		print ("CLEARED GAME SCREEN");
		Parent.ShowPnMScreen();
		Parent = null;
		Destroy (this.gameObject.GetComponent("ResultScreen"));
	}
}
