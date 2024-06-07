using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    #region GetInstance

    public static PipeSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion
    
    [SerializeField] private GameObject[] _PipePrefabs;

    [SerializeField] private float _MaxposY;
    [SerializeField] private float _MinposY;
    
    [SerializeField] private float _SpawneTime;

    [SerializeField] private PipeMove _PipeMove;

    [SerializeField] private int _SpawnePipe;
    
    
    private List<GameObject> _Pipes;
    
    private int Index;

    public void SpawnePipe()
    {
        DestroyPipes();
        _PipeMove.transform.position = Vector3.zero;
        _Pipes = new List<GameObject>(_SpawnePipe);
        for (int i = 0; i < _SpawnePipe; i++)
        {
            GameObject obj = Instantiate(_PipePrefabs[Index], transform.position, quaternion.identity, _PipeMove.transform);
          _Pipes.Add(obj);   
          obj.gameObject.SetActive(false);
        }
    }

    public int SetIndex
    {
        set
        {
            Index = value;
        }
    }

    public void StartSpawne()
    {
        StartCoroutine("ActivePipe");
    }

    public void StopSpawne()
    {
      StopCoroutine("ActivePipe");
    }

    public void OffObject()
    {
        for (int i = 0; i < _Pipes.Count; i++)
        {
                _Pipes[i].gameObject.SetActive(false);
        }
    }
    
    private IEnumerator ActivePipe()
    {
        Active();
        yield return new WaitForSeconds(_SpawneTime);
        StartSpawne();
    }

    private void DestroyPipes()
    {
        if (_Pipes != null)
        {
            for (int i = 0; i < _Pipes.Count; i++)
            {
                Destroy(_Pipes[i].gameObject);
            }

            _Pipes = null;
        }
    }
    private void Active()
    {
        for (int i = 0; i < _Pipes.Count; i++)
        {
            if (!_Pipes[i].gameObject.activeInHierarchy)
            {
                _Pipes[i].transform.position = new Vector3(transform.position.x,Random.Range(_MinposY,_MaxposY), 0);
                _Pipes[i].gameObject.SetActive(true);
                return;
            }
        }
    }
    
}
