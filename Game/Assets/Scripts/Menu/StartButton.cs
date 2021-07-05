using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : AbstractButton
{
    public override void OnClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        PauseController.pause_bool = false;
        SceneManager.LoadSceneAsync("GameScene");
    }
}
