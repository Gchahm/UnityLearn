using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public Vector3 direction;

    public float speed;

    public double baseDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }
}
