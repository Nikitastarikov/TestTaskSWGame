using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ContinueButton : AbstractButton
{
    [SerializeField]
    private GameObject PausePanel;

    public override void OnClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        PauseController.pause_bool = false;
    }
}
