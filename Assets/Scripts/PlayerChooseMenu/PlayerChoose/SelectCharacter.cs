using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    private ShowPlayerCard playerCard;

    private GameObject _selectedCharacter;
    public GameObject SelectedCharacterCard 
    {
        get
        {
            return _selectedCharacter;
        }
        set
        {
            // Убираем выдиление с предыдущего выбранного персонажа
            if (_selectedCharacter != null)
            {
                _selectedCharacter.GetComponentInChildren<Outline>().enabled = false;
            }

            // Выделяем текущего выбранного персонажа
            _selectedCharacter = value;
            _selectedCharacter.GetComponentInChildren<Outline>().enabled = true;

            // Отображаем информацию о персонаже на карточке
            playerCard.ShowCharacter(_selectedCharacter.GetComponent<CharacterData>().Character);
        }
    }  

    private void Start()
    {
        playerCard = GameObjectManager.Instance.Objects["PlayerCard"].GetComponent<ShowPlayerCard>();
    }
}
