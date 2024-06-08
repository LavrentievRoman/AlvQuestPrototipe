using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using AlvQuestCore;

public class Arena : MonoBehaviour
{

    [SerializeField] private GameObject namePanel;
    [SerializeField] private GameObject characteristicPanel;
    public StoneBoard stoneBoard;
    // Start is called before the first frame update
    void Awake()
    {
        stoneBoard = new StoneBoard(this);
    }

    void Start()
    {
    }

    public void UpdatePlayerCard()
    {
        if (CharacterDataBase.Instance.SelectedCharacter is CharacterDTO character)
        {
            namePanel.GetComponent<Text>().text = character.BaseData.Name;

            GameObject strengthPanel = characteristicPanel.transform.Find("Strength").gameObject;
            strengthPanel.transform.Find("ParameterValue").gameObject.GetComponent<Text>().text = character.Characteristics[ECharacteristic.Strength].ToString();
        }
        
    }

}
