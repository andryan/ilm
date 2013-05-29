using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	
	//balancing the customer spawning speed and etc
	public class CustomerSpawning
	{
		
		//Testing , Change to protected after finish testing
		public int day;
		protected DateTime OpeningTime;
		public int SpawningSpeed;
		public int MaxCustomerSpawn;
		
		
		protected List<GameObject> SpawnedObject;
		private GameObject createdCustomer;
		
		public CustomerSpawning (int day)
		{
			this.day = day;
		
			this.init();
		}
		
		public void init()
		{
			this.SpawnedObject = new List<GameObject>();
		}
		
		
		public Boolean isSpawnCustomer()
		{
			Boolean result = false;
			if(SpawnedObject.Count == MaxCustomerSpawn)
			{
				return result;
			}
			
			//Created a new customer
			//Customer Type
			
			
			
			return result;
		}
		
		private Boolean isTimePermitted()
		{
			Boolean result = false;

			return result;
			
		}
		
		private int generatedCustomerType()
		{
			return -1;
			//Generated a customer type using the spawnedObject and random as a factor
			//1st   day : introduce mekanism (1 type customer);
			//2-3   day : introduce different customer type;
			//4-7   day : fever and customer combo play
			//8-11  day : introduce more customer type;
			//12-15 day : introduce helper combo play
			//16-20 day : 
			//21-25 day : 
			//26-onwards: 
		}
		
		public GameObject getCustomer()
		{
			GameObject result = createdCustomer;
			
			this.SpawnedObject.Add(createdCustomer);

			createdCustomer = null;
			return result;
		}
	}
}

