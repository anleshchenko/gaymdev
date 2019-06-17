using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public void Start()
    {
        BulletsTotal = 12;
        ShootDelay = 0.5f;
        Reload();
        UpdateText();
    }
}
