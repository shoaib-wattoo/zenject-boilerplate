using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public enum HeaderFooterState
{
    Enable,
    Disable,
    FollowPrevious
}

public class HeaderFooterController : MonoBehaviour
{
    [Inject] SignalBus signalBus;
    public Button profileButton, messageButton;
    public HeaderManager headerManager;

    private void Start()
    {
    }

    void OnClickProfileButton()
    {
    }

    public void OnUpdateUserName()
    {
        headerManager.SetUserName();
    }

    public void OnUpdateUserAvatar()
    {
        headerManager.UpdateAvatar();
    }

    public void Show(BacklogType backlogType = BacklogType.DisablePreviousScreen)
    {
        View();
        Services.BackLogService.OnScreenOpen(gameObject, backlogType);
    }

    public void Show(params BacklogType[] backlogTypes)
    {
        View();
        Services.BackLogService.OnScreenOpen(gameObject, backlogTypes);
    }

    private void View()
    {
        //gameObject.transform.SetAsLastSibling();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
