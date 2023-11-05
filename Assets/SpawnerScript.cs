using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        _timer = new Timer(2);
    }

    // Update is called once per frame
    void Update()
    {
       _timer.Tick(AddEnemy); 
    }

    bool AddEnemy()
    {
        var transform1 = transform;
        Instantiate(enemy, transform1.position, transform1.rotation);
        return true;
    }
}
