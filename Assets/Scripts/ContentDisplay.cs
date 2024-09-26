using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentDisplay : MonoBehaviour
{

    public GameObject contentWindow;
    public TMP_Text title;
    public TMP_Text description;
    public GameObject ScrollArea;
    public GameObject ContactScrollArea;
    public GameObject MyMessagePrefab;
    public GameObject OtherMessagePrefab;
    public GameObject ContactLink;
    public GameObject ZoomImageObject;
    public Image ZoomImagePlaceholder;

    public static ContentDisplay instance;

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

    public void DisplayContent(Task task)
    {
        foreach (Transform child in ScrollArea.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in ContactScrollArea.transform)
        {
            Destroy(child.gameObject);
        }


        title.text = task.title;
        description.text = task.description;

        List<Contact> contactList = LevelManager.instance.contactInLevelList;

        foreach (MessageItem item in task.messages)
        {
            GameObject instanceMyMessage = null;
            GameObject instanceContact = null;
            if (item.contactName == ContactName.Me)
            {
                instanceMyMessage = Instantiate(MyMessagePrefab, ScrollArea.transform);
            }
            else
            {
                instanceMyMessage = Instantiate(OtherMessagePrefab, ScrollArea.transform);
                instanceContact = Instantiate(ContactLink, ContactScrollArea.transform);
                instanceContact.GetComponentInChildren<TMP_Text>().text = item.contactName.ToString();

                Contact contactMatch = contactList.Find(x => x.contactName == item.contactName);
                instanceContact.GetComponentInChildren<TMP_Text>().color = contactMatch.color;
            }

            instanceMyMessage.GetComponent<MessageDisplay>()
            .Display(item.contactName, item.messages, item.Image, item.audioClip);
            LayoutRebuilder.ForceRebuildLayoutImmediate(ScrollArea.GetComponent<RectTransform>());
            LayoutRebuilder.ForceRebuildLayoutImmediate(ContactScrollArea.GetComponent<RectTransform>());

        }

        StartCoroutine(UpdateLayout());

        contentWindow.SetActive(true);
    }

    IEnumerator UpdateLayout()
    {
        yield return new WaitForSeconds(0.1f);
        LayoutRebuilder.ForceRebuildLayoutImmediate(ScrollArea.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(ContactScrollArea.GetComponent<RectTransform>());
    }

    public void ZoomImage(Sprite sprite)
    {
        ZoomImagePlaceholder.sprite = sprite;
        ZoomImageObject.SetActive(true);
    }
}
