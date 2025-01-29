using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PickupDynamicBoxPuzzle : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject pickupPillar;
    public float distanceRequired;
    public float speed;
    public AudioClip solveSound;
    
    private Vector3 initialPosition1;
    private Vector3 initialPosition2;
    private Vector3 initialPosition3;
    private bool alreadyWon = false;

    // Start is called before the first frame update
    void Start()
    {

        initialPosition1 = object1.transform.position;
        initialPosition2 = object2.transform.position;
        initialPosition3 = object3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (ObjectMoved(initialPosition1, object1.transform.position) && 
            ObjectMoved(initialPosition2, object2.transform.position) && 
            ObjectMoved(initialPosition3, object3.transform.position))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0.5f, transform.position.z), step);
            pickupPillar.transform.position = Vector3.MoveTowards(pickupPillar.transform.position, new Vector3(pickupPillar.transform.position.x, -3.0f, pickupPillar.transform.position.z), step);
            if (!alreadyWon)
            {
                alreadyWon = true;
                AudioSource.PlayClipAtPoint(solveSound, transform.position);
            }
        }
    }

    private bool ObjectMoved(Vector3 initialPosition, Vector3 currentPosition)
    {
        if (Vector3.Distance(initialPosition, currentPosition) > distanceRequired)
        {
            return true;
        }
        return false;
    }
}
