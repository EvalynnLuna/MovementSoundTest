using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField]
    public GameObject target;

    private void Start()
    {

    }

    void Update()
    {
        Transform _target = target.transform;
        SetTarget(_target);
    }

    public void SetTarget(Transform target)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;
    }
}
