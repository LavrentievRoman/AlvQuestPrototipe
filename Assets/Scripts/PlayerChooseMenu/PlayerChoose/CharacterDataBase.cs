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
        // Заполняем БД зарание созданными персонажами
        FillDataBase();

        // Выводим зарание созданых персонажей на экран
        AddGraphics();
    }

    // Заполнение базы данных существующими персонажами
    private void FillDataBase()
    {
        characterDataBase = new List<CharacterDTO>();
    }

    // Вывод БД персонажей на экран
    private void AddGraphics()
    {     
        // Добавляем каждого пероснажа в список
        for (int i = 0; i < characterDataBase.Count; i++)
        {
            AddCharacterToList(characterDataBase[i]);
        }
    }

    // Добавление персонажа в список
    private void AddCharacterToList(CharacterDTO _character)
    {
        // Создаём новый игровой объект
        characterGameObject = Instantiate(characterEntity, contentPanel.transform);

        // Присваиваем ему имя
        characterGameObject.name = (characterDataBase.Count + 1).ToString();

        // Передаём информацию о персонажа
        characterGameObject.GetComponent<CharacterData>().Character = _character;

        // Выравниваем в списке
        rt = characterGameObject.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0, 0, 0);
        rt.localScale = new Vector3(1, 1, 1);
        characterGameObject.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    // Добавление нового персонажа
    public void AddNewCharacter(CharacterDTO newCharacter)
    {
        // Добавляем персонажа в БД
        characterDataBase.Add(newCharacter);

        // Добавляем его в список
        AddCharacterToList(newCharacter);
    }
}
