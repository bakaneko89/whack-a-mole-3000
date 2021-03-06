﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour {

    private bool isPaused;
    private GameObject rzecz;
    private Image image;
    private Text text;
    private Button backToMenu;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        isPaused = false;
        rzecz = GameObject.FindWithTag("ruszacz");
        image = GameObject.Find("pauseOverlay").GetComponent<Image>();
        text = GameObject.Find("pauseOverlay").GetComponentInChildren<Text>();
        backToMenu = GameObject.Find("wrocDoMenu").GetComponent<Button>();
        backToMenu.gameObject.SetActive(false);
        image.enabled = false;
        text.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape"))
        {
            pauseMethod();
            checkForPause();
        }
	}
    
    void pauseMethod()
    {
        isPaused = !isPaused;
    }

    void checkForPause()
    {
        if (isPaused)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            rzecz.GetComponent<MoveWithMouse>().enabled = false;
            image.enabled = true;
            text.enabled = true;
            backToMenu.gameObject.SetActive(true);
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            rzecz.GetComponent<MoveWithMouse>().enabled = true;
            image.enabled = false;
            text.enabled = false;
            backToMenu.gameObject.SetActive(false);
        }
    }
}
