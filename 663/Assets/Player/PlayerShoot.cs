using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private Transform barrel;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject[] ammo;

    private int ammoAmount;
    //Start is called before the first frame update
     void Start()
    {
        for (int i = 0; i <= 2; i++)
        {
            ammo[i].gameObject.SetActive(false);
        }
        ammoAmount = 0;
    }
    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletLifetime = 2.0f;
    public AudioClip shootSound;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        //when the mouse is clicked
        if (Input.GetButtonDown("Fire1") && ammoAmount > 0)
        {
            var spwnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            spwnedBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
            ammoAmount -= 1;
            ammo[ammoAmount].gameObject.SetActive(false);
            //GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 shootDir = mousePosition - transform.position;
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(shootSound);
        }
        if (Input.GetKey(KeyCode.R))
        {
            ammoAmount = 8;
            for (int i = 0; i <= 2; i++)
            {
                ammo[i].gameObject.SetActive(true);
            }
        }


    }
}
