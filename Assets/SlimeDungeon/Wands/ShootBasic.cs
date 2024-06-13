using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBasic : MonoBehaviour
{
    public PlayerLifeMana mana;
    public GameObject basicProjectile;
    public Transform shootPoint, shootDirection;
    public Camera playerCamera;

    public float fireRate, fireRateMax;

    private void Start()
    {
        mana = GameObject.Find("PlayerROOT").GetComponent<PlayerLifeMana>();
    }


    // Update is called once per frame
    void Update()
    {
        FireRate();
        Shoot();
    }
    public void Shoot()
    {
        //calcula a direção que a camera aponta
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 targetpoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetpoint = hit.point;
        }
        else
        {
            targetpoint = ray.GetPoint(100);
        }
        //calcula a direferença das distâncias dos pontos, decidindo a diereção do projétil
        Vector3 targetDirection = targetpoint - shootDirection.position;

        //condição para instanciar o objeto na cena
        if (mana.mana > 0 && Input.GetMouseButtonDown(0) && fireRate <= 0)
        {
            GameObject currentProjectile = Instantiate(basicProjectile, shootPoint.position, Quaternion.identity);
            mana.mana--;
            currentProjectile.transform.forward = targetDirection.normalized;
            fireRate = fireRateMax;
        }
        
    }
    public void FireRate()
    {
        fireRate -= 1 * Time.deltaTime;
    }

}
