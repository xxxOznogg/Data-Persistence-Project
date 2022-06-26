using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject BoardManager;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        BoardManager.GetComponent<BoardManager>().GameOver();
    }
}
