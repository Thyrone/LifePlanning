using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeekFlow", menuName = "ScriptableObject/WeekFlow", order = 50)]

public class WeekFlow : ScriptableObject
{
    public List<Week> weeksOrder = new List<Week>();
}
