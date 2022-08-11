using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontGoPast : MonoBehaviour
{
    void Awake()
    {
        GameObject A = GameObject.FindGameObjectWithTag("Music");
        Destroy(A);
    }
}
