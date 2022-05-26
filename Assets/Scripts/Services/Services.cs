using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class Services : SingletonMonobehaviour<Services>
{
    public bool clearPrefs;
    public bool developmentMode = true;
    public bool testMode = true;

    [Inject]
    public Canvas canvas;

    [Inject]
    public UserService _userService;

	[Inject]
    public LocalizationService _localizationService;

    [Inject]
	public IAPService _iapService;

	[Inject]
    public ContentService _contentService;

	[Inject]
    public DownloadService _downloadService;

    [Inject]
    public GamesService _gamesService;

    [SerializeField]
    public BackLogService _backLogService;

    [SerializeField]
    public UIService _uiService;
    
    [SerializeField]
    public LocationService _locationService;

    //[Inject]
    //public Screen2 screen2;

    [Inject]
    public Screen1 screen1;

    [Inject] public SignalBus publicSignalBus;

    private void Update()
    {
        if (clearPrefs)
        {
            clearPrefs = false;
            PlayerPrefs.DeleteAll();
            Debug.Log("Prefs Cleared");
        }
    }

    public bool IsInternetConntected()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }

        return true;
    }

    #region public api

    public static UserService UserService {
		get	{return instance._userService; }
	}

	public static LocalizationService LocalizationService {
		get	{ return instance._localizationService; }
	}


	public static ContentService ContentService {
		get	{ return instance._contentService; }
	}

    public static LocationService LocationService
    {
        get { return instance._locationService; }
    }

    public static IAPService IAPService {
		get	{ return instance._iapService; }
	}

	public static DownloadService DownloadService {
		get	{ return instance._downloadService; }
	}

    public static BackLogService BackLogService
    {
        get { return instance._backLogService; }
    }

    public static UIService UIService
    {
        get { return instance._uiService; }
    }

    public static GamesService GamesService
    {
        get { return instance._gamesService; }
    }

    public static Canvas Canvas
    {
        get { return instance.canvas; }
    }

    public static SignalBus SignalBus
    {
        get { return instance.publicSignalBus; }
    }

    #endregion

    #region UI Screens

    /*
    public SplashScreen _splashScreen;

    [Inject]
    private SettingsScreen _settingsScreen;

    public static SettingsScreen SettingsScreen
    {
        get { return instance._settingsScreen; }
    }

    [Inject]
    private LoginScreen _loginScreen;

    public static LoginScreen LoginScreen
    {
        get { return instance._loginScreen; }
    }
    */
    #endregion
}
