using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        BoardManager.Instance.GetComponent<BoardManager>().GameOver();
    }
}
