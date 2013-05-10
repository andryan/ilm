using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class MainScene : MonoBehaviour 
{
	string tapPointsLabel = "";
	bool autoRefresh = false;
	bool openingFullScreenAd = false;
	
	void Start ()
	{
#if UNITY_ANDROID
		// Attach our thread to the java vm; obviously the main thread is already attached but this is good practice..
		if (Application.platform == RuntimePlatform.Android)
			UnityEngine.AndroidJNI.AttachCurrentThread();
#endif
		// Enable logging.
		TapjoyPlugin.EnableLogging(true);
		
		// Set the Handler class. This needs to be a unity GameObject
		//TapjoyPlugin.SetCallbackHandler("MainScene");											// Set this to the name of your linked GameObject 
		
		// Connect to the Tapjoy servers.
		if (Application.platform == RuntimePlatform.Android)
		{
			TapjoyPlugin.RequestTapjoyConnect(	"bba49f11-b87f-4c0f-9632-21aa810dd6f1", 				// YOUR APP ID GOES HERE
		    	          						"yiQIURFEeKm0zbOggubu");								// YOUR SECRET KEY GOES HERE
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			TapjoyPlugin.RequestTapjoyConnect(	"13b0ae6a-8516-4405-9dcf-fe4e526486b2", 				// YOUR APP ID GOES HERE
		    	          						"XHdOwPa8de7p4aseeYP0");								// YOUR SECRET KEY GOES HERE
		}
		
		// Get the user virtual currency
		TapjoyPlugin.GetTapPoints();
		
		// Get a banner ad
		TapjoyPlugin.GetDisplayAd();
	}
	
	void Awake()
	{
		print("Awaking and adding Tapjoy Events");
		// Tapjoy Connect Events
		TapjoyPlugin.connectCallSucceeded += HandleTapjoyConnectSuccess;
		TapjoyPlugin.connectCallFailed += HandleTapjoyConnectFailed;
		
		// Tapjoy Virtual Currency Events
		TapjoyPlugin.getTapPointsSucceeded += HandleGetTapPointsSucceeded;
		TapjoyPlugin.getTapPointsFailed += HandleGetTapPointsFailed;
		TapjoyPlugin.spendTapPointsSucceeded += HandleSpendTapPointsSucceeded;
		TapjoyPlugin.spendTapPointsFailed += HandleSpendTapPointsFailed;
		TapjoyPlugin.awardTapPointsSucceeded += HandleAwardTapPointsSucceeded;
		TapjoyPlugin.awardTapPointsFailed += HandleAwardTapPointsFailed;
		TapjoyPlugin.tapPointsEarned += HandleTapPointsEarned;
		
		// Tapjoy Full Screen Ad Events
		TapjoyPlugin.getFullScreenAdSucceeded += HandleGetFullScreenAdSucceeded;
		TapjoyPlugin.getFullScreenAdFailed += HandleGetFullScreenAdFailed;
		
		// Tapjoy Daily Reward Ad Events
		TapjoyPlugin.getDailyRewardAdSucceeded += HandleGetDailyRewardAdSucceeded;
		TapjoyPlugin.getDailyRewardAdFailed += HandleGetDailyRewardAdFailed;
		
		// Tapjoy Display Ad Events
		TapjoyPlugin.getDisplayAdSucceeded += HandleGetDisplayAdSucceeded;
		TapjoyPlugin.getDisplayAdFailed += HandleGetDisplayAdFailed;
		
		// Tapjoy Video Ad Events
		TapjoyPlugin.videoAdStarted += HandleVideoAdStarted;
		TapjoyPlugin.videoAdFailed += HandleVideoAdFailed;
		TapjoyPlugin.videoAdCompleted += HandleVideoAdCompleted;
		
		// Tapjoy Ad View Closed Events
		TapjoyPlugin.viewOpened += HandleViewOpened;
		TapjoyPlugin.viewClosed += HandleViewClosed;
 	
		// Tapjoy Show Offers Events
		TapjoyPlugin.showOffersFailed += HandleShowOffersFailed;
	}
	
	void OnDisable()
	{
		print("Disabling and removing Tapjoy Events");
		// Tapjoy Connect Events
		TapjoyPlugin.connectCallSucceeded -= HandleTapjoyConnectSuccess;
		TapjoyPlugin.connectCallFailed -= HandleTapjoyConnectFailed;
		
		// Tapjoy Virtual Currency Events
		TapjoyPlugin.getTapPointsSucceeded -= HandleGetTapPointsSucceeded;
		TapjoyPlugin.getTapPointsFailed -= HandleGetTapPointsFailed;
		TapjoyPlugin.spendTapPointsSucceeded -= HandleSpendTapPointsSucceeded;
		TapjoyPlugin.spendTapPointsFailed -= HandleSpendTapPointsFailed;
		TapjoyPlugin.awardTapPointsSucceeded -= HandleAwardTapPointsSucceeded;
		TapjoyPlugin.awardTapPointsFailed -= HandleAwardTapPointsFailed;
		TapjoyPlugin.tapPointsEarned -= HandleTapPointsEarned;
		
		// Tapjoy Full Screen Ad Events
		TapjoyPlugin.getFullScreenAdSucceeded -= HandleGetFullScreenAdSucceeded;
		TapjoyPlugin.getFullScreenAdFailed -= HandleGetFullScreenAdFailed;
		
		// Tapjoy Daily Reward Ad Events
		TapjoyPlugin.getDailyRewardAdSucceeded -= HandleGetDailyRewardAdSucceeded;
		TapjoyPlugin.getDailyRewardAdFailed -= HandleGetDailyRewardAdFailed;
		
		// Tapjoy Display Ad Events
		TapjoyPlugin.getDisplayAdSucceeded -= HandleGetDisplayAdSucceeded;
		TapjoyPlugin.getDisplayAdFailed -= HandleGetDisplayAdFailed;
		
		// Tapjoy Video Ad Events
		TapjoyPlugin.videoAdStarted -= HandleVideoAdStarted;
		TapjoyPlugin.videoAdFailed -= HandleVideoAdFailed;
		TapjoyPlugin.videoAdCompleted -= HandleVideoAdCompleted;
		
		// Tapjoy Ad View Closed Events
		TapjoyPlugin.viewOpened -= HandleViewOpened;
		TapjoyPlugin.viewClosed -= HandleViewClosed;
		
		// Tapjoy Show Offers Events
		TapjoyPlugin.showOffersFailed -= HandleShowOffersFailed;
	}

	
	#region Tapjoy Callback Methods (These must be implemented in your own c# script file.)

	// CONNECT
	public void HandleTapjoyConnectSuccess()
	{
		print("HandleTapjoyConnectSuccess");
	}
	
	public void HandleTapjoyConnectFailed()
	{
		print("HandleTapjoyConnectFailed");
	}
	
	// VIRTUAL CURRENCY
	void HandleGetTapPointsSucceeded(int points)
	{
		print("HandleGetTapPointsSucceeded: " + points);
		tapPointsLabel = "Total TapPoints: " + TapjoyPlugin.QueryTapPoints();
	}
	
	public void HandleGetTapPointsFailed()
	{
		print("HandleGetTapPointsFailed");
	}
	
	public void HandleSpendTapPointsSucceeded(int points)
	{
		print("HandleSpendTapPointsSucceeded: " + points);
		tapPointsLabel = "Total TapPoints: " + TapjoyPlugin.QueryTapPoints();
	}

	public void HandleSpendTapPointsFailed()
	{
		print("HandleSpendTapPointsFailed");
	}

	public void HandleAwardTapPointsSucceeded()
	{
		print("HandleAwardTapPointsSucceeded");
		tapPointsLabel = "Total TapPoints: " + TapjoyPlugin.QueryTapPoints();
	}

	public void HandleAwardTapPointsFailed()
	{
		print("HandleAwardTapPointsFailed");
	}
	
	public void HandleTapPointsEarned(int points)
	{
		print("CurrencyEarned: " + points);
		tapPointsLabel = "Currency Earned: " + points;
		
		TapjoyPlugin.ShowDefaultEarnedCurrencyAlert();
	}
	
	// FULL SCREEN ADS
	public void HandleGetFullScreenAdSucceeded()
	{
		print("HandleGetFullScreenAdSucceeded");
		
		TapjoyPlugin.ShowFullScreenAd();
	}
	
	public void HandleGetFullScreenAdFailed()
	{
		print("HandleGetFullScreenAdFailed");
	}
	
	// DAILY REWARD ADS
	public void HandleGetDailyRewardAdSucceeded()
	{
		print("HandleGetDailyRewardAdSucceeded");
		
		TapjoyPlugin.ShowDailyRewardAd();
	}
	
	public void HandleGetDailyRewardAdFailed()
	{
		print("HandleGetDailyRewardAdFailed");
	}
	
	// DISPLAY ADS
	public void HandleGetDisplayAdSucceeded()
	{
		print("HandleGetDisplayAdSucceeded");
		
		if (!openingFullScreenAd)
			TapjoyPlugin.ShowDisplayAd();
	}
	
	public void HandleGetDisplayAdFailed()
	{
		print("HandleGetDisplayAdFailed");
	}
	
	// VIDEO
	public void HandleVideoAdStarted()
	{
		print("HandleVideoAdStarted");
	}
	
	public void HandleVideoAdFailed()
	{
		print("HandleVideoAdFailed");
	}
	
	public void HandleVideoAdCompleted()
	{
		print("HandleVideoAdCompleted");
	}
	
	// VIEW OPENED	
	public void HandleViewOpened(TapjoyViewType viewType)
	{
		print("HandleViewOpened of view type " + viewType.ToString());
		openingFullScreenAd = true;
	}
	
	// VIEW CLOSED	
	public void HandleViewClosed(TapjoyViewType viewType)
	{
		print("HandleViewClosed of view type " + viewType.ToString());
		openingFullScreenAd = false;
	}
	
	// OFFERS
	public void HandleShowOffersFailed()
	{
		print("HandleShowOffersFailed");
	}
	
	#endregion
	
	#region GUI for sample app
	
	public void ResetTapPointsLabel()
	{
		tapPointsLabel = "Updating Tap Points...";
	}
	
	void OnGUI()
	{
		if (openingFullScreenAd)
			return;
		
		GUIStyle labelStyle = new GUIStyle();
		labelStyle.alignment = TextAnchor.MiddleCenter;
		labelStyle.normal.textColor = Color.white;
		labelStyle.wordWrap = true;
		
		float centerx = Screen.width / 2;
		//float centery = Screen.height / 2;
		float spaceSize = 60;
		float buttonWidth = 300;
		float buttonHeight = 50;
		float fontSize = 20;
		float spacer = 100;
		
		// Quit app on BACK key.
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
		
		GUI.Label(new Rect(centerx - 200, spacer, 400, 25), "Tapjoy Connect Sample App", labelStyle);
		
		spacer += fontSize + 10;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Show Offers"))
		{
			TapjoyPlugin.ShowOffers();
		}
		
		spacer += spaceSize;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Show Daily Reward Ad"))
		{
			TapjoyPlugin.GetDailyRewardAd();
		}
		
		spacer += spaceSize;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Get Display Ad"))
		{
			TapjoyPlugin.GetDisplayAd();
		}
		
		spacer += spaceSize;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Hide Display Ad"))
		{
			TapjoyPlugin.HideDisplayAd();
		}
		
		spacer += spaceSize;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Toggle Display Ad Auto-Refresh"))
		{
			autoRefresh = !autoRefresh;
			TapjoyPlugin.EnableDisplayAdAutoRefresh(autoRefresh);
		}
		
		spacer += spaceSize;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Show FullScreen Ad"))
		{
			TapjoyPlugin.GetFullScreenAd();
		}
		
		spacer += spaceSize;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Get Tap Points"))
		{
			TapjoyPlugin.GetTapPoints();
			ResetTapPointsLabel();
		}
		
		spacer += spaceSize;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Spend Tap Points"))
		{
			TapjoyPlugin.SpendTapPoints(10);
			ResetTapPointsLabel();
		}
		
		spacer += spaceSize;
		
		if (GUI.Button(new Rect(centerx - (buttonWidth / 2), spacer, buttonWidth, buttonHeight), "Award Tap Points"))
		{
			TapjoyPlugin.AwardTapPoints(10);
			ResetTapPointsLabel();
		}
		
		spacer += fontSize;
		
		// Display status
		GUI.Label(new Rect(centerx - 200, spacer, 400, 150), tapPointsLabel, labelStyle);
	}
	
	#endregion
}