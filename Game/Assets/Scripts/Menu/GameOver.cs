using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<HPController>()._hp <= 0)
        {
            SceneManager.LoadSceneAsync("GameOverScene");
        }
    }
}
