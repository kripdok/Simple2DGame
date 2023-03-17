using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashEnemyAnimation : MonoBehaviour
{
    private int _speedHash;

    public int SpeedHash => _speedHash;

    private void Awake()
    {
        _speedHash = Animator.StringToHash("Speed");
    }
}
