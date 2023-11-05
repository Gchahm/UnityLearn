using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float walkingSpeed = 3;
    private Rigidbody2D _player;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var clampedMovement = Vector2.ClampMagnitude(_player.position - body.position, 1);
        body.MovePosition(body.position + clampedMovement * (walkingSpeed * Time.fixedDeltaTime));
    }
}
