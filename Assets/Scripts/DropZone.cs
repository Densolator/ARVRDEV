using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {


    [SerializeField] private Transform prefab;

	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("OnPointerEnter");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.placeholderParent = this.transform;
            
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	
	public void OnDrop(PointerEventData eventData) {
		Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        if(gameObject.name.Equals("Water Landscape"))
        {
            //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(eventData.pointerDrag);
        }
        if (gameObject.name.Equals("Land Landscape"))
        {
            //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(eventData.pointerDrag);
        }
        if (gameObject.name.Equals("Clouds Landscape"))
        {
            //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(eventData.pointerDrag);
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.parentToReturnTo = this.transform;
            
        }

	}
}
