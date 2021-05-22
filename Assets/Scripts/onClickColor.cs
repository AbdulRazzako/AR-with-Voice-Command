using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickColor : MonoBehaviour
{

        // private Button button;
        // Start is called before the first frame update
        // [SerializeField]
    new Renderer renderer;
    Renderer red;
    Material material;
    public Material shirtColor1,shirtColor2,shirtColor3;
    [SerializeField]
    // GameObject[] children = new GameObject[8];
    void Start()
    {
    //    renderer = children[0].GetComponent<Renderer>();
    // renderer = this.GetComponentsInChildren<MeshRenderer>();
   // material = children[0].GetComponent<Material>();
    //    renderer = GameObject.Find("")
        // button = GameObject.Find("colorbutton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorChange(){
        // renderer = children[0].GetComponent<Renderer>();
        // renderer.material.color=Color.red;
        red.material.color = Color.red;
      //  material = shirtColor1;
    }
}
