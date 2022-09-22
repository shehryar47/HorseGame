using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instanc;

    public GameObject BreadingCam;

    public GameObject Selecter;

    public GameObject WinnerPanal;
    // Start is called before the first frame update
    void Start()
    {
        Instanc = this;
    }

    // Update is called once per frame
 
    public void BreadindButton()
    {
        Selecter.SetActive(false);
        BreadingCam.SetActive(true);
    }
    public void Back()
    {
        Selecter.SetActive(true);
        BreadingCam.SetActive(false);
    }
}
