using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private Transform prefab;
    public IList<Status> units = new List<Status>();
    private int nUnits = 0;
    public int atkStat = 0;
    public int defStat = 0;
    //[SerializeField] private GameObject[] troops;
    //private int nTroops = 0;

    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.placeholderParent = this.transform;
        }
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
		if (eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	
	public void OnDrop(PointerEventData eventData) {
        string strCurPlayer = GameObject.Find("GameManager").GetComponent<GameManager>().GetCurPlayer().name; // returns either string "Player1" or "Player2"
        Card usedCard = eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().GetCardDetails(); // contains card's stats

        if (GameObject.Find(strCurPlayer).GetComponent<Player>().enoughActionPoints(usedCard.value)) // check if enough points to use card
        {
            if ((usedCard.landscape == 2 && gameObject.name.Equals("Water Landscape")) ||
                (usedCard.landscape == 1 && gameObject.name.Equals("Land Landscape")) ||
                (usedCard.landscape == 3 && gameObject.name.Equals("Cloud Landscape"))) {
                Debug.Log("Card Type " + usedCard.landscape + " was dropped on " + gameObject.name);

                // Subtract from Player's action points
                GameObject.Find(strCurPlayer).GetComponent<Player>().putIntoPlay(eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().GetCardDetails().value);



                atkStat += eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().GetCardDetails().attack;
                defStat += eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().GetCardDetails().defense;
                units.Add(new Status(usedCard.name, usedCard.attack, usedCard.defense));
                nUnits++;
                Destroy(eventData.pointerDrag);
                //troops[nTroops] = eventData.pointerDrag.gameObject;
                //nTroops++;

                if (gameObject.name.Equals("Land Landscape"))
                {
                    if (strCurPlayer.Equals("Player1")) { 
                    float coordinate_x = Random.Range(-50, 90);
                    float coordinate_z = Random.Range(30, 110);
                    Vector3 vector = new Vector3(coordinate_x, 0, coordinate_z);

                    GameObject unitLand = Instantiate(Resources.Load("Models/Private"), vector, Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                    unitLand.transform.localScale = new Vector3(3, 3, 3);
                    unitLand.transform.SetParent(GameObject.Find("Image Target").transform);
                }
                    else
                    {
                        float coordinate_x = Random.Range(206, 354);
                        float coordinate_z = Random.Range(45, 123);
                        Vector3 vector = new Vector3(coordinate_x, 0, coordinate_z);

                        GameObject unitLand = Instantiate(Resources.Load("Models/Private"), vector, Quaternion.Euler(0f, -90f, 0f)) as GameObject;
                        unitLand.transform.localScale = new Vector3(3, 3, 3);
                        unitLand.transform.SetParent(GameObject.Find("Image Target").transform);
                    }
                }

                if(gameObject.name.Equals("Water Landscape"))
                {
                    if (strCurPlayer.Equals("Player1"))
                    {
                        float coordinate_x = Random.Range(-94.7f, 27.6f);
                        float coordinate_z = Random.Range(-88f, -4f);
                        Vector3 vector = new Vector3(coordinate_x, 0, coordinate_z);

                        GameObject unitWater = Instantiate(Resources.Load("Models/Battleship"), vector, Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        unitWater.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        unitWater.transform.SetParent(GameObject.Find("Image Target").transform);
                    }
                    else
                    {
                        float coordinate_x = Random.Range(314f, 399f);
                        float coordinate_z = Random.Range(-88f, -4f);
                        Vector3 vector = new Vector3(coordinate_x, 0, coordinate_z);

                        GameObject unitWater = Instantiate(Resources.Load("Models/Battleship"), vector, Quaternion.Euler(0f, -90f, 0f)) as GameObject;
                        unitWater.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        unitWater.transform.SetParent(GameObject.Find("Image Target").transform);
                    }
                }

                if (gameObject.name.Equals("Cloud Landscape"))
                {
                    if (strCurPlayer.Equals("Player1"))
                    {
                        float coordinate_x = Random.Range(-90f, 50);
                        float coordinate_z = Random.Range(-202, -132);
                        Vector3 vector = new Vector3(coordinate_x, 0, coordinate_z);

                        GameObject unitCloud = Instantiate(Resources.Load("Models/Jet"), vector, Quaternion.Euler(0f, 180f, 0f)) as GameObject;
                        unitCloud.transform.localScale = new Vector3(6, 6, 6);
                        unitCloud.transform.SetParent(GameObject.Find("Image Target").transform);
                    }
                    else
                    {
                        float coordinate_x = Random.Range(206, 363);
                        float coordinate_z = Random.Range(-202, -132);
                        Vector3 vector = new Vector3(coordinate_x, 0, coordinate_z);

                        GameObject unitCloud = Instantiate(Resources.Load("Models/Jet"), vector, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
                        unitCloud.transform.localScale = new Vector3(6, 6, 6);
                        unitCloud.transform.SetParent(GameObject.Find("Image Target").transform);
                    }

                }


                Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
                if (d != null)
                {
                    d.parentToReturnTo = this.transform;
                }
            }
        } else
        {
            Debug.Log("Not enough action points to use that card!");
        }
	}
}
