using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCard : MonoBehaviour
{

    public Button drawButton;
    public Text text;
    public Text actionPoint;
    int num;
    int actionPoints;



    [SerializeField] private Card[] cards;
    
    [SerializeField] private Transform cardPrefab;

    Transform cardClone;

    

    // Start is called before the first frame update
    void Start()
    {
        drawButton.onClick.AddListener(TaskOnClick);
        actionPoints = int.Parse(actionPoint.GetComponent<Text>().text);

    }


    void drawCard()
    {

        if (actionPoints > 0)
        {
            Debug.Log("Entered");
            num = int.Parse(text.GetComponent<Text>().text);
            Debug.Log(num);
            if (num >= 0)
            {
                num--;
                text.GetComponent<Text>().text = num.ToString();
                }
                else
                    {
                     //TODO: Put message in game that user has no more cards
                    Debug.Log("No more cards");
                }
        
            cardClone = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            cardClone.transform.SetParent(GameObject.Find("Hand").transform);
            actionPoints--;
            actionPoint.GetComponent<Text>().text = actionPoints.ToString();
        }
        else
        {
            //TODO: UI for no more action points
            Debug.Log("No Action Points");
        }


    }

    void TaskOnClick()
    {

        
        
        if (GameObject.Find("Hand").transform.childCount <= 6)
        {
            drawCard();
        }
        else
        {
            Debug.Log("You have excess cards");
        }
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
