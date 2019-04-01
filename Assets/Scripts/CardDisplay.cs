using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {


	public Text nameText;
	public Text descriptionText;

	public Image artworkImage;

	public Text defenseText;
	public Text attackText;
	public Text valueText;

    [SerializeField] private Card[] cards;

    

    // Use this for initialization
    void Start () {


            int rand = Random.Range(0, cards.Length);
            nameText.text = cards[rand].name;
            descriptionText.text = cards[rand].description;
            artworkImage.sprite = cards[rand].artwork;
            defenseText.text = "Def: " + cards[rand].defense.ToString();
            attackText.text = "Atk: " + cards[rand].attack.ToString();
  
       
	}
	
}
