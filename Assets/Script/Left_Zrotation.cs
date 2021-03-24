using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Zrotation : MonoBehaviour
{
    float t;
    public float RotateSpeed=20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t = 10 * Time.deltaTime;
        this.transform.Rotate(0,0, -t* RotateSpeed);
    }
}
