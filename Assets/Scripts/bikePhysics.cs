using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikePhysics : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource adSrc;
    [SerializeField] AudioClip bikeRing;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        adSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(5, 5));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-5, 5));
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
        rb.AddForceAtPosition(new Vector2(200, 0), new Vector2(transform.position.x-2f, transform.position.y-2f));
        adSrc.PlayOneShot(bikeRing);
    }
}
