using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreedingTimeScript : MonoBehaviour
{
    [Header("Timer Functionality variables")]
    public float timer;
    public TextMeshProUGUI timerOnUI;
    private int counter = 0;

    [Header("New Animal Panel variables")]
    public GameObject newAnimalPannel;
    public GameObject newHorse;
    
    public ParticleSystem particleSystem;   
    public GameObject buttons;

    [Header("Camera and canvas related variables")]
    public Camera camera;
    public GameObject canvas;
    public LayerMask layers1;
    public LayerMask layers2;
    public GameObject babyCamera;

    private void Update()
    {
        if (TimerScript.isReady(ref timer) && counter<1)
        {
            counter++;
            ShowNewAnimal();
        }
        else
        {
            TimerScript.DisplayTimer(timer, timerOnUI);
        }
    }

    void ShowNewAnimal()
    {
        //display new animal panel...
        //newAnimalPannel.SetActive(true);

        //Hide timer container...
        gameObject.SetActive(false);

        //hide the buttons...
        buttons.SetActive(false);

        //Set camera and canvas to display 3D horse prefab...
        //camera.cullingMask = layers1;
        //PopUp.SetActive(true);
        babyCamera.SetActive(true);
        particleSystem.gameObject.SetActive(true);
        particleSystem.Play();

        newHorse.SetActive(true);
        //canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
    }

    public void RemoveNewAnimalCanvas()
    {
        //hide animal panel...
        newAnimalPannel.SetActive(false);

        //Show buttons again...
        buttons.SetActive(true);

        //Set camera back to normal...
        camera.cullingMask = layers2;
        newHorse.SetActive(false);
        //PopUp.SetActive(false);
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        timer = 180;
    }
}
