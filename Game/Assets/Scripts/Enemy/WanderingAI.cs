using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private SimpleEnemyData _simpleEnemyData;
    private float _currentHP;
    private float _damage = 0f;
    private float _distance;
    private bool _alive;
    private NavMeshAgent _agent;
    private Animator _animator;

    public float HP { set { _currentHP = value; } get { return _currentHP; } }
    public float Damage { set { _damage = value; } get { return _damage; } }

    [SerializeField] private Transform _target;
    public Transform Target { set { _target = value; } get { return _target; } }

    private void Start()
    {
        SetAlive(true);
        _currentHP = _simpleEnemyData.HP;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    /*public void Started()
    {
        SetAlive(true);
        _currentHP = _simpleEnemyData.HP;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }*/

    private void FixedUpdate()
    {
        _distance = Vector3.Distance(transform.position, _target.transform.position);
        if (_alive)
        {
            if (_damage > 0)
            {
                _agent.enabled = false;
                _animator.SetFloat("Damage", _damage);
                StartCoroutine(DamageFunUpav());
            }
            else
            {
                if (_distance > 1.5f)
                {
                    _agent.enabled = true;
                    _agent.SetDestination(_target.position);
                    //_animator.Play("Walk");
                    _animator.SetFloat("Distance", _distance);
                }

                if (_distance <= 1.5f)
                {
                    _agent.enabled = false;
                    //_animator.Play("Kick");
                    _animator.SetFloat("Distance", _distance);
                }
            }
        }
        else
        {
            _agent.enabled = false;
            if (_damage > 99)
            {
                _animator.SetFloat("Damage", _damage);
            }
            else
            {
                //_animator.Play("Dying");
                _animator.SetBool("Alive", false);
            }
        }
    }

    private IEnumerator DamageFunUpav()
    {

        yield return new WaitForSeconds(1);
        _animator.SetFloat("Damage", 0f);
        //_agent.enabled = false;
        _damage = 0;
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
