using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBShare : MonoBehaviour {

	[Header("Share Details")]
	public string appid;
	public string appurl;
	public string appname;
	public string appcaption;
	public string appdecription;
	public string appimage;
	public string appredirecturl;


	
	private const string FACEBOOK_APP_ID = "1813525715574073";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
			"&link=" + WWW.EscapeURL(linkParameter) +
			"&name=" + WWW.EscapeURL(nameParameter) +
			"&caption=" + WWW.EscapeURL(captionParameter) + 
			"&description=" + WWW.EscapeURL(descriptionParameter) + 
			"&picture=" + WWW.EscapeURL(pictureParameter) + 
			"&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}

	public void Action_FB_Share()
	{
		ShareToFacebook (appid, appname, appcaption, appdecription, appimage, appredirecturl);
	}

}
