using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("click");
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward))) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
            }
        }
    }
}
