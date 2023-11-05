using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public float hitDelay = 0.02f;

    public float baseDamage;

    public int lives;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(DelayedHit(col.collider));
    }

    private IEnumerator DelayedHit(Collider2D col)
    {
        yield return new WaitForSeconds(hitDelay);
        Hit(col);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Hit(col);
    }

    private void Hit(Collider2D col)
    {
        Destroy(col.gameObject);
        lives -= 1;
        if (lives <= 0)
            Destroy(gameObject);
    }
}