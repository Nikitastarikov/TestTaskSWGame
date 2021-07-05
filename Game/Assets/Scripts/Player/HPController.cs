using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public float _hp = 100f;
    public Slider _mySlider;
    public Image myImage;

    void Update()
    {
        _mySlider.value = _hp;
        if (_hp <= 0)
        {
            myImage.enabled = false;
        }
        else
        {
            myImage.enabled = true;
        }
    }
}
