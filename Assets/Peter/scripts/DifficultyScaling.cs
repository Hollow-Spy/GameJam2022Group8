using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScaling : MonoBehaviour
{
    public float difficulty;
    [SerializeField] private AnimationCurve scale;
    public float startTime;
    [SerializeField] private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.time - startTime;

        difficulty = scale.Evaluate(elapsedTime/200);
    }
}
