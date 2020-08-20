using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    
    [SerializeField]private int damage = 10;
    public float range = 100f;
    [SerializeField]private int magazine = 10;
    [SerializeField]private int rounds;
    [SerializeField]private int reserves;
    private bool isReloading;
    public Camera cam;
    [SerializeField]private GameObject bullet;
    [SerializeField]private Transform BulletSpawn;
    public TextMeshProUGUI roundsText;
    public TextMeshProUGUI reservesText;
    [SerializeField] private float reloadTime;
    private bool canShoot;
    [SerializeField] float shootingIntervals;
    private float shootTimer;

    public int _reserves{get{return reserves;} set{reserves = value;}}
    public int _magazine{get{return magazine;} set{magazine = value;}}
    public bool _canShoot{get{return canShoot;} set{canShoot = value;}}


    private void Start() 
    {
        shootTimer = shootingIntervals;
        isReloading = false;
        canShoot = true;
        rounds = magazine;
        roundsText = GameObject.Find("Canvas/Rounds HUD").GetComponent<TextMeshProUGUI>();
        reservesText = GameObject.Find("Canvas/Reserves HUD").GetComponent<TextMeshProUGUI>();

        updateText();

    }

    void Update()
    {
        if(isReloading == true) return;

        if(shootTimer <= 0)
        {
            canShoot = true;
            shootTimer = shootingIntervals;
        }

        if(canShoot == false)
        {
            shootTimer -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
            return;
        }

        if(rounds <= 0 && Input.GetMouseButtonDown(0))
        {
            if(reserves >= magazine)
            {
                
                StartCoroutine(reload());
                return;
            }
            else
            {
                rounds += reserves;
                reserves -= reserves;
            }
        }
    }

    public void ShootBullet()
    {
        if(isReloading == true) return;
        if(rounds <= 0 && reserves <= 0) return;
        
        canShoot = false;
        rounds--;

        updateText();

        GameObject shotBullet = Instantiate(bullet, BulletSpawn.position, transform.rotation);
        Bullet shotBulletScript = shotBullet.GetComponent<Bullet>();
        shotBulletScript._damage = damage;
    }

    private IEnumerator reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        int reloadAmount = magazine - rounds;

        rounds += reloadAmount;
        reserves -= reloadAmount;

        updateText();

        isReloading = false;
    }

    public void updateText()
    {
        roundsText.text = "Rounds: " + rounds;
        reservesText.text = "Reserves: " + reserves;
    }

    private void OnDrawGizmos() 
    {
        
    }
}
