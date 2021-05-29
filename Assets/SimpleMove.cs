using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SimpleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float step = 1f;
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) { transform.SetPositionAndRotation(new Vector3(transform.position.x,transform.position.y + step * Time.deltaTime, transform.position.z), Quaternion.identity); 

        }
    }
}
