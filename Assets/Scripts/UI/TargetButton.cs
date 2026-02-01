using UnityEngine;

public class TargetButton : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject loseCanvas;

    public void OnTarget()
    {
        GameObject canvas = (GameManager.Instance.InteractingNPC == GameManager.Instance.target) ? winCanvas : loseCanvas;
        SwitchCanvas(canvas);
    }

    private void SwitchCanvas(GameObject targetCanvas)
    {
        transform.parent.gameObject.SetActive(false);
        targetCanvas.SetActive(true);
    }
}
