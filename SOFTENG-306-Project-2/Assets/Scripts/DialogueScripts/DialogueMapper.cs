﻿public class DialogueMapper
{
    public BinaryOptionDialogue PlotCardToBinaryOptionDialogue(PlotCard plotCard)
    {
        if (plotCard.Options.Count > 1)
        {
            return new BinaryOptionDialogue(plotCard.Question, 
                        plotCard.Options[0].Dialogue, 
                        plotCard.Options[1].Dialogue, 
                        new SimpleDialogue(
                        plotCard.PrecedingDialogue, 
                        plotCard.Name));
        }
        
        return new BinaryOptionDialogue(plotCard.Question, 
            plotCard.Options[0].Dialogue, 
            "", 
            new SimpleDialogue(
                plotCard.PrecedingDialogue, 
                plotCard.Name));
    }
    
    public BinaryOptionDialogue MinorCardToBinaryOptionDialogue(MinorCard minorCard)
    {
            
        return new BinaryOptionDialogue(minorCard.Question, 
            minorCard.Options[0].Dialogue, 
            minorCard.Options[1].Dialogue, 
            new SimpleDialogue(
                minorCard.PrecedingDialogue, 
                ""));
    }

    public SimpleDialogue FeedbackToDialogue(string feedback)
    {
        return new SimpleDialogue(new string[] { feedback }, "Board of Advisors");
    }
}