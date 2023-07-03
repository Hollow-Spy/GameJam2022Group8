using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShankItemActive : MonoBehaviour
{

    ObjectPooler objectpooler;
    Transform ShootPoint;
    [SerializeField] float Delay;
    float delayR;
    Text AmountText;

    private void Start()
    {
        AmountText = GetComponentInChildren<Text>();
        ShootPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().ShootPoint;
        objectpooler = ObjectPooler.Instance;
       
    }



    public void Add()
    {
        Delay /= 1.5f;
        int number;
        int.TryParse(AmountText.text, out number).ToString();
        number++;
        AmountText.text = number.ToString();
    }

    private void Update()
    {
       if(delayR <= 0 && Input.GetKey(KeyCode.Space) )
        {
            delayR = Delay;
            StartCoroutine(Shooting());
        }
       else
        {
            delayR -= Time.deltaTime;
        }



    }

    IEnumerator Shooting()
    {
        for(int i=0;i<5;i++)
        {
            yield return null;
            objectpooler.SpawnFromPool("SpikeBullet", ShootPoint.position, Quaternion.identity);
        }
    }
}
