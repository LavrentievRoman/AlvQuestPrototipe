using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    public void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        // ����������� ������� � ������
        button.onClick.AddListener(delegate { ShowMenu(); });
    }

    // ����� ����
    private void ShowMenu()
    {
        // ������ �������� ���� ��������
        mainMenu.SetActive(true);

        // �������� ������� ����
        transform.parent.gameObject.SetActive(false);
    }
}
