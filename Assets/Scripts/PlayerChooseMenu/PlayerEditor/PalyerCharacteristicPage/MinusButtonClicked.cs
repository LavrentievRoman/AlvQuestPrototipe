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

        // ��������� ������� ��� ������� �� ������
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { ReduceCharacteristicValue(); });
    }

    public void Update()
    {
        // �������� ��������������� ������, ���� �������� ������ �������� ������������ �������
        if (int.Parse(characteristic.GetComponentInChildren<Text>().text) == 1)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }      
    }

    // ��������� �������� ������
    public void ReduceCharacteristicValue()
    {
        // ��������� �������� ������ �� 1
        characteristic.GetComponentInChildren<Text>().text = (int.Parse(characteristic.GetComponentInChildren<Text>().text) - 1).ToString();

        // ���������� 1 � ���������� �����
        characteristicSetup.AvailableCP++;
    }
}
