using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;
    public int text;
    public Text invBullet;
    public float newBull = 5;

    public bool isShoot;

    public float RealoadTime;

    public float bulletLifeTime;
   
    // Start is called before the first frame update
    public void Start()
    {
        invBullet = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    public void Update()
    {
        newBull -= Time.deltaTime * 1f;
        if (newBull < 0)
        {
            text += 1;
            newBull = 5;
        }
            

        invBullet.text = text.ToString();

        if(Input.GetMouseButtonDown(1) && isShoot==true && text>0)
        {
            isShoot = false;
            Invoke("ShootTrue", RealoadTime);
            text -= 1;
            GameObject myBullet = Instantiate(bullet);
            myBullet.transform.position = shootPoint.position;
            myBullet.transform.rotation = shootPoint.rotation;
            Destroy(myBullet, bulletLifeTime);
        }
        
    }

    public void ShootTrue()
    {
        isShoot = true;
    }
}
