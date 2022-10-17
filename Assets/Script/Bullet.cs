using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    
    public void seekTarget(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;                           // khoang cach trong 1 khung
        if (dir.magnitude <= distanceThisFrame)                                     //neu do dai vector <= khoang cach vien dan trong 1 khung
        {
            HitTarget();
            Destroy(target.gameObject);
            //Debug.Log("magnitude: " + dir.magnitude);
            return;
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);
    }
    /// <summary>
    /// //////// ban chung cai j do thi destroy bullet
    /// </summary>
    void HitTarget()                
    {
        GameObject effectInt = Instantiate(impactEffect, target.position, target.rotation);
        Destroy(effectInt, 2f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
