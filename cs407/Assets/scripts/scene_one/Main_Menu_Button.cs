using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu_Button : MonoBehaviour {
    Button myButton;
    // Use this for initialization
    void Start () {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => launchMenu());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //This method will lauch the main menu if called upon
    public static void launchMenu()
    {
        Debug.Log("Menu Launched");
        SceneManager.LoadScene("MainMenu");
    }
}
