using UnityEngine;
using UnityEngine.UI;

public class ShowMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    public void Start()
    {      
        Button button = gameObject.GetComponent<Button>();

        // ����������� ������� � ������
        button.onClick.AddListener(delegate { Show(); });
    }

    // ����� ����
    private void Show()
    {
        // ������ ���� ��������
        menu.SetActive(true);

        // �������� ������� ����
        transform.parent.gameObject.SetActive(false);
    }
}
