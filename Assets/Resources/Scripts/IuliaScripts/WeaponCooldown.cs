using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponCooldown
{
    [SerializeField] private float coolDownTime;
    private float nextFireTime;

    public bool isCoolingDown => Time.time < nextFireTime;
    public void StartCooldown() => nextFireTime = Time.time + coolDownTime;
}
