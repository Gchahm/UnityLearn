using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public List<GameObject> weapons;
    public Rigidbody2D body;
    public float speed;
    
    private Vector2 _movement;

    private void Start()
    {
        foreach (var weapon in weapons)
        {
            var transform1 = transform;
            var pro = Instantiate(weapon, transform1.position, transform1.rotation, transform1);
        }
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        var clampedMovement = Vector2.ClampMagnitude(_movement, 1);
        body.MovePosition(body.position + clampedMovement * (speed * Time.fixedDeltaTime));
    }
}