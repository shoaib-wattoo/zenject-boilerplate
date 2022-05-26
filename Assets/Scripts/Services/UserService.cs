using System;
using UnityEngine;
using System.Collections.Generic;

public class UserService
{
    private const string USER_KEY = "UserObjString";
    private string password;
    private string authToken;
    public User _user = null;
    public Season season;
    public LeagueData league;

    public Action<Backend.ResponseMessage<User>> _serviceLoadListener;

    [SerializeField]
    private SocialService _socialService;

    #region public API

    public bool _isUserRegistered { get { return IsUserRegistered(_user); } }

    public static bool IsUserRegistered(User user) { return !string.IsNullOrEmpty(user.fbid) || !string.IsNullOrEmpty(user.cellPhone); }

    public void LoadService()
    {
        
    }

    public string Test()
    {
        return "This is test";
    }


    public void LoginFB()
    {
        if (!_socialService._isInialized)
            _socialService.Initialize(LoginFBAction);
        else
            LoginFBAction();
    }


    #endregion


    private void LoginFBAction()
    {
        _socialService.Login(success =>
        {
            if (_socialService._isLoggedIn)
            {
                //Backend.UserAPI.ConnectFB(_user.id.ToString(), _socialService._externalID, _socialService._authToken, OnUserInfoResponse);
            }
            else
            {
                Debug.LogWarning("Something went wrong!");
                Backend.UserAPI.GetUserById(_user._id.ToString(), OnUserInfoResponse);
            }
        });
    }


    public void Login(string email, string password, Action<Backend.ResponseMessage<User>> loginListener)
    {
        _serviceLoadListener = loginListener;
        this.password = password;

        // You might want to check internet connectivity here, before requesting to create guest user.
        Backend.UserAPI.Login(email, password, OnUserInfoResponse);
    }

    public void AutoLogin(Action<Backend.ResponseMessage<User>> loginListener)
    {
        _serviceLoadListener = loginListener;
        this.password = _user.password;

        Backend.UserAPI.Login(_user.emailAddress, password, OnUserInfoResponse);
    }


    public void UpdateUser(Action<Backend.ResponseMessage<User>> updateListener)
    {
        _serviceLoadListener = updateListener;

        Backend.UserAPI.UpdateProfile(OnUserInfoResponse);
    }

    public void LinkAccount(Backend.LinkAccountData data, Action<Backend.ResponseMessage<string>> linkAccountListener)
    {
        Backend.UserAPI.LinkAccount(data.firstName, data.lastName, data.property, data.playersClubAccNo, data.accountPin, linkAccountListener);
    }


    private void OnUserInfoResponse(Backend.ResponseMessage<User> userResponse)
    {
        //Means that the request never reached the backend Abjadiyat web app...
        if (userResponse._statusCode != (int)System.Net.HttpStatusCode.OK)
        {
            //Services.UIService.ShowAlert("Error", "Something went wrong. Please try again later.", Services.UIService.HideLoading, "Close");

            /*if (_user == null)
				ShowQuitOnError ();
			else
				ProceedOffline ();
			return;*/
        }

        if (userResponse._statusCode == (int)System.Net.HttpStatusCode.OK)
        {
            User newUser = userResponse._entity;
            Debug.Log("new User : " + newUser.userName);
            bool isDifferentUser = _user == null || _user._id != newUser._id || (newUser.token != null && _user.token != newUser.token);

            if (isDifferentUser)
                _user = newUser;

            if (!password.Equals(""))
                _user.password = password;

            if (_user.emailStatus.Equals("confirmed"))
                SaveUser();

            if (_serviceLoadListener != null)
                _serviceLoadListener(userResponse);
        }
        else
        {
            // Handle error code here... If _user is not null, proceed offline...
        }
    }


    private void ShowQuitOnError()
    {
        /*UIManager.LoadUI<TwoButtonPopup> ().Show ("Error Title", "Something went wrong", "Try again", () => {
			UIManager.DestroyUI<TwoButtonPopup> ();
			LoadService (_serviceLoadListener);
		}, "Quit", () => {
			Application.Quit();
		});*/
    }


    // Only call this method if the _user variable is not null...
    private void ProceedOffline()
    {
        //if(_serviceLoadListener != null)
        //_serviceLoadListener();
    }


    private void AuthenticateUser()
    {
        // If has fb id...
        if (!string.IsNullOrEmpty(_user.fbid))
        {
            // If FB.islogged in
            if (_socialService._isLoggedIn)
            {
                //Backend.UserAPI.ConnectFB(_user.id.ToString(), _socialService._externalID, _socialService._authToken, OnUserInfoResponse);
            }
            else
            {
                LoginFB();
            }
        }
        else
            Backend.UserAPI.GetUserById(_user._id.ToString(), OnUserInfoResponse);
    }


    public void SaveUser()
    {
    }

    public void SaveFCMToken(string fcmToken)
    {
        if (_user._id != null)
        {
            Backend.UserAPI.SetFCMToken((user) => { });
            _user.fcmToken = fcmToken;
            SaveUser();
        }
    }

    public void VerifyOTP(string myOtp, Action<Backend.ResponseMessage<User>> otpListener)
    {
        _serviceLoadListener = otpListener;

        Backend.UserAPI.VerifyOTP(myOtp, OnUserInfoResponse);
    }

    public void ForgetUsername(string email, Action<Backend.ResponseMessage<string>> otpListener)
    {
        Backend.UserAPI.ForgetUsername(email, otpListener);
    }


    public void AcceptOrRejectFriendRequest(string userID, string requestID, string recordID, bool accept, Action<object> otpListener)
    {
        Backend.UserAPI.AcceptOrRejectFriendRequest(userID, requestID, recordID, accept, (response) =>
        {
            otpListener?.Invoke(response);
        });
    }

    public void FetchFriendRequests(string id, Action<FriendRequest> responseListener)
    {
        Backend.UserAPI.FetchFriendRequests(id, (response) =>
        {
            responseListener(response._entity);
        });
    }

    public void FetchFriends(string id, Action<Friends> responseListener)
    {
        Backend.UserAPI.FetchFriends(id, (response) =>
        {
            responseListener(response._entity);
        });
    }

    public void SearchFriends(string email, string cellPhone, Action<Friend> responseListener)
    {
        Backend.UserAPI.SearchFriends(email, cellPhone, (response) =>
        {
            responseListener(response._entity);
        });
    }

    

    #region MarketPlace

    public void UpdateMarketPlace(string itemType, string itemAmount, Action<MarketPlaceData> responseListener)
    {
        Backend.UserAPI.UpdateMarketPalce(itemType, itemAmount, (response) =>
        {

            if (response._statusCode != (int)System.Net.HttpStatusCode.OK)
            {
            }

            if (response._statusCode == (int)System.Net.HttpStatusCode.OK)
            {
                responseListener?.Invoke(response._entity);
            }

        });
    }

    #endregion

    public long GetIncrementedTimeInUnix(double seconds)
    {
        var timeSpan = (DateTime.UtcNow.AddSeconds(seconds) - new DateTime(1970, 1, 1, 0, 0, 0));
        return (long)timeSpan.TotalSeconds * 1000;
    }

    public DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
        return dtDateTime;
    }

    public List<User> GetDummyUsersList()
    {
        List<User> users = new List<User>();
        users.Add(CreateDummyUser("William"));
        users.Add(CreateDummyUser("James"));
        users.Add(CreateDummyUser("Mason"));
        users.Add(CreateDummyUser("Evelyn"));
        users.Add(CreateDummyUser("Ella"));
        users.Add(CreateDummyUser("Jackson"));
        users.Add(CreateDummyUser("Avery"));
        users.Add(CreateDummyUser("Scarlett"));
        users.Add(CreateDummyUser("Madison"));
        users.Add(CreateDummyUser("Eleanor"));
        users.Add(CreateDummyUser("Grayson"));
        users.Add(CreateDummyUser("Lily"));
        users.Add(CreateDummyUser("Ellie"));
        users.Add(CreateDummyUser("Lillian"));
        users.Add(CreateDummyUser("Lincoln"));
        users.Add(CreateDummyUser("Colton"));
        users.Add(CreateDummyUser("Addison"));
        users.Add(CreateDummyUser("Landon"));
        users.Add(CreateDummyUser("Hadley"));
        users.Add(CreateDummyUser("Andrea"));

        return users;
    }

    public User CreateDummyUser(string firstName)
    {
        User user = new User();
        user.firstName = firstName;
        return user;
    }

}
