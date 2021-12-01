using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public PostProcessVolume volume;

    public Vignette vignette;

    public float vigValue;

    private float h, v;

    public float smoothTime = 0.3f;
    private void Awake()
    {
        volume = GetComponent<PostProcessVolume>();
    }
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
    }
    void Update()
    {
        //PostProcessVolume
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (h==0 || v==0)
        {
            vignette.intensity.value = vigValue;
        }
        if(h!=0 || v!=0)
        {
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.25f, smoothTime * Time.fixedDeltaTime);
        }
    }
}
