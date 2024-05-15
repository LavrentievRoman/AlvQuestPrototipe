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

    private int availableCP = 10;

    private int strength;
    private int dexterity;
    private int endurance;
    private int fireMastery;
    private int earthMastery;
    private int airMastery;
    private int waterMastery;

    // Start is called before the first frame update
    public void Start()
    {
        strength = defaultStrengthValue;
        dexterity = defaultDexterityValue;
        endurance = defaultEnduranceValue;
        fireMastery = defaultAirMasteryValue;
        earthMastery = defaultEarthMasteryValue;
        airMastery = defaultAirMasteryValue;
        waterMastery = defaultWaterMasteryValue;

        UpdateInformation();
    }

    public void IncreaseCharacteristicPoint()
    {
        availableCP++;
    }

    public void ReduceCharacteristicPoint()
    {
        availableCP--;
    }

    public int GetCharacteristicPointValue()
    {
        return availableCP;
    }

    public void UpdateInformation()
    {
        cpValue.GetComponentInChildren<Text>().text = availableCP.ToString();

        /*strengthValue.GetComponentInChildren<Text>().text = strength.ToString();
        dexterityValue.GetComponentInChildren<Text>().text = dexterity.ToString();
        enduranceValue.GetComponentInChildren<Text>().text = endurance.ToString();
        fireMasteryValue.GetComponentInChildren<Text>().text = fireMastery.ToString();
        earthMasteryValue.GetComponentInChildren<Text>().text = earthMastery.ToString();
        airMasteryValue.GetComponentInChildren<Text>().text = airMastery.ToString();
        waterMasteryValue.GetComponentInChildren<Text>().text = waterMastery.ToString();*/

        strength = int.Parse(strengthValue.GetComponentInChildren<Text>().text);
        dexterity = int.Parse(dexterityValue.GetComponentInChildren<Text>().text);
        endurance = int.Parse(enduranceValue.GetComponentInChildren<Text>().text);
        fireMastery = int.Parse(fireMasteryValue.GetComponentInChildren<Text>().text);
        earthMastery = int.Parse(earthMasteryValue.GetComponentInChildren<Text>().text);
        airMastery = int.Parse(airMasteryValue.GetComponentInChildren<Text>().text);
        waterMastery = int.Parse(waterMasteryValue.GetComponentInChildren<Text>().text);
    }
}
