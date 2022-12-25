using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (SaveManager.LoadPlayer() == null)
        {
            Player player = new Player();
            player._highScore = 0;
            player._currentTank = ETank.Red;
            player._boughtTanks.Add(_currentTank);
            player._collectedGoldCount = 0;

            SaveManager.SavePlayer(player);
        }

        LoadSave();
    }
    #endregion

    [Header("Tank")]
    [SerializeField] private Tank _tank = null;
    public Tank Tank => _tank;

    [Header("Controllers")]
    [SerializeField] private PowerUpController _powerUpController = null;
    public PowerUpController PowerUpController => _powerUpController;

    [Header("Save Variables")]
    private int _highScore = 0;
    public int HighScore
    {
        get { return _highScore; }
        set { _highScore = value; }
    }

    private ETank _currentTank = 0;
    public ETank CurrentTank
    {
        get { return _currentTank; }
        set { _currentTank = value; }
    }

    private List<ETank> _boughtTanks = new List<ETank>();
    public List<ETank> BoughtTanks
    {
        get { return _boughtTanks; }
        set { _boughtTanks = value; }
    }

    private int _collectedGoldCount = 0;
    public int CollectedGoldCount
    {
        get { return _collectedGoldCount; }
        set { _collectedGoldCount = value; }
    }

    private void OnDestroy()
    {
        SaveGame();
    }

    private void LoadSave()
    {
        PlayerData data = SaveManager.LoadPlayer();

        _highScore = data._highScore;
        _currentTank = data._currentTank;
        _boughtTanks = data._boughtTanks;
        _collectedGoldCount = data._collectedGoldCount;
    }

    public void SaveGame()
    {
        SaveManager.SavePlayer(this);
    }
}