using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraFlash : MonoBehaviour
{
    private LiftGammaGain liftGammaGain;
    private Vector4 defaultLiftValue;
    private Vector4 targetLiftValue;
    public Volume polaroidVolume;
    public GameObject cameraFlashLight;
    [SerializeField] private bool photoTaking = false;
    [SerializeField] private bool isLerping = false;

    void Awake()
    {
        if(polaroidVolume.profile.TryGet<LiftGammaGain>(out liftGammaGain))
        {
            defaultLiftValue = liftGammaGain.lift.value;
            targetLiftValue = defaultLiftValue + new Vector4(1,1,1,1);
        }
        else
        {
            Debug.LogWarning("Polaroid Volume - LiftGammaGain Missing");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!photoTaking)
            {
                StartCoroutine(cameraFlash());
                if (!isLerping)
                {
                    StartCoroutine(screenFlash());
                }
            }
            else
            {
                photoTaking = false;
            }
        }
    }

    IEnumerator cameraFlash()
    {
        cameraFlashLight.gameObject.SetActive(true);
        photoTaking = true;

        //could use WaitForEndOfFrame() but this is more reliable and smoother 
        yield return new WaitForSecondsRealtime(0.1f);

        //photoTaking = false;
        cameraFlashLight.SetActive(false);
    }

    IEnumerator screenFlash()
    {
        //delay the screen flash so that the captured image is clean
        yield return new WaitForSecondsRealtime(0.1f);

        isLerping = true;
        float elapsedTime = 0;

        while (elapsedTime < 0.1f)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / 0.1f;
            liftGammaGain.lift.value = Vector4.Lerp(defaultLiftValue, targetLiftValue, t);
            yield return null;
        }

        elapsedTime = 0;

        while (elapsedTime < 0.1f)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / 0.1f;
            liftGammaGain.lift.value = Vector4.Lerp(targetLiftValue, defaultLiftValue, t);
            yield return null;
        }
        isLerping = false;
    }
}
