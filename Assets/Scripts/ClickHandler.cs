using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;



public class ClickHandler : MonoBehaviour
{
    public UnityEvent upEvent;
    public UnityEvent downEvent;
    void OnMouseDown()
    {
        downEvent?.Invoke();
        
    }

    void OnMouseUp()
    {
        upEvent?.Invoke();
    }

}
