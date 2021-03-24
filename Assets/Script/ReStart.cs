using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour
{
    public GameObject Ball;
    Vector3 StartPos;
    Quaternion StartRot;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = new Vector3(14,-27,-12);
        StartRot = new Quaternion();
        Ball = GameObject.FindGameObjectWithTag ("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //DestroyとInstantiateよりも座標移動の方が処理かるいかも
            //Destroy(Ball);
            //Instantiate(Ball, StartPos, StartRot);

            Ball.transform.position = StartPos;
            Ball = GameObject.FindGameObjectWithTag("Ball");
        }
    }
}
