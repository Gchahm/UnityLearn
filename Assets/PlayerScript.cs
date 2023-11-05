using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public List<GameObject> weapons;
    public Rigidbody2D body;
    
    public float baseSpeed;
    
    public readonly List<GameObject> Weapons = new();

    public float SpeedModifier { get; set; }
    
    private void Start()
    {
        SpeedModifier = 1;
        foreach (var weapon in weapons)
        {
            var transform1 = transform;
            var go = Instantiate(weapon, transform1.position, transform1.rotation, transform1);
            Weapons.Add(go);
        }
    }

    private void Update()
    {
        var movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        var clampedMovement = Vector2.ClampMagnitude(movement, 1);
        body.MovePosition(body.position + clampedMovement * (baseSpeed * SpeedModifier * Time.fixedDeltaTime));
    }
}