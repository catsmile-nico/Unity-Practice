﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void FixedUpdate()    {
        transform.position = new Vector3(transform.position.x, (transform.position.y+0.1f), transform.position.z);
    }
}
