using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgItem : Item
{
    [SerializeField] float _dmg = 5; 
    public override void Use()
    {
        FindObjectOfType<GameManager>().HpFluctuation(_dmg);
        Debug.Log("A");
    }
}
