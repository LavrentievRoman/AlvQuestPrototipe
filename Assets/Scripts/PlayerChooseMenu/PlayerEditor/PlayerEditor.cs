using UnityEngine;

public class PlayerEditor : MonoBehaviour
{
    public CharacterDTO CustomPlayer { get; set; }

    public void Start()
    {
        CustomPlayer = new CharacterDTO();
    }

    // �������� ��������� ���������
    public void CloseEditor()
    {
        // ������������� �������� ��������� ��������� �� �������� �� ���������
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
            SetPanelDefault<IPlayerSetup>(gameObject.transform.GetChild(i).gameObject);
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        // ���������� ������ ������
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        // ������ "�������" ���������
        CustomPlayer = new CharacterDTO();

        // �������� �������� ���������
        gameObject.SetActive(false);
    }

    // ���������� ���������� ���������
    public void SavePlayer()
    {
        // ��������� ���������� ��������� � ������ ���������
        GameObjectManager.Instance.Objects["CharacterList"].GetComponent<CharacterDataBase>().AddNewCharacter(CustomPlayer);

        // ��������� ��������
        CloseEditor();
    }

    // ���������� ���������� � ������
    public void SaveInformation()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            SavePanelInformation<IPlayerSetup>(gameObject.transform.GetChild(i).gameObject);
        }
    }

    // ����� ���������� � ������ 
    public void SetDefault()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            SetPanelDefault<IPlayerSetup>(gameObject.transform.GetChild(i).gameObject);
        }
    }

    // ����� ������������ ������ ���������� ����������
    private void SavePanelInformation<T>(GameObject panel) where T : IPlayerSetup
    {
        if (panel.activeInHierarchy)
        {
            panel.GetComponentInChildren<T>()?.SaveInformation(CustomPlayer);
        }
    }

    // ����� ������������ ������ ������ ���������� ������
    private void SetPanelDefault<T>(GameObject panel) where T : IPlayerSetup
    {
        if (panel.activeInHierarchy)
        {
            panel.GetComponentInChildren<T>()?.SetDefaults();
        }
    }
}
