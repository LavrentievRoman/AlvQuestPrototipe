using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacteristicSetup : MonoBehaviour
{
    public int defaultStrengthValue = 5;
    public int defaultDexterityValue = 5;
    public int defaultEnduranceValue = 5;
    public int defaultFireMasteryValue = 5;
    public int defaultEarthMasteryValue = 5;
    public int defaultAirMasteryValue = 5;
    public int defaultWaterMasteryValue = 5;

    public GameObject cpValue;
    public GameObject strengthValue;
    public GameObject dexterityValue;
    public GameObject enduranceValue;
    public GameObject fireMasteryValue;
    public GameObject earthMasteryValue;
    public GameObject airMasteryValue;
    public GameObject waterMasteryValue;

    private int availableCP;

    private Dictionary<ECharacteristic, int> characteristics;

    /*private int strength;
    private int dexterity;
    private int endurance;
    private int fireMastery;
    private int earthMastery;
    private int airMastery;
    private int waterMastery;*/

    // Start is called before the first frame update
    public void Start()
    {
        characteristics = new Dictionary<ECharacteristic, int>();

        characteristics.Add(ECharacteristic.Strength, defaultStrengthValue);
        characteristics.Add(ECharacteristic.Dexterity, defaultDexterityValue);
        characteristics.Add(ECharacteristic.Endurance, defaultEnduranceValue);
        characteristics.Add(ECharacteristic.Fire, defaultFireMasteryValue);
        characteristics.Add(ECharacteristic.Water, defaultEarthMasteryValue);
        characteristics.Add(ECharacteristic.Air, defaultAirMasteryValue);
        characteristics.Add(ECharacteristic.Earth, defaultWaterMasteryValue);

        /*strength = defaultStrengthValue;
        dexterity = defaultDexterityValue;
        endurance = defaultEnduranceValue;
        fireMastery = defaultAirMasteryValue;
        earthMastery = defaultEarthMasteryValue;
        airMastery = defaultAirMasteryValue;
        waterMastery = defaultWaterMasteryValue;*/

        SetDefaults();
    }

    public void SetCharacteristicPointValue(int CP)
    {
        availableCP = CP;

        cpValue.GetComponentInChildren<Text>().text = availableCP.ToString();
    }

    public void IncreaseCharacteristicPoint()
    {
        availableCP++;

        UpdateInformation();
    }

    public void ReduceCharacteristicPoint()
    {
        availableCP--;

        UpdateInformation();
    }   

    public int GetCharacteristicPointValue()
    {
        return availableCP;
    }

    public void UpdateInformation()
    {
        cpValue.GetComponentInChildren<Text>().text = availableCP.ToString();

        characteristics[ECharacteristic.Strength] = int.Parse(strengthValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Dexterity] = int.Parse(dexterityValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Endurance] = int.Parse(enduranceValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Fire] = int.Parse(fireMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Water] = int.Parse(waterMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Air] = int.Parse(airMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Earth] = int.Parse(earthMasteryValue.GetComponentInChildren<Text>().text);

        /*strength = int.Parse(strengthValue.GetComponentInChildren<Text>().text);
        dexterity = int.Parse(dexterityValue.GetComponentInChildren<Text>().text);
        endurance = int.Parse(enduranceValue.GetComponentInChildren<Text>().text);
        fireMastery = int.Parse(fireMasteryValue.GetComponentInChildren<Text>().text);
        earthMastery = int.Parse(earthMasteryValue.GetComponentInChildren<Text>().text);
        airMastery = int.Parse(airMasteryValue.GetComponentInChildren<Text>().text);
        waterMastery = int.Parse(waterMasteryValue.GetComponentInChildren<Text>().text);*/
    }

    public void SaveInformation(CharacterDTO character)
    {
        /*var characteristics = new Dictionary<ECharacteristic, int>();
        characteristics.Add(ECharacteristic.Strength, strength);
        characteristics.Add(ECharacteristic.Dexterity, dexterity);
        characteristics.Add(ECharacteristic.Endurance, endurance);
        characteristics.Add(ECharacteristic.Fire, fireMastery);
        characteristics.Add(ECharacteristic.Water, earthMastery);
        characteristics.Add(ECharacteristic.Air, airMastery);
        characteristics.Add(ECharacteristic.Earth, waterMastery);*/

        character.Characteristics = characteristics;
        character.CharPoints = availableCP;
    }

    public void SetDefaults()
    {
        strengthValue.GetComponentInChildren<Text>().text = defaultStrengthValue.ToString();
        dexterityValue.GetComponentInChildren<Text>().text = defaultDexterityValue.ToString();
        enduranceValue.GetComponentInChildren<Text>().text = defaultEnduranceValue.ToString();
        fireMasteryValue.GetComponentInChildren<Text>().text = defaultFireMasteryValue.ToString();
        waterMasteryValue.GetComponentInChildren<Text>().text = defaultEarthMasteryValue.ToString();
        airMasteryValue.GetComponentInChildren<Text>().text = defaultAirMasteryValue.ToString();
        earthMasteryValue.GetComponentInChildren<Text>().text = defaultWaterMasteryValue.ToString();

        UpdateInformation();
    }
}
