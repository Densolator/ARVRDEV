using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

	public new string name;
	public string description;

	public Sprite artwork;

	public int defense;
	public int attack;
	public int value;
    public int landscape;

    public Card()
    {

    }

    public Card(Card toBeCopied)
    {
        this.name = toBeCopied.name;
        this.description = toBeCopied.description;
        this.artwork = toBeCopied.artwork;
        this.defense = toBeCopied.defense;
        this.attack = toBeCopied.attack;
        this.value = toBeCopied.value;
        this.landscape = toBeCopied.landscape;
    }

	public void Print()
	{
		Debug.Log(name + ": " + description + " The card costs: " + value);
	}

}
