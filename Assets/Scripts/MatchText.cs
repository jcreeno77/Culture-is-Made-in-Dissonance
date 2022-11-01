using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MatchText : MonoBehaviour
{
    private Transform placeHolder;
    private string m_text;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        placeHolder = transform.GetChild(0).transform.GetChild(1);
        

        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(placeHolder.GetComponent<TextMeshProUGUI>().text[counter]);
        //Debug.Log(m_text.GetComponent<TextMeshProUGUI>().text[counter]);
        /*m_text = GetComponent<InputFieldCustom>().text;
        if (m_text.Length > 0 && counter < placeHolder.GetComponent<TextMeshProUGUI>().text.Length)
        {
            if (Input.anyKey)
            {

               if (m_text[counter] == placeHolder.GetComponent<TextMeshProUGUI>().text[counter])
                {
                    counter += 1;
                    
                }
                else
                {

                    m_text.Remove(counter);
                }
            }
        }*/
    }
}
