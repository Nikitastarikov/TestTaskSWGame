using UnityEngine;

[CreateAssetMenu(fileName = "BoxData", menuName = "BoxData/Ak47Data", order = 1)]
public class Ak47Data : ScriptableObject
{

    [SerializeField] private int _storeVolume = 30;
    [SerializeField] private int _totalCartridges = 300;
    public int TotalCartridges => _totalCartridges;
    public int StoreVolume => _storeVolume;
}