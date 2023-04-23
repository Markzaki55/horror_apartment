using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlickerLights : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float maxIntensity = 1f;
    public Color color = Color.white;

    private Light[] _lights;
    private bool _isFlickering;

    private void Start()
    {
        _lights = GetComponentsInChildren<Light>();
    }

    private void Update()
    {
        if (!_isFlickering)
        {
            StartCoroutine(Flicker(Random.Range(0.1f, 0.5f)));
        }
    }

    private IEnumerator Flicker(float duration)
    {
        _isFlickering = true;

        foreach (var light in _lights)
        {
            light.intensity = Random.Range(minIntensity, maxIntensity);
            light.color = color;
        }

        yield return new WaitForSeconds(duration);

        foreach (var light in _lights)
        {
            light.intensity = 1f;
            light.color = Color.white;
        }

        _isFlickering = false;
    }
}
