using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour
{

    public GameObject cameraOne;
    public GameObject cameraTwo;

    [SerializeField] GameObject _editingObject;
    TurnBack _editingObjectSec;


    AudioListener cameraOneAudio;
    AudioListener cameraTwoAudio;

    bool isEnter = false;


    void Start()
    {
        cameraOneAudio = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudio = cameraTwo.GetComponent<AudioListener>();
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
        _editingObjectSec = gameObject.GetComponent<TurnBack>(); 
    }


    void Update()
    {
        switchCamera();
    }

    public void cameraPositionM()
    {
        cameraChangeCounter();
    }

    void switchCamera()
    {
        if(Input.GetKeyDown(KeyCode.E) && isEnter==true)
        {
            if(_editingObject.activeSelf==true){
                _editingObject.SetActive(false);
                _editingObjectSec.enabled=false;
            } else{
                _editingObject.SetActive(true);
                _editingObjectSec.enabled=true;
            }
           cameraChangeCounter();  
        }    
    }

    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    void cameraPositionChange(int camPosition)
    {
        if(camPosition>1)
        {
            camPosition = 0;
        }

        PlayerPrefs.SetInt("CameraPosition", camPosition);

        if(camPosition==0)
        {
           cameraOne.SetActive(true);
           cameraOneAudio.enabled = true;
           cameraTwoAudio.enabled = false; 
           cameraTwo.SetActive(false);
        }

        if(camPosition==1)
        {
           cameraTwo.SetActive(true);
           cameraTwoAudio.enabled = true;
           cameraOneAudio.enabled = false; 
           cameraOne.SetActive(false);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        print("Enter");
        isEnter = true;
    }

    void OnTriggerExit(Collider other)
    {
        print("Exit");
        isEnter = false;
    }

    
    
     
}