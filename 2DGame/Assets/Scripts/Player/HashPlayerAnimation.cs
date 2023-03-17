using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashPlayerAnimation : MonoBehaviour
{
    private int _speedHash;
    private int _isJumpingHash;
    private int _rBVilocityYHash;

    public int SpeedHash => _speedHash;
    public int IsJumpingHash => _isJumpingHash;
    public int RBVilocityYHash => _rBVilocityYHash;

    private void Awake()
    {
        _speedHash = Animator.StringToHash("Speed");
        _isJumpingHash = Animator.StringToHash("IsJumping");
        _rBVilocityYHash = Animator.StringToHash("RBVilocityY");
    }
}
