using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    public GameObject Apples;
    public GameObject Plane;
    public int apples = 1;
    public float Distance_;
    float x, z;

    float startX = 0f;
    float startZ = -5f;
    // Start is called before the first frame update
    void Start()
    {
            for (int i = 0; i < apples; i++)
            {
                for (int j = 0; j < apples; j++)
                {
                    x = (i * 0.1f) + (startX + 0.1f);
                    z = (j * 0.1f) + (startZ + 0.1f);
                    var gObj = GameObject.Instantiate(Apples, new Vector3(x, 1, z), Quaternion.identity);
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        Distance_ = Vector3.Distance(Apples.transform.position, Plane.transform.position);
        for (int i = 0; i <= 20; i++)
        {
            if (Distance_ > 0)
            {
                Start();
            }
        }
    }
}
