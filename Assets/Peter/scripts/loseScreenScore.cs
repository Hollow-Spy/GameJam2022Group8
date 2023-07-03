using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loseScreenScore : MonoBehaviour
{
    [SerializeField] GameObject dontdestroy;
    [SerializeField] Text highscore;
    [SerializeField] Text score;

    // Start is called before the first frame update
    void Awake()
    {
        dontdestroy = GameObject.FindWithTag("DontDestroy");
        score.text = dontdestroy.GetComponent<Save>().currentScore.ToString("n2");
        highscore.text = dontdestroy.GetComponent<Save>().LoadFile().ToString("n2");
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
