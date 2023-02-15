using UnityEngine;
using UnityEngine.Events;
public class AppScreen : MonoBehaviour
{

    public string ScreenName;

    [SerializeField]
    private GameObject screenInterface;

    [SerializeField]
    private bool welcomeScreen;

    [SerializeField]
    private UnityEvent onScreenClosedEvent;

    private void Start()
    {


        ScreenManager.onScreenAdded += EnableScreen;
        ScreenManager.onScreenRemoved += DisableScreen;

        if (welcomeScreen)
        {
            ScreenManager.AddScreen(this);

        }
        else
        {
            ShowContent(false);
        }

    }



    private void OnDisable()
    {
        ScreenManager.onScreenAdded -= EnableScreen;
        ScreenManager.onScreenRemoved -= DisableScreen;

    }

    public void OnScreenClosed()
    {
        //If there is an OnClose event invoke it
        onScreenClosedEvent?.Invoke();
    }

    void EnableScreen(string screenName) => ShowContent(this.ScreenName.Equals(screenName));



    void DisableScreen(string screenName)
    {

        if (this.ScreenName.Equals(screenName))
        {

            ShowContent(false);
        }

    }

    private void OnValidate()
    {
        this.name = ScreenName + "_Screen";
    }

    public void ShowContent(bool show) => screenInterface.SetActive(show);
}
