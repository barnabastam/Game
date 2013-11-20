﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Tactibru/Dialog/Speaker")]
public class TalkerBehaviour : MonoBehaviour 
{
    /// <summary>
    /// Used set the talkers render off.
    /// </summary>
	
	void Start () 
    {
        //transform.localScale = 
        transform.renderer.enabled = false;
	}

    public void SetTalker(Material theTalker)
    {
        transform.renderer.material = theTalker;
    }
}
