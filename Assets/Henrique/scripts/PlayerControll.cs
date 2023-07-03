using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    int Dashes = 3;
    float DashRegen = 1.5f;
    float DashRegenRefresh;
    float DashCooldown = 0.05f;
    float DashCooldownRefresh;
    [Header("Stats")]
    [SerializeField] float MovementSpeed;
    [SerializeField] float PassiveSpeed;
    [SerializeField] float MaxPassiveSpeed;
    [SerializeField] float MinPassiveSpeed;
    [SerializeField] float NormalPassiveSpeed;
    [SerializeField] float DashDuration;
    [SerializeField] float DashSpeed;
    [SerializeField] DashTrail Trailer;
    [SerializeField] int maxDashes;

    [SerializeField] bool disabled;

    [SerializeField] GameObject DontDestroy;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        PassiveSpeed = NormalPassiveSpeed;
        DontDestroyOnLoad(gameObject);
    }
    private void OnLevelWasLoaded(int level)
    {
        disabled = true;
        gameObject.tag = "Untagged";
        transform.position = new Vector3(transform.position.x, 0.41f, -23);
        StartCoroutine(ReEnable());
    }
    IEnumerator ReEnable()
    {
        yield return new WaitForSeconds(1);
        disabled = false;
        gameObject.tag = "Player";

    }


    // Update is called once per frame
    void Update()
    {
       if (!disabled)   
        { 
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");


        if (Dashes < maxDashes)
        {

            if (DashRegenRefresh <= 0)
            {

                DashRegenRefresh = DashRegen;
                Dashes++;
            }
            else
            {
                DashRegenRefresh -= Time.deltaTime;
            }
        }


        if (Input.GetKey(KeyCode.S) && PassiveSpeed > MinPassiveSpeed)
        {
            PassiveSpeed -= 5 * Time.deltaTime;

        }
        else
        {
            if (PassiveSpeed < NormalPassiveSpeed)
            {
                PassiveSpeed += 5 * Time.deltaTime;


            }
        }

        if (Input.GetKey(KeyCode.W) && PassiveSpeed < MaxPassiveSpeed)
        {
            PassiveSpeed += 5 * Time.deltaTime;

        }
        else
        {
            if (PassiveSpeed > NormalPassiveSpeed)
            {
                PassiveSpeed -= 5 * Time.deltaTime;


            }
        }

        if (DashCooldownRefresh > -1)
        {
            DashCooldownRefresh -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && DashCooldownRefresh < 0 && Dashes > 0)
        {
            DashCooldownRefresh = DashCooldown;
            Dashes--;

            if (Vertical == 0 && Horizontal == 0)
            {
                StartCoroutine(DashNumerator(new Vector3(0, 0, 1)));

            }
            else
            {
                if (Vertical < 0 && Horizontal == 0)
                {
                    StartCoroutine(DashNumerator(new Vector3(0, 0, 1)));

                }
                else
                {
                    if (Vertical > 0)
                    {
                        StartCoroutine(DashNumerator(new Vector3(Horizontal, 0, Vertical)));
                    }
                    else
                    {
                        StartCoroutine(DashNumerator(new Vector3(Horizontal, 0, 0)));
                    }

                }
            }




        }

        controller.Move(new Vector3(0, 0, PassiveSpeed * Time.deltaTime));
        controller.Move(new Vector3(Horizontal * MovementSpeed * Time.deltaTime, 0, 0));


    }

    }


    IEnumerator DashNumerator(Vector3 Dir)
    {
        float DashElapsed = DashDuration;
        Trailer.StartTrail();
        while (DashElapsed > 0)
        {
           
            DashElapsed -= Time.deltaTime;
            controller.Move(new Vector3(Dir.x * DashSpeed * Time.deltaTime, 0, Dir.z * DashSpeed * Time.deltaTime));
            yield return null;
        }
        Trailer.EndTrail();


    }

    private void FixedUpdate()
    {
        DontDestroy.GetComponent<Save>().currentScore += (DontDestroy.GetComponent<DifficultyScaling>().difficulty * PassiveSpeed);
    }

}

