using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Camera _cam;
    public float distance = 100f;

	// Use this for initialization
	void Start () {
		if(_cam == null)
        {
            _cam = Camera.main;
        }
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 rayOrigin = _cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, _cam.transform.forward, out hit, distance))
        {
            Debug.LogFormat("Hit!: {0} {1}", hit.collider.name, hit.collider.tag);
        }

        

    }



}
