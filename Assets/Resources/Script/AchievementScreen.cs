using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementScreen : MonoBehaviour {
	
	
	void Start()
	{
		this.Init();
	}
	public void Init()
	{
		//this.getAchievementListFromServer();
		this.buildAchievementScreen();
	}
	
	List<string> listOfAchievedAchievement;
	
	public void getAchievementListFromServer()
	{
		this.listOfAchievedAchievement = Main.myServices.getAchievementList();
	}
	
	private GameObject contentPanel;
	
	public void buildAchievementScreen()
	{
		//Paging or Scrolling
		GameObject mainPanel = (GameObject) Instantiate((GameObject)Resources.Load("Prefabs/MainPanel"));
		Main.AddParent(mainPanel);
		
		mainPanel.transform.localPosition = new Vector3(0,0,-2);
		mainPanel.transform.localScale = new Vector3(1024,768,0.1f);

		this.contentPanel = (GameObject) mainPanel.transform.GetChild(0).gameObject;
		Main.AddParent(this.contentPanel);
		
		this.contentPanel.transform.localPosition = new Vector3(0,0,-3);
		this.contentPanel.transform.localScale = new Vector3(1024, 500, 0.1f);
		
		for(int i = 0; i < 108; i++)
		{
			GameObject dataPanel = (GameObject) Instantiate((GameObject)Resources.Load("Prefabs/DataPanel"));
			dataPanel.transform.parent = this.contentPanel.transform;
			dataPanel.transform.localScale = new Vector3(0.8f,0.1f,0.1f);
			dataPanel.transform.localPosition = new Vector3(0, 0.45f - (i*(0.1f) + 0.05f), 0);
		}
	}
	
	public void Update()
	{
		/*
		 * if (Input.GetMouseButton(0)) {      // If we click the mouse...
			//move content panel
			Vector3 temp = this.contentPanel.transform.position;
			this.contentPanel.transform.position = new Vector3(temp.x, temp.y += 200*Time.deltaTime, temp.z);
		}
		*/
		
		this.updatePlayerInput();
	}
	
	Vector2 mouseDownedPosition;
	
	float timeLeft;
	Vector2 originalPosition;
	
	
	private void updatePlayerInput()
	{
		if( Input.anyKey)
		{
			Vector2 inputPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			if ( Input.GetMouseButtonDown(0))
			{
				mouseDowned = true;
				originalPosition = inputPosition;
				mouseDownedPosition = inputPosition;
			}
			if ( mouseDowned )
			{
				timeLeft = 1.5f;
				Move(inputPosition);
			}
		}
		else if ( Input.touchCount > 0)
		{
			Vector2 inputPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

			if ( Input.GetTouch(0).phase == TouchPhase.Began)
			{
				mouseDowned = true;
				originalPosition = inputPosition;
				mouseDownedPosition = inputPosition;
			}
			
			if ( mouseDowned && Input.GetTouch(0).phase == TouchPhase.Moved )
			{
				timeLeft = 1.5f;
				Move(inputPosition);
			}
		}
		else
		{
			if(timeLeft < 0)
			{
				mouseDowned = false;
				state = States.Idle;
				autoMove = false;
			}
			else
			{
				Move();
				autoMove = true;
				speed = 1;
			}
		}
	}
	
	private bool autoMove = false;
	public enum States
	{
		Idle = 0,
		Up = 1,
		Down = 2,
	}
	
	States state;
	float speed = 1f;
		
	private bool mouseDowned = false;
	
	private float isStillMoreThan2Seconds = 0;
	
	private void Move()
	{
		Vector3 pos = contentPanel.transform.position;
		
		float scrollSpeed = Time.deltaTime*400*timeLeft*speed;
		if(scrollSpeed > 20)
		{
			scrollSpeed = 20;
		}
		if (state == States.Down)
		{
			pos.y+= scrollSpeed;
		}
		else if (state == States.Up)
		{
			pos.y-=scrollSpeed;
		}
		
		this.contentPanel.transform.position = pos;
		timeLeft-= Time.deltaTime;
	}
	
	private void Move(Vector2 newPosition)
	{
		
		if ( newPosition.y-mouseDownedPosition.y > 0 )
		{
			state = States.Up;
		}
		else if ( newPosition.y-mouseDownedPosition.y < 0 )
		{
			state = States.Down;
		}
		
		float delta = Mathf.Abs(originalPosition.y - mouseDownedPosition.y);
		float deltaFactor = delta/Res.DefaultHeight();
		
		mouseDownedPosition = newPosition;
		
		Vector3 pos = contentPanel.transform.position;

		if(delta/Screen.height <= 0.05 && delta != 0)
		{
			autoMove = false;
		}
		
		if(autoMove)
		{
			speed = speed + timeLeft/5;
			Move();
			return;
		}

		
		if(delta/Screen.height < 0.1)
		{
			float scrollSpeed = delta/20;
			if(scrollSpeed > 15)
				scrollSpeed = 15;
			if(state == States.Down)
			pos.y+=scrollSpeed;
			else if(state == States.Up)
			pos.y-=scrollSpeed;
			
			timeLeft = 0;
			
		}
		else
		{
			
			float scrollSpeed = Time.deltaTime*800* deltaFactor ;
			if(scrollSpeed > 15)
				scrollSpeed = 15;
		if (state == States.Down)
		{
			pos.y+=scrollSpeed;
		}
		else if (state == States.Up)
		{
			pos.y-=scrollSpeed;
		}
		
		
		
		}
		this.contentPanel.transform.position = pos;
		
	}

}	
	