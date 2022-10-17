using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int heart = 100;

    private Transform taget;
    private int wavePointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        taget = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = taget.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, taget.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        taget = Waypoints.points[wavePointIndex];
    }
    void EndPath()
    {
        Destroy(gameObject);
        PlayerStart.Lives--;
    }

    void TakeDamage(int amount)
    {
        heart -= amount;
        if(heart < 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
