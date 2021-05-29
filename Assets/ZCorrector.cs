using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCorrector : MonoBehaviour
{
    private void FixedUpdate() {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
