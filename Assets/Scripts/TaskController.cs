using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public Task task; //To Delate

    public TMP_Text title;
    public TMP_Text description;
    public GameObject notifs;

    public void InintTask(Task _task)
    {
        task = _task;
        title.text = task.title;
        //        description.text = task.description;
        if (task.messages.Count > 0)
        {
            notifs.SetActive(true);
            notifs.GetComponentInChildren<TMP_Text>().text = task.messages.Count.ToString();
        }
    }
}
