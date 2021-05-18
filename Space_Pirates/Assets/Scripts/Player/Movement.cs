using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Movement : MonoBehaviour
{
    public LayerMask Clicked;
    private NavMeshAgent navMesh;
    private Vector3 target;
    private Ray ray;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            pers();


            if (Input.GetMouseButton(0))
            {

                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitinfo;

                if (Physics.Raycast(myRay, out hitinfo, 100, Clicked))
                {
                    navMesh.SetDestination(hitinfo.point);
                }
            }
        }
    }

    void pers()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag != "Player") 
                target = hit.point;
        }
        Vector3 dir = (target - transform.position);
        dir = new Vector3(dir.x, 0, dir.z);
        if (dir != Vector3.zero) 
            transform.forward = dir;
    }

}
