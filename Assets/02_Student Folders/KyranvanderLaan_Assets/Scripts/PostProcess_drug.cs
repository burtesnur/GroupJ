using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcess_drug : MonoBehaviour
{
    public PostProcessVolume Volume;
    public Collider Trigger;
    public float timer = 10f;

    private Bloom _Bloom;
    private ColorGrading _ColorGrading;
    private Vignette _Vignette;
    private bool Drugged = false;
    private bool After = false;
    // Start is called before the first frame update
    void Start()
    {
        Volume.profile.TryGetSettings(out _Bloom);
        Volume.profile.TryGetSettings(out _ColorGrading);
         Volume.profile.TryGetSettings(out _Vignette);
        _Bloom.intensity.value = 0;
        _ColorGrading.hueShift.value = 0;
        _ColorGrading.saturation.value = 0;
        _Vignette.intensity.value = 0;
    }

    // Update is called once per frame
    void Update()
    {  
        if(Drugged && timer > 0f){
            _ColorGrading.hueShift.value = Mathf.Sin(Time.realtimeSinceStartup) * 180;
            timer -= Time.deltaTime;
        }else if(Drugged){
            Drugged = false;
            After = true;
            _Bloom.intensity.value = 0;
            _ColorGrading.hueShift.value = 0;
        }
        if(After && timer > -10f){
            _Vignette.intensity.value = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup) * .5f);
            _ColorGrading.saturation.value = -100;
            timer -= Time.deltaTime;
        }else if(After){
            After = false;
            _Vignette.intensity.value = 0;
            _ColorGrading.saturation.value = 0;
            timer = 10f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _Bloom.intensity.value = 17;
            _ColorGrading.saturation.value = 100;
            Drugged = true;
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
