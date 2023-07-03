using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shottingbehavior : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [Header("Shottin Stats")]

    [SerializeField] float frecuency;
    [SerializeField] float speedShot;

    
    [SerializeField] float burstFrecuency;
    [Range(1, 100)]
    [SerializeField] int numberBulletPerBurst;

    [SerializeField] bool wave;
    [SerializeField] float numberBullets;
    [SerializeField] float initialAngle;
    [SerializeField] float endAngle;
    float angle;
    int angleIndex;
    int angleStep;
    int currentBullets;


    float currentTime;
    float previousTime;
    float previousBulletTime;
    Transform enemyTransform;
    GameObject tmp;
    bullet tmpBullet;

    GameObject bulletsPoolGO;
    bulletPool bulletsPool;


    // Start is called before the first frame update
    void Start(){

        currentTime = 0.0f;
        previousTime = 0.0f;
        previousBulletTime = 100.0f;
        enemyTransform = GetComponent<Transform>();


        angle = endAngle - initialAngle;
        angle = angle / numberBullets;
        angleIndex = 0;
        angleStep = 1;

        currentBullets = numberBulletPerBurst;

        bulletsPoolGO = GameObject.Find("BulletsPool");
        if(null != bulletsPoolGO)
        {
            bulletsPool = bulletsPoolGO.GetComponent<bulletPool>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        angle = endAngle - initialAngle;
        angle = angle / (numberBullets - 1);
        burstFrecuency = Mathf.Clamp(burstFrecuency, 0, frecuency);

        if (wave)
        {
            if (currentTime - previousTime >= frecuency)
            {
                for (int i = 0; i < numberBullets; i++)
                {
                    shotBullet(i);
                }

                previousTime = currentTime;
            }
        }
        else
        {
            //Single
            if (currentTime - previousTime >= frecuency)
            {
                shotBullet(angleIndex);
                if (numberBulletPerBurst <= 1) { 
                    angleIndex += angleStep;
                    if (angleIndex >= numberBullets - 1) { angleStep = -1; }
                    if (angleIndex <= 0) { angleStep = 1; }
                }
                previousBulletTime = currentTime;
                previousTime = currentTime;
                currentBullets = numberBulletPerBurst;
                currentBullets--;
            }


            //Burst
            if (numberBulletPerBurst > 1 && currentBullets > 0)
            {
                if (currentTime - previousBulletTime >= burstFrecuency)
                {
                    shotBullet(angleIndex);
                    currentBullets--;
                    previousBulletTime = currentTime;
                    if (currentBullets == 0)
                    {
                        angleIndex += angleStep;
                        if (angleIndex >= numberBullets - 1) { angleStep = -1; }
                        if (angleIndex <= 0) { angleStep = 1; }
                    }
                
                }
            }
            
        }

        
    }

    private void shotBullet(int bulletAngle)
    {
        Vector3 newRotation = new Vector3(0.0f, initialAngle + (angle * (float)bulletAngle), 0.0f);
        Quaternion newQRot = enemyTransform.rotation;
        newQRot.eulerAngles += newRotation;

        //tmp = Instantiate(bulletPrefab, enemyTransform.position + enemyTransform.forward, newQRot);
        tmp = bulletsPool.shot();
        tmpBullet = tmp.GetComponent<bullet>();
        tmpBullet.shot(speedShot, enemyTransform.position - enemyTransform.forward, newQRot);
    }
}
