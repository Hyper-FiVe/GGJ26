using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject targetCanvas;

    public void OnSwitchCanvas()
    {
        transform.parent.gameObject.SetActive(false);
        targetCanvas.SetActive(true);
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
