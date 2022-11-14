using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikePhysics : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource adSrc;
    [SerializeField] AudioClip bikeRing;
    [SerializeField] GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        adSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

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
        float force = mainCam.GetComponent<EventManager>().WPM / 10;
        rb.AddForceAtPosition(new Vector2(25*force, 0), new Vector2(transform.position.x-2f, transform.position.y-1.5f));
        adSrc.PlayOneShot(bikeRing);
    }
}
