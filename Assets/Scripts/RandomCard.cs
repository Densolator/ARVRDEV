using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCard : MonoBehaviour
{

    public Button drawButton;
    public Text text;
    int num;
    [SerializeField] private Card[] cards;
    
    // Start is called before the first frame update
    void Start()
    {
        drawButton.onClick.AddListener(TaskOnClick);
    }
    void decreaseCard()
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
    }
    void TaskOnClick()
    {
        decreaseCard();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
