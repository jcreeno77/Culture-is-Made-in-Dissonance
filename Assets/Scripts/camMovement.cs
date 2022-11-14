using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMovement : MonoBehaviour
{
    [SerializeField] GameObject bike;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(bike.transform.position.x, transform.position.y, transform.position.z);
        float bikeXVal = bike.transform.position.x;
        float bikeYVal = bike.transform.position.y;
        float xVal = transform.position.x;
        float yVal = transform.position.y;
        float xsetVal = Mathf.Lerp(xVal, bikeXVal, Time.deltaTime*5f);
        float ysetVal = Mathf.Lerp(yVal, bikeYVal+3.5f, Time.deltaTime*3f);
        transform.position = new Vector3(xsetVal, ysetVal, transform.position.z);

    }
}
