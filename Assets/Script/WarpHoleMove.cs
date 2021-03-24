using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpHoleMove : MonoBehaviour
{
    public float XDistance;
    public float YDistance;
    public float ZDistance;
    public float Speed;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t = Time.time;
        Vector3 pos = this.transform.position;
        pos.x =pos.x+ XDistance * Mathf.Cos(t*Speed);
        pos.y =pos.y+ YDistance * Mathf.Cos(t*Speed);
        pos.z =pos.z+ ZDistance * Mathf.Cos(t * Speed);
        this.transform.position = new Vector3(pos.x,pos.y,pos.z);
    }
}
