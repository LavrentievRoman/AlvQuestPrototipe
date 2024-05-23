using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBase : MonoBehaviour
{
    public GameObject characterEntity;
    public GameObject contentPanel;

    private List<CharacterDTO> characterDataBase;

    void Start()
    {
        characterDataBase = new List<CharacterDTO>();

        FillDataBase();

        AddGraphics();
    }

    public void AddNewCharacter(CharacterDTO newCharacter)
    {    
        characterDataBase.Add(newCharacter);

        GameObject character = Instantiate(characterEntity, contentPanel.transform) as GameObject;

        character.name = "Character" + (characterDataBase.Count + 1).ToString();
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

    }
}
