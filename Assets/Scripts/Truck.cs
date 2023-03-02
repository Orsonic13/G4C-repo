using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] List<Sprite> spriteList = new List<Sprite>();
    [SerializeField] List<Vector3> spawnPointList = new List<Vector3>();
    [SerializeField] List<GameObject> itemList = new List<GameObject>();
    [SerializeField] List<Vector3> directionList = new List<Vector3>();

    [SerializeField] Transform trans;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    Vector3 direction;

    Vector3 spawnPoint;
    GameObject item;
    int orientation;

    Vector3 speedModifier = new Vector3(80, 80, 80);

    // Start is called before the first frame update
    void Start()
    {
        orientation = Random.Range(0, 4);
        spriteRenderer.sprite = spriteList[orientation];

        trans.localScale = new Vector3(1f, 1f, 1f);
        trans.position = spawnPointList[orientation];
        direction = directionList[orientation];

        
        item = itemList[Random.Range(0, itemList.Count)];

        StartCoroutine("DropOffItem");
    }

    IEnumerator DropOffItem()
    {
        if(item != null)
        {
            Instantiate(item, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
        for(var i = 0; i < 10; i++)
        {
            rb.AddForce(Vector3.Scale(direction, speedModifier));
        }

        yield return new WaitForSeconds(1.5f);
        
        Destroy(this.gameObject);
    }
}