
public interface IPlayerSetup
{
    // Перенесение информации с панели в данные персонажа
    public void SaveInformation(CharacterDTO character);

    // Приведение панели к параметрам по умолчанию
    public void SetDefaults();
}
