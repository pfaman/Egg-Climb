using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EggShoot : MonoSingleton<EggShoot>
{
    public event Action EggTossed;

    public void EggShootEventButton()
    {
        EggTossed?.Invoke();
    }
}
