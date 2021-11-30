using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAi : MonoBehaviour
{
    public Transform [] goal;
    private NavMeshAgent agent;
    int x = 1;
    float dist;
    bool Turn ;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      
       // agent.SetDestination(goal[x].position);
        x++;
        NavMesh.avoidancePredictionTime = 2f;
        Turn = true;

    }

    /// <summary>
    /// /
    /// 
    /// 
    /// </summary>
    private bool IsGreaterOrEqual(Vector3 local, Vector3 other)
    {
        if (local.x >= other.x && local.y >= other.y && local.z >= other.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsLesserOrEqual(Vector3 local, Vector3 other)
    {
        if (local.x <= other.x && local.y <= other.y && local.z <= other.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// /
    /// </summary>





    // Update is called once per frame
    void Update()
    {


        if (chooseCharacter.isChooseChar)
        {

            if (Turn)
            {
                Turn = false;
                StartCoroutine(ExampleCoroutine());

            }
        }

    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        agent.SetDestination(transform.position+Random.insideUnitSphere);
        this.transform.Rotate(new Vector3(0, Random.Range(90,135), 0));
        Turn = true;

        //After we have waited 5 seconds print the time again.
    }

    IEnumerator ExampleCoroutine2()
    {
        //Print the time of when the function is first called.

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);
        //After we have waited 5 seconds print the time again.
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("xxx " + collision.other.name);
    }
}
