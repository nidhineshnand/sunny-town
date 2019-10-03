﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CardFactory
{
    private Reader reader;
    private PlotCard currentPlotCard;
    private List<MinorCard> minorCards;

    public CardFactory()
    {
        reader = new Reader();
        currentPlotCard = reader.RootState;
        minorCards = reader.AllMinorStates;
        minorCards.Randomize();
    }

    public Card GetNewCard(string cardDescriptor)
    {

        switch (cardDescriptor)
        {
            case ("story"):
                // TODO: add some error handling here, because right now we are assuming NextState has been set
                // also the users of this class are unaware that state should be changed on the current card
                string nextStateId = currentPlotCard.NextStateId ?? currentPlotCard.Id;
                currentPlotCard = reader.AllStoryStates.Single(s => s.Id.Equals(nextStateId));
                return currentPlotCard;
            case ("minor"):
                if (minorCards.Count == 0)
                {
                    minorCards = reader.AllMinorStates;
                    minorCards.Randomize();
                }
                
                var minorCard = minorCards[0];
                minorCards.Remove(minorCard);
                return minorCard;
            default:
                throw new System.ArgumentException("Argument invalid for CardFactory");
        }
    }
}