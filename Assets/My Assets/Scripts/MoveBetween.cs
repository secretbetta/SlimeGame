using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    private Transform ThisTransform = null;
    public Vector3 startPos = Vector3.zero;
    public Vector3 endPos = Vector3.zero;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Awake ()
    {
        ThisTransform = GetComponent<Transform>();
    }

    void Update()
    {
        print(Mathf.MoveTowards(-7, 7, speed));
        ThisTransform.position.Set(Mathf.MoveTowards(startPos.x, endPos.x, speed), ThisTransform.position.y, ThisTransform.position.z);
    }

    private void pingPong() {
        ThisTransform.position.Set(Mathf.MoveTowards(startPos.x, endPos.x, speed), ThisTransform.position.y, ThisTransform.position.z);
    }
}
