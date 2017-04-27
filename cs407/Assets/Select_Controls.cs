using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select_Controls : MonoBehaviour {
    Button myButton;
    // Use this for initialization
    void Start () {
        Debug.Log("hi");
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => LoadControls());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadControls()
    {
        
        SceneManager.LoadScene("ControlsScene");
    }
}
