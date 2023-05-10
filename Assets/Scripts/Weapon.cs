using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 25;
    [SerializeField] ParticleSystem flash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammsoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] GameObject rock;
    [SerializeField] GameObject hand;
    [SerializeField] TextMeshProUGUI ammoText;
    bool canShoot = true;
    private void OnEnable() {
        hitEffect.SetActive(false);

        flash.Stop();
        canShoot = true;

         if (ammoType.ToString() == "Rocks") {
            rock.SetActive(true);
            hand.SetActive(true);

            if (ammsoSlot.ReturnAmmoAmount(ammoType) == 0) {
                rock.SetActive(false);
                canShoot = false;
            }
         }
    }
    void Update()
    {
        DispayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot) {
            StartCoroutine(Shoot());
      }   
    }

    void DispayAmmo() {
        int currentAmoAmount = ammsoSlot.ReturnAmmoAmount(ammoType);
        ammoText.text = currentAmoAmount.ToString();
    }
    IEnumerator Shoot() 
    {
        canShoot = false;
         if (ammoType.ToString() == "Rocks") {
                rock.SetActive(false);
                hand.SetActive(false);
            }
        if (ammsoSlot.ReturnAmmoAmount(ammoType) > 0) {
            PlayFlash();
            ProcessRayCast();
            ammsoSlot.DecreaseAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        if (ammoType.ToString() != "Rocks") {
        canShoot = true;
        }
    }

    void PlayFlash() {
        flash.Play();
    }

   void ProcessRayCast() {
    RaycastHit hit;
    if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {
        CreateHitImpact(hit);
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target != null) {
            target.downLife(damage);
        }
    }
    else {
        return;
        }
    }

    void CreateHitImpact(RaycastHit hit) {
        hitEffect.SetActive(true);
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
    

