using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : AbstractButton
{
    public override void OnClicked()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }
}
