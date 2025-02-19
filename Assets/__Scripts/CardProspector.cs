﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum defines a variable type with a few prenamed values        // a This is an enum, which defines a type of variable that only has a few possible named values. The eCardState variable type has one of four values: drawpile, tableau, target, and discard, which help CardProspector instances track where they should be in the game.
public enum eCardState
{
    drawpile,
    tableau,
    target,
    discard
}

public class CardProspector : Card
{ // Make sure CardProspector extends Card 
    [Header("Set Dynamically: CardProspector")]
    // This is how you use the enum eCardState 
    public eCardState state = eCardState.drawpile;
    // The hiddenBy list stores which other cards will keep this one face down 
    public List<CardProspector> hiddenBy = new List<CardProspector>();
    // The layoutID matches this card to the tableau XML if it's a tableau card 
    public int layoutID;
    // The SlotDef class stores information pulled in from the LayoutXML <slot> 
    public SlotDef slotDef;

    // This allows the card to react to being clicked 
    override public void OnMouseUpAsButton()
    {
        // Call the CardClicked method on the Prospector singleton 
        Prospector.S.CardClicked(this);
        // Also call the base class (Card.cs) version of this method
        base.OnMouseUpAsButton();                                                  // a Because this line calls the base class (Card) version of OnMouseUpAsButton(), CardProspectors will still print their name to the Console pane when clicked
    }
}