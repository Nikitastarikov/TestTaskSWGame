using UnityEngine;

public class SpawnerEnamy : AbstractSpawner
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Transform _target;
    public override GameObject FactoryMethod(Vector3 position)
    {
        //Debug.Log("spawn: " + position.x + " " + position.y + " " + position.z);
        GameObject ob = Instantiate(_prefab, position, Quaternion.identity);
        //ob.GetComponent<WanderingAI>().Started();
        ob.GetComponent<WanderingAI>().Target = _target;
        return ob;
    }
}
