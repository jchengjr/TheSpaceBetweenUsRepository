using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
    public enum NPCState { Patrol, Follow }

    public NPCState currentState;

    public Transform player;

    public float sightDistance = 10f;

    public float wanderRadius = 10f;
    public float wanderTimer = 5f;

    private NavMeshAgent agent;
    private float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case NPCState.Patrol:
                Wander();
                if (Vector3.Distance(this.transform.position, player.position) < sightDistance)
                {
                    currentState = NPCState.Follow;
                }
                break;
            case NPCState.Follow:
                Follow();
                if (Vector3.Distance(this.transform.position, player.position) > sightDistance)
                {
                    currentState = NPCState.Follow;
                }
                break;
        }
    }

    private void Wander()
    {
        timer -= Time.deltaTime;
        if (timer >= wanderTimer || agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 newPos = RandomNavMeshLocation();
            agent.SetDestination(newPos);
            timer = wanderTimer;
        }
    }

    private void Follow()
    {
        agent.SetDestination(player.position);
    }

    private Vector3 RandomNavMeshLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // scene loading to text level goes here.
        }
    }
}
