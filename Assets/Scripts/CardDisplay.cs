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
    public Text typeText; // Yanyan: TODO: ALL RELATED SETUP, prefab, Card class, etc.
    
    [SerializeField] private Card[] poolOfCards;
    private Card corCardClass;

    // Use this for initialization
    void Start() {
        int rand = Random.Range(0, poolOfCards.Length-1);
        nameText.text = poolOfCards[rand].name;
        descriptionText.text = poolOfCards[rand].description;
        artworkImage.sprite = poolOfCards[rand].artwork;
        defenseText.text = "Def: " + poolOfCards[rand].defense.ToString();
        attackText.text = "Atk: " + poolOfCards[rand].attack.ToString();
        valueText.text = poolOfCards[rand].value.ToString();
        

        // Create an on-hand Card class
        corCardClass = new Card();
        corCardClass.name = poolOfCards[rand].name;
        corCardClass.description = poolOfCards[rand].description;
        corCardClass.artwork = poolOfCards[rand].artwork;
        corCardClass.defense = poolOfCards[rand].defense;
        corCardClass.attack = poolOfCards[rand].attack;
        corCardClass.value = poolOfCards[rand].value;
        corCardClass.landscape = poolOfCards[rand].landscape ;
        
        // TODO: corCardClass.type = poolOfCards[rand].type;
    }
    
    public Card GetCardDetails()
    {
        return corCardClass;
    }
}
