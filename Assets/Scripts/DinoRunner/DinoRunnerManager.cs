using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoRunnerManager : Level
{
    public GameObject[] presets;
    public Transform spawn;
    public int presetSelected;
    void OnEnable()
    {
        presetSelected = Random.Range(0, presets.Length);
        Instantiate(presets[presetSelected], spawn.position,Quaternion.identity,spawn);
        Debug.Log(presetSelected);

    }

}
