using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : MonoBehaviour
{
    private Rigidbody2D myrigidbody;
    public Vector3 destination = Vector3.zero;

    void Awake()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Player") return;
        myrigidbody.AddForce(transform.up * 15, ForceMode2D.Impulse);
        StartCoroutine(BossCoroutine());
    }

    IEnumerator BossCoroutine() {
        yield return new WaitForSecondsRealtime(2);
        transform.position = destination;
    }
}
