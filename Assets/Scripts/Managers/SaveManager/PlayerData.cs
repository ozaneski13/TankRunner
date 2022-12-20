using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int _highScore;
    public ETank _currentTank;
    public List<ETank> _boughtTanks = new List<ETank>();
    public int _collectedGoldCount;

    public PlayerData(Player player)
    {
        _highScore = player.HighScore;
        _currentTank = player.CurrentTank;
        _boughtTanks = player.BoughtTanks;
        _collectedGoldCount = player.CollectedGoldCount;
    }
}