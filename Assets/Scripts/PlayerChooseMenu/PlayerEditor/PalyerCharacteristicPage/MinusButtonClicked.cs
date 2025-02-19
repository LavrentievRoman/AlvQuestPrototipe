using UnityEngine.UI;
using UnityEngine;

public class MinusButtonClicked : MonoBehaviour
{
    private GameObject characteristic;

    private PlayerCharacteristicSetup characteristicSetup;

    public void Start()
    {
        characteristic = transform.parent.Find("CharacteristicValue").gameObject;
        characteristicSetup = GetComponentInParent<PlayerCharacteristicSetup>();

        // Добавляем событее при нажатии на кнопку
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { ReduceCharacteristicValue(); });
    }

    public void Update()
    {
        // Изменяем интерактивность кнопки, если значение навыка достигло минимального предела
        if (int.Parse(characteristic.GetComponentInChildren<Text>().text) == 1)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }      
    }

    // Изменение значения навыка
    public void ReduceCharacteristicValue()
    {
        // Уменьшаем значение навыка на 1
        characteristic.GetComponentInChildren<Text>().text = (int.Parse(characteristic.GetComponentInChildren<Text>().text) - 1).ToString();

        // Прибавляем 1 к оставшимся очкам
        characteristicSetup.AvailableCP++;
    }
}
