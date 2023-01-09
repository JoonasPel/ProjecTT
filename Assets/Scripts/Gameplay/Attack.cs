using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float _attackTimeoutDelta = 0.0f;
    private float _attackTimeout = 1.0f;

    delegate void AttackStyle();
    AttackStyle attackStyle;


    void Start()
    {
        // TODO: Change this to the default weapon or something.
        attackStyle = Shoot;
    }

    void Update()
    {
        _attackTimeoutDelta -= Time.deltaTime;
    }

    public void ExecuteAttack()
    {
        if (_attackTimeoutDelta <= 0.0f)
        {
            attackStyle();
            _attackTimeoutDelta = _attackTimeout;
        }
    }

    private void Shoot()
    {
        Debug.Log("I shoot");
        GameObject bullet = ObjectPooling.Instance.getPooledObj();
        if (bullet != null)
        {
            bullet.transform.position = gameObject.transform.position +
                transform.TransformDirection(new Vector3(0, 1.0f, 1.5f));
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.SetActive(true);   
        }
        
    }

    private void Hit()
    {
        Debug.Log("I hit");
    }

    private void ChangeWeapon()
    {
        // weapon changing things come here

        // initial = when taking weapon in hand
        float initialWeaponCooldown = 0.8f;
        // after attack/shot
        float weaponCooldown = 1.3f;
        
        _attackTimeout = weaponCooldown;
        _attackTimeoutDelta = initialWeaponCooldown;
    }
}
