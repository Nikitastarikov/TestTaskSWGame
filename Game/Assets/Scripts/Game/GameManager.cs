using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _mobsNumber = 2;
    [SerializeField] private Transform Map;
    private SpawnerEnamy _factory;
    private float x;
    private float z;
    private List<GameObject> _listMobs;

    public List<GameObject> getListMobs { get { return _listMobs; } set { } }

    void Start()
    {
        
        x = Map.position.x;
        z = Map.position.z;
        _listMobs = new List<GameObject>(0);
        _factory = GetComponent<SpawnerEnamy>();
        if (_factory != null)
        {
            MobsSpawner();
        }
        else
        {
            Debug.LogError("_spawner == null");
        }
        
    }

    public void MobsSpawner()
    {
        for (int i = 0; i < _mobsNumber; i++)
        {
            _listMobs.Add(_factory.FactoryMethod(new Vector3(Random.Range(x - 5, x + 5), 0.5f, Random.Range(z - 4, z + 4))));
        }
    }
}
