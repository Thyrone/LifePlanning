using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalendarSlot : MonoBehaviour, IDropHandler
{
    public enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
    public enum MomentOfDay { Morning, Afternoon, Evening }
    public Task task;

    public WeekDays day;
    public MomentOfDay moment;
    GameObject currentObject = null;


    private void Start()
    {
        Debug.Log((int)WeekDays.Friday);
        if (transform.childCount > 0)
        {
            currentObject = transform.GetChild(0).gameObject;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop on " + gameObject.name);

        // Vérifiez si un objet a été glissé
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            // Récupère le script DragItem depuis l'objet glissé
            DragItem draggableItem = dropped.GetComponent<DragItem>();


            if (draggableItem != null)
            {
                /*if (transform.childCount > 0)
                {
                    currentObject.GetComponent<DragItem>().parentAfterDrag = transform;
                    currentObject.transform.SetParent(draggableItem.GetComponent<DragItem>().parentAfterDrag);
                }*/

                if (transform.childCount == 0)
                {
                    // currentObject = draggableItem.gameObject;
                    // StartCoroutine(AnimationInOut(draggableItem, 0.25f));
                    LeanTween.scale(draggableItem.gameObject, new Vector2(1f, 1f), 0).setEase(LeanTweenType.easeInQuad);
                    draggableItem.parentAfterDrag = transform;
                    draggableItem.transform.SetParent(transform);
                    // Ajuste la position du RectTransform pour qu'il soit correctement aligné dans le slot
                    RectTransform rectDraggable = draggableItem.GetComponent<RectTransform>();
                    if (rectDraggable != null)
                    {
                        rectDraggable.anchoredPosition = Vector2.zero; // Assure l'alignement
                    }
                    task = draggableItem.gameObject.GetComponent<TaskController>().task;
                    UpdateLevelManager();
                    LeanTween.scale(draggableItem.gameObject, new Vector2(1f, 1f), 0.5f).setEase(LeanTweenType.easeInQuad);


                }
            }
            else
            {
                Debug.LogWarning("Le GameObject glissé n'a pas de composant DragItem.");
            }
        }
        else
        {
            Debug.LogWarning("Aucun objet n'a été glissé.");
        }

        /*

               Debug.Log("OnDrop on " + gameObject.name);
               GameObject dropped = eventData.pointerDrag;
               DragItem draggableItem = dropped.GetComponent<DragItem>();
               draggableItem.parentAfterDrag = transform;
               RectTransform rectDraggable = draggableItem.GetComponent<RectTransform>();
               rectDraggable.anchorMin = new Vector2(0, 0);
               rectDraggable.anchorMax = new Vector2(1, 1);
               rectDraggable.pivot = new Vector2(0.5f, 0.5f);



               rectDraggable.offsetMin = new Vector2(margin, margin);
               rectDraggable.offsetMax = new Vector2(-margin, -margin);          */             // Set dimensions 


    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            task = null;
        }
    }

    IEnumerator AnimationInOut(DragItem _draggableItem, float time)
    {
        //LeanTween.scale(_draggableItem.gameObject, new Vector2(0f, 0f), time).setEase(LeanTweenType.easeInQuad);
        yield return new WaitForSeconds(time);
    }

    void UpdateLevelManager()
    {
        switch (day)
        {
            case WeekDays.Monday:
                switch (moment)
                {
                    case MomentOfDay.Morning:
                        LevelManager.instance.curentWeek.Monday.Morning = task;
                        break;
                    case MomentOfDay.Afternoon:
                        LevelManager.instance.curentWeek.Monday.Afternoon = task;
                        break;

                    case MomentOfDay.Evening:
                        LevelManager.instance.curentWeek.Monday.Evening = task;
                        break;
                }
                break;

            case WeekDays.Tuesday:
                switch (moment)
                {
                    case MomentOfDay.Morning:
                        LevelManager.instance.curentWeek.Tuesday.Morning = task;
                        break;
                    case MomentOfDay.Afternoon:
                        LevelManager.instance.curentWeek.Tuesday.Afternoon = task;
                        break;

                    case MomentOfDay.Evening:
                        LevelManager.instance.curentWeek.Tuesday.Evening = task;
                        break;
                }
                break;

            case WeekDays.Wednesday:
                switch (moment)
                {
                    case MomentOfDay.Morning:
                        LevelManager.instance.curentWeek.Wednesday.Morning = task;
                        break;
                    case MomentOfDay.Afternoon:
                        LevelManager.instance.curentWeek.Wednesday.Afternoon = task;
                        break;

                    case MomentOfDay.Evening:
                        LevelManager.instance.curentWeek.Wednesday.Evening = task;
                        break;
                }
                break;

            case WeekDays.Thursday:
                switch (moment)
                {
                    case MomentOfDay.Morning:
                        LevelManager.instance.curentWeek.Thursday.Morning = task;
                        break;
                    case MomentOfDay.Afternoon:
                        LevelManager.instance.curentWeek.Thursday.Afternoon = task;
                        break;

                    case MomentOfDay.Evening:
                        LevelManager.instance.curentWeek.Thursday.Evening = task;
                        break;
                }
                break;

            case WeekDays.Friday:
                switch (moment)
                {
                    case MomentOfDay.Morning:
                        LevelManager.instance.curentWeek.Friday.Morning = task;
                        break;
                    case MomentOfDay.Afternoon:
                        LevelManager.instance.curentWeek.Friday.Afternoon = task;
                        break;

                    case MomentOfDay.Evening:
                        LevelManager.instance.curentWeek.Friday.Evening = task;
                        break;
                }
                break;

            case WeekDays.Saturday:
                switch (moment)
                {
                    case MomentOfDay.Morning:
                        LevelManager.instance.curentWeek.Saturday.Morning = task;
                        break;
                    case MomentOfDay.Afternoon:
                        LevelManager.instance.curentWeek.Saturday.Afternoon = task;
                        break;

                    case MomentOfDay.Evening:
                        LevelManager.instance.curentWeek.Saturday.Evening = task;
                        break;
                }
                break;

            case WeekDays.Sunday:
                switch (moment)
                {
                    case MomentOfDay.Morning:
                        LevelManager.instance.curentWeek.Sunday.Morning = task;
                        break;
                    case MomentOfDay.Afternoon:
                        LevelManager.instance.curentWeek.Sunday.Afternoon = task;
                        break;

                    case MomentOfDay.Evening:
                        LevelManager.instance.curentWeek.Sunday.Evening = task;
                        break;
                }
                break;
        }
    }
}
