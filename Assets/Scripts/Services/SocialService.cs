using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Facebook.Unity;

public class SocialService 
{
	public string[] _permissions;

	public void Initialize(Action initializationListener)
	{
		/*if(FB.IsInitialized)
		{
			if (initializationListener != null)
				initializationListener ();
		
			return;
		}

		FB.Init(() => {
			if(FB.IsInitialized)
				FB.ActivateApp();
			initializationListener();
		});*/
	}


	public void Login(Action<bool> successListener)
	{
		/*FB.LogInWithReadPermissions(new List<string>(_permissions), (ILoginResult result) => {
			if(string.IsNullOrEmpty(result.Error))
			{
				successListener(true);
			}
			else
				successListener(false);
		});*/
	}

	public bool _isLoggedIn		{
        get	{ return false; /*FB.IsLoggedIn;*/	}	}

	public bool _isInialized	{	get	{ return false;  /*FB.IsInitialized;*/	}	}

	public string _externalID	{	get	{ return "";  /*AccessToken.CurrentAccessToken.UserId;*/	}	}

	public string _authToken	{	get	{ return ""; /*AccessToken.CurrentAccessToken.TokenString;*/	}	}
}
