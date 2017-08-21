using UnityEngine;


public class Levitar : MonoBehaviour {

    [SerializeField]
    public float force = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 10f))
        {
            if(hit.distance < 1)
            {
                transform.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
            }
        }
	}
}
