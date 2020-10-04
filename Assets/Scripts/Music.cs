using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
    public static Music Instance { get; private set; } = null;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}