using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCorrector : MonoBehaviour
{
    float initialZ = 0;
    [SerializeField] bool inverse = false;
    private void Awake() {
        initialZ = transform.position.z;
    }
    private void FixedUpdate() {
        if(inverse)
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -transform.localPosition.y + initialZ);
        else
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y + initialZ);
    }
}
