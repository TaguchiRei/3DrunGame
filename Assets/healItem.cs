using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    [SerializeField] float heal = 5;
    public override void Use()
    {
        FindObjectOfType<GameManager>().HpFluctuation(heal*-1);
    }
}
