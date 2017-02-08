using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItemManager : ItemManager
{
    private void OnCollisionEnter(Collision collision)
    {
        ObjectDestroy(
            transform.gameObject,
            collision.gameObject.tag.Contains("Player"));
        ObjectDestroy(
            transform.gameObject,
            collision.transform.tag.Contains("Enemy"));
    }
}
