using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IPointerClickHandler
{
	public UnityEvent clickAction;

	public void OnPointerClick(PointerEventData eventData)
	{
		clickAction.Invoke();
	}
}
