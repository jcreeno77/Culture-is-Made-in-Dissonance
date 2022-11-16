using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikePhysics : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource adSrc;
    [SerializeField] AudioClip bikeRing;
    [SerializeField] GameObject mainCam;

    public bool win;

    private int winTalkSelect;
    private GameObject guy1;
    private GameObject guy2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        adSrc = GetComponent<AudioSource>();
        win = false;
        winTalkSelect = 0;
        guy1 = transform.GetChild(0).gameObject;
        guy2 = transform.GetChild(1).gameObject;
    }
    private void Update()
    {
        if (win)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                float force = mainCam.GetComponent<EventManager>().WPM / 20;
                rb.AddForceAtPosition(new Vector2(55 * force, 0), new Vector2(transform.position.x - 2f, transform.position.y - 1.2f));
                adSrc.PlayOneShot(bikeRing);
            }
            if (Input.anyKeyDown)
            {
                winTalkSelect++;
                if(winTalkSelect % 2 == 0)
                {
                    guy1.GetComponent<AudioSource>().Play();
                    guy1.GetComponent<guyTalk>().talkNow = true;
                    guy1.GetComponent<guyTalk>().timer = 0;
                }
                else
                {
                    guy2.GetComponent<AudioSource>().Play();
                    guy2.GetComponent<guyTalk2>().talkNow = true;
                    guy2.GetComponent<guyTalk2>().timer = 0;
                }
            }
        }
    }

    private void OnEnable()
    {
        //InputFieldCustom
        EventManager.onEnterPressed += addForce;
    }

    private void OnDisable()
    {
        EventManager.onEnterPressed -= addForce;
    }

    void addForce()
    {
        float force = mainCam.GetComponent<EventManager>().WPM / 20;
        rb.AddForceAtPosition(new Vector2(45*force, 0), new Vector2(transform.position.x-2f, transform.position.y-1.5f));
        adSrc.PlayOneShot(bikeRing);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        win = true;
    }
}
