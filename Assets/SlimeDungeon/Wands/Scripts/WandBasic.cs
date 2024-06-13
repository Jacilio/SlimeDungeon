using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandBasic : MonoBehaviour
{
    //recurso necessário para atirar
    public GameObject projectile;
    public PlayerLifeMana manaCast;
    public int manaPerShot, mana;
    public float fireRate, fireRateMax;

    //força do projétil
    public float projectForce;



    //referências para o tiro
    public Camera playerCamera;
    public Transform attackPoint;

    private void Start()
    {
        manaCast = GameObject.Find("PlayerROOT").GetComponent<PlayerLifeMana>();
        mana = manaCast.mana;
    }

    private void Update()
    {
        if(Input.GetAxis("Fire1") == 1 && fireRate<=0 && mana > 0)
        {
            Shoot();
        }
        FireRate();
    }

    public void Shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        //checar se o raio atingiu alguma coisa
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;

        }
        else
        {
            targetPoint = ray.GetPoint(100);

        }
        //calculo de direção do projétil
        Vector3 attackDirection = targetPoint - attackPoint.position;

        //instatiate projectile
        GameObject cP = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        cP.transform.forward = attackDirection.normalized;

        cP.GetComponent<Rigidbody>().AddForce(attackDirection.normalized * projectForce, ForceMode.Impulse);

        manaCast.ManaCast(manaPerShot);
        fireRate = fireRateMax;




    }


    public void FireRate()
    {
        fireRate -= 1 * Time.deltaTime;
    }
}
