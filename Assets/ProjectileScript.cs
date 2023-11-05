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
        StartCoroutine(DelayedHit());
    }

    private IEnumerator DelayedHit()
    {
        yield return new WaitForSeconds(hitDelay);
        Hit();
    }
    

    public void OnTriggerEnter2D(Collider2D col)
    {
        Hit();
    }

    private void Hit()
    {
        lives -= 1;
        if (lives <= 0)
            Destroy(gameObject);
    }
}