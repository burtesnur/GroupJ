using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFace : MonoBehaviour
{
	public Transform GetRotate;
	public Transform RotateStructure;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
    }

    // Update is called once per frame
    void Update()
    {
        RotateStructure.transform.localRotation = Quaternion.Euler(0 , GetRotate.localRotation.eulerAngles.y, 0);
    }
}
