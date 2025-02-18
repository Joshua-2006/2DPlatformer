using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Movement player;
    public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Movement>();
        StartCoroutine(Wait2());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(2);
        bc.enabled = true;
    }
}
