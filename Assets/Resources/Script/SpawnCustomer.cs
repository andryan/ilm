using UnityEngine;
using System.Collections;

public class SpawnCustomer : MonoBehaviour {
	
	public int myDay = 2; // hari pada mulai game start Day 2
	
	public float myDisappearIcon = 10.0f; // waktu pada saat icon customer jadi besar kecil (impatient)
	
	public float myCustomerSpeed = 0.3f; // penampung kecepatan customer
	
	public float myMinusTime = 0.0f; // penampung pengurangan waktu untuk durasi customer saat menunggu
	
	public float maxDisappearIcon = 2.0f;
	
	public int vipCount = 0; // jumlah customer yg datang
	public int shortTCount = 0;
	public int normalCount = 0;
	public int casualCount = 0;
	
	public int myVipCount = 0; // penampung jumlah customer yg datang
	public int myShortTCount = 0;
	public int myNormalCount = 0;
	public int myCasualCount = 0;
	
	public int totalCustomer = 0; // total keseluruhan customer per hari
	public int tempTotalCust = 0; // penampung total customer
	
	public int daysForUpgradeCustomerSpeed = 1;
	public int daysForUpgradeCustomerSpeedCount;
	
	public int daysForUpgradeCustomerSize = 3; // hari buat update jumlah max customer per hari
	public int daysForUpgradeCount;
	
	public int addNormalCustomer = 1; // jumlah max customer per hari yg akan ditambahkan
	public int addVipCustomer = 1;
	public int addShortTCustomer = 1;
	public int addCasualCustomer = 1;
	
	public float additionalCustomerSpeed = 0.0025f;  // penambahan customer speed
	
	public int maxNormalCustomerSize = 2; // jumlah max customer normal perhari
	public int maxVipCustomerSize = 2;
	public int maxShortTCustomerSize = 2;
	public int maxCasualCustomerSize = 2;
	
	public float maxCustomerSpeed = 0.1f;
	public float maxMinusTime = 19.0f;
	
	public int daysForUpdateIconCustDisappear = 1; // hari buat ngubah durasi icon customer
	public int daysForUpdateIconCustDisappearCount;
	
	public float addTimeForIconCustDisappear = 0.4f; // buat ngurangin durasi icon customer yg besar-kecil (impatient)
	
	public int daysForUpdateCustWaitingTime = 1; // hari buat ngubah waiting time
	public int daysForUpdateCustWaitingTimeCount;
	
	public float addTimeForCustWaitingTime = 0.5f; // buat ngurangin waiting time customer
	
	public int daysForUpdateCustomerMaxAction = 5; // hari buat ngubah action list
	public int daysForUpdateCustomerMaxActionCount;
	
	public int addNormalCustomerActionSize  = 1; // buat nambah action list customer
	public int addVipCustomerActionSize = 1;
	public int addShortTCustomerActionSize = 1;
	public int addCasualCustomerActionSize = 1;
	
	public int myNormalAction = 4; //penampung action
	public int myVIPAction = 6;
	public int myShortTAction = 4;
	public int myCasualAction = 3;
	
	public int myMaxWave = 2;
	
	public int daysForUpdateMaxWave = 3;
	public int daysForUpdateMaxWaveCount;
	
	public int addMaxWave = 1;
	
	public float reduceDelaySpawn = 0.0f;
	
	public int daysForUpdateReduceDelaySpawn = 2;
	public int daysForUpdateReduceDelaySpawnCount;
	
	public float addReduceDelay = 0.1f;
	
	public float maxReduceDelay = 2.8f;
	
	// Use this for initialization
	void Start () {
		daysForUpgradeCount = 0;
		daysForUpgradeCustomerSpeedCount = 0;
		daysForUpdateIconCustDisappearCount = 0;
		daysForUpdateCustWaitingTimeCount = 0;
		daysForUpdateCustomerMaxActionCount = 0;
		daysForUpdateMaxWaveCount = 0;
		daysForUpdateReduceDelaySpawnCount = 0;
			
	}
	
	// Update is called once per frame
	void Update () {
		totalCustomer = normalCount + vipCount + shortTCount + casualCount;
		tempTotalCust = myNormalCount + myVipCount + myShortTCount + myCasualCount;
		
		if(myDay < Main.MyPlayerAtr.Day)
		{
			myDay++;
			daysForUpgradeCount++;
			daysForUpgradeCustomerSpeedCount++;
			daysForUpdateIconCustDisappearCount++;
			daysForUpdateCustWaitingTimeCount++;
			daysForUpdateIconCustDisappearCount++;
			daysForUpdateCustomerMaxActionCount++;
			daysForUpdateMaxWaveCount++;
			daysForUpdateReduceDelaySpawnCount++;
		}

		if(daysForUpgradeCount >= daysForUpgradeCustomerSize)
		{	
			AddNormalCustomerSize();
			AddVipCustomerSize();
			AddShortTCustomerSize();
			AddCasualCustomerSize();	
			daysForUpgradeCount = 0;
		}
		
		if(daysForUpgradeCustomerSpeedCount >= daysForUpgradeCustomerSpeed)
		{
			if(myCustomerSpeed > maxCustomerSpeed)
			{
				AddCustomerSpeed();
			}
			if(myCustomerSpeed > 1.0f)
			{
				myCustomerSpeed = 1.0f;
			}
			else if(myCustomerSpeed < maxCustomerSpeed)
			{
				myCustomerSpeed = maxCustomerSpeed;
			}
			daysForUpgradeCustomerSpeedCount = 0;
		}
		
		if(daysForUpdateIconCustDisappearCount >= daysForUpdateIconCustDisappear)
		{
			if(myDisappearIcon > maxDisappearIcon)
			{
				AddTimeCustIcon();
			}
			if(myDisappearIcon > 10.0f)
			{
				myDisappearIcon = 10.0f;
			}
			if(myDisappearIcon < maxDisappearIcon)
			{
				myDisappearIcon = maxDisappearIcon;
			}
			daysForUpdateIconCustDisappearCount = 0;
		}
		
		if(daysForUpdateCustomerMaxActionCount >= daysForUpdateCustomerMaxAction)
		{
			AddMaxNormalCustomerAction();
			AddMaxVipCustomerAction();
			AddMaxShortTCustomerAction();
			AddMaxCasualCustomerAction();
			Main.MySpawn.daysForUpdateCustomerMaxActionCount = 0;
		}
		
		if(daysForUpdateCustWaitingTimeCount >= daysForUpdateCustWaitingTime)
		{
			if(myMinusTime < maxMinusTime)
			{
				AddMinusTime();
			}
		
			if(myMinusTime > maxMinusTime)
			{
				myMinusTime = maxMinusTime;
			}
			else if(myMinusTime < 0.0f)
			{
				myMinusTime = 0.0f;
			}
			daysForUpdateCustWaitingTimeCount = 0;
		}
		
		if(daysForUpdateMaxWaveCount >= daysForUpdateMaxWave)
		{
			AddMaxWave();
			daysForUpdateMaxWaveCount = 0;
		}
		
		if(daysForUpdateReduceDelaySpawnCount >= daysForUpdateReduceDelaySpawn)
		{
			if(reduceDelaySpawn < maxReduceDelay)
			{
				AddReduceDelaySpawn();
			}
			if(reduceDelaySpawn > maxReduceDelay)
			{
				reduceDelaySpawn = maxReduceDelay;
			}
			else if(reduceDelaySpawn < 0.0f)
			{
				reduceDelaySpawn = 0.0f;
			}
			daysForUpdateReduceDelaySpawnCount = 0;
		}
	}
	
	private void AddCustomerSpeed()
	{
		myCustomerSpeed -= additionalCustomerSpeed;
	}
	
	// ---------------------------------------------------------
	
	private void AddNormalCustomerSize()
	{
		maxNormalCustomerSize += addNormalCustomer;
	}
	
	private void AddVipCustomerSize()
	{
		maxVipCustomerSize += addVipCustomer;
	}
	
	private void AddShortTCustomerSize()
	{
		maxShortTCustomerSize += addShortTCustomer;
	}
	
	private void AddCasualCustomerSize()
	{
		maxCasualCustomerSize += addCasualCustomer;
	}
	
	// -------------------------------------------------------
	
	private void AddMaxNormalCustomerAction()
	{
		myNormalAction += addNormalCustomerActionSize;
	}
	
	private void AddMaxVipCustomerAction()
	{
		myVIPAction += addVipCustomerActionSize;
	}
	
	private void AddMaxShortTCustomerAction()
	{
		myShortTAction += addShortTCustomerActionSize;
	}
	
	private void AddMaxCasualCustomerAction()
	{
		myCasualAction += addCasualCustomerActionSize;
	}
	
	// --------------------------------------------------------
	
	private void AddTimeCustIcon()
	{
		myDisappearIcon -= addTimeForIconCustDisappear;
	}
	
	// --------------------------------------------------------
	
	private void AddMinusTime()
	{
		myMinusTime += addTimeForCustWaitingTime;
	}
	
	// --------------------------------------------------------
	
	private void AddMaxWave()
	{
		myMaxWave += addMaxWave;
	}
	
	// --------------------------------------------------------
	
	private void AddReduceDelaySpawn()
	{
		reduceDelaySpawn += addReduceDelay;
	}
}
