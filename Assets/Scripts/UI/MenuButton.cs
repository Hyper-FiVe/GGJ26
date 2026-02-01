using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void OnSwitchCanvas(GameObject targetCanvas)
    {
        transform.parent.gameObject.SetActive(false);
        targetCanvas.SetActive(true);
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnEndGame()
    {
        SceneManager.LoadScene("UIScene_Menu");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
