using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    [SerializeField]
    Text uiText;

    void Start()
    {
        Setup(LANG_CODE);

        SpeechToText.instance.onPartialResultsCallback = onPartialSpeechResult;
        SpeechToText.instance.onResultCallback = onFinalSpeechResult;
        CheckPermission(); 
    }
    void CheckPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }
    #region  Speech to Text 
    public void StartListening(string message)
    {
        SpeechToText.instance.StartRecording();
    }
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();

    }
    void onFinalSpeechResult(string result)
    {
        uiText.text = result;
    }
    void onPartialSpeechResult(string result)
    {
        uiText.text = result;
    }
    #endregion
    void Setup(string Code)
    {
        SpeechToText.instance.Setting(Code);
    }
}
