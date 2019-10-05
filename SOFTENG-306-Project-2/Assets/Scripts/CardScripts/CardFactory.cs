﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CardFactory
{
    private Reader reader;
    private PlotCard currentPlotCard;
    private List<Card> minorCards;

    public CardFactory()
    {
        reader = new Reader();
        currentPlotCard = reader.RootState;
        minorCards = reader.AllMinorStates;
        // TODO : Remove this, it is just for testing
        minorCards = new List<Card>(minorCards.Where(x => x is SliderCard).ToList<Card>());

        //minorCards.Randomize();
    }

    public Card GetNewCard(string cardDescriptor)
    {

        switch (cardDescriptor)
        {
            case ("story"):
                string nextStateId = string.IsNullOrEmpty(currentPlotCard.NextStateId) ? currentPlotCard.Id : currentPlotCard.NextStateId;
                currentPlotCard = reader.AllStoryStates.Single(s => s.Id.Equals(nextStateId));
                return currentPlotCard;
            case ("minor"):
                if (minorCards.Count == 0)
                {
                    minorCards = reader.AllMinorStates;
                    minorCards.Randomize();
                }

                // TODO : Remove this, it is just for testing
                minorCards = new List<Card>(minorCards.Where(x => x is SliderCard).ToList<Card>());

                var minorCard = minorCards[0];
                minorCards.Remove(minorCard);
                return minorCard;
            default:
                throw new System.ArgumentException("Argument invalid for CardFactory");
        }
    }
}