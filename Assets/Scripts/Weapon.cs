using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // 5 Raycasting
    // The process of shooting an invisible ray from a point, in a specified direction, to detect whether any colliders lay in the path of the ray
    [SerializeField] private Camera FPCamera;

    // 6
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 30f;

    // 7
    [SerializeField] private ParticleSystem muzzleFlash;

    // 8
    [SerializeField] private GameObject hitEffect;

    //20
    [SerializeField] private Ammo ammoSlot;

    //200
    [SerializeField] private AmmoType ammoType;

    //21
    private bool canShoot = true;

    //25
    [SerializeField] private float timeBetweenShoots = 0.5f;

    //199
    private void OnEnable() // bug fix to delay the start coroutine delay
    {
        canShoot = true;
    }

    void Update()
    {
        if (/*Input.GetButtonDown("Fire1")*/ Input.GetMouseButtonDown(0) && canShoot == true) //5
        {
            //Shoot();

            // 22
            StartCoroutine(Shoot());
        }
    }

    //private void Shoot()
    //{
    //    //5
    //    //RaycastHit hit;
    //    //Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
    //    //// challange
    //    //Debug.Log("I hit this thing: " + hit.transform.name);

    //    //// 6
    //    //RaycastHit hit;
    //    //if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
    //    //{
    //    //    Debug.Log("I hit this thing: " + hit.transform.name);
    //    //    // TODO: add some hit effect for visual players
    //    //    EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

    //    //    // call a method on EnemyHealth that decreases the enemy's health
    //    //    if (target == null)
    //    //        return;

    //    //    target.TakeDamage(damage);
    //    //}
    //    //else
    //    //{
    //    //    return;
    //    //}

    //    // 7
    //    if (ammoSlot.GetCurrentAmmo() > 0)
    //    {
    //        PlayMuzzleFlash();
    //        ProcessRaycast();
    //        ammoSlot.ReduceAmmo();
    //    }
    //}

    // 24

    // 23
    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShoots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        // 7
        //RaycastHit hit;
        //if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        //{
        //    Debug.Log("I hit this thing: " + hit.transform.name);
        //    // TODO: add some hit effect for visual players
        //    EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

        //    // call a method on EnemyHealth that decreases the enemy's health
        //    if (target == null)
        //        return;

        //    target.TakeDamage(damage);
        //}
        //else
        //{
        //    return;
        //}

        // 8
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            // TODO: add some hit effect for visual players
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            // call a method on EnemyHealth that decreases the enemy's health
            if (target == null)
                return;

            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); // can be Quaternion.Identity too
        Destroy(impact, .1f);
    }
}
