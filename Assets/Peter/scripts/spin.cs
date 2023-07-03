using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{

    [SerializeField] private GameObject cube;
    [SerializeField] private float speed = 1;
    [SerializeField] private AnimationCurve curve;
    private Rigidbody cubebody;
    private float randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0f,1f);
        cube = this.gameObject;
        cubebody = cube.GetComponent<Rigidbody>();
        cubebody.maxAngularVelocity = 9999;
        cubebody.velocity = new Vector3(0, 1, 0);
        cube.transform.eulerAngles = new Vector3(0, Random.Range(0,360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        cubebody.angularVelocity = new Vector3(0, speed, 0);

        cubebody.transform.localPosition = new Vector3(cubebody.transform.localPosition.x, (curve.Evaluate(Time.time + randomNumber) * .4f) + .5f, cubebody.transform.localPosition.z);
    }
}
