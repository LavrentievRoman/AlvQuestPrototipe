using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    // ��������� ������
    public static GameObjectManager Instance { get; private set; } = null;

    // ������� ����� ������������ ��������
    public Dictionary<string, GameObject> Objects { get; private set; } = new();

    void Awake()
    {
        // ���� ������ ��� �� ������������, ���������� ���� ���������
        if (Instance == null)
        {
            Instance = this;
        }
        // ���� ������ ��� ����������, ������� ���� ���������
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }
}
