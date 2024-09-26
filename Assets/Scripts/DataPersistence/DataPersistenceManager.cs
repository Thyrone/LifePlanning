using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance { get; private set; }

    public GameData gameData;
    public WeekFlow weekFlow;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("instance already exist");
        }
        instance = this;
    }

    private void Start()
    {
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData(weekFlow);
    }

    public void LoadGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults");
            NewGame();
        }
    }

    public void SaveGame()
    {

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
