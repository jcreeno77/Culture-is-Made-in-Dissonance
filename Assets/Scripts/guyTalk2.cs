using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guyTalk2 : MonoBehaviour
{
    [SerializeField] GameObject mainCam;
    public bool talkNow;
    float timer;
    [SerializeField] Sprite talking_spr;
    [SerializeField] Sprite normal_spr;
    AudioSource audSrc;
    // Start is called before the first frame update
    void Start()
    {
        talkNow = false;
        timer = 0;
        audSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (talkNow)
        {
            GetComponent<SpriteRenderer>().sprite = talking_spr;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = normal_spr;
        }

        if(timer > .06f)
        {
            talkNow = false;
        }
        timer += Time.deltaTime;
    }

    private void OnEnable()
    {
        EventManager.onCorrectCharPressed += willTalk;
    }
    private void OnDisable()
    {
        EventManager.onCorrectCharPressed -= willTalk;
    }

    void willTalk()
    {
        if (mainCam.GetComponent<EventManager>().playerTurn % 2 != 0)
        {
            talkNow = true;
            timer = 0;
            audSrc.Play();
            Debug.Log("Things happening");
        }
        
    }

}
