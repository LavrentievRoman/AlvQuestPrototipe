using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    // Ёкземпл€р класса
    public static GameObjectManager Instance { get; private set; } = null;

    // —ловарь часто используемых объектов
    public Dictionary<string, GameObject> Objects { get; private set; } = new();

    void Awake()
    {
        // ≈сли скрипт ещЄ не используетс€, используем этот экземпл€р
        if (Instance == null)
        {
            Instance = this;
        }
        // ≈сли скрипт уже существует, удал€ем этот жкземпл€р
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }
}
