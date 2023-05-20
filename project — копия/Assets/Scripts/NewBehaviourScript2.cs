using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript2 : MonoBehaviour
{
    public GameObject cube;
    public List<GameObject> PLS;
    private Camera _cam;
    public LayerMask layer , PL;
    private GameObject _cubeSelect;
    private RaycastHit hit;

    private void Awake()
    {
        _cam = GetComponent<Camera>();    
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0) && PLS.Count > 0)
        {
             Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

             if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f , layer))
                foreach (var el in PLS)
                    el.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(agentTarget.point);

        }

        if (Input.GetMouseButtonDown(0)) 
        {

            foreach (var el in PLS) 
                el.transform.GetChild(0).gameObject.SetActive(false);

            PLS.Clear();

            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            
             if (Physics.Raycast(ray, out hit, 1000f , layer))
                 _cubeSelect = Instantiate(cube, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity);
        }  


        
        if (_cubeSelect)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

             if (Physics.Raycast(ray, out RaycastHit hitD, 1000f, layer))
             {
                float xScale = (hit.point.x - hitD.point.x) * -1;
                float zScale = hit.point.z - hitD.point.z;

                if(xScale < 0.0f && zScale < 0.0f)
                    _cubeSelect.transform.localRotation = Quaternion.Euler(new Vector3(0 , 180 ,0));

                else if(xScale < 0.0f )
                    _cubeSelect.transform.localRotation = Quaternion.Euler(new Vector3(0 , 0 ,180));

                else if (zScale < 0.0f)
                    _cubeSelect.transform.localRotation = Quaternion.Euler(new Vector3(180 , 0 ,0));

                else
                    _cubeSelect.transform.localRotation = Quaternion.Euler(new Vector3(0 , 0 ,0));

                _cubeSelect.transform.localScale = new Vector3 (Mathf.Abs(xScale), 1,(Mathf.Abs(zScale) ));
             }
        }

        if (Input.GetMouseButtonUp(0) && _cubeSelect)
        {
           RaycastHit[] hits = Physics.BoxCastAll(
               _cubeSelect.transform.position,
               _cubeSelect.transform.localScale,
               Vector3.up,
               Quaternion.identity,
               0,
               PL);
           
           foreach (var el in hits)
           {
               PLS.Add(el.transform.gameObject );
               el.transform.GetChild(0).gameObject.SetActive(true);
           }


            Destroy(_cubeSelect);
        }
    }
}
