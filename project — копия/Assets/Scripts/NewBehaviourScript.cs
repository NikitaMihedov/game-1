using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{



public float rotateSpeed = 20.0f , speed = 20.0f , zoomSpeed = 700.0f;

private float mult = 1f;

    private void Update() 
    {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float rotate = 0f;
        if (Input.GetKey(KeyCode.Z))
            rotate = -1f;
        else
        {
            if (Input.GetKey(KeyCode.X))
            rotate = 1f;
        }

        mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f ;

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * mult , Space.World);
        transform.Translate(new Vector3(hor , 0 , ver ) * Time.deltaTime * mult * speed, Space.World );

        transform.position += transform.up * zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * mult;

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, 3f , 30f),
            transform.position.z);
    }

    
}

