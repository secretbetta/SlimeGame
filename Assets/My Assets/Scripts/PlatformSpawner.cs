using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject target;
    public int count = 0;
    
    public float dist_y = 1.3f;

    public float confine_x_left;
    public float confine_x_right;
    void Awake() {
        Vector3 curr_position = target.transform.position;
        Vector3 curr_angles = target.transform.eulerAngles;
        Quaternion quat = new Quaternion();
        quat = Quaternion.Euler(curr_angles.x, curr_angles.x, curr_angles.x);
        float curr_y = curr_position.y;
        while (count > 0) {
            curr_position.y += dist_y;
            curr_position.x = Random.Range(confine_x_left, confine_x_right);
            GameObject newobj = GameObject.Instantiate(target, curr_position, quat);
            // newobj.
            print("Made object at (x,y): " + curr_position.x + "," + curr_position.y);
            count--;
        }
    }



    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
