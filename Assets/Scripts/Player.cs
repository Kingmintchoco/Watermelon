using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    
    private int iterFruit = 0;
    public GameObject fruitPrefab;
    public GameObject curFruit;
    public List<GameObject> listFruits = new List<GameObject>();

    void Start(){
        GetRandomFruit();
        SetSpawnFruit();
    }

    void Update()
    {
        if(Input.GetKeyDown("space")){
            DropFruit();
            GetRandomFruit();
            SetSpawnFruit();
        }

        float playerMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(new Vector3(playerMove, 0, 0));

    }

    void SetSpawnFruit(){
        Vector3 spawnPoint = transform.position - new Vector3(0, 1.5f, 0);

        curFruit = Instantiate(fruitPrefab, spawnPoint, Quaternion.identity);

        Rigidbody2D fruitRigidbody = curFruit.GetComponent<Rigidbody2D>();
        if(fruitRigidbody != null){
            fruitRigidbody.isKinematic = true;
        }

        curFruit.transform.parent = transform;
    }

    void GetRandomFruit(){
        if(iterFruit > listFruits.Count || iterFruit < 0) return;
        iterFruit = Random.Range(0, listFruits.Count);
        fruitPrefab = listFruits[iterFruit];
    }

    void DropFruit(){
        if(curFruit == null) return;

        Rigidbody2D fruitRigidbody = curFruit.GetComponent<Rigidbody2D>();
        if(fruitRigidbody != null){
            fruitRigidbody.isKinematic = false;
            fruitRigidbody.AddForce(Vector2.down * 5.0f, ForceMode2D.Impulse);
        }

        curFruit.transform.parent = null;
    }
}
