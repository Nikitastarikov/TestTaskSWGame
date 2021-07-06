using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    public Slider _mySlider;
    public Image myImage;
    private float _currentHP;

    private void Start()
    {
        _currentHP = _playerData.HP;
    }

    public float HP { set { _currentHP = value; } get { return _currentHP; } }

    void Update()
    {
        _mySlider.value = _currentHP;
        if (_currentHP <= 0)
        {
            myImage.enabled = false;
        }
        else
        {
            myImage.enabled = true;
        }
    }
}
