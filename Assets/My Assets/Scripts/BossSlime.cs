using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlime : MonoBehaviour
{
    private Rigidbody2D myrigidbody;
    private bool runaway = false;
    public GameObject NPC;
    public Vector3 destination = Vector3.zero;
    public Text dialogue;

    void Awake()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Player") return;
        if (!runaway) {
            myrigidbody.AddForce(transform.up * 15, ForceMode2D.Impulse);
            StartCoroutine(BossCoroutine());
            runaway = true;
        }
    }

    IEnumerator BossCoroutine() {
        GameObject NPCHelper = GameObject.Instantiate(NPC);
        NPCHelper.GetComponentInChildren<Text>().text = "He's getting away! Get to the top fast!";
        NPCHelper.SetActive(false);
        NPCHelper.transform.position = gameObject.transform.position;
        NPCHelper.transform.position += new Vector3(-2, 0, 10);
        yield return new WaitForSecondsRealtime(2);
        transform.position = destination;
        dialogue.text = "Nooo you got me! Not my treasure!";
        Vector3 scaleChange = transform.GetChild(0).localScale;
        scaleChange.x *= -1;
        transform.GetChild(0).localScale = scaleChange;
        NPCHelper.SetActive(true);

    }
}
