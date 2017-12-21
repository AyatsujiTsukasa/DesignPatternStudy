using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewControllerSample : MonoBehaviour {

    public Text mText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddElement(string text){
        mText.text += string.Format("{0}\n", text);
    }
}
