using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    public GameObject contact;
    public TMP_Text textMessage;
    public Image image;
    public AudioSource vocal;

    public void Display(ContactName _contact, string _textMessage, Sprite _image, AudioClip _vocal)
    {
        if (_contact != ContactName.Me)
        {
            contact.GetComponent<TMP_Text>().text = _contact.ToString();
            contact.GetComponent<TMP_Text>().color = LevelManager.instance.contactInLevelList.Find(x => x.contactName == _contact).color;

        }
        textMessage.text = _textMessage;
        image.sprite = _image;
        vocal.clip = _vocal;
    }

    public void ZoomMessageImage()
    {
        ContentDisplay.instance.ZoomImage(image.sprite);
    }
}
