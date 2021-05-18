using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{

    public GameObject player;
    Vector3 playerPos;
    private float speed;
    public float lifeTime;
    public RaycastHit hit;
    // Start is called before the first frame update

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position - transform.position;
        transform.rotation =Quaternion.LookRotation(playerPos);
        
        Physics.Raycast(transform.position, transform.forward, out hit);
        speed = hit.distance/Random.Range(3f, 8f);
    }

    // Update is called once per frame
    public void Update()
    {      
        transform.position += playerPos.normalized * speed * Time.deltaTime;
        Destroy(this.gameObject, lifeTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            Time.timeScale = 0;
        }
    }
}
