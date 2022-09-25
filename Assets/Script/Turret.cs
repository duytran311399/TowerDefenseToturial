using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public Transform partToRotate;

    [Header("Attribute")]
    public float range = 15f;
    public float fireRate = 1.0f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public GameObject bulletPrepab;
    public Transform bulletFirePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);                  // Kiem tra enemy gan nhat 5 lan 1s
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;         // Vi tri cua target
        Quaternion lookRotation = Quaternion.LookRotation(dir);     // Goc quay giua turret ban dau vs khi nhin vao target
        Vector3 rotation = lookRotation.eulerAngles;                // gan ratation = vs goc quay cua turret
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //////////// Bo dem nguoc turret fire
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO =  Instantiate(bulletPrepab, bulletFirePoint.position, bulletFirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.seekTarget(target);
        }
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;                    // khoang cach vs enemy gan nhat
        GameObject nearestEnemy = null;                             // enemy gan nhat
        foreach (GameObject enemy in enemies)
        {
            float distanceEnemy = Vector3.Distance(transform.position, enemy.transform.position); // khoang cach cua tung enemy
            if (distanceEnemy <= shortestDistance)                  // kiem tra khoang cach cua tung enemy vs khong cach ngan nhat
            {
                shortestDistance = distanceEnemy;                   // gan khoang cach ngan nhat = khoang cach vs enemy
                nearestEnemy = enemy;                               // gan enemy gan nhat = enemy
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
