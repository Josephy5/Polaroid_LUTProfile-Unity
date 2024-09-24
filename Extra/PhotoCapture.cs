using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [SerializeField] private Camera polaroidCam;
    [SerializeField] private Image photoDisplay;
    [SerializeField] private GameObject polaroidPhoto;
    private Texture2D screenCapture;
    private bool viewingPhoto = false;

    private void Awake()
    {
        /*
        if(polaroidCam.targetTexture == null)
        {
            polaroidCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        }
        else
        {
            width = polaroidCam.targetTexture.width;
            height = polaroidCam.targetTexture.height;
        }

        polaroidCam.gameObject.SetActive(false);
        */
        polaroidCam.gameObject.SetActive(false);
    }
    void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!viewingPhoto)
            {
                StartCoroutine(capturePhoto());
            }
            else
            {
                removePhoto();
            }
        }
    }
    IEnumerator capturePhoto()
    {
        polaroidCam.gameObject.SetActive(true);
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        //RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
        //polaroidCam.targetTexture = screenTexture;
        //RenderTexture.active = screenTexture;
        //polaroidCam.Render();
        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        Texture2D screenCapture = new Texture2D(Screen.width, Screen.height);
        screenCapture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenCapture.Apply();
        //RenderTexture.active = null;

        byte[] bytes = screenCapture.EncodeToPNG();
        string fileName = PhotoName();
        System.IO.File.WriteAllBytes(fileName, bytes);

        Debug.Log("Photo Taken!");
        polaroidCam.gameObject.SetActive(false);
        showPhoto(screenCapture);
    }
    string PhotoName()
    {
        return string.Format("{0}/Photos/Photo_{1}.png",
            Application.dataPath,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
    void showPhoto(Texture2D input)
    {
        polaroidPhoto.SetActive(true);

        Sprite photoSprite = Sprite.Create(input, new Rect(0f, 0f, input.width, input.height), new Vector2(.5f, .5f), 100f);
        photoDisplay.sprite = photoSprite;
    }
    void removePhoto()
    {
        viewingPhoto = false;
        polaroidPhoto.SetActive(false);
    }
}
