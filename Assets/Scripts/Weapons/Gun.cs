using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    
    private bool isReloading;
    private TextMeshProUGUI roundsText;
    private TextMeshProUGUI reservesText;
    private bool canShoot;
    private float shootTimer;
    [SerializeField]private Camera TPSCam;
    private Vector3 lookObject;
    [Header("Gun Specs")]
    [SerializeField]private float range = 100f;
    [SerializeField]private int rounds;
    [SerializeField]private int reserves;
    [SerializeField]private int damage = 10;
    [SerializeField]private int magazine = 10;
    [Range(0,1)][SerializeField] float shootingIntervals;
    [SerializeField] private float reloadTime;
    [SerializeField]private float bulletVelocity;

    [Header("Bullet Info")]
    [SerializeField]private GameObject bullet;
    [SerializeField]private Transform BulletSpawn;
    [SerializeField]private Transform HUD;


    public int _reserves{get{return reserves;} set{reserves = value;}}
    public int _magazine{get{return magazine;} set{magazine = value;}}
    public bool _canShoot{get{return canShoot;} set{canShoot = value;}}


    private void Start() 
    {
        shootTimer = shootingIntervals;
        isReloading = false;
        canShoot = true;
        rounds = magazine;
        roundsText = HUD.GetChild(1).GetComponent<TextMeshProUGUI>();
        reservesText = HUD.GetChild(2).GetComponent<TextMeshProUGUI>();
        TPSCam = Camera.main;

        Physics.gravity *= 2;

        updateText();

    }

    void Update()
    {
        checkReload();
        FindShootLocation();

    }

    void LateUpdate() 
    {
        
    }
    private void checkReload()
    {
        if (isReloading == true) return;

        if (shootTimer <= 0)
        {
            canShoot = true;
            shootTimer = shootingIntervals;
        }

        if (canShoot == false)
        {
            shootTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
            return;
        }

        if (rounds <= 0 && Input.GetMouseButtonDown(0))
        {
            if (reserves >= magazine)
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

    private void FindShootLocation()
    {
        Ray cameraRay = new Ray(TPSCam.transform.position, TPSCam.transform.forward);
        RaycastHit hitInfo;
        
        if(Physics.Raycast(cameraRay, out hitInfo ,range))
        {
            lookObject = hitInfo.point;
        }
        else
        {
            Vector3 point = cameraRay.origin + (cameraRay.direction * range);
            lookObject = point;
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
        Vector3 direction = (lookObject - (BulletSpawn.position)).normalized;
        shotBulletScript._Direction =  direction;
        shotBulletScript._Speed = bulletVelocity;
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
}
