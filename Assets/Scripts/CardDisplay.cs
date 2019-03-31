using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card card;

	public Text nameText;
	public Text descriptionText;

	public Image artworkImage;

	public Text defenseText;
	public Text attackText;
	public Text valueText;

	// Use this for initialization
	void Start () {
		nameText.text = card.name;
		descriptionText.text = card.description;

		artworkImage.sprite = card.artwork;

        defenseText.text = "Def: " + card.defense.ToString();
		attackText.text = "Atk: " + card.attack.ToString();
        valueText.text = card.value.ToString();
	}
	
}
