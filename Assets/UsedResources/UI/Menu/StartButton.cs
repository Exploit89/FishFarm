using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _cashPanel;
    [SerializeField] private GameObject _stacksPanel;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        _menu.ClosePanel(_menuPanel);
        _menu.GetComponent<Image>().enabled = false;
        _cashPanel.SetActive(true);
        _stacksPanel.SetActive(true);
    }
}
