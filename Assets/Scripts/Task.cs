using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "ScriptableObject/Task", order = 1)]

[Serializable]
public class Task : ScriptableObject
{

    [Header("Content")]
    [Space]
    public new string title;
    public string description;
    public string location;

    public List<MessageItem> messages = new List<MessageItem>();

    [Space]
    [Header("Conditions To Apear")]
    [Space]

    public List<Task> madatoryTask = new List<Task>(); //Les taches d'avant obligatoires pour que la tache s'affiche
    public List<Task> cancelTask = new List<Task>(); //Les taches qui si elle ont était choisie annule l'apparition de la tache
    public List<ContactCondition> ContactsConditions = new List<ContactCondition>(); //Avoir tel niveau d'amitier pour que la tache s'affiche

    [Header("Output")]
    [Space]
    public List<ContactModifier> ContactsModifier = new List<ContactModifier>();

    public bool ActivationCondition()
    {
        if (madatoryTask.Count > 0)
        {

        }
        return true; // to fill
    }



}

[System.Serializable]
public class MessageItem
{
    [SerializeField] public ContactName contactName;

    [SerializeField][TextAreaAttribute] public string messages;
    [SerializeField] public Sprite Image;
    [SerializeField] public AudioClip audioClip;

}

[System.Serializable]
public class ContactCondition
{
    public enum ifString { MoreThan, LessThan }
    [SerializeField] public ContactName contactName;
    [SerializeField] public ifString condition;
    [SerializeField] public float values;

}

[System.Serializable]
public class ContactModifier
{
    public enum AddLess { Add, Less }
    [SerializeField] public ContactName contactName;
    [SerializeField] public AddLess modifier;
    [SerializeField] public float values;

}
