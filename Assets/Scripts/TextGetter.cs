using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextGetter : MonoBehaviour
{
    
    public ARPlacement ar;
     private Text uiText;
     //public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GameObject.Find("inputtext").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        string command = uiText.text;
        if (command.Contains("rotate"))
        {
           transform.localEulerAngles += new Vector3(0, transform.rotation.y + 90, 0);
           uiText.text= "ok";
        };
        if(command.Contains("red"))
        {
            
            uiText.text ="ok";
        }
        
    }
}
