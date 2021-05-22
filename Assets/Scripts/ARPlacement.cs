using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


public class ARPlacement : MonoBehaviour
{
    new Renderer renderer;
    [SerializeField]
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;

    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    //colour change
        public GameObject redObject;
        public GameObject greenObject;
        public GameObject blueObject;


    //ui text for voice command
    private Text uiText;
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        uiText = GameObject.Find("inputtext").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        string command = uiText.text;
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject(arObjectToSpawn);
        }

        if(command.Contains("red"))
        {
            red();
            uiText.text ="ok";
        }
        if(command.Contains("white"))
        {
            white();
            uiText.text ="ok";
        }
        if(command.Contains("green"))
        {
            green();
            uiText.text ="ok";
        }
        if(command.Contains("blue"))
        {
            blue();
            uiText.text ="ok";
        }


        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    public void red(){
        redObject.transform.position = PlacementPose.position;
        redObject.transform.rotation = PlacementPose.rotation;
        redObject.transform.localScale = spawnedObject.transform.localScale;
        Destroy(spawnedObject);
        ARPlaceObject(redObject);
    }
    public void green(){
        greenObject.transform.position = PlacementPose.position;
        greenObject.transform.rotation = PlacementPose.rotation;
        greenObject.transform.localScale = spawnedObject.transform.localScale;
        Destroy(spawnedObject);
        ARPlaceObject(greenObject);
    }
    public void blue(){
        blueObject.transform.position = PlacementPose.position;
        blueObject.transform.rotation = PlacementPose.rotation;
        blueObject.transform.localScale = spawnedObject.transform.localScale;
        Destroy(spawnedObject);
        ARPlaceObject(blueObject);
    }
    public void white(){
        arObjectToSpawn.transform.position = PlacementPose.position;
        arObjectToSpawn.transform.rotation = PlacementPose.rotation;
        arObjectToSpawn.transform.localScale = spawnedObject.transform.localScale;
        Destroy(spawnedObject);
        ARPlaceObject(arObjectToSpawn);
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject(GameObject arObjectToSpawn)
    {
        
        
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation * Quaternion.Euler(0,180,0));
    }


}

