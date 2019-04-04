using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player Player1;
    public Player Player2;
    private Player curPlayer;
    private bool player1Turn;

    public Card[] poolOfCards;

    private Text UIActionPoints;
    private Text UINumCardsDeck;
    private Button UIDrawButton;
    private Button UIEndTurnButton;

    private Text UILandAtk;
    private Text UILandDef;
    private Text UIWaterAtk;
    private Text UIWaterDef;
    private Text UICloudAtk;
    private Text UICloudDef;
    private Text UISelfHP;
    private Text UIEnemyHP;

    void Start()
    {
        GameObject.Find("Player1").transform.Find("Canvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("Player2").transform.Find("Canvas").GetComponent<Canvas>().enabled = false;
        curPlayer = GameObject.Find("Player1").GetComponent<Player>();
        player1Turn = true;
        curPlayer.SendMessage("StartTurn");

        UIActionPoints = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("ActionPoints").transform.Find("ActionPointsText").GetComponent<Text>();
        UINumCardsDeck = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("DrawButton").transform.Find("nCardsDeckText").GetComponent<Text>();
        //UIDrawButton = GameObject.Find("DrawButton").GetComponent<Button>();
        //UIDrawButton.onClick.AddListener(curPlayer.draw);

        UILandAtk = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Land Landscape").transform.Find("AtkStat").GetComponent<Text>();
        UILandDef = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Land Landscape").transform.Find("DefStat").GetComponent<Text>();
        UIWaterAtk = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Water Landscape").transform.Find("AtkStat").GetComponent<Text>();
        UIWaterDef = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Water Landscape").transform.Find("DefStat").GetComponent<Text>();
        UICloudAtk = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Cloud Landscape").transform.Find("AtkStat").GetComponent<Text>();
        UICloudDef = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Cloud Landscape").transform.Find("DefStat").GetComponent<Text>();
        UISelfHP = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("SelfHP").transform.Find("SelfHPText").GetComponent<Text>();
        UIEnemyHP = GameObject.Find("Player1").transform.Find("Canvas").transform.Find("EnemyHP").transform.Find("EnemyHPText").GetComponent<Text>();
    }

    void Update()
    {
        UIActionPoints.text = curPlayer.actionPoints.ToString();
        UINumCardsDeck.text = curPlayer.nCardsDeck.ToString();

        UILandAtk.text = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Land Landscape").GetComponent<DropZone>().atkStat.ToString();
        UILandDef.text = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Land Landscape").GetComponent<DropZone>().defStat.ToString();
        UIWaterAtk.text = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Water Landscape").GetComponent<DropZone>().atkStat.ToString();
        UIWaterDef.text = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Water Landscape").GetComponent<DropZone>().defStat.ToString();
        UICloudAtk.text = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Cloud Landscape").GetComponent<DropZone>().atkStat.ToString();
        UICloudDef.text = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Cloud Landscape").GetComponent<DropZone>().defStat.ToString();

        if (player1Turn)
        {
            UISelfHP.text = GameObject.Find("Player1").GetComponent<Player>().healthPoints.ToString();
            UIEnemyHP.text = GameObject.Find("Player2").GetComponent<Player>().healthPoints.ToString();
        } else
        {
            UISelfHP.text = GameObject.Find("Player2").GetComponent<Player>().healthPoints.ToString();
            UIEnemyHP.text = GameObject.Find("Player1").GetComponent<Player>().healthPoints.ToString();
        }

        if(GameObject.Find("Player2").GetComponent<Player>().healthPoints <= 0)
        {
            SceneManager.LoadScene(1);
        }

        if (GameObject.Find("Player1").GetComponent<Player>().healthPoints <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }

    public Player GetCurPlayer()
    {
        return curPlayer;
    }

    public void Attack()
    {
        int attackCost = 2;

        if (curPlayer.enoughActionPoints(attackCost))
        {
            if (player1Turn)
            {
                Player1.attack(attackCost);
                int p1Atk = 0, p2Def = 0;
                p1Atk += GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Land Landscape").GetComponent<DropZone>().atkStat;
                p2Def += GameObject.Find("Player2").transform.Find("Canvas").transform.Find("Land Landscape").GetComponent<DropZone>().defStat;
                p1Atk += GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Water Landscape").GetComponent<DropZone>().atkStat;
                p2Def += GameObject.Find("Player2").transform.Find("Canvas").transform.Find("Water Landscape").GetComponent<DropZone>().defStat;
                p1Atk += GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Cloud Landscape").GetComponent<DropZone>().atkStat;
                p2Def += GameObject.Find("Player2").transform.Find("Canvas").transform.Find("Cloud Landscape").GetComponent<DropZone>().defStat;
                if (p1Atk - p2Def > 0)
                    Player2.receiveDmg(p1Atk - p2Def);
            }
            else
            {
                Player2.attack(attackCost);
                int p2Atk = 0, p1Def = 0;
                p2Atk += GameObject.Find("Player2").transform.Find("Canvas").transform.Find("Land Landscape").GetComponent<DropZone>().atkStat;
                p1Def += GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Land Landscape").GetComponent<DropZone>().defStat;
                p2Atk += GameObject.Find("Player2").transform.Find("Canvas").transform.Find("Water Landscape").GetComponent<DropZone>().atkStat;
                p1Def += GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Water Landscape").GetComponent<DropZone>().defStat;
                p2Atk += GameObject.Find("Player2").transform.Find("Canvas").transform.Find("Cloud Landscape").GetComponent<DropZone>().atkStat;
                p1Def += GameObject.Find("Player1").transform.Find("Canvas").transform.Find("Cloud Landscape").GetComponent<DropZone>().defStat;
                if (p2Atk - p1Def > 0)
                    Player1.receiveDmg(p2Atk - p1Def);
            }
        }

        // Yanyan: I recommend putting EndTurn() here
    }

    public void EndTurn()
    {
        if (!player1Turn) // Player2 ends turn, switch control to Player1
        {
            GameObject.Find("Player2").transform.Find("Canvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Player1").transform.Find("Canvas").GetComponent<Canvas>().enabled = true;
            curPlayer = Player1;
            player1Turn = true;
            Player1.SendMessage("StartTurn");
            Player2.SendMessage("EndTurn");
        } else 
        {
            GameObject.Find("Player1").transform.Find("Canvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Player2").transform.Find("Canvas").GetComponent<Canvas>().enabled = true;
            curPlayer = Player2;
            player1Turn = false;
            Player2.SendMessage("StartTurn");
            Player1.SendMessage("EndTurn");
        }

        UIActionPoints = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("ActionPoints").transform.Find("ActionPointsText").GetComponent<Text>();
        UINumCardsDeck = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("DrawButton").transform.Find("nCardsDeckText").GetComponent<Text>();
        UILandAtk = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Land Landscape").transform.Find("AtkStat").GetComponent<Text>();
        UILandDef = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Land Landscape").transform.Find("DefStat").GetComponent<Text>();
        UIWaterAtk = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Water Landscape").transform.Find("AtkStat").GetComponent<Text>();
        UIWaterDef = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Water Landscape").transform.Find("DefStat").GetComponent<Text>();
        UICloudAtk = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Cloud Landscape").transform.Find("AtkStat").GetComponent<Text>();
        UICloudDef = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("Cloud Landscape").transform.Find("DefStat").GetComponent<Text>();
        UISelfHP = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("SelfHP").transform.Find("SelfHPText").GetComponent<Text>();
        UIEnemyHP = GameObject.Find(curPlayer.name).transform.Find("Canvas").transform.Find("EnemyHP").transform.Find("EnemyHPText").GetComponent<Text>();


    }
}
