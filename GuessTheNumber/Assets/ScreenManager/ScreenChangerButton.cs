using UnityEngine;
using UnityEngine.UI;
public class ScreenChangerButton : MonoBehaviour
{

    [Tooltip("This button used to pop the current screen")][SerializeField] private bool _isPopButton;
    public bool IsPopButton
    {
        get
        {
            return _isPopButton;
        }
        set
        {
            _isPopButton = value;
        }
    }
    [SerializeField] private AppScreen _screenToNavigateTo;
    public AppScreen ScreenToNavigateTo
    {
        get
        {
            return _screenToNavigateTo;
        }
        set
        {
            _screenToNavigateTo = value;
        }
    }

    //Internal
    private Button _button;

    private void Awake()
    {

        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {

        //_button.onClick.AddListener(_isPopButton ? PopScreen : NavigateToScreen);
        if(_isPopButton){
            _button.onClick.AddListener(PopScreen);
        }
        else
        {
            _button.onClick.AddListener(NavigateToScreen);
        }
    }
    private void OnDisable()
    {

        //_button.onClick.RemoveListener(_isPopButton ? PopScreen : NavigateToScreen);
        if (_isPopButton)
        {
            _button.onClick.AddListener(PopScreen);
        }
        else
        {
            _button.onClick.AddListener(NavigateToScreen);
        }
    }


    private void NavigateToScreen() => ScreenManager.AddScreen(_screenToNavigateTo);
    private void PopScreen() => ScreenManager.PopScreen();
}
