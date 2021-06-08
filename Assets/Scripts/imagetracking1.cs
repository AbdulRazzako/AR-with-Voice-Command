using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class imagetracking1 : MonoBehaviour
{
    ARTrackedImageManager manager;
    public XRReferenceImageLibrary myReferenceImageLibrary;
    public GameObject placedprefab;
    
    // Start is called before the first frame update
    void Start()
    {
        manager =  gameObject.GetComponent<ARTrackedImageManager>();
        manager.referenceLibrary = myReferenceImageLibrary;
        manager.requestedMaxNumberOfMovingImages = 3;
        manager.trackedImagePrefab= placedprefab;
        manager.enabled = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable() {
        manager.trackedImagesChanged += OnTrackedImageChanged;
        
    }
    void OnDisable() => manager.trackedImagesChanged -= OnTrackedImageChanged;
    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs){
        foreach(ARTrackedImage trackedImage in eventArgs.added){
            // trackedImage.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        }
        foreach (var updatedImage in eventArgs.updated)
    {
        // Handle updated event
    }

    foreach (var removedImage in eventArgs.removed)
    {
        // Handle removed event
    }
    }
}
