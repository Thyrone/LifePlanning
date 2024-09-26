using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Content", menuName = "ScriptableObject/ContentTask", order = 0)]
public class ContentTask : ScriptableObject
{

    [CustomEditor(typeof(ContentTask))]
    public class ContentTaskInspector : Editor
    {
        SerializedProperty m_type;
        SerializedProperty m_data;

        private void OnEnable()
        {
            m_type = serializedObject.FindProperty("type");
            m_data = serializedObject.FindProperty("data");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_type);

            if (EditorGUI.EndChangeCheck())
            {

                m_data.managedReferenceValue =
                        ContentTask.CreateBlankData((ItemType)m_type.intValue);
            }


            // avoid drawing type a second time
            // avoid drawing annoying Script field
            DrawPropertiesExcluding(serializedObject, new string[] { "type", "m_Script" });
            serializedObject.ApplyModifiedProperties();
        }
    }

    [System.Serializable]
    public enum ItemType
    {
        Audio,
        Image,
        Messages
    }

    // Determines how to create an Item from each ItemType
    public static Item CreateBlankData(ItemType type)
    {
        switch (type)
        {
            default:
            case ItemType.Audio:
                return new AudioItem();

            case ItemType.Image:
                return new ImageItem();

            case ItemType.Messages:
                return new MessagesItem();
        }
    }

    [System.Serializable]
    public class Item
    {

    }

    [System.Serializable]
    public class ImageItem : Item
    {
        [SerializeField] ContactName contactName;
        [SerializeField] AudioClip audioClip;

    }

    [System.Serializable]
    public class AudioItem : Item
    {
        [SerializeField] ContactName contactName;
        [SerializeField] AudioClip audioClip;

    }

    [System.Serializable]
    public class MessageItem : Item
    {
        [SerializeField] ContactName contactName;
        [SerializeField] string messages;

    }

    [System.Serializable]
    public class MessagesItem : Item
    {
        [SerializeField] List<MessageItem> messages = new List<MessageItem>();

    }

    public ItemType type;
    [SerializeReference] public Item data;
}
