using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon: MonoBehaviour
{
    public Text bulletsText;

    public int BulletsTotal { get; set; }
    public int CurrentBullets { get; set; }

    public float ShootDelay { get; set; }

    public bool CanShoot()
    {
        return CurrentBullets > 0;
    }

    public bool CanReload()
    {
        return CurrentBullets != BulletsTotal;
    }

    public void Shoot()
    {
        CurrentBullets--;
        UpdateText();
    }

    public void Reload()
    {
        CurrentBullets = BulletsTotal;
        UpdateText();
    }

    public void UpdateText()
    {
        bulletsText.text = CurrentBullets + "/" + BulletsTotal;
    }
}
