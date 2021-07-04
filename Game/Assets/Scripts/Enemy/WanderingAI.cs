using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{
    private float _hp;
    private float _distance;
    private bool _alive;
    private NavMeshAgent _agent;
    private Animator _animator;

    public Transform _target;

    private void Start()
    {
        SetAlive(true);
        _hp = 100f;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _distance = Vector3.Distance(transform.position, _target.transform.position);
        if (_alive)
        {
            if (_distance > 1.5f)
            {
                _agent.enabled = true;
                _agent.SetDestination(_target.position);
                _animator.Play("Walk");
              
            }

            if (_distance <= 1.5)
            {
                _agent.enabled = false;
                _animator.Play("Kick");
            }
            
        }
        else
        {
            _agent.enabled = false;
            _animator.Play("Dying");
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
