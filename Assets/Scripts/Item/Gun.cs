using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    
    [SerializeField]private int damage = 10;
    [SerializeField]private float range = 100f;
    [SerializeField]private int magazine = 10;
    [SerializeField]private int rounds;
    [SerializeField]private int reserves;

    [SerializeField]private Camera cam;
    [SerializeField]private GameObject bullet;
    [SerializeField]private Transform BulletSpawn;
    public TextMeshProUGUI roundsText;
    public TextMeshProUGUI reservesText;

    public int _reserves{get{return reserves;} set{reserves = value;}}
    public int _magazine{get{return magazine;} set{magazine = value;}}

    private void Start() 
    {
        rounds = magazine;
        roundsText = GameObject.Find("Canvas/Rounds HUD").GetComponent<TextMeshProUGUI>();
        reservesText = GameObject.Find("Canvas/Reserves HUD").GetComponent<TextMeshProUGUI>();

        updateText();

    }

    public void ShootBullet()
    {
        if(rounds <= 0 && reserves <= 0) return;
        if(rounds <= 0)
        {
            if(reserves >= magazine)
            {
                rounds += magazine;
                reserves -= magazine;
            }
            else
            {
                rounds += reserves;
                reserves -= reserves;
            }
        }

        rounds--;

        updateText();

        GameObject shotBullet = Instantiate(bullet, BulletSpawn.position, transform.rotation);
        Bullet shotBulletScript = shotBullet.GetComponent<Bullet>();
        shotBulletScript._damage = damage;
    }

    private void SniperShoot()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo, range))
        {
            Health target = hitInfo.transform.GetComponent<Health>();
            if(target != null)
            {
                target.damage((int)damage);
            }
        }
    }

    public void updateText()
    {
        roundsText.text = "Rounds: " + rounds;
        reservesText.text = "Reserves: " + reserves;
    }
}
