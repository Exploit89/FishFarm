using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;

    private void Start()
    {
        OpenPanel(_menuPanel);
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
