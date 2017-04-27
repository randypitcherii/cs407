using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit_Script : MonoBehaviour {
    Button myButton;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Awake");
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => exitGame());
    }

    // Update is called once per frame
    void Update () {
		
	}
    //Called to exit Game
    public static void exitGame()
    {
        Debug.Log("Exit Game");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
