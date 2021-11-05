using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    private void OnTriggerEnter(Collider _col)
    {
        if (_col.CompareTag("Player"))
        {
            Destroy(gameObject);
            Player player = _col.GetComponent<Player>();
            player.StartCoroutine("PowerMode");
        }
    }
}
