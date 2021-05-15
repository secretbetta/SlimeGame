using UnityEngine;
using System.Collections;

///<summary></summary>
public class PingPongMovement : MonoBehaviour 
{
  private Transform ThisTransform = null;

  private Vector3 OrigPos = Vector3.zero;

  public Vector3 MoveAxes = Vector2.zero;

  public float Distance = 3f;
  public float Speed = 1f;

  void Awake ()
  {
    ThisTransform = GetComponent<Transform>();

    OrigPos = ThisTransform.position;
  }

  void Update () 
  {
    ThisTransform.position = OrigPos + MoveAxes * Mathf.PingPong(Time.time * Speed, Distance);
  }
}