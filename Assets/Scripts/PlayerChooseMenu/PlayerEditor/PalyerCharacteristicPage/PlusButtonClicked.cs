using UnityEngine;
using UnityEngine.UI;

public class PlusButtonClicked : MonoBehaviour
{
    private GameObject characteristic;

    private PlayerCharacteristicSetup characteristicSetup;

    public void Start()
    {
        characteristic = transform.parent.Find("CharacteristicValue").gameObject;
        characteristicSetup = GetComponentInParent<PlayerCharacteristicSetup>();

        // Добавляем событее при нажатии на кнопку
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { IncreaseCharacteristicValue(); });
    }

    public void Update()
    {
        // Изменяем интерактивность кнопки, если значение навыка или оставшихся очков достигли предела
        if (int.Parse(characteristic.GetComponentInChildren<Text>().text) == 99 || characteristicSetup.AvailableCP == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    // Изменение значения наввыка
    public void IncreaseCharacteristicValue()
    {
        // Прибавляем 1 к значению навыка
        characteristic.GetComponentInChildren<Text>().text = (int.Parse(characteristic.GetComponentInChildren<Text>().text) + 1).ToString();

        // Уменьшаем значение оставшихся очков на 1
        characteristicSetup.AvailableCP--;
    }
}
