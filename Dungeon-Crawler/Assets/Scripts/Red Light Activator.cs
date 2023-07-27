using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class RedLightActivator : MonoBehaviour
{
    private Light2D lightSource;
    public float targetIntensity = 4f;
    public float minIntensity = 0f;
    public float intensityChangeDuration = 0.5f;
    public float pulseSpeed = 1.0f;

    private bool playerHasEntered = false;

    void Start()
    {
        lightSource = GameObject.FindGameObjectWithTag("Red Light Source").GetComponent<Light2D>();
        lightSource.intensity = 0f;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHasEntered = true;
            DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, targetIntensity, intensityChangeDuration);
            StartCoroutine(GlowEffect());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHasEntered = false;
            DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, 0f, intensityChangeDuration);
            StopCoroutine(GlowEffect());
        }
    }

    private IEnumerator GlowEffect()
    {
        float time = 0f;
        while (playerHasEntered)
        {
            float pulsatingIntensity = Mathf.Lerp(minIntensity, targetIntensity, Mathf.Abs(Mathf.Sin(time * pulseSpeed)));
            lightSource.intensity = pulsatingIntensity;
            yield return null;
            time = time + Time.deltaTime;
        }
    }
}
