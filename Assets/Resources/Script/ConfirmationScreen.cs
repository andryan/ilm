using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//@ Author: Kaizer

public class ConfirmationScreen : MonoBehaviour 
{
	//@ Kaizer: Data
	public PnMScreen Parent = null;
	private string Type = "";
	private int Slot = 0;
	private int Level = 0;
	private Hashtable Req = null;
	private List<string> MListenerList = null;
	private string ButtonSelection = "";
	private int VFXTimer = 0;
	private List<Vector3> StoreSize = null;
	private bool Upgraded = false;
	
	//@ Kaizer: UI Component
	
	private GameObject MyInfoPanelBG = null;
	
	private GameObject MyInfoPanelGO = null;
	private Material MyInfoPanelBmp = null;
	
	private GameObject MyInfoPanelCoinBarGO = null;
	private Material MyInfoPanelCoinBarBmp = null;
	
	private GameObject MyInfoPanelDiamondBarGO = null;
	private Material MyInfoPanelDiamondBarBmp = null;
	
	private GameObject MyInfoPanelConfirmGO = null;
	private Material MyInfoPanelConfirmBmp = null;
	
	private GameObject MyInfoPanelCancelGO = null;
	private Material MyInfoPanelCancelBmp = null;
	
	private GameObject MyInfoPanelGetDiamondGO = null;
	private Material MyInfoPanelGetDiamondBmp = null;
	
	private GameObject MyInfoPanelPictureBarGO = null;
	private Material MyInfoPanelPictureBarBmp = null;
	
	private GameObject MyInfoPanelPotraitGO = null;
	private Material MyInfoPanelPotraitBmp = null;
	
	private GameObject CoinText = null;
	private GameObject DiamondText = null;
	private GameObject NameText = null;
	private GameObject DescriptionText = null;
	private GameObject CostText = null;
	
	private void Start()
	{
		
	}
	public void Init(PnMScreen MyPnMScreen, string TypeName, int CurrentSlot)
	{
		Parent = MyPnMScreen;
		Type = TypeName;
		Slot = CurrentSlot;
		MListenerList = new List<string>();
		StoreSize = new List<Vector3>();
		StoreSize.Add (new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f));
		StoreSize.Add (new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f));
		StoreSize.Add (new Vector3(69/Main.SizeFactor*2, 1, 81/Main.SizeFactor*2));
		StoreSize.Add (new Vector3(49/Main.SizeFactor*2, 1, 44/Main.SizeFactor*2));
		StoreSize.Add (new Vector3(39/Main.SizeFactor*2, 1, 38/Main.SizeFactor*2));
		StoreSize.Add (new Vector3(36/Main.SizeFactor*2, 1, 73/Main.SizeFactor*2));
		StoreSize.Add (new Vector3(178/Main.SizeFactor/1.2f, 1, 103/Main.SizeFactor/1.2f));
		StoreSize.Add (new Vector3(150/Main.SizeFactor, 1, 115/Main.SizeFactor));
		BuildScreen();
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
			iTween.FadeTo (MyInfoPanelCoinBarGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelCoinBarGO.renderer.enabled = true;
			iTween.FadeTo (MyInfoPanelDiamondBarGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelDiamondBarGO.renderer.enabled = true;
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelPictureBarGO.renderer.enabled = true;	
			iTween.FadeTo (MyInfoPanelGetDiamondGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelGetDiamondGO.renderer.enabled = true;
			iTween.FadeTo (MyInfoPanelConfirmGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelConfirmGO.renderer.enabled = true;	
			iTween.FadeTo (MyInfoPanelCancelGO,iTween.Hash("alpha",1f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			MyInfoPanelCancelGO.renderer.enabled = true;
			UpdateData();
			BuildAllText();
			UpdatePotrait();
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
			ClearAllText();
			if(MyInfoPanelConfirmGO != null)
			{
				iTween.FadeTo (MyInfoPanelConfirmGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));	
			}
			iTween.FadeTo (MyInfoPanelPotraitGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelCoinBarGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelDiamondBarGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));	
			iTween.FadeTo (MyInfoPanelGetDiamondGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelCancelGO,iTween.Hash("alpha",0f,"time",0.2f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.FadeTo (MyInfoPanelBG,iTween.Hash("alpha",0f,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
			iTween.ScaleTo (MyInfoPanelGO,iTween.Hash("x",0.000001f,"z",0.000001,"time",0.3f, "easetype",iTween.EaseType.easeOutCubic));
		}
		if(VFXTimer == 25)
		{
			StopEndVFX();	
			Parent.ClearCS ();
		}
	}
	//@ Kaizer: Listener
	private void MUpOnButtons()
	{
		if(MListenerList != null)
		{
			if(MyInfoPanelConfirmGO != null)
			{
				if(!MListenerList.Contains(MyInfoPanelConfirmGO.name))	
				{
					MListenerList.Add (MyInfoPanelConfirmGO.name);
				}	
			}
			if(MyInfoPanelCancelGO != null)
			{
				if(!MListenerList.Contains(MyInfoPanelCancelGO.name))
				{
					MListenerList.Add (MyInfoPanelCancelGO.name);	
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
	//@ Kaizer: Features
	private void SelectButton()
	{
		if(ButtonSelection == "InfoPanelConfirm")
		{
			SelectConfirm ();
			Upgraded = true;
			Main.MySE.PlaySFX ("Select");
		}
		else
		{
			Main.MySE.PlaySFX("Cancel");	
		}
		EndVFX();
	}
	private void CostCalculation()
	{
		if(Req.Contains("Coin"))
		{
			Main.MyPlayerAtr.AddCoin (-(int)Req["Coin"]);	
			Main.MyPlayerAtr.AddSpentCoin((int)Req["Coin"]);
		}
		if(Req.Contains ("Diamond"))
		{
			Main.MyPlayerAtr.AddDiamond(-(int)Req["Diamond"]);
			Main.MyPlayerAtr.AddSpentDiamond((int)Req["Diamond"]);
		}
		Main.MyPlayerAtr.AddUpgradeCount(1);
	}
	private void SelectConfirm()
	{
		CostCalculation();
		switch(Type)
		{
			case "Char":
			{
				Main.MyPlayerAtr.LevelActionSpeedLevel(Level+1);
				Main.MyPlayerAtr.LevelMovementSpeedLevel(Level+1);
			}break;
			case "Helper":
			{
				Main.MyPlayerAtr.AddHelperSlot(Slot);
			}break;
			case "QueueUp":
			{
				if(Level ==0)
				{
					Main.MyPlayerAtr.AddQueueUpSlot();
				}
				else
				{
					Main.MyPlayerAtr.LevelQueueUpSlot(Slot,Level+1);	
				}
			}break;
			case "Food":
			{
				if(Level ==0)
				{
					Main.MyPlayerAtr.AddFoodSlot();
				}
				else
				{
					Main.MyPlayerAtr.LevelFoodSlot(Slot,Level+1);	
				}
			}break;
			case "TDisplay":
			{
				if(Level ==0)
				{
					Main.MyPlayerAtr.AddTDisplaySlot();
				}
				else
				{
					Main.MyPlayerAtr.LevelTDisplaySlot(Slot,Level+1);	
				}
			}break;
			case "Bar":
			{
				if(Level ==0)
				{
					Main.MyPlayerAtr.AddBarSlot();
				}
				else
				{
					Main.MyPlayerAtr.LevelBarSlot(Slot,Level+1);	
				}
			}break;
			case "Cashier":
			{
				Main.MyPlayerAtr.LevelCashierLevel(Level+1);	
			}break;
			case "Deco":
			{
				Main.MyPlayerAtr.EquipExtraDeco(Level+1);
			}break;
		}
		Parent.UpdatePnM();
	}
	private void UpdatePotrait()
	{
		if(MyInfoPanelPotraitGO != null)
		{
			int TemLevel = Level;
			if(TemLevel == 0)
			{
				TemLevel = 1;	
			}
			switch(Type)
			{
				case "Char":
				{
					MyInfoPanelPotraitGO.transform.localScale = StoreSize[0];
					MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/MainChar");
				}break;
				case "Helper":
				{
					MyInfoPanelPotraitGO.transform.localScale = StoreSize[1];
					MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/Helper"+(Slot+1).ToString()+"Potrait");
				}break;
				case "QueueUp":
				{
					MyInfoPanelPotraitGO.transform.localScale = StoreSize[2];
					MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/QueueUpLv"+TemLevel);
				}break;
				case "Food":
				{
					MyInfoPanelPotraitGO.transform.localScale = StoreSize[3];
					MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/FoodLv"+TemLevel);
				}break;
				case "TDisplay":
				{
					MyInfoPanelPotraitGO.transform.localScale = StoreSize[4];
					MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/TDisplayLv"+TemLevel);
				}break;
				case "Bar":
				{
					MyInfoPanelPotraitGO.transform.localScale = StoreSize[5];
					MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/BarLv"+TemLevel);
				}break;
				case "Cashier":
				{
					MyInfoPanelPotraitGO.transform.localScale = StoreSize[6];
					MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/Cashier");
				}break;
				case "Deco":
				{
					MyInfoPanelPotraitGO.transform.localScale = StoreSize[7];
					MyInfoPanelPotraitBmp = (Material)Resources.Load ("PlanAndManage/Materials/DecoLv"+TemLevel);
					Debug.Log ("PlanAndManage/Materials/DecoLv+"+TemLevel);
				}break;
			}
			MyInfoPanelPotraitGO.renderer.material = MyInfoPanelPotraitBmp;
			MyInfoPanelPotraitGO.renderer.enabled = true;
		}
	}
	private void UpdateData()
	{
		Req = new Hashtable();
		switch(Type)
		{
			case "Char":
			{
				Level = Main.MyPlayerAtr.ReturnActionSpeedLevel();
				Hashtable TemASPDHash = Main.MyReqCheck.GetASPDReqByLevel(Level+1);
				Hashtable TemMSPDHash = Main.MyReqCheck.GetMSPDReqByLevel(Level+1);
				Req["Coin"] = (int)TemASPDHash["Coin"] + (int)TemMSPDHash["Coin"];
				Req["Like"] = (int)TemMSPDHash["Like"];
				Req["Description"] = (string)TemASPDHash["Description"]+", "+(string)TemMSPDHash["Description"];
			}break;
			case "Helper":
			{
				Level = Main.MyPlayerAtr.ReturnHelper (Slot);
				Req = Main.MyReqCheck.GetHelperReqByID (Slot+1);
				
			}break;
			
			case "QueueUp":
			{
				Level = Main.MyPlayerAtr.ReturnQueueUpLevel(Slot);
				if(Level == 0)
				{
					Req = Main.MyReqCheck.GetQueueUpUnlockReqBySlot(Slot);
				}
				else
				{
					Req = Main.MyReqCheck.GetQueueUpLevelReqByLevel(Level+1);	
				}
			}break;
			case "Food":
			{
				Level = Main.MyPlayerAtr.ReturnFoodLevel(Slot);
				if(Level == 0)
				{
					Req = Main.MyReqCheck.GetFoodUnlockReqBySlot(Slot);
				}
				else
				{
					Req = Main.MyReqCheck.GetFoodLevelReqByLevel(Level+1);	
				}
			}break;
			case "TDisplay":
			{
				Level = Main.MyPlayerAtr.ReturnTDisplayLevel(Slot);
				if(Level == 0)
				{
					Req = Main.MyReqCheck.GetFoodUnlockReqBySlot(Slot);
				}
				else
				{
					Req = Main.MyReqCheck.GetFoodLevelReqByLevel(Level+1);	
				}
			}break;
			case "Bar":
			{
				Level = Main.MyPlayerAtr.ReturnBarLevel(Slot);
				if(Level == 0)
				{
					Req = Main.MyReqCheck.GetFoodUnlockReqBySlot(Slot);
				}
				else
				{
					Req = Main.MyReqCheck.GetFoodLevelReqByLevel(Level+1);	
				}
			}break;
			case "Cashier":
			{
				Level = Main.MyPlayerAtr.ReturnCashierLevel();
				Req = Main.MyReqCheck.GetCashierLevelReqByLevel(Level+1);
			}break;
			case "Deco":
			{
				Level = Main.MyPlayerAtr.ReturnExtraDeco();
				Req = Main.MyReqCheck.GetDecoReqByID(Level+1);
			}break;
		}
		bool Upgradable = true;
		if(Req.Count <= 0)
		{
			Upgradable = false;
		}
		else
		{
			if(Req.Contains("Coin") && (int)Req["Coin"] > Main.MyPlayerAtr.ReturnCoin ())
			{
				Upgradable = false;	
			}
			if(Req.Contains("Diamond") && (int)Req["Diamond"] > Main.MyPlayerAtr.ReturnDiamond())
			{
				Upgradable = false;	
			}
			if(Req.Contains ("Like") && (int)Req["Like"] > Main.MyPlayerAtr.ReturnLike())
			{
				Upgradable = false;	
			}
		}
		if(Upgradable == false)
		{
			ClearInfoPanelConfirm();	
		}
	}
	private void UpdateAllText()
	{
		((TextMesh)CoinText.GetComponent("TextMesh")).text = ""+Main.MyPlayerAtr.ReturnCoin().ToString ();
		((TextMesh)DiamondText.GetComponent("TextMesh")).text = ""+Main.MyPlayerAtr.ReturnDiamond().ToString ();
		string TemString = "Upgrade "+Type+" Lv"+Level;
		if(Level == 0)
		{
			TemString = "Purchase "+Type;	
		}
		((TextMesh)NameText.GetComponent("TextMesh")).text = TemString;
		string ReqText = "Req :";
		if(Req.Count >0)
		{
			
			if(Req.Contains("Like"))
			{
				ReqText = ReqText + Req["Like"].ToString ()+" Like";
			}
			if(Req.Contains ("Coin") && (int)Req["Coin"] >0)
			{
				ReqText = ReqText +", "+Req["Coin"].ToString ()+" Coin";	
			}
			if(Req.Contains("Diamond") && (int)Req["Diamond"] >0)
			{
				ReqText = ReqText+", "+Req["Diamond"].ToString()+" Diamond";	
			}
		}
		((TextMesh)CostText.GetComponent("TextMesh")).text = ReqText;
		if(Req.Contains("Description"))
		{
			((TextMesh)DescriptionText.GetComponent("TextMesh")).text = "Effect: "+(string)Req["Description"];	
		}
	}
	//@ Kaizer: Build UI Component
	private void BuildScreen()
	{
		BuildBG();	
		BuildInfoPanel();
		BuildInfoPanelCoinBar();
		BuildInfoPanelDiamondBar();
		BuildInfoPanelPictureBar();
		BuildInfoPanelGetDiamondBar();
		BuildInfoPanelConfirm();
		BuildInfoPanelCancel ();
		
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
	private void BuildInfoPanelCoinBar()
	{
		if(MyInfoPanelCoinBarGO == null)
		{
			MyInfoPanelCoinBarGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelCoinBarGO.name = "InfoPanelCoinBar";
			MyInfoPanelCoinBarGO.transform.position = new Vector3((430-(0/2))/Main.PostFactor,((0/2) - 112)/Main.PostFactor,-50);
			MyInfoPanelCoinBarGO.transform.localScale = new Vector3((186/Main.SizeFactor)/1.5f, 1, (48/Main.SizeFactor)/1.5f);
			MyInfoPanelCoinBarGO.transform.Rotate (90,-180,0);
			MyInfoPanelCoinBarGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelCoinBarGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelCoinBarBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelCoinBar");
			MyInfoPanelCoinBarGO.renderer.material = MyInfoPanelCoinBarBmp;
			
		}
	}
	private void BuildInfoPanelDiamondBar()
	{
		if(MyInfoPanelDiamondBarGO == null)
		{
			MyInfoPanelDiamondBarGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelDiamondBarGO.name = "InfoPanelDiamondBar";
			MyInfoPanelDiamondBarGO.transform.position = new Vector3((569-(0/2))/Main.PostFactor,((0/2) - 112)/Main.PostFactor,-50);
			MyInfoPanelDiamondBarGO.transform.localScale = new Vector3((186/Main.SizeFactor)/1.5f, 1, (48/Main.SizeFactor)/1.5f);
			MyInfoPanelDiamondBarGO.transform.Rotate (90,-180,0);
			MyInfoPanelDiamondBarGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelDiamondBarGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelDiamondBarBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelDiamondBar");
			MyInfoPanelDiamondBarGO.renderer.material = MyInfoPanelDiamondBarBmp;
			
		}	
	}
	private void BuildInfoPanelPictureBar()
	{
		if(MyInfoPanelPictureBarGO == null)
		{
			MyInfoPanelPictureBarGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelPictureBarGO.name = "InfoPanelPictureBar";
			MyInfoPanelPictureBarGO.transform.position = new Vector3((275-(0/2))/Main.PostFactor,((0/2) - 235)/Main.PostFactor,-50);
			MyInfoPanelPictureBarGO.transform.localScale = new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f);
			MyInfoPanelPictureBarGO.transform.Rotate (90,-180,0);
			MyInfoPanelPictureBarGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelPictureBarGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelPictureBarBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelPictureBar");
			MyInfoPanelPictureBarGO.renderer.material = MyInfoPanelPictureBarBmp;	
			
			MyInfoPanelPotraitGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelPotraitGO.name = "InfoPanelPictureBar";
			MyInfoPanelPotraitGO.transform.position = new Vector3((275-(0/2))/Main.PostFactor,((0/2) - 235)/Main.PostFactor,-50);
			MyInfoPanelPotraitGO.transform.localScale = new Vector3((281/Main.SizeFactor)/1.5f, 1, (278/Main.SizeFactor)/1.5f);
			MyInfoPanelPotraitGO.transform.Rotate (90,-180,0);
			MyInfoPanelPotraitGO.renderer.enabled = false;
		}
	}
	private void BuildInfoPanelGetDiamondBar()
	{
		if(MyInfoPanelGetDiamondGO == null)
		{
			MyInfoPanelGetDiamondGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelGetDiamondGO.name = "InfoPanelGetDiamond";
			MyInfoPanelGetDiamondGO.transform.position = new Vector3((275-(0/2))/Main.PostFactor,((0/2) - 352)/Main.PostFactor,-50);
			MyInfoPanelGetDiamondGO.transform.localScale = new Vector3((276/Main.SizeFactor)/1.5f, 1, (65/Main.SizeFactor)/1.5f);
			MyInfoPanelGetDiamondGO.transform.Rotate (90,-180,0);
			MyInfoPanelGetDiamondGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelGetDiamondGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelGetDiamondBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelGetDiamond");
			MyInfoPanelGetDiamondGO.renderer.material = MyInfoPanelGetDiamondBmp;		
		}
	}
	private void BuildInfoPanelConfirm()
	{
		if(MyInfoPanelConfirmGO == null)
		{
			MyInfoPanelConfirmGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelConfirmGO.name = "InfoPanelConfirm";
			MyInfoPanelConfirmGO.transform.position = new Vector3((460-(0/2))/Main.PostFactor,((0/2) - 330)/Main.PostFactor,-50);
			MyInfoPanelConfirmGO.transform.localScale = new Vector3((117/Main.SizeFactor)/1.5f, 1, (130/Main.SizeFactor)/1.5f);
			MyInfoPanelConfirmGO.transform.Rotate (90,-180,0);
			MyInfoPanelConfirmGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelConfirmGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelConfirmBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelConfirm");
			MyInfoPanelConfirmGO.renderer.material = MyInfoPanelConfirmBmp;			
		}
	}
	private void BuildInfoPanelCancel()
	{
		if(MyInfoPanelCancelGO == null)
		{
			MyInfoPanelCancelGO = GameObject.CreatePrimitive(PrimitiveType.Plane);
			MyInfoPanelCancelGO.name = "InfoPanelCancel";
			MyInfoPanelCancelGO.transform.position = new Vector3((560-(0/2))/Main.PostFactor,((0/2) - 330)/Main.PostFactor,-50);
			MyInfoPanelCancelGO.transform.localScale = new Vector3((117/Main.SizeFactor)/1.5f, 1, (130/Main.SizeFactor)/1.5f);
			MyInfoPanelCancelGO.transform.Rotate (90,-180,0);
			MyInfoPanelCancelGO.renderer.enabled = false;
			iTween.FadeTo (MyInfoPanelCancelGO,iTween.Hash("alpha",0f,"time",0f, "easetype",iTween.EaseType.linear));
			MyInfoPanelCancelBmp = (Material)Resources.Load ("PlanAndManage/Materials/InfoPanelCancel");
			MyInfoPanelCancelGO.renderer.material = MyInfoPanelCancelBmp;			
		}	
	}
	private void BuildAllText()
	{
		if(CoinText == null)
		{
			CoinText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			CoinText.name = "InfoPanelCoinText";
			CoinText.transform.position = new Vector3((410 - (0/2))/Main.PostFactor, ((0/2) -112f)/Main.PostFactor, -52);
			CoinText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			CoinText.transform.Rotate (0,-180,0);
			CoinText.renderer.material.color = Color.black;	
		}
		if(DiamondText == null)
		{
			DiamondText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			DiamondText.name = "InfoPanelDiamondText";
			DiamondText.transform.position = new Vector3((550 - (0/2))/Main.PostFactor, ((0/2) - 112f)/Main.PostFactor, -52);
			DiamondText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			DiamondText.transform.Rotate (0,-180,0);
			DiamondText.renderer.material.color = Color.black;	
		}
		if(NameText == null)
		{
			NameText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			NameText.name = "InfoPanelDescriptionText";
			NameText.transform.position = new Vector3((385 - (0/2))/Main.PostFactor, ((0/2) - 165f)/Main.PostFactor, -50);
			NameText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			NameText.transform.Rotate (0,-180,0);
			NameText.renderer.material.color = Color.black;		
		}
		if(CostText == null)
		{
			CostText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			CostText.name = "InfoPanelCostText";
			CostText.transform.position = new Vector3((385 - (0/2))/Main.PostFactor, ((0/2) - 195f)/Main.PostFactor, -50);
			CostText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			CostText.transform.Rotate (0,-180,0);
			CostText.renderer.material.color = Color.black;	
		}
		if(DescriptionText == null)
		{
			DescriptionText = (GameObject)Instantiate((GameObject)Resources.Load ("PlanAndManage/Prefabs/TextSprite_Left"));
			DescriptionText.name = "InfoPanelDescriptionText";
			DescriptionText.transform.position = new Vector3((385 - (0/2))/Main.PostFactor, ((0/2) - 225)/Main.PostFactor, -50);
			DescriptionText.transform.localScale = new Vector3(1*Main.FontFactor, 1*Main.FontFactor, 1*Main.FontFactor);
			DescriptionText.transform.Rotate (0,-180,0);
			DescriptionText.renderer.material.color = Color.black;	
		}
		UpdateAllText();
	}
	//@ Kaizer: Clearance
	private void ClearAllText()
	{
		if(CostText != null)
		{
			Destroy (CostText);
			CostText = null;
		}
		if(DescriptionText != null)
		{
			Destroy (DescriptionText);
			DescriptionText = null;
		}
		if(NameText != null)
		{
			Destroy (NameText);
			NameText = null;
		}
		if(DiamondText != null)
		{
			Destroy (DiamondText);
			DiamondText = null;
		}
		if(CoinText != null)
		{
			Destroy (CoinText);
			CoinText = null;
		}
	}
	private void ClearInfoPanelCancel()
	{
		if(MyInfoPanelCancelGO != null)
		{
			MyInfoPanelCancelBmp = null;
			Destroy (MyInfoPanelCancelGO);
			MyInfoPanelCancelGO = null;
		}		
	}
	private void ClearInfoPanelConfirm()
	{
		if(MyInfoPanelConfirmGO != null)
		{
			MyInfoPanelConfirmBmp = null;
			Destroy (MyInfoPanelConfirmGO);
			MyInfoPanelConfirmGO = null;
		}	
	}
	private void ClearInfoPanelGetDiamondBar()
	{
		if(MyInfoPanelGetDiamondGO != null)
		{
			MyInfoPanelGetDiamondBmp = null;
			Destroy (MyInfoPanelGetDiamondGO);
			MyInfoPanelGetDiamondGO = null;
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
	}
	private void ClearInfoPanelDiamondBar()
	{
		if(MyInfoPanelDiamondBarGO != null)
		{
			MyInfoPanelDiamondBarBmp = null;
			Destroy (MyInfoPanelDiamondBarGO);
			MyInfoPanelDiamondBarGO = null;
		}	
	}
	private void ClearInfoPanelCoinBar()
	{
		if(MyInfoPanelCoinBarGO != null)
		{
			MyInfoPanelCoinBarBmp = null;
			Destroy (MyInfoPanelCoinBarGO);
			MyInfoPanelCoinBarGO = null;
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
		ClearInfoPanelCancel ();
		ClearInfoPanelConfirm();
		ClearInfoPanelGetDiamondBar();
		ClearInfoPanelPictureBar();
		ClearInfoPanelDiamondBar();
		ClearInfoPanelCoinBar();
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
		StoreSize = null;
		Req = null;
		MListenerList = null;
		ClearAllVFX();
		ClearAllListener();
		ClearAllComponent();
		Parent.Upgraded = Upgraded;
		Parent = null;
	}
}
