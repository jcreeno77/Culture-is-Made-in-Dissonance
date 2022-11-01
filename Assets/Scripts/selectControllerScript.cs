using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class selectControllerScript : MonoBehaviour
{
    [SerializeField] GameObject inputFields;
    GameObject[] inputs = new GameObject[400];
    private int selection = 0;
    // Start is called before the first frame update
    void Start()
    {
        selection = 0;
        int i = 0;
        Debug.Log(inputs[0]);
        foreach (Transform child in inputFields.transform)
        {
            
            inputs[i] = child.transform.GetChild(0).gameObject;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(selection);
        //Debug.Log(inputs[selection].name);
        if(inputs[selection] != null)
        {
            inputs[selection].GetComponent<InputFieldCustom>().Select();
        }
    }

    private void OnEnable()
    {
        EventManager.onEnterPressed += increaseSelection;
    }
    private void OnDisable()
    {
        EventManager.onEnterPressed -= increaseSelection;
    }

    void increaseSelection()
    {
        selection += 1;
    }
}
