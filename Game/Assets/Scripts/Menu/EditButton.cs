using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EditButton : AbstractButton
{
    public override void OnClicked()
    {
        SceneManager.LoadSceneAsync("EditScene");
    }
}
