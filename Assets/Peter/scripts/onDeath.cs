using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDeath : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private float startHealth;
    private float health;
    private bool dead;
    [SerializeField] GameObject Spark,DeathSpark;
    [SerializeField] Material Normal, White;
    MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        startHealth = GameObject.FindWithTag("DontDestroy").GetComponent<DifficultyScaling>().difficulty * 100;
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l") || health <= 0)
        {
            Instantiate(DeathSpark, transform.position, Quaternion.identity);

            if (Random.Range(0f, 1f) > .49f && !dead)
            {
                Instantiate(items[Random.Range(0,items.Length)], this.gameObject.transform.position, new Quaternion(0, 0, 0, 1));
                dead = true;
            }

            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, -5, 0);
        }

        if (this.gameObject.transform.position.y < -1)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator FlashWhite()
    {
        renderer.material = White;
        yield return new WaitForSeconds(.02f);
        renderer.material = Normal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            StartCoroutine(FlashWhite());
            Instantiate(Spark, other.transform.position, Quaternion.identity);

            health -= 1;
            //health -= collision.gameObject.GetComponent<damage>().damage;
            other.gameObject.SetActive(false);
        }
    }
}
