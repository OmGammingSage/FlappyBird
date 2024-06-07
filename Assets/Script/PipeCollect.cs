using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollect : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Pipe"))
      {
         other.transform.parent.gameObject.SetActive(false);
      }
   }
}
