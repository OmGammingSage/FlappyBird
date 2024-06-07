using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
  Hit,Die,Swooshing,Wing
}

public class SoundManager : MonoBehaviour
{

  #region GetInstance

  public static SoundManager Instance;

  private void Awake()
  {
    Instance = this;
  }
  
  #endregion
  
  [SerializeField] private AudioSource _AudioSource;
  [SerializeField] private AudioSource _PointAudioSource;

  
 
  [System.Serializable]
  public class Sounds
  {
    public SoundType _SoundType;
    public AudioClip Audio;
  }

  public List<Sounds> _sounds;

  public void Play(int index)
  {
    _AudioSource.clip = _sounds[index].Audio;
    _AudioSource.Play();
  }

  public void PointSoundPlay()
  {
    _PointAudioSource.Play();
  }
}
