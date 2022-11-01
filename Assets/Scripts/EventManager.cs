using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void textCompleteAction();
    public static event textCompleteAction onEnterPressed;
    public bool entPressValid = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entPressValid)
        {
            if (onEnterPressed != null)
            {
                onEnterPressed();
            }
            entPressValid = false;
        }
    }
}
