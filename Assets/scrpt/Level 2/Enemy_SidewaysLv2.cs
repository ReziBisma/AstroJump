using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SidewaysLv2 : MonoBehaviour
{
     [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerLv2>().TakeDemage(damage);
        }
    }
}
