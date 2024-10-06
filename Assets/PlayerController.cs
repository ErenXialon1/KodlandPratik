using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform rifleStart;
    [SerializeField] private Text HpText;

    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Victory;
    [SerializeField] private GameObject mainCamera;
    public float moveSpeed;
    Vector3 moveDir;
    Rigidbody rb;
    public static int enemyDestroyed;

    public float health = 0; //Hata say�lmaz ama Default de�er olarak 0 girmek yerine 100 girilebilir.

    void Start()
    {
        //Destroy(this);//Scriptin, script devreye girer girmez kendisini yok etmesine sebep olan bir sat�r
        //ChangeHealth(0);//Oyuncunun can de�erine parantez i�erisindeki de�eri ekliyor.17. sat�rdaki 0 de�eri 100 ile de�i�tirilirse sorun ��z�l�r
        //ya da ChangeHealth(100) �eklinde de�i�tirilebilir.
        ChangeHealth(100);
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        mainCamera = GameObject.Find("Main Camera");
        enemyDestroyed = 0;
        
    }
    

    

    

    public void ChangeHealth(int hp)
    {
        health += hp;
        if (health > 100)
        {
            health = 100;
        }
        else if (health <= 0)
        {
            Lost();
        }
        HpText.text = health.ToString();
    }

    public void Win()
    {
        Victory.SetActive(true);
        ;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Lost()
    {
        GameOver.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        float x_input, y_input;
        x_input = Input.GetAxis("Horizontal");
        y_input = Input.GetAxis("Vertical");
        moveDir = mainCamera.transform.forward * y_input + mainCamera.transform.right * x_input;
        moveDir.y = 0;
        rb.AddForce(moveDir.normalized * moveSpeed,ForceMode.Force);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject buf = Instantiate(bullet);
            buf.transform.position = rifleStart.position;
            buf.GetComponent<Bullet>().setDirection(mainCamera.transform.forward);
            buf.transform.rotation = mainCamera.transform.rotation;
            
                
                    
                
            
        }
        if (enemyDestroyed >= 3)
        {
            Win();
        }


        /*if (Input.GetMouseButtonDown(1)) 
        {
            Collider[] tar = Physics.OverlapSphere(transform.position, 2);
            foreach (var item in tar)
            {
                if (item.tag == "Enemy")
                {
                    Destroy(item.gameObject);
                }
            }
        }*/


        Collider[] targets = Physics.OverlapSphere(transform.position, 3);
        foreach (var item in targets)
        {
            if (item.tag == "Heal")
            {
                ChangeHealth(50);
                Destroy(item.gameObject);
            }
         
            if (item.tag == "Enemy")
            {
                Lost();
            }
        }
    }
}
