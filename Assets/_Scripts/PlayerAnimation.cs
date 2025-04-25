using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [Inject] PlayerMovement _PlayerMovement;

    private Animator _Animator;

    private void Awake()
    {
        _Animator = GetComponent<Animator>();
    }

    void Update()
    {
        _Animator.SetFloat("Speed", _PlayerMovement.GetCurrentSpeed());
        _Animator.SetBool("IsRunning", _PlayerMovement.IsRunning());
    }
}
