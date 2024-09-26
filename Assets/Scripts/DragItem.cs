using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
   public Image image;
   private bool isDragging;
   private Vector2 startPointerPosition;
   private Vector2 startObjectPosition;
   private const float dragThreshold = 10.0f; // Adjust this value as needed

   [HideInInspector] public Transform parentAfterDrag;
   public void OnPointerDown(PointerEventData eventData)
   {
      startPointerPosition = eventData.position;
      startObjectPosition = transform.position;
      isDragging = false;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      if (!isDragging)
      {
         HandleClick(eventData);
      }
      else
      {
         HandleDrop(eventData);
      }
      isDragging = false;
   }

   public void OnDrag(PointerEventData eventData)
   {
      if (!isDragging)
      {
         if (Vector2.Distance(eventData.position, startPointerPosition) > dragThreshold)
         {
            isDragging = true;
            HandleBeginDrag(eventData);
         }
      }
      else
      {
         HandleDragging(eventData);
      }
   }

   private void HandleClick(PointerEventData eventData)
   {
      Debug.Log("Click detected");
      ContentDisplay.instance.DisplayContent(GetComponent<TaskController>().task);
      // Add your click logic here
   }

   private void HandleBeginDrag(PointerEventData eventData)
   {
      Debug.Log("Drag started");
      parentAfterDrag = transform.parent;
      transform.SetParent(transform.root);
      transform.SetAsLastSibling();
      image.raycastTarget = false;
      // Add your drag start logic here
   }

   private void HandleDragging(PointerEventData eventData)
   {
      Vector2 currentPointerPosition = eventData.position;
      Vector2 offset = currentPointerPosition - startPointerPosition;
      transform.position = startObjectPosition + offset;
      Debug.Log("Dragging");
      Debug.Log("My Parent is " + parentAfterDrag.name);
      // Add your dragging logic here
   }

   private void HandleDrop(PointerEventData eventData)
   {
      Debug.Log("Drag ended");

      image.raycastTarget = true;
      transform.SetParent(parentAfterDrag);
      // Add your drop logic here
   }
}
