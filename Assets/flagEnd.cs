using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagEnd : MonoBehaviour
{
    [SerializeField] GameObject textParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TriggeredFlag");
        transform.GetChild(0).gameObject.SetActive(true);
        textParent.SetActive(false);
    }
}
