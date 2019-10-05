﻿using System.Collections.Generic;

public abstract class Card
{
    public string[] PrecedingDialogue { get; set; }
    public string Question { get; set; }
    public List<Transition> Options { get; protected set; }
    public string Feedback { get; protected set; }
    public abstract void HandleDecision(int decisionIndex);
}