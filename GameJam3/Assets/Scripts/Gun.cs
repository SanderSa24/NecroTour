using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public enum GunType {
		Pistol,Shotgun,Machinegun
	};

	public static GunType gunType;
	[Header ("Gun attributes")]
	public Sprite sprite;
    SpriteRenderer spriteRenderer;
    public Sprite playerPistol, playerMachinegun, playerShotgun;
    public int magSize;
	public float reloadSpeed;
	public float fireRate;
	float machineGunFireRatio =1;
	public Vector3 barrel;
	public GameObject bullet, shotgunBullet;

	private GameObject bulletStartPosition, shotgunBulletSpawn;
	private GameObject player;
	private float nextFire = 0f;

    [HideInInspector]
    public bool outOfAmmo;
    [HideInInspector]
    public bool noHandgunAmmo;
    [HideInInspector]
    public bool noShotgunAmmo;
    [HideInInspector]
    public bool noMachinegunAmmo;

    // Use this for initialization
    void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		bulletStartPosition = GameObject.FindGameObjectWithTag ("GunBarrel");
        shotgunBulletSpawn = GameObject.FindGameObjectWithTag("ShotgunBulletSpawn");
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {




	}

	void FixedUpdate () {
		//changing weapons by pressing alpha nums
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ChangeWeapon (GunType.Pistol);
            spriteRenderer.sprite = playerPistol;
            Debug.Log ("Pistol");
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ChangeWeapon (GunType.Shotgun);
            spriteRenderer.sprite = playerShotgun;
            Debug.Log ("ShotGUn");
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ChangeWeapon (GunType.Machinegun);
            spriteRenderer.sprite = playerMachinegun;
            Debug.Log ("MachineGun");
		}

		//shooting if not out of ammo
		if (Input.GetAxis ("Fire1") > 0 && (gunType == GunType.Pistol)) {
			if (PlayerAmmoManager.pistolClip > 0) {
                ShootPistol ();                
			} else if (PlayerAmmoManager.pistolClip <= 0)
            {
                //noHandgunAmmo = true;
                outOfAmmo = true;
                FindObjectOfType<AudioManager>().Play("Empty_Gun");
            }
		} else if (Input.GetAxis ("Fire1") > 0 && (gunType == GunType.Shotgun)) {
			if (PlayerAmmoManager.shotgunClip > 0) {
                ShootShotGun ();                
			}
            else if (PlayerAmmoManager.shotgunClip <= 0)
            {
                //noShotgunAmmo = true;
                outOfAmmo = true;
                FindObjectOfType<AudioManager>().Play("Empty_Gun");
            }
        } else if (Input.GetAxis ("Fire1") > 0 && (gunType == GunType.Machinegun)) {
			if (PlayerAmmoManager.machinegunClip > 0) {
                ShootMachineGun ();                
			}
            else if (PlayerAmmoManager.machinegunClip <= 0)
            {
                //noMachinegunAmmo = true;
                outOfAmmo = true;
                FindObjectOfType<AudioManager>().Play("Empty_Gun");
            }
        }
	}

	public void ShootPistol () {
		//Shooting with a pistol
		if (gunType == GunType.Pistol) {
			//Input.GetKeyDown for non automatic shooting
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				if (Time.time > nextFire) {
					Quaternion rot = Quaternion.LookRotation (player.transform.position - Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector3.forward);
					nextFire = Time.time + fireRate;
					FindObjectOfType<AudioManager> ().Play ("Gunshot");
					Instantiate (bullet, bulletStartPosition.transform.position, rot);
					PlayerAmmoManager.pistolClip -= 1;
				}
			}
		}
	}
	public void ShootShotGun(){

		//Shooting with a shotgun
		if (gunType == GunType.Shotgun) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				Quaternion rot = Quaternion.LookRotation (player.transform.position - Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector3.forward);
				nextFire = Time.time + fireRate;
				FindObjectOfType<AudioManager> ().Play ("ShotgunShot");
				GameObject shotgunBullets = Instantiate (shotgunBullet, shotgunBulletSpawn.transform.position, rot);
				PlayerAmmoManager.shotgunClip -= 1;
			}

		}
	} 

		public void ShootMachineGun(){
		//Shooting with a assault rifle
		if (gunType == GunType.Machinegun) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				if (Time.time > nextFire) {
					Quaternion rot = Quaternion.LookRotation (player.transform.position - Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector3.forward);
					nextFire = Time.time + fireRate * machineGunFireRatio;
					FindObjectOfType<AudioManager> ().Play ("Gunshot");
					Instantiate (bullet, bulletStartPosition.transform.position, rot);
					PlayerAmmoManager.machinegunClip -= 1;
				}
			}
		}
	}

	public void ChangeWeapon (GunType newGunType) {
		//When you are changing to a pistol
		/*if (newGunType == GunType.Pistol) {
			magSize = 6;
			reloadSpeed = 2f;
			fireRate = 0.0f;
		}

		//When you are changing to a shotgun
		if (newGunType == GunType.Shotgun) {
            magSize = 2;
			reloadSpeed = 5f;
			fireRate = 0.5f;
		}*/

		gunType = newGunType;
	}
}
 