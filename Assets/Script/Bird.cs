using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bird : MonoBehaviour
{
   [SerializeField] private Rigidbody2D _Rb;

   [SerializeField] private float _Force;
   [SerializeField] private float _RotateSpeed;

   [SerializeField] private ScoreCounter _Score;
   

   private bool IsDie;

   private void FixedUpdate()
   {
      if (!IsDie)
      {
         if (_Rb.velocity.y < 0)
         {
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion.Euler(0, 0, -45), _RotateSpeed * Time.deltaTime);
         }
         else
         {
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion.Euler(0, 0, 0), _RotateSpeed * Time.deltaTime);
         }
      }
   }

   public void Fly()
   {
      if(IsDie)
         return;
      
      _Rb.velocity = Vector2.up *  _Force;
   }

   public void SetHomeMenu()
   {
      transform.rotation = Quaternion.identity;
      _Rb.bodyType = RigidbodyType2D.Kinematic;
      _Rb.velocity = Vector2.zero;
      transform.position = Vector2.zero;
   }
   public void GameStart()
   {
      IsDie = false;
      transform.rotation = Quaternion.identity;
      _Score.PlayAgain(); 
      _Rb.velocity = Vector2.zero;
      transform.position = Vector2.zero;
      _Rb.bodyType = RigidbodyType2D.Dynamic;
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if(IsDie)
         return;
         
      if (other.collider.CompareTag("Pipe") && !IsDie)
      {
         SoundManager.Instance.Play((int)SoundType.Hit);
         IsDie = true;
         GameOver();
         PipeSpawner.Instance.StopSpawne();
      }
      else if (other.collider.CompareTag("Ground"))
      {
         GameOver();
         SoundManager.Instance.Play((int)SoundType.Die);
         PipeSpawner.Instance.StopSpawne();
      }
   }

   private void GameOver()
   {
      GameManager.Instance.GameOver();
      _Score.SetScore();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Point"))
      {
         _Score.ScoreIncrese();
         SoundManager.Instance.PointSoundPlay();
      }
   }
}
