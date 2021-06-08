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

    public List<GameObject> pants;
    public List<GameObject> shirts;
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    bool isShirt = true;

    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    //colour change
    public GameObject redObject;
    public GameObject greenObject;
    public GameObject blueObject;

    Vector3 scaleup = new Vector3(3.5f,3.5f,3.5f);


    Vector3 scaledown = new Vector3(3.5f,3.5f,3.5f);

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

        if (command.ToLower().Contains("red"))
        {
            if (isShirt == true)
            {
                shirtcolour(1);
            }else{
                pantcolour(1);
            }

            uiText.text = "ok";
        }
        if (command.ToLower().Contains("white"))
        {
            if (isShirt == true)
            {
                shirtcolour(0);
            }else{
                pantcolour(0);
            }


            uiText.text = "ok";
        }
        if (command.ToLower().Contains("green"))
        {
            if (isShirt == true)
            {
                shirtcolour(2);
            }else{
                pantcolour(2);
            }

            uiText.text = "ok";
        }
        if (command.ToLower().Contains("blue"))
        {
            if (isShirt == true)
            {
                shirtcolour(3);
            }else{
                pantcolour(3);
            }

            uiText.text = "ok";
        }
        if (command.ToLower().Contains("model"))
        {
            changemodel();
            uiText.text = "OK";
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

    public void pantcolour(int index){
        pants[index].transform.position = PlacementPose.position;
        pants[index].transform.rotation = PlacementPose.rotation;
        pants[index].transform.localScale=spawnedObject.transform.localScale;
        Destroy(spawnedObject);
        ARPlaceObject(pants[index]);

    }
    public void shirtcolour(int index){
        shirts[index].transform.position = PlacementPose.position;
        shirts[index].transform.rotation = PlacementPose.rotation;
        shirts[index].transform.localScale=spawnedObject.transform.localScale;
        Destroy(spawnedObject);
        ARPlaceObject(shirts[index]);

    }
    // public void redshirt()
    // {
        
    //     redObject.transform.position = PlacementPose.position;
    //     redObject.transform.rotation = PlacementPose.rotation;
    //     redObject.transform.localScale = spawnedObject.transform.localScale;
    //     Destroy(spawnedObject);
    //     ARPlaceObject(redObject);
    // }
    // public void greenshirt()
    // {
    //     // isShirt = true;
    //     greenObject.transform.position = PlacementPose.position;
    //     greenObject.transform.rotation = PlacementPose.rotation;
    //     greenObject.transform.localScale = spawnedObject.transform.localScale;
    //     Destroy(spawnedObject);
    //     ARPlaceObject(greenObject);
    // }
    // public void blueshirt()
    // {
    //     // isShirt = true;
    //     blueObject.transform.position = PlacementPose.position;
    //     blueObject.transform.rotation = PlacementPose.rotation;
    //     blueObject.transform.localScale = spawnedObject.transform.localScale;
    //     Destroy(spawnedObject);
    //     ARPlaceObject(blueObject);
    // }
    // public void whiteshirt()
    // {
    //     // isShirt = true;
    //     arObjectToSpawn.transform.position = PlacementPose.position;
    //     arObjectToSpawn.transform.rotation = PlacementPose.rotation;
    //     arObjectToSpawn.transform.localScale = spawnedObject.transform.localScale;
    //     Destroy(spawnedObject);
    //     ARPlaceObject(arObjectToSpawn);
    // }
    void changemodel()
    {
        if (isShirt == true)
        {
            isShirt = false;
            pants[0].transform.position = PlacementPose.position;
            pants[0].transform.rotation = PlacementPose.rotation;
            pants[0].transform.localScale=spawnedObject.transform.localScale - scaleup;
            Destroy(spawnedObject);
            ARPlaceObject(pants[0]);
        }
        else
        {
            isShirt = true;
            arObjectToSpawn.transform.position = PlacementPose.position;
            arObjectToSpawn.transform.rotation = PlacementPose.rotation;
            arObjectToSpawn.transform.localScale = spawnedObject.transform.localScale + scaleup;
            Destroy(spawnedObject);
            ARPlaceObject(arObjectToSpawn);

        }
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


        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation * Quaternion.Euler(0, 180, 0));
    }


}

