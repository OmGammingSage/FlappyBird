using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField] private Material[] _Material;

    private Material _CureentMaterial;

    [SerializeField] private float _MoveSpeed;

    private int _CurrentIndex=0;
    
    private void Start()
    {
        ChangeMaterial(_CurrentIndex);
    }

    private void Update()
    {
         Vector2 offset = _CureentMaterial.GetTextureOffset("_MainTex");
         offset.x += Time.deltaTime * _MoveSpeed;
         _CureentMaterial.SetTextureOffset("_MainTex",offset);
    }

    public void ChangeMaterial(int index)
    {
        GetComponent<MeshRenderer>().material = _Material[index];
        _CureentMaterial = GetComponent<MeshRenderer>().material;
        _CurrentIndex = index;
        PipeSpawner.Instance.SetIndex = index;
    }
}
