using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponScript : MonoBehaviour
{
    private float _timer;
    public float speed = 2;
    public TargetingType targetingType = TargetingType.Close;

    public GameObject projectile;
    
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }
    void Update()
    {
        if (_timer < speed)
            _timer += Time.deltaTime;
        else
        {
            _timer = 0;
            Shoot();
        }
    }
    
    private void Shoot()
    {
            var transform1 = transform;
            var pro = Instantiate(projectile, transform1.position, transform1.rotation);
            var script = pro.GetComponent<ProjectileScript>();
            script.direction = (GetTargetPosition() - transform.position).normalized;
            script.speed = 5;
    }

    private Vector3 GetTargetPosition()
    {
        return targetingType == TargetingType.None ? Vector3.zero : GetTarget().transform.position;
    }

    private GameObject GetTarget()
    {
        var position = transform.position;
        var enemies = GameObject.FindGameObjectsWithTag("Enemy")
            .OrderBy(enemy =>
            {
                var enemyPosition = transform.position;
                return Math.Sqrt(Math.Pow(position.x - enemyPosition.x, 2) + Math.Pow(position.y - enemyPosition.y, 2));
            })
            .ToList();
    
        return targetingType switch
        {
            TargetingType.Far => enemies.Last(),
            TargetingType.Close => enemies.First(),
            TargetingType.Random => enemies[Random.Range(0, enemies.Count)],
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public enum TargetingType
{
    None,
    Far,
    Close,
    Random
}