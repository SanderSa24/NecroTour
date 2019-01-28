using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmoManager : MonoBehaviour
{


    // ammo variables before the slash
    public static int pistolClip;
    public static int shotgunClip;
    public static int machinegunClip;

    //ammo variables after the slash

    public static int currentPistolAmmo;
    public static int currentMachinegunAmmo;
    public static int currentShotgunAmmo;

    int pistolAmmoUsed;
    int machinegunAmmoUsed;
    int shotgunAmmoUsed;

    bool reloading;
    public float reloadTime;
    public float nReloadTime;

    Text ammoText;
    AudioManager audiomanager;
    Gun gunScript;
    public bool tutorial;

    // Sprites for ammo
    public Image ammoImage;

    public float flashSpeed = 5f;                                   // The speed the outOfAmmoImage and reloadImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);         // The colour the damageImage is set to, to flash.
    public Image outOfAmmoImage;                                    // Reference to an image to flash on the screen on being hurt.

    public Color flashColourReload = new Color(1f, 0f, 0f, 0.1f);
    public Image reloadImage;

    public Sprite[] pistolAmmoSprites;
    public Sprite[] shotgunAmmoSprites;
    public Sprite[] machinegunAmmoSprites;



    // Use this for initialization

    // in de ammomanager word er ammunutie opgeteld en afgetrokken.
    // bij een pick up komt er ammunutie bij
    // bij het schieten gaat er ammunutie vanaf.
    // dit kan niet groter dan de max.ammo in de gamevariables.

    void Start()
    {
        ammoText = GetComponent<Text>();
        audiomanager = FindObjectOfType<AudioManager>();
        pistolClip = GameVariables.pistolMagazineSize;
        //GameVariables.maxAmmo = GameVariables.startingAmmo;
        reloadTime = nReloadTime;
        gunScript = FindObjectOfType<Gun>();
    }


    // Update is called once per frame
    void Update()
    {


        //ammo text laat shotgun/machine gun blabla zien
        //if ammo  = meer dan maxammo , ammo = maxammo
        // dit moet nog in de ui en is voor de ui , ook moet er Pistol Ammo : uit komen

        if (gunScript.outOfAmmo)
        {
            OutOfAmmo();
        }
        else
        {
            reloadImage.color = Color.Lerp(reloadImage.color, Color.clear, flashSpeed * Time.deltaTime);
            outOfAmmoImage.color = Color.Lerp(outOfAmmoImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        gunScript.outOfAmmo = false;

        if (Gun.gunType == Gun.GunType.Pistol)
        {
            if (pistolClip > 0)
            {
                ammoImage.sprite = pistolAmmoSprites[pistolClip];
            }
            else if (pistolClip <= 0)
            {
                ammoImage.sprite = pistolAmmoSprites[0];
            }
            //amText.text = " " + pistolClip + " / " + currentPistolAmmo;
           // ammoText.text = " x " + (currentPistolAmmo / GameVariables.pistolMagazineSize);
            ammoText.text = " / " + (currentPistolAmmo );

        }
        else if (Gun.gunType == Gun.GunType.Shotgun)
        {

            if (shotgunClip > 0)
            {
                ammoImage.sprite = shotgunAmmoSprites[shotgunClip];
            }
            else if (shotgunClip <= 0)
            {
                ammoImage.sprite = shotgunAmmoSprites[0];
            }
            ammoText.text = " / " + (currentShotgunAmmo );
           // ammoText.text = " x " + (currentShotgunAmmo / GameVariables.shotgunMagazineSize);
            // ammoText.text = " " + shotgunClip + " / " + currentShotgunAmmo;

        }
        else if (Gun.gunType == Gun.GunType.Machinegun)
        {
            if (machinegunClip > 0)
            {
                ammoImage.sprite = machinegunAmmoSprites[machinegunClip];
            }
            else if (machinegunClip <= 0)
            {
                ammoImage.sprite = machinegunAmmoSprites[0];
            }
            ammoText.text = " / " + (currentMachinegunAmmo );
            //ammoText.text = " x " + (currentMachinegunAmmo / GameVariables.machinegunMagazineSize);
            // ammoText.text = " " + machinegunClip + " / " + currentMachinegunAmmo;
        }
        

        if (tutorial)
        {
            ammoText.text = " Unlimited";
        }
            
        CheckIfMaxMagazineSize();

        CheckIfMaxAmmo();


    }

    public void FixedUpdate()
    {
        if (reloading)
        {

            reloadTime -= Time.deltaTime;


            if (reloadTime <= 0)
            {

                if (Gun.gunType == Gun.GunType.Pistol)
                {
                    ReloadPistol();
                }
                else if (Gun.gunType == Gun.GunType.Shotgun)
                {
                    ReloadShotgun();
                }
                else if (Gun.gunType == Gun.GunType.Machinegun)
                {
                    ReloadMachinegun();
                }
                reloading = false;
                reloadTime = nReloadTime;
            }


        }


        //manual reload. regardless of active gun.
        if (Input.GetKeyDown("r"))
        {
            reloading = true;
        }

        // if the pistol is equipped it automaticly reloads.
        if (Gun.gunType == Gun.GunType.Pistol)
        {
            if (pistolClip <= 0 && !GameVariables.realisticMode)
            {
                reloading = true;
            }
        }
        else if (Gun.gunType == Gun.GunType.Shotgun)
        {
            if (shotgunClip <= 0 && !GameVariables.realisticMode)
            {
                reloading = true;
            }

        }
        else if (Gun.gunType == Gun.GunType.Machinegun)
        {
            if (machinegunClip <= 0 && !GameVariables.realisticMode)
            {
                reloading = true;
            }
        }


    }

    void CheckIfMaxMagazineSize()
    {
        //if statements die ervoor zorgen dat zodra je magazine overvloed het bij je andere ammo erbij komt (na de slash)
        if (pistolClip > GameVariables.pistolMagazineSize)
        {

        }

    }

    void CheckIfMaxAmmo()
    {
        // if statements om te zorgen dat er een max aantal ammo is waar niet overheen gegaan kan worden
        //smerig stukje if statements wat werkt
        if (currentPistolAmmo > GameVariables.maxPistolAmmo)
        {
            currentPistolAmmo = GameVariables.maxPistolAmmo;
        }
        if (currentShotgunAmmo > GameVariables.maxShotgunAmmo)
        {
            currentShotgunAmmo = GameVariables.maxShotgunAmmo;
        }
        if (currentMachinegunAmmo > GameVariables.maxMachinegunAmmo)
        {
            currentMachinegunAmmo = GameVariables.maxMachinegunAmmo;
        }
    }


    void ReloadMachinegun()
    {
        PlayReloadSound();

        if (machinegunClip < GameVariables.machinegunMagazineSize)
        {
            machinegunAmmoUsed = GameVariables.machinegunMagazineSize - machinegunClip;
            if (currentMachinegunAmmo >= GameVariables.machinegunMagazineSize && reloadTime <= 0)
            {

                if (!tutorial)
                {
                    if (GameVariables.realisticMode)
                    {
                        currentMachinegunAmmo -= GameVariables.machinegunMagazineSize;
                    }
                    else
                    {
                        currentMachinegunAmmo -= machinegunAmmoUsed;
                    }
                }
                machinegunClip = GameVariables.machinegunMagazineSize;

            }
            else if (currentMachinegunAmmo >= 0 && currentMachinegunAmmo < GameVariables.machinegunMagazineSize && reloadTime <= 0)
            {
                machinegunClip += currentMachinegunAmmo;
                if (!tutorial) currentMachinegunAmmo -= currentMachinegunAmmo;

            }
            else if (currentMachinegunAmmo <= 0)
            {
                machinegunClip = 0;
            }

        }
    }

    void ReloadShotgun()
    {
        PlayReloadSound();
        if (shotgunClip < GameVariables.shotgunMagazineSize)
        {
            shotgunAmmoUsed = GameVariables.shotgunMagazineSize - shotgunClip;
            if (currentShotgunAmmo >= GameVariables.shotgunMagazineSize && reloadTime <= 0)
            {
                if (!tutorial)
                {
                    if (GameVariables.realisticMode)
                    {
                        currentShotgunAmmo -= GameVariables.shotgunMagazineSize;
                    }
                    else
                    {
                        currentShotgunAmmo -= shotgunAmmoUsed;
                    }
                }
                shotgunClip = GameVariables.shotgunMagazineSize;

            }
            else if (currentShotgunAmmo >= 0 && currentShotgunAmmo < GameVariables.shotgunMagazineSize && reloadTime <= 0)
            {
                shotgunClip += currentShotgunAmmo;
                if (!tutorial) currentShotgunAmmo -= currentShotgunAmmo;

            }
            else if (currentShotgunAmmo <= 0)
            {
                shotgunClip = 0;
            }

        }
    }

    void ReloadPistol()
    {
        PlayReloadSound();
        //pistol reload.
        // reload moet opnieuw gemaakt worden waarin de max mag size niet aangepast word en alleen een aparte waarde na de slash //
        if (pistolClip < GameVariables.pistolMagazineSize)
        {
            pistolAmmoUsed = GameVariables.pistolMagazineSize - pistolClip;
            if (currentPistolAmmo >= GameVariables.pistolMagazineSize && reloadTime <= 0)
            {
                if (!tutorial)
                {
                    if (GameVariables.realisticMode)
                    {
                        currentPistolAmmo -= GameVariables.pistolMagazineSize;
                    }
                    else
                    {
                        currentPistolAmmo -= pistolAmmoUsed;
                    }
                }
                pistolClip = GameVariables.pistolMagazineSize;

            }
            else if (currentPistolAmmo >= 0 && currentPistolAmmo < GameVariables.pistolMagazineSize && reloadTime <= 0)
            {
                pistolClip += currentPistolAmmo;
                if (!tutorial) currentPistolAmmo -= currentPistolAmmo;

            }
            else if (currentPistolAmmo <= 0)
            {
                pistolClip = 0;
            }

        }
    }

    void PlayReloadSound()
    {

        if (Gun.gunType == Gun.GunType.Pistol && currentPistolAmmo > 0)
        {
            audiomanager.Play("ReloadGun");
        }
        else if (Gun.gunType == Gun.GunType.Shotgun && currentShotgunAmmo > 0)
        {
            audiomanager.Play("ReloadGun");
        }
        else if (Gun.gunType == Gun.GunType.Machinegun && currentMachinegunAmmo > 0)
        {
            audiomanager.Play("ReloadGun");
        }

    }

    void OutOfAmmo()
    {
        if (!tutorial)
        {
            if (Gun.gunType == Gun.GunType.Pistol)
            {
                if (currentPistolAmmo <= 0)
                {
                    outOfAmmoImage.color = flashColour;
                }
                else
                {
                    reloadImage.color = flashColourReload;
                }
            }

            if (Gun.gunType == Gun.GunType.Shotgun)
            {
                if (currentShotgunAmmo <= 0)
                {
                    outOfAmmoImage.color = flashColour;
                }
                else
                {
                    reloadImage.color = flashColourReload;
                }
            }

            if (Gun.gunType == Gun.GunType.Machinegun)
            {
                if (currentMachinegunAmmo <= 0)
                {
                    outOfAmmoImage.color = flashColour;
                }
                else
                {
                    reloadImage.color = flashColourReload;
                }
            }
        }
        else
        {
            reloadImage.color = flashColourReload;
        }
        
        
    }
}
