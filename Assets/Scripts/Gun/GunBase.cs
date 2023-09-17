using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [Header("Prefabs")]
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public Transform playerSideReference;

    [Header("Props")]
    public float timeBetweenShoot = 1f;


    [Header("Sound")]
    public AudioSource shootSound;

    private Coroutine _currentCoroutine;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        } else if (Input.GetKeyUp(KeyCode.R))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
        shootSound.Play();
    }
}
