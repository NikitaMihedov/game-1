using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3 : MonoBehaviour
{
 public GameObject tavern;

 public void PlaceBuild()
    {
        Instantiate(tavern , Vector3.zero , Quaternion.identity);
    }
 
}
