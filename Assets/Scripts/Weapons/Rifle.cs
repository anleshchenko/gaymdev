using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public void Start()
    {
        BulletsTotal = 30;
        ShootDelay = 0.25f;
        Reload();
    }
}
