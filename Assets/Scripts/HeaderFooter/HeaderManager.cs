using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HeaderManager : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public Image avatar;

    void OnEnable()
    {
        SetUserName();
        UpdateAvatar();
    }

    public void SetUserName()
    {
        headerText.SetText(Services.UserService._user.userName);
    }

    public void UpdateAvatar()
    {
    }
}
