using TMPro;
using UnityEngine;

public class PlayerNameSetup : MonoBehaviour, IPlayerSetup
{    
    [SerializeField] private string defaultPlayerName;
    [SerializeField] private int defaultPlayerLvl;

    [SerializeField] private GameObject playerNameInputField;
    [SerializeField] private GameObject playerLvlInputField;

    public void Start()
    {
        SetDefaults();
    }

    // ��������� �������� �� ���������
    public void SetDefaults()
    {
        playerNameInputField.GetComponent<TMP_InputField>().text = defaultPlayerName;
        playerLvlInputField.GetComponent<TMP_InputField>().text = defaultPlayerLvl.ToString();
    }

    // ���������� ����������
    public void SaveInformation(CharacterDTO character)
    {
        // ��������� ��� ���������
        character.Level = int.Parse(playerLvlInputField.GetComponent<TMP_InputField>().text);
        // ���� ��� 0 ��� ������ �������� ��� � �������� �� ���������
        if (character.Level <= 0)
        {
            character.Level = defaultPlayerLvl;
            playerLvlInputField.GetComponent<TMP_InputField>().text = defaultPlayerLvl.ToString();
        }

        character.CharPoints = character.Level * 4;

        // ��������� ��� ���������
        character.BaseData.Name = playerNameInputField.GetComponent<TMP_InputField>().text;    
    }
}
