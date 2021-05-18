using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float startSpeed;

    Rigidbody rb;
    float shootTime;
    Vector3 startingPosition,startingAngle;
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootTime = Time.time;
        startingPosition = transform.position;
        startingAngle = transform.forward;
    }

    // Update is called once per frame
    public void Update()
    {
        if (rb.isKinematic == false) return;
        float time = Time.time - shootTime;
        Vector3 newPos = startingAngle * startSpeed * time +startingPosition;
        transform.LookAt(newPos);
        transform.Rotate(90,0,0);
        float speed = Vector3.Distance(transform.position, newPos);
        
        float force = (speed / Time.deltaTime) * (speed / Time.deltaTime) * rb.mass / 2f;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, speed, 3))
        {  
            rb.AddForceAtPosition(transform.forward * force, hit.point);
        }
        else
        {
            transform.position = newPos;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Rigidbody enemyRb;
        if(other.tag=="Enemy")
        {
            enemyRb = other.GetComponent<Rigidbody>();
            Destroy(enemyRb.transform.gameObject);
            Destroy(this.gameObject);
        }
    }
}
