[System.Serializable]
public class GameData
{
    public bool[] selectedAirplanes = new bool[3];
    public bool[] purchasedAirplanes = new bool[3];

    public bool[] purchasedUpgrades = new bool[3];
    
    public int coin;

    public GameData()
    {
        coin = 0;

        selectedAirplanes[0] = true;
        selectedAirplanes[1] = false;
        selectedAirplanes[2] = false;

        purchasedAirplanes[0] = true;
        purchasedAirplanes[1] = false;
        purchasedAirplanes[2] = false;

        purchasedUpgrades[0] = false;
        purchasedUpgrades[1] = false;
        purchasedUpgrades[2] = false;
    }
}
