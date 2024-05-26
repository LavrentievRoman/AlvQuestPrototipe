using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arena : MonoBehaviour
{

    [SerializeField] private GameObject namePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdatePlayerCard()
    {
        if (CharacterDataBase.Instance.SelectedCharacter is CharacterDTO character)
        {
            namePanel.GetComponent<Text>().text = character.BaseData.Name;
        }
        
    }

}
