using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{


    [SerializeField]
    private GameObject[] placeablePrefabs;  
    private ARTrackedImageManager trackedImageManager;

    public void Awake(){
        trackedImageManager= FindObjectOfType<ARTrackedImageManager>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
