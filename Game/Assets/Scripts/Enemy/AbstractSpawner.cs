using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpawner : MonoBehaviour
{
    /// <summary>
    /// Фабричный метод для запуска / генерации / инициализации врагов
    /// </summary>
    public abstract GameObject FactoryMethod(Vector3 position);
}
