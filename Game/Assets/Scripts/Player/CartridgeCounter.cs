using UnityEngine.UI;
using UnityEngine;

public class CartridgeCounter : MonoBehaviour
{
    public int _сounterСartridges;
    [SerializeField] private GameObject _counterOb;

    public void Count(int _storeVolume, int _totalCartridges)
    {
        _сounterСartridges = _storeVolume;
        _counterOb.GetComponent<Text>().text = _сounterСartridges.ToString() + "/" + _totalCartridges.ToString();
    }    
}
