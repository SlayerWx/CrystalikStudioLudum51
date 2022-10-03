using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinLevel : Level
{

    [SerializeField] private Penguin _penguin;
    [SerializeField] private PenguinPlatformsController _platformsController;

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        _penguin.ResetPenguin();
        _platformsController.ResetPlatforms();
    }





}
