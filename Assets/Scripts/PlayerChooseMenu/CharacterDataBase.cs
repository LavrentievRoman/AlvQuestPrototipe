using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDataBase : MonoBehaviour
{
    public static CharacterDataBase Instance { get; private set; }

    public GameObject characterEntity;
    public GameObject contentPanel;

    private GameObject currentCharacter;

    public CharacterDTO SelectedCharacter { get; private set; }

    private List<CharacterDTO> characterDataBase;

    void Start()
    {     
        FillDataBase();

        AddGraphics();

        Instance = this;
    }

    public void SetCurrentCharacter(GameObject character)
    {
        if (currentCharacter != null)
        {
            currentCharacter.GetComponentInChildren<Outline>().enabled = false;
        }

        currentCharacter = character;
        currentCharacter.GetComponentInChildren<Outline>().enabled = true;

        SelectedCharacter = characterDataBase[int.Parse(currentCharacter.name) - 1];

        GameObject.Find("PlayerCard").GetComponent<ShowPlayerCard>().ShowCharacter(characterDataBase[int.Parse(currentCharacter.name)-1]);
    }

    public void AddNewCharacter(CharacterDTO newCharacter)
    {
        characterDataBase.Add(newCharacter);

        GameObject character = Instantiate(characterEntity, contentPanel.transform) as GameObject;

        character.name = (characterDataBase.Count).ToString();
        character.GetComponent<CharacterData>().SetCharacterData(newCharacter);

        RectTransform rt = character.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0, 0, 0);
        rt.localScale = new Vector3(1, 1, 1);
        character.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    private void AddGraphics()
    {
        for (int i = 0; i < characterDataBase.Count; i++)
        {
            GameObject character = Instantiate(characterEntity, contentPanel.transform) as GameObject;

            character.name = "Character" + (i + 1).ToString();
            character.GetComponent<CharacterData>().SetCharacterData(characterDataBase[i]);

            RectTransform rt = character.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            character.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void FillDataBase()
    {
        characterDataBase = new List<CharacterDTO>();
    }
}
