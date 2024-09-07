using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform cameraPosition;
    private void Update()
    {
        //makes the hole camera attached to the character camera postion
        transform.position = cameraPosition.position;
    }
}
