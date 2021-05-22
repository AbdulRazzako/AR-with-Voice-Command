using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void scene1(){
        SceneManager.LoadScene(1);
    }
    public void loadimageTrack(){
        SceneManager.LoadScene(2);
    }
    public void goToMainMenu(){
        SceneManager.LoadScene(0);
}
}
