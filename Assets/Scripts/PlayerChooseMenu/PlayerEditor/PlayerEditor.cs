using UnityEngine;

public class PlayerEditor : MonoBehaviour
{
    public CharacterDTO CustomPlayer { get; set; }

    public void Start()
    {
        CustomPlayer = new CharacterDTO();
    }

    // Закрытее редактора персонажа
    public void CloseEditor()
    {
        // Устанавливаем значения редактора персонажа на значения по умолчанию
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
            SetPanelDefault<IPlayerSetup>(gameObject.transform.GetChild(i).gameObject);
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        // Показываем первую панель
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        // Создаём "пустого" персонажа
        CustomPlayer = new CharacterDTO();

        // Скрываем редактор персонажа
        gameObject.SetActive(false);
    }

    // Сохранение созданного пероснажа
    public void SavePlayer()
    {
        // Добавляем созданного персонажа в список доступных
        GameObjectManager.Instance.Objects["CharacterList"].GetComponent<CharacterDataBase>().AddNewCharacter(CustomPlayer);

        // Закрываем редактор
        CloseEditor();
    }

    // Сохранение информации с панели
    public void SaveInformation()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            SavePanelInformation<IPlayerSetup>(gameObject.transform.GetChild(i).gameObject);
        }
    }

    // Сброс информации с панели 
    public void SetDefault()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            SetPanelDefault<IPlayerSetup>(gameObject.transform.GetChild(i).gameObject);
        }
    }

    // Вызов необходимого метода сохранения информации
    private void SavePanelInformation<T>(GameObject panel) where T : IPlayerSetup
    {
        if (panel.activeInHierarchy)
        {
            panel.GetComponentInChildren<T>()?.SaveInformation(CustomPlayer);
        }
    }

    // Вызов необходимого метола сброса параметров панели
    private void SetPanelDefault<T>(GameObject panel) where T : IPlayerSetup
    {
        if (panel.activeInHierarchy)
        {
            panel.GetComponentInChildren<T>()?.SetDefaults();
        }
    }
}
