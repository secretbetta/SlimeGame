using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlime : MonoBehaviour
{
    private Rigidbody2D myrigidbody;
    private bool runaway = false;
    public Vector3 destination = Vector3.zero;
    public Text dialogue;

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
        if (!runaway) {
            myrigidbody.AddForce(transform.up * 15, ForceMode2D.Impulse);
            StartCoroutine(BossCoroutine());
            print("Finish Routine");
            runaway = true;
        }
    }

    IEnumerator BossCoroutine() {
        yield return new WaitForSecondsRealtime(2);
        transform.position = destination;
        dialogue.text = "Nooo you got me! Not my treasure!";
        Vector3 scaleChange = transform.GetChild(0).localScale;
        scaleChange.x *= -1;
        transform.GetChild(0).localScale = scaleChange;
    }
}
