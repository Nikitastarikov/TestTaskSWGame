using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<HPController>().HP <= 0)
        {
            SceneManager.LoadSceneAsync("GameOverScene");
        }
    }
}
