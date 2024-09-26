using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Week", menuName = "ScriptableObject/Week", order = 2)]

[Serializable]
public class Week : ScriptableObject
{
    public enum Months
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    /*
        public int day;
        public Months month;
        [Range(1,1000)]
        public int year;*/
    public string Date;

    [Header("Fix Task")]
    [Space]

    public WeekDays Monday;
    public WeekDays Tuesday;
    public WeekDays Wednesday;
    public WeekDays Thursday;
    public WeekDays Friday;
    public WeekDays Saturday;
    public WeekDays Sunday;

    [Space]
    public List<Task> TasksToPlace = new List<Task>();

    public Week Clone()
    {
        return new Week
        {
            Date = this.Date,
            Monday = this.Monday,
            Tuesday = this.Tuesday,
            Wednesday = this.Wednesday,
            Thursday = this.Thursday,
            Friday = this.Friday,
            Saturday = this.Saturday,
            Sunday = this.Sunday,
            TasksToPlace = this.TasksToPlace

        };
    }
}
[Serializable]

public class WeekDays
{
    public Task Morning;
    public Task Afternoon;
    public Task Evening;
}