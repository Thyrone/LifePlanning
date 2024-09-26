using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[System.Serializable]
public enum ContactName
{
    Me,
    Julie,
    Cam
}

[CreateAssetMenu(fileName = "Contact", menuName = "ScriptableObject/Contact", order = 3)]
public class Contact : ScriptableObject
{
    public ContactName contactName;
    public Sprite profilImage;
    public Color color;

    private List<ContentTask> pinMessages = new List<ContentTask>();
}
