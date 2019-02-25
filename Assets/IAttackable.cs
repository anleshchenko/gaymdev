using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    void Attack(float damage);
    Vector2 GetPosition();
}
