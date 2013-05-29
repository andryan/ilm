using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RestfulServices : MonoBehaviour {
	
	private string serverAddress;
	private string token;
	
	
	
	public bool connectToServer(Dictionary<string, string> loginDetail)
	{
		WWWForm form = new WWWForm();
		
		Hashtable headers = form.headers;

		foreach (KeyValuePair<string, string> item in loginDetail) {
			form.AddField(item.Key, item.Value);
		}
		
		WWW www = new WWW (serverAddress, form.data, headers);
		StartCoroutine (WaitForRequest (www));
		if(www.error == null)
		{
    		this.token = www.text;
			return true;
		}
		else
			return false;
	}
	
	public Hashtable getPlayerAttribute()
	{
		Hashtable result = null;

		WWWForm form = new WWWForm();
		
		Hashtable headers = form.headers;
		headers.Add("token", this.token);
		
		WWW www = new WWW (serverAddress, form.data, headers);
		StartCoroutine (WaitForRequest (www));
		if(www.error == null)
		{
    		//result = www.text;
			return result;
		}
		else
			return result;
	}
	
	public bool microTransactionUpdate(Hashtable transactionDetails)
	{
		bool result = false;

		WWWForm form = new WWWForm();
		Hashtable headers = form.headers;
		headers.Add("token", this.token);
		
		WWW www = new WWW (serverAddress, form.data, headers);
		StartCoroutine (WaitForRequest (www));
		if(www.error == null)
		{
			if(!bool.TryParse(www.text, out result))
				result = false;
		}
		else
			result = false;
		
		return result;
	}
	
	public List<string> submitDailyResult(Hashtable dailyResult)
	{
		List<string> result = null;

		WWWForm form = new WWWForm();
		
		Hashtable headers = form.headers;
		headers.Add("token", this.token);
		
		foreach (var item in dailyResult.Keys)
		{
			form.AddField(item.ToString(), dailyResult[item].ToString());	
		}
		
		WWW www = new WWW (serverAddress, form.data, headers);
		StartCoroutine (WaitForRequest (www));
		if(www.error != null)
		{
    		result.Add(www.text);
			return result;
		}
		else
			return result;
	}
	
	public List<string> getAchievementList()
	{
		List<string> result = null;

		WWWForm form = new WWWForm();
		
		Hashtable headers = form.headers;
		headers.Add("token", this.token);
		
		WWW www = new WWW (serverAddress, form.data, headers);
		StartCoroutine (WaitForRequest (www));
		if(www.error == null)
		{
    		result.Add(www.text);
			return result;
		}
		else
			return result;
	}
	
	public int getDailyLimit()
	{
		int result = -1;

		WWWForm form = new WWWForm();
		
		Hashtable headers = form.headers;
		headers.Add("token", this.token);
		
		WWW www = new WWW (serverAddress, form.data, headers);
		StartCoroutine (WaitForRequest (www));
		if(www.error == null)
		{
    		if(int.TryParse(www.text, out result))
				return result;
			else
				return -1;
		}
		else
			return result;

	}
	
	public bool updateDailyLimit(int playerLifeLimit)
	{
		bool result = false;

		WWWForm form = new WWWForm();
		
		Hashtable headers = form.headers;
		headers.Add("token", this.token);
		
		form.AddField("DailyLimit", playerLifeLimit);
		
		WWW www = new WWW (serverAddress, form.data, headers);
		StartCoroutine (WaitForRequest (www));
		if(www.error == null)
		{
			if(!bool.TryParse(www.text, out result))
				result = false;
		}
		else
			result = false;
		
		return result;

	}
	/*
	
	public WWW GET2(string url)
    {
		WWWForm form = new WWWForm();
		Hashtable headers = form.headers;
		//headers.Add("Authorization","Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("admin:1234")));
		headers.Add("ilm_name","NANDI");
		form.AddField("social_type","1");
		form.AddField("social_id","1241t319512");
		
		Debug.Log("GET Function called");
		WWW www = new WWW (url, form.data, headers);
		Debug.Log("Awaiting result");
    	StartCoroutine (WaitForRequest (www));
    	return www; 
    }

	
	
	public WWW POST(string url, Hashtable headers, Dictionary<string,string> post)
	{
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<string,string> post_arg in post)
    	{
     	  	form.AddField(post_arg.Key, post_arg.Value);
    	}
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
    	return www; 
    
	}
	
	
	public WWW GET(string url)
    {
		WWWForm form = new WWWForm();
		form.AddField("2ww","Www");
		Hashtable headers = form.headers;
		headers.Add("Authorization","Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("admin:1234")));
		headers.Add("ilm_name","NANDI");
		Debug.Log("GET Function called");
		WWW www = new WWW (url, form.data, headers);
		Debug.Log("Awaiting result");
    	StartCoroutine (WaitForRequest (www));
    	return www; 
    }

  
	public WWW POST(string url, Dictionary<string,string> post)
    {
   	 	WWWForm form = new WWWForm();
   		foreach(KeyValuePair<string,string> post_arg in post)
    	{
     	  	form.AddField(post_arg.Key, post_arg.Value);
    	}
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
    	return www; 
    }
	*/
    
	
	private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
	}
}
