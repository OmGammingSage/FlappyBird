using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdChange : MonoBehaviour
{

    private Bird _Bird;
    [SerializeField] private PipeSpawner _pipeSpawner;
    
    private void Start()
    {
        _Bird = GetComponent<Bird>();
    }

    public void ChangeBird(int IsOne)
    {
        int index = CurrentBird();

        if (1 == IsOne)
        {
            index++;
            if (index >= transform.childCount)
            {
                index = 0;
                transform.GetChild(transform.childCount-1).gameObject.SetActive(false);
                transform.GetChild(index).gameObject.SetActive(true);
            }
            else
            {
                int swich = index;
                if (swich == 0)
                {
                    swich = transform.childCount-1;
                }
                else
                {
                    swich--;
                }
                transform.GetChild(swich).gameObject.SetActive(false);
                transform.GetChild(index).gameObject.SetActive(true);
            }
        }
        else
        {
            index--;
            if (index < 0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                index = transform.childCount-1;
                transform.GetChild(index).gameObject.SetActive(true);
            }
            else
            {
                int swich = index;
                if (index == transform.childCount-1)
                {
                    swich = 0;
                }
                else
                {
                    swich++;
                }
                transform.GetChild(swich).gameObject.SetActive(false);
                transform.GetChild(index).gameObject.SetActive(true);
            }
        }
    }

    private int CurrentBird()
    {
        int current = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy)
            {
                current = i;
            }
        }
        return current;
    }

}