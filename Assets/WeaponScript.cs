using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WeaponScript : MonoBehaviour
{
    public TargetingType targetingType = TargetingType.Close;
    public float baseSpeed;
    public float baseProjectileSpeed;

    public GameObject projectile;
    
    private Timer _timer;

    public float SpeedModifer { get => _timer.Modifier; set => _timer.Modifier = value; }

    public float ProjectileSpeedModifier { get; set; }
    private void Start()
    {
        _timer = new Timer(baseSpeed);
        ProjectileSpeedModifier = 1;
        Shoot();
    }
    
    private void Update()
    {
        _timer.Tick(Shoot);
    }
    
    private bool Shoot()
    {
            var transform1 = transform;
            var pro = Instantiate(projectile, transform1.position, transform1.rotation);
            var script = pro.GetComponent<ProjectileScript>();
            script.direction = (GetTargetPosition() - transform.position).normalized;
            script.speed =baseProjectileSpeed * ProjectileSpeedModifier;
            return true;
    }
    
    private Vector3 GetTargetPosition()
    {
        var position = transform.position;
        var enemies = GameObject.FindGameObjectsWithTag("Enemy")
            .OrderBy(enemy =>
            {
                var enemyPosition = transform.position;
                return Math.Sqrt(Math.Pow(position.x - enemyPosition.x, 2) + Math.Pow(position.y - enemyPosition.y, 2));
            })
            .ToList();
        
        if (enemies.Count == 0)
            return Vector3.left;
    
        return targetingType switch
        {
            TargetingType.Far => enemies.Last().transform.position,
            TargetingType.Close => enemies.First().transform.position,
            TargetingType.Random => enemies[Random.Range(0, enemies.Count)].transform.position,
            TargetingType.None => Vector3.left,
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