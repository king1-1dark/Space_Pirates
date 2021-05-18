using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
    {
        transform.localScale = new Vector3(Screen.width/100,1f, Screen.height/100);
    }

}
