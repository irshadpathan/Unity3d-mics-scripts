using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareTwitter : MonoBehaviour {

	public string massage;
	public string url;
	public string hashtags;
	public string senduser;


	public void TwitterShare()
	{
		TWShare ();
	}


	 void TWShare()
	{
		Application.OpenURL 
		(
			"https://twitter.com/intent/tweet?text=" + massage + "&url=" + url + "&hashtags=" + hashtags + "&via=" + senduser + "&related=twitter"
		);
	}

}
