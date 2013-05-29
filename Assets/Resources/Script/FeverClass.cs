using System;
using UnityEngine;

public class FeverClass : MonoBehaviour
{
	
	public int FeverTime = 10000;
	
	private delegate void UpdateDelegate();
	private UpdateDelegate updateSceneDelegate;
	
	private DateTime startTime;
	
	private float defaultMS;
	private float defaultAS;
	
	public FeverClass ()
	{
		updateSceneDelegate = DetectingFever;	
	}
	
	
	
	public void Update()
	{
		updateSceneDelegate();
	}
	
	private void DetectingFever()
	{
		if(Input.GetKeyUp(KeyCode.Space) && Main.FeverPoint == 1)
		{
			this.defaultAS = Main.MyPlayer.PlayerActionSpeed;
			this.defaultMS = Main.MyPlayer.PlayerWalkingSpeed;
			
			Main.MyPlayer.PlayerWalkingSpeed = 0;
			Main.MyPlayer.PlayerActionSpeed = 1f;
			
			Main.MyControl.activateFever();
			Main.MyHelper.ActivateFever();
			
			
			startTime = DateTime.Now;
			updateSceneDelegate = FeverRunning;
		}
	}
	
	private void FeverRunning()
	{
		TimeSpan span = DateTime.Now - startTime;
		Main.FeverPoint = 1 - (float) span.TotalMilliseconds/FeverTime;
		if(span.TotalMilliseconds > FeverTime)
		{
			Main.MyPlayer.PlayerActionSpeed = this.defaultAS;
			Main.MyPlayer.PlayerWalkingSpeed = this.defaultMS;
			
			Main.MyHelper.DeactivateFever();
			
			updateSceneDelegate = DetectingFever;
			Main.FeverPoint = 0;
		}
	}
}

