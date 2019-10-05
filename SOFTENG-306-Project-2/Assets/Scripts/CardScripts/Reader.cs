﻿using System.Collections.Generic;
using System.IO;
using System;
using SimpleJSON;
using UnityEngine;
using System.Linq;

public class Reader
{

    public PlotCard RootState { get; private set; }
    public List<PlotCard> AllStoryStates { get; private set; }
    public List<Card> AllMinorStates { get; private set; }

    public Reader()
    {

        AllStoryStates = this.ParseJson(Directory.GetCurrentDirectory() + "/Assets/json/plotStates.json", true).Cast<PlotCard>().ToList();
        AllMinorStates = this.ParseJson(Directory.GetCurrentDirectory() + "/Assets/json/minorStates.json", false);
        RootState = this.AllStoryStates[0];
    }

    private List<Card> ParseJson(string filePath, bool isPlotJson)
    {
        List<Card> result = new List<Card>();

        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();

            JSONArray stateArray = SimpleJSON.JSON.Parse(json).AsArray;
            foreach (JSONNode state in stateArray)
            {
                List<string> precedingDialogue = new List<string>();

                var foundPrecedingDialogue = state["precedingDialogue"].AsArray;
                if (foundPrecedingDialogue.Count != 0)
                {
                    foreach (JSONNode dialogue in state["precedingDialogue"])
                    {
                        precedingDialogue.Add(dialogue);
                    }
                }

                List<Transition> optionList = new List<Transition>();

                JSONNode transitions = isPlotJson ? state["transitions"].AsArray : state["options"];

                foreach (JSONNode transition in transitions)
                {
                    int popHappinessModifier = 0;
                    int goldModifier = 0;
                    int envHealthModifier = 0;
                    
                    if (transition["happiness"])
                    {
                        popHappinessModifier = transition["happiness"];
                    }

                    if (transition["money"])
                    {
                        goldModifier = transition["money"];
                    }

                    if (transition["environment"])
                    {
                        envHealthModifier = transition["environment"];
                    }
                    
                    MetricsModifier metricsModifier = new MetricsModifier(popHappinessModifier, goldModifier, envHealthModifier);

                    if (state["sliderType"])
                    {
                        optionList.Add(new SliderTransition(transition["feedback"], metricsModifier, state["threshold"]));
                    } 
                    else
                    {
                        optionList.Add(new Transition(transition["feedback"], metricsModifier, transition["label"], transition["state"]));
                    }
                }

                if (isPlotJson)
                {
                    String name = "";
                    if (state["name"])
                    {
                        name = state["name"];
                    }
                    result.Add(new PlotCard(state["id"], precedingDialogue.ToArray<string>(), name, state["question"], optionList));

                }
                else if (state["sliderType"])
                {
                    result.Add(new SliderCard(precedingDialogue.ToArray<string>(), state["name"], state["question"], optionList.Cast<SliderTransition>().ToList(), state["maxValue"], state["minValue"]));
                    Debug.Log("made slider type" + precedingDialogue.ToArray<string>() + state["name"] + state["question"] + optionList.Cast<SliderTransition>().ToList() + state["maxValue"]+ state["minValue"]);
                }
                else
                {
                    result.Add(new MinorCard(precedingDialogue.ToArray<string>(), state["question"], optionList));
                }
            }

        }

        return result;
    }
}