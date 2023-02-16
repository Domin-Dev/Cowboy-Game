using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{
    public event EventHandler OnShot;
    

    Transform shootingTransform;
    Transform gunTransform;
    Animator animator;
    ParticleSystem particleSystem;

    void Start()
    {
        shootingTransform = transform.GetChild(1).transform;
        gunTransform = shootingTransform.GetChild(0).transform;
        animator = gunTransform.GetChild(0).GetComponent<Animator>();
        particleSystem = gunTransform.GetChild(0).GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            particleSystem.Play();
            if (OnShot != null) OnShot(this, EventArgs.Empty);
            animator.SetTrigger("Shot");
            UpdateGun(true);
        }


        UpdateGun(false);
    }

    float currentVelocity1;

    private void UpdateGun(bool isRecoil)
    {
        float recoil = 0;
        Vector3 mousePosition = Functions.GetMousePosition();

        Vector3 aimDirection = (mousePosition - shootingTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + recoil;
        angle = Mathf.SmoothDampAngle(shootingTransform.eulerAngles.z, angle, ref currentVelocity1, 0.07f);
        shootingTransform.localRotation = Quaternion.Euler(0, 0, angle);

        if (mousePosition.x - shootingTransform.position.x >= 0)
        {
            if (isRecoil) recoil = 15;
            gunTransform.localRotation = new Quaternion(0, 0, gunTransform.localRotation.z, 0);
        }
        else
        {
            if (isRecoil) recoil = -15;
            gunTransform.localRotation = new Quaternion(180, 0, gunTransform.localRotation.z, 0);
        }
    }



}
