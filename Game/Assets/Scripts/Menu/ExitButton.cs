using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitButton : AbstractButton
{
    public override void OnClicked()
    {
        Application.Quit();
    }
}
