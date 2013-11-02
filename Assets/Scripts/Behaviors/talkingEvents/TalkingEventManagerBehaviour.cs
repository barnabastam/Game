﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This is the overall manager, for the typewriters.
/// 
/// Alex Reiss
/// </summary>

public class TalkingEventManagerBehaviour : MonoBehaviour 
{
    /// <summary>
    /// This is used for the switch.
    /// 
    /// Alex Reiss
    /// </summary>
    public enum Panels
    {
        LowerLeft,
        LowerRight,
        UpperLeft,
        UpperRight,
        None,
        NUM_PANELS
    }
    
    /// <summary>
    /// To keep track of the four talking panels. 
    /// </summary>
  
    public TalkerBehaviour[] talkers;

    /// <summary>
    /// To keep track of the two text boxes.
    /// </summary>

    public TypeWriterBoxBehaviour[] textBox;

    /// <summary>
    /// The variable to control the switch.
    /// </summary>
    
    Panels currentPanel = Panels.None;

    /// <summary>
    /// Acts as the status of all panels.
    /// </summary>

    bool activePanels = false;

    /// <summary>
    /// This is the boolean that the textboxes control, the reason it is here is to 
    /// stay static effectively without being static. 
    /// </summary>

    public bool playingEvent = false;

    /// <summary>
    /// No use at the moment, but it would be used to control the conversation.
    /// 
    /// </summary>

    int currentTalkingEvent = 0;

    /// <summary>
    /// Test at the moment but could have uses.
    /// </summary>

    public List<TalkingEventChain> talkingEventChain = new List<TalkingEventChain>();

    /// <summary>
    /// The currently running event chain.
    /// </summary>

    public List<TalkingEvent> currentTalkingEventChain = new List<TalkingEvent>();

    //public bool triggerEvent = false;
    
    
    /// <summary>
    /// These are for testing purposes only
    /// </summary>
    
    public Material testActorLeft;
    public Material testActorRight;

	/// <summary>
	/// This is to tell the textboxes where they are.
	/// </summary>

	void Start () 
    {
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, Screen.height, 6.0f));
        //talkers[0].transform.localPosition = screenPosition - Camera.main.transform.forward;
        //talkers[0].transform.position = screenPosition;

        //TalkingEventChain newTalkingEventChain = new TalkingEventChain();
       
        ////test
        //TalkingEvent newTalkingEvent0 = new TalkingEvent();
        //newTalkingEvent0.normalText = "Testing Testing Testing Testing Testing Testing 456 Testing Testing Testing 789 Testing Testing.";
        //newTalkingEvent0.annoyText = "Yup It works.";
        //newTalkingEvent0.selectedPanel = Panels.LowerLeft;
        //newTalkingEvent0.theTalker = testActorLeft;
        //newTalkingEventChain.talkingEvents.Add(newTalkingEvent0);

        //TalkingEvent newTalkingEvent1 = new TalkingEvent();
        //newTalkingEvent1.normalText = "Testing Testing Testing 123 Testing 456 Testing Testing Testing 789 Testing Testing.";
        ////newTalkingEvent1.annoyText = "Up Top.";
        //newTalkingEvent1.selectedPanel = Panels.UpperRight;
        //newTalkingEvent1.theTalker = testActorRight;
        //newTalkingEventChain.talkingEvents.Add(newTalkingEvent1);

        //talkingEventChain.Add(newTalkingEventChain);

        //StarTalkingEventChain(0);

        textBox[0].posOfBox = TypeWriterBoxBehaviour.PositionOfTheTextBox.bottom;
        textBox[1].posOfBox = TypeWriterBoxBehaviour.PositionOfTheTextBox.top;


        
    }
	
	/// <summary>
	/// This is for test at the moment, acting as the test trigger.
    /// 
    /// Alex Reiss
	/// </summary>

	void Update () 
    {
        if (currentTalkingEvent < currentTalkingEventChain.Count || activePanels)
        {
            
            if (!activePanels && !playingEvent && Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Hi");
                if (currentTalkingEventChain[currentTalkingEvent].selectedPanel == Panels.UpperLeft)
                {
                    textBox[1].transform.renderer.enabled = true;
                    talkers[2].transform.renderer.enabled = true;
                    activePanels = true;
                    currentPanel = Panels.UpperLeft;
                    textBox[1].startTalkingEvent(currentTalkingEventChain[currentTalkingEvent].normalText, currentTalkingEventChain[currentTalkingEvent].annoyText);
                    talkers[2].SetTalker(currentTalkingEventChain[currentTalkingEvent].theTalker);
                }
                else if (currentTalkingEventChain[currentTalkingEvent].selectedPanel == Panels.UpperRight)
                {
                    textBox[1].transform.renderer.enabled = true;
                    talkers[3].transform.renderer.enabled = true;
                    activePanels = true;
                    currentPanel = Panels.UpperRight;
                    textBox[1].startTalkingEvent(currentTalkingEventChain[currentTalkingEvent].normalText, currentTalkingEventChain[currentTalkingEvent].annoyText);
                    talkers[3].SetTalker(currentTalkingEventChain[currentTalkingEvent].theTalker);
                }
                else if (currentTalkingEventChain[currentTalkingEvent].selectedPanel == Panels.LowerLeft)
                {
                    
                    textBox[0].transform.renderer.enabled = true;
                    talkers[0].transform.renderer.enabled = true;
                    activePanels = true;
                    currentPanel = Panels.LowerLeft;
                    textBox[0].startTalkingEvent(currentTalkingEventChain[currentTalkingEvent].normalText, currentTalkingEventChain[currentTalkingEvent].annoyText);
                    talkers[0].SetTalker(currentTalkingEventChain[currentTalkingEvent].theTalker);
                }
                else if (currentTalkingEventChain[currentTalkingEvent].selectedPanel == Panels.LowerRight)
                {
                    textBox[0].transform.renderer.enabled = true;
                    talkers[1].transform.renderer.enabled = true;
                    activePanels = true;
                    currentPanel = Panels.LowerRight;
                    textBox[0].startTalkingEvent(currentTalkingEventChain[currentTalkingEvent].normalText, currentTalkingEventChain[currentTalkingEvent].annoyText);
                    talkers[1].SetTalker(currentTalkingEventChain[currentTalkingEvent].theTalker);
                }
                currentTalkingEvent++;
            }
            else if (!playingEvent)
            {
                switch (currentPanel)
                {
                    case Panels.LowerLeft:
                        textBox[0].transform.renderer.enabled = false;
                        talkers[0].transform.renderer.enabled = false;
                        activePanels = false;
                        currentPanel = Panels.None;
                        break;
                    case Panels.LowerRight:
                        textBox[0].transform.renderer.enabled = false;
                        talkers[1].transform.renderer.enabled = false;
                        activePanels = false;
                        currentPanel = Panels.None;
                        break;
                    case Panels.UpperRight:
                        textBox[1].transform.renderer.enabled = false;
                        talkers[3].transform.renderer.enabled = false;
                        activePanels = false;
                        currentPanel = Panels.None;
                        break;
                    case Panels.UpperLeft:
                        textBox[1].transform.renderer.enabled = false;
                        talkers[2].transform.renderer.enabled = false;
                        activePanels = false;
                        currentPanel = Panels.None;
                        break;
                }
            }
        }
	}

    public void StarTalkingEventChain(int numberOfEvent)
    {
        currentTalkingEventChain = talkingEventChain[numberOfEvent].talkingEvents;

        for (int index = 0; index < talkingEventChain[numberOfEvent].talkingEvents.Count; index++)
        {
            currentTalkingEventChain[index].annoyText = talkingEventChain[numberOfEvent].talkingEvents[index].annoyText;
            currentTalkingEventChain[index].normalText = talkingEventChain[numberOfEvent].talkingEvents[index].normalText;
            currentTalkingEventChain[index].selectedPanel = talkingEventChain[numberOfEvent].talkingEvents[index].selectedPanel;
            currentTalkingEventChain[index].theTalker = talkingEventChain[numberOfEvent].talkingEvents[index].theTalker;
        }
    }
}

/// <summary>
/// To handle multiple talking sessions in the scene.
/// </summary>

public class TalkingEventChain
{
    public List<TalkingEvent> talkingEvents = new List<TalkingEvent>();
}

/// <summary>
/// Temporary but could be used for the test event but could be used for more.
/// </summary>

public class TalkingEvent
{
    public string normalText = "";
    public string annoyText= "";
    public TalkingEventManagerBehaviour.Panels selectedPanel;
    public Material theTalker;
}