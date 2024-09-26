using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static Week;

[CustomEditor(typeof(Week))]
public class WeekEditor : Editor
{/*
    private GUIStyle titleStyle;

    private string[] days = new string[31];
    private void OnEnable()
    {
        for (int i = 0; i < 31; i++)
        {
            days[i] = (i + 1).ToString();
        }

       titleStyle = new GUIStyle(EditorStyles.label)
        {
            fontStyle = FontStyle.Bold,
            fontSize = 14,
            margin = new RectOffset(0, 0, 10, 10) // Ajuste les marges si nécessaire
        };
    }

    public override void OnInspectorGUI()
    {
        // Obtenez une référence à l'objet cible
        Week weekData = (Week)target;

        int selectedIndex = Mathf.Clamp(weekData.day - 1, 0, 30);

//        EditorGUILayout.LabelField("Date", titleStyle);
        // Démarrez une ligne horizontale
        EditorGUILayout.BeginHorizontal();

        GUILayoutOption[] options = { GUILayout.MaxWidth(50) };
        GUIStyle style = new GUIStyle(GUI.skin.textField);
        //style.margin = new RectOffset(2, 2, 2, 2);
        // Affichez chaque int en ligne

        selectedIndex = EditorGUILayout.Popup(selectedIndex, days, style, options);
        weekData.day = selectedIndex + 1;
        GUILayout.Space(2);

        weekData.month = (Months)EditorGUILayout.EnumPopup(weekData.month, GUILayout.MaxWidth(100));
        GUILayout.Space(2);

        weekData.year = EditorGUILayout.IntField(weekData.year, style, options);

        // Terminez la ligne horizontale
        EditorGUILayout.EndHorizontal();

        // Assurez-vous que les changements sont enregistrés
        if (GUI.changed)
        {
            EditorUtility.SetDirty(weekData);
        }
    }*/
}
