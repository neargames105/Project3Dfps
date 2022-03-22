using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameEffects : MonoBehaviour
{
    private PostProcessVolume volume;

    [SerializeField] private Vignette vignette;

    [SerializeField] private float valueSlow;

    [SerializeField] private float valueNormal;

    [SerializeField] private float smoothTime = 0.3f;

    private bool isSlow = true;
    private void Awake()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
    }
    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        isSlow = (h != 0 || v != 0) ? false : true;
        vignette.intensity.value = isSlow ? valueSlow : valueNormal;

    }
}
