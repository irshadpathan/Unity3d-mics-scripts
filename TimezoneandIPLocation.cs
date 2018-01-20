using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimezoneandIPLocation : MonoBehaviour {

	public Button IpButton;
	public Button TimeZoneButton;

	public RootObject GetIP = new RootObject();

	public TimeZone timezone = new TimeZone ();

	void Start()
	{
		IpButton.onClick.AddListener (delegate {
			Action_GetIP();	
		});

		TimeZoneButton.onClick.AddListener (delegate {
			Action_GetTimezone();	
		});
	}


	// Click Event
	public void Action_GetIP()
	{
		StartCoroutine ("Ipfetch");
	}

	// Click Event
	public void Action_GetTimezone()
	{
		StartCoroutine ("Fetchtimezone");
	}

	// Fetch IP and Location
	IEnumerator Ipfetch()
	{
		WWW url = new WWW ("https://extreme-ip-lookup.com/json/");

		yield return url;

		GetIP = JsonUtility.FromJson<RootObject> (url.text);
	}

	// Fetch Time zone
	IEnumerator Fetchtimezone()
	{
		WWW url = new WWW ("https://script.googleusercontent.com/macros/echo?user_content_key=BWd7XJdRZu4Lz_Dqt7mt68faW4GfMfOnxRWXDgM-sd9ZrJlLBK_J7EuPZNqB-U8BMEn8avTH9qsR5NvzOoVPEbjsrlZ-E4Qvm5_BxDlH2jW0nuo2oDemN9CCS2h10ox_1xSncGQajx_ryfhECjZEnJ9GRkcRevgjTvo8Dc32iw_BLJPcPfRdVKhJT5HNzQuXEeN3QFwl2n0M6ZmO-h7C6eIqWsDnSrEd&lib=MwxUjRcLr2qLlnVOLh12wSNkqcO1Ikdrk");

		yield return url;

		timezone = JsonUtility.FromJson<TimeZone> (url.text);
	}

}

[System.Serializable]
public class RootObject
{
	public string businessName;
	public string businessWebsite;
	public string city;
	public string continent;
	public string country;
	public string countryCode;
	public string ipName;
	public string ipType;
	public string isp;
	public string lat;
	public string lon;
	public string org;
	public string query;
	public string region;
	public string status;
}

[System.Serializable]
public class TimeZone
{
	public int dayofweek ;
	public string dayofweekName ;
	public int day ;
	public int month ;
	public string monthName ;
	public int year ;
	public int hours ;
	public int minutes ;
	public int seconds ;
	public int millis ;
	public string fulldate ;
	public string timezone ;
	public string status ;
}
