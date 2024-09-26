using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainSlot : MonoBehaviour, IDropHandler
{
    // public List<Task> tasks = new List<Task>();
    public void OnDrop(PointerEventData eventData)
    {
        // Vérifiez si un objet a été glissé
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            // Récupère le script DragItem depuis l'objet glissé
            DragItem draggableItem = dropped.GetComponent<DragItem>();
            if (draggableItem != null)
            {
                // Change la parenté de l'objet glissé pour le rendre enfant du CalendarSlot
                draggableItem.parentAfterDrag = transform;
                draggableItem.transform.SetParent(transform);

                // Ajuste la position du RectTransform pour qu'il soit correctement aligné dans le slot
                RectTransform rectDraggable = draggableItem.GetComponent<RectTransform>();
                if (rectDraggable != null)
                {
                    rectDraggable.anchoredPosition = Vector2.zero; // Assure l'alignement
                }
                // tasks.Add(draggableItem.gameObject.GetComponent<TaskController>().task);
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
    }
}
