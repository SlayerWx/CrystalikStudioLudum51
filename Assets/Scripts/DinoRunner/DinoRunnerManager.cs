using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoRunnerManager : Level
{
    public GameObject[] presets;
    public Transform spawn;
    void OnEnable()
    {
        Instantiate(presets[Random.Range(0,presets.Length)], spawn.position,Quaternion.identity,spawn);
    }

}
