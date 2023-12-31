using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Button _continueButton;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _cashPanel;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        _menu.ClosePanel(_menuPanel);
        _cashPanel.SetActive(true);
    }
}
