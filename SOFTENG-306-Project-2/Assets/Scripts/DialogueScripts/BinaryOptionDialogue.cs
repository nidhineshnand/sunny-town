﻿using UnityEngine;

[System.Serializable]
public class BinaryOptionDialogue
{
    [SerializeField]
    private SimpleDialogue leadingDialogue;
    [SerializeField]
    private string question;
    [SerializeField]
    private string option1;
    [SerializeField]
    private string option2;
    public string Question => question; 
    public string Option1 => option1;
    public string Option2 => option2;
    public SimpleDialogue LeadingDialogue => leadingDialogue;

    public BinaryOptionDialogue(string question, string option1, string option2, SimpleDialogue dialogue)
    {
        this.leadingDialogue = dialogue;
        this.question = question;
        this.option1 = option1;
        this.option2 = option2;
    }

}