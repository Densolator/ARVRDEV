using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int healthPoints;
    public int actionPoints;
    public int nCardsDeck;
    private int nCardsHand = 0;
    //[SerializeField] private Card[] hand;
    [SerializeField] private GameObject[] hand;
    private bool initialDraw;
    public bool curTurn;
    

    [SerializeField] private Card[] deck;
    [SerializeField] private Transform cardPrefab;
    private Transform tempDrawnCard;

    void Start()
    {
        healthPoints = 100;
        curTurn = false;

        initialDraw = true;
        for(int i = 0; i < 5; i++)
        {
            draw();
        }
        initialDraw = false;
    }

    void Update()
    {
        
    }

    public void StartTurn()
    {
        curTurn = true;
        actionPoints += 3;
    }

    public void EndTurn()
    {
        curTurn = false;
    }

    public bool enoughActionPoints(int projectedCost)
    {
        if (projectedCost <= actionPoints)
            return true;
        else
            return false;
    }

    public void draw()
    {
        if (initialDraw || curTurn)
        {
            if (GameObject.Find(this.name).transform.Find("Canvas").transform.Find("Hand").transform.childCount < 7)
            {
                if (initialDraw || enoughActionPoints(1))
                {
                    if (nCardsDeck > 0)
                    {
                        if (!initialDraw)
                        {
                            actionPoints--;
                        }
                        nCardsDeck--;
                        
                        tempDrawnCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                        tempDrawnCard.transform.SetParent(GameObject.Find(this.name).transform.Find("Canvas").transform.Find("Hand").transform);
                        hand[nCardsHand] = tempDrawnCard.gameObject;
                        //new Card(tempDrawnCard.gameObject.GetComponent<CardDisplay>().GetCardDetails());
                        nCardsHand++;
                    }
                    else
                    {
                        //TODO: Put message in game that user has no more cards
                        Debug.Log("You have no cards in your hand.");
                    }
                }
                else
                {
                    //TODO: UI for no more action points
                    Debug.Log("You have no action points left.");
                }
            }
            else
            {
                Debug.Log("You can't draw more than 7 cards!");
            }
        }
        Debug.Log("PLAYER (" + this.name + ") : " + actionPoints);
    }

    public void putIntoPlay(int cardCost)
    {
        actionPoints -= cardCost;
    }

    public void attack(int attackCost)
    {
        actionPoints -= attackCost;
    }

    public void receiveDmg(int dmg)
    {
        healthPoints -= dmg;
    }
}
