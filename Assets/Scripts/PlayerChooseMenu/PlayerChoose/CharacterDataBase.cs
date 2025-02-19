using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBase : MonoBehaviour
{
    [SerializeField]
    private GameObject characterEntity;

    [SerializeField]
    private GameObject contentPanel;

    private List<CharacterDTO> characterDataBase;

    private GameObject characterGameObject;
    private RectTransform rt;

    void Start()
    {     
        // ��������� �� ������� ���������� �����������
        FillDataBase();

        // ������� ������� �������� ���������� �� �����
        AddGraphics();
    }

    // ���������� ���� ������ ������������� �����������
    private void FillDataBase()
    {
        characterDataBase = new List<CharacterDTO>();
    }

    // ����� �� ���������� �� �����
    private void AddGraphics()
    {     
        // ��������� ������� ��������� � ������
        for (int i = 0; i < characterDataBase.Count; i++)
        {
            AddCharacterToList(characterDataBase[i]);
        }
    }

    // ���������� ��������� � ������
    private void AddCharacterToList(CharacterDTO _character)
    {
        // ������ ����� ������� ������
        characterGameObject = Instantiate(characterEntity, contentPanel.transform);

        // ����������� ��� ���
        characterGameObject.name = (characterDataBase.Count + 1).ToString();

        // ������� ���������� � ���������
        characterGameObject.GetComponent<CharacterData>().Character = _character;

        // ����������� � ������
        rt = characterGameObject.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0, 0, 0);
        rt.localScale = new Vector3(1, 1, 1);
        characterGameObject.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    // ���������� ������ ���������
    public void AddNewCharacter(CharacterDTO newCharacter)
    {
        // ��������� ��������� � ��
        characterDataBase.Add(newCharacter);

        // ��������� ��� � ������
        AddCharacterToList(newCharacter);
    }
}
