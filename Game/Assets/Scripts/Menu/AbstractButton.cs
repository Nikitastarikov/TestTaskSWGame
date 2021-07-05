using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractButton : MonoBehaviour
{
    protected Button ButtonMenu = default;

    private void Awake()
    {
        ButtonMenu = this.GetComponent<Button>();
        if (ButtonMenu == null) Debug.LogError("Button netu");
    }

    private void OnEnable()
    {
        ButtonMenu.onClick.AddListener(OnClicked);
    }

    public abstract void OnClicked();
}
