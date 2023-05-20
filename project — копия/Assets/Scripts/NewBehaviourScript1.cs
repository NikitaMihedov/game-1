using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
public LayerMask Layer;
private void Update() 
{
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit hit;
    if(Physics.Raycast(ray , out hit , 1000f , Layer ))
         transform.position = hit.point;

    if(Input.GetMouseButtonDown(0))
        Destroy(gameObject.GetComponent<NewBehaviourScript1>());
}

}
