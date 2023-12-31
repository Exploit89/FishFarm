using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private CashExchanger _playerCashExchanger;

    private void Start()
    {
        OpenPanel(_menuPanel);
    }

    private void OnEnable()
    {
        _playerCashExchanger.ShopEntered += OpenPanel;
    }

    private void OnDisable()
    {
        _playerCashExchanger.ShopEntered -= OpenPanel;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
