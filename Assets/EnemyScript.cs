using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float walkingSpeed;
    private Rigidbody2D _player;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var position = body.position;
        var clampedMovement = (_player.position - position).normalized;
        body.MovePosition(position + clampedMovement * (walkingSpeed * Time.fixedDeltaTime));
    }
}
