using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine;

public class EscScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
            SceneManager.LoadSceneAsync("MenuScene");
        }
    }
}
