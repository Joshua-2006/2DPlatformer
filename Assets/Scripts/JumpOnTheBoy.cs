using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class JumpOnTheBoy : MonoBehaviour
{
    public UnityEvent us;
    public Animator am;
    public BoxCollider2D bc;
    public GameObject potion;
    public GameObject offset;
    public AudioSource a;
    public AudioClip ap;
    private void Update()
    {
        am = GetComponent<Animator>();
        a = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Death"))
        {
            a.PlayOneShot(ap);
            am.SetBool("IsDead", true);
            Instantiate(potion, offset.transform.position, transform.rotation);
            Destroy(gameObject, 2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            bc.enabled = false;
            am.SetBool("IsDead", true);
            Destroy(gameObject, 1.5f);
        }
    }
}
