using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //rate of fire to be increased as per level and random drops
    [SerializeField]
    [Range (0.5f, 1.5f)]
    float fireRange = 1;


    // damage to be increased as per level and random drops
    [SerializeField]
    [Range(1f, 10f)]
    int damage = 1;





}
