using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {

    public GameObject FireBall;
    public GameObject Lightning;
    public Transform ShootingPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newFireball = Instantiate(FireBall, ShootingPoint.position, Quaternion.FromToRotation(Vector3.forward, Vector3.forward));
            newFireball.GetComponent<Rigidbody>().AddForce(ShootingPoint.transform.forward * 1000f);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(ShootingPoint.position, ShootingPoint.transform.forward, out hit, 100f)){
                Vector3 direction = (hit.point - ShootingPoint.position);
                int distance = 2;
                for (int i = 0; i < direction.magnitude; i += distance)
                {
                    GameObject newLightning = Instantiate(Lightning, ShootingPoint.position + direction.normalized * i, Quaternion.FromToRotation(Vector3.up, ShootingPoint.forward));
                    Destroy(newLightning, 0.5f);

                }
            }
        }
    }
}
