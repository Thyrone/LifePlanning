using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;


public class LevelManager : MonoBehaviour, IDataPersistence
{
    public static LevelManager instance;
    public Week startWeek; //only for debuging
    public List<Contact> contactInLevelList = new List<Contact>();
    public Transform TasksHolder;
    public TMP_Text DateHolder;
    public GameObject TaskPrefab;

    [HideInInspector]
    public Week curentWeek;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        LoadWeek(startWeek);
    }

    public void LoadWeek(Week weekToLoad)
    {
        DateHolder.text = weekToLoad.Date;

        foreach (Task task in weekToLoad.TasksToPlace)
        {
            //Debug.Log("hey");
            if (task.ActivationCondition())
            {
                GameObject taskInstantiate = Instantiate(TaskPrefab, TasksHolder);
                //taskInstantiate.transform.parent=TasksHolder;
                taskInstantiate.GetComponent<TaskController>().InintTask(task);
            }
        }

        curentWeek = (Week)weekToLoad.Clone();
    }
    public void ValidateWeek()
    {
        CalendarSlot[] calendarsSlots = FindObjectsOfType<CalendarSlot>();
    }

    public void LoadData(GameData data)
    {
        LoadWeek(data.currentWeek);
    }

    public void SaveData(ref GameData data)
    {
        data.currentWeek = curentWeek;
    }
}
