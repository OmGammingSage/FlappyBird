using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
  public float _moveSpeed;
  private void Update()
  {
    transform.Translate(Vector3.left* _moveSpeed *Time.deltaTime);
  }
}
