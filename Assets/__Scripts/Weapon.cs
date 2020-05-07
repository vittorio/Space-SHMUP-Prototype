using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Перечисление возможных типов оружия
/// Также включает тип "shield" для увеличения уровня щита
/// </summary>
public enum WeaponType {
    none,
    blaster,
    spread,
    phaser,
    missile,
    laser,
    shield
}

/// <summary>
/// Позволяет настраивать свойства конкретного вида оружия в инспекторе
/// </summary>
[System.Serializable]
public class WeaponDefinition {
    public WeaponType type = WeaponType.none;
    public string letter;
    
    public Color color = Color.white;
    public GameObject projectilePrefab;
    public Color projectileColor = Color.white;
    public float damageOnHit = 0;
    public float continuousDamage = 0;

    public float delayBetweenShots = 0;
    public float velocity = 20;
}

public class Weapon : MonoBehaviour
{
   
}
