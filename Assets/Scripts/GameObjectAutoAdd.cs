using UnityEngine;

public class GameObjectAutoAdd : MonoBehaviour
{
    void Awake()
    {
        // Добавляем этот GameObject в словарь часто используемых объектов при создании
        GameObjectManager.Instance.Objects.Add(gameObject.name, gameObject);
    }

    void OnDestroy()
    {
        // Удаляет этот GameObject из словаря часто используемых объектов при его уничтожении
        GameObjectManager.Instance.Objects.Remove(gameObject.name);
    }
}
