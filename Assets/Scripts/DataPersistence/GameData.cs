using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[SerializeField]
public class GameData
{
    public static WeekFlow weekFlow;
    public List<Contact> contacts = new List<Contact>();
    public Week currentWeek;
    public List<Week> passedWeek = new List<Week>();
    public GameData(List<Contact> _contacts, Week _currentWeek, List<Week> _passedWeek)
    {
        contacts = _contacts;
        currentWeek = _currentWeek;
        passedWeek = _passedWeek;
    }

    public GameData(WeekFlow _weekFlow)
    {
        //contacts = _contacts;
        currentWeek = _weekFlow.weeksOrder[0];
        //passedWeek = _passedWeek;
    }
}
