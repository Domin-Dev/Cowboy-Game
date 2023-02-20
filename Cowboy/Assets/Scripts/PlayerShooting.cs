using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] GameObject bullet;

    Transform shootingTransform;
    Transform gunTransform;
    Animator animator;
    ParticleSystem particleSystem;
    Animator particleAnimator;


    void Start()
    {
        shootingTransform = transform.GetChild(1).transform;
        gunTransform = shootingTransform.GetChild(0).transform;
        animator = gunTransform.GetChild(0).GetComponent<Animator>();
        particleSystem = gunTransform.GetChild(0).GetComponentInChildren<ParticleSystem>();
        particleAnimator = gunTransform.GetChild(0).GetChild(1).GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shot();
        }


        UpdateGun();

        if(shotTimer > 0)
        {
            shotTimer -= Time.deltaTime;
            if(shotTimer <= 0)
            {
                canShot = true;
            }
        }
    }

    bool canShot = true;
    float shotTimer;
    private void Shot()
    {
        if (canShot)
        {
            Transform bulletTransform = Instantiate(bullet, particleSystem.transform.position, Quaternion.identity).transform;

            Vector3 shootDir = (Functions.GetMousePosition() - shootingTransform.position).normalized;
            bulletTransform.GetComponent<Bullet>().SetUp(shootDir);

            SoundManager.Instance.PlaySound(0);
            particleAnimator.SetTrigger("Shot");
            particleSystem.Play();
            animator.SetTrigger("Shot");
            UpdateGun();
            SetShotTimer();
        }
    }

    private void SetShotTimer()
    {
        canShot = false;
        shotTimer = 0.5f;
    }

    float currentVelocity1;
    private void UpdateGun()
    {
        float recoil = 0;
        Vector3 mousePosition = Functions.GetMousePosition();

        Vector3 aimDirection = (mousePosition - shootingTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + recoil;
        angle = Mathf.SmoothDampAngle(shootingTransform.eulerAngles.z, angle, ref currentVelocity1, 0.07f);
        shootingTransform.localRotation = Quaternion.Euler(0, 0, angle);

        if (mousePosition.x - shootingTransform.position.x >= 0)
        {
            gunTransform.localRotation = new Quaternion(0, 0, gunTransform.localRotation.z, 0);
        }
        else
        {
            gunTransform.localRotation = new Quaternion(180, 0, gunTransform.localRotation.z, 0);
        }
    }



}
