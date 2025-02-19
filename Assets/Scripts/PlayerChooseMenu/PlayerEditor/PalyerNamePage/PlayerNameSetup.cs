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

    // Установка значений по умолчанию
    public void SetDefaults()
    {
        playerNameInputField.GetComponent<TMP_InputField>().text = defaultPlayerName;
        playerLvlInputField.GetComponent<TMP_InputField>().text = defaultPlayerLvl.ToString();
    }

    // Сохранение параметров
    public void SaveInformation(CharacterDTO character)
    {
        // Сохраняем лвл персонажа
        character.Level = int.Parse(playerLvlInputField.GetComponent<TMP_InputField>().text);
        // Если лвл 0 или меньше приводим его к значению по умолчанию
        if (character.Level <= 0)
        {
            character.Level = defaultPlayerLvl;
            playerLvlInputField.GetComponent<TMP_InputField>().text = defaultPlayerLvl.ToString();
        }

        character.CharPoints = character.Level * 4;

        // Сохраняем имя пероснажа
        character.BaseData.Name = playerNameInputField.GetComponent<TMP_InputField>().text;    
    }
}
