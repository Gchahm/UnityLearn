using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public List<GameObject> weapons;

    private void Start()
    {
        foreach (var weapon in weapons)
        {
            var transform1 = transform;
            var pro = Instantiate(weapon, transform1.position, transform1.rotation);
        }
    }
}