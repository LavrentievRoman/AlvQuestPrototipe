using UnityEngine;

public class GameObjectAutoAdd : MonoBehaviour
{
    void Awake()
    {
        // ��������� ���� GameObject � ������� ����� ������������ �������� ��� ��������
        GameObjectManager.Instance.Objects.Add(gameObject.name, gameObject);
    }

    void OnDestroy()
    {
        // ������� ���� GameObject �� ������� ����� ������������ �������� ��� ��� �����������
        GameObjectManager.Instance.Objects.Remove(gameObject.name);
    }
}
