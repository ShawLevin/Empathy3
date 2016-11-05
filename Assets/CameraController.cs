using UnityEngine;
using System;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public WebCamTexture mCamera = null;
    public GameObject plane;

    // Use this for initialization
    void Start()
    {
        Application.RequestUserAuthorization(UserAuthorization.WebCam);
        Debug.Log("Script has been started");
        plane = GameObject.FindWithTag("Player");

        mCamera = new WebCamTexture();
        plane.GetComponent<Renderer>().material.mainTexture = mCamera;
        mCamera.Play();

        if (mCamera.isPlaying)
        {
            Debug.Log("Camera is playing.");
            Color[] pixels = mCamera.GetPixels(1, 1, 1, 1);
            
            Debug.Log(pixels.Length);
        }
        else
        {
            Debug.Log("Camera was told to play but is not playing!");
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now.Second % 5 == 0)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
