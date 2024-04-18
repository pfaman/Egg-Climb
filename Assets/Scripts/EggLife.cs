using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggLife : MonoSingleton<EggLife>
{
    [SerializeField] private Sprite egg;
    [SerializeField] private Sprite eggCracked;

    public event Action GameOver;
    public event Action EggCrack;

    [SerializeField] private Image Egg1;
    [SerializeField] private Image Egg2;
    [SerializeField] private Image Egg3;
    [SerializeField] private Image Egg4;

    private int eggCount = 0;
    public bool eggRemains;

    private void Start()
    {
        Egg1.sprite = egg;
        Egg2.sprite = egg;
        Egg3.sprite = egg;
        Egg4.sprite = egg;
        eggRemains = true;
    }

    public void EggDisabled(int increment)
    {
        eggCount += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        EggCrack.Invoke();

        if(eggCount == 1)
        {
            Egg1.sprite = eggCracked;
        }
        else if(eggCount == 2)
        {
            Egg2.sprite = eggCracked;
        }
        else if(eggCount == 3)
        {
            Egg3.sprite = eggCracked;
        }
        else if(eggCount == 4)
        {
            eggRemains = false;
            Egg4.sprite = eggCracked;
            GameOver?.Invoke();
        }
    }
}
