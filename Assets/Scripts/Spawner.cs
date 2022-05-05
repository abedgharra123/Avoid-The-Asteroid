using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float secondsBetweenStones = 2f;
    [SerializeField] private Vector2  forcRange;
    
    private float timer;
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            SpawneStone();
            timer += secondsBetweenStones;
        }
    }

    private void SpawneStone(){
        if (secondsBetweenStones > 0.3f) secondsBetweenStones -= 0.02f;
        int side = Random.Range(0,4);
        Vector2 point = Vector2.zero;
        Vector2 direction = Vector2.zero;

        if (side == 0){
            //left
            point.x = 0;
            point.y = Random.value;
            direction = new Vector2(1f,Random.Range(-1f,1f));
        } else if (side == 1){
            //right
            point.x = 1;
            point.y = Random.value;
            direction = new Vector2(-1f,Random.Range(-1f,1f));
        } else if (side == 2){
            //bottom
            point.x = Random.value;
            point.y = 0;
            direction = new Vector2(Random.Range(-1f,1f),1f);
        } else if (side == 3){
            //up
            point.x = Random.value;
            point.y = 1;
            direction = new Vector2(Random.Range(-1f,1f),-1f);
        } else return;

        Vector3 wordPosition = mainCamera.ViewportToWorldPoint(point);
        wordPosition.z = 0;
        GameObject SelectedPrefab = Instantiate(prefabs[Random.Range(0,prefabs.Length)],wordPosition,Quaternion.Euler(0f,0f,Random.Range(0,360f)));
        Rigidbody rb = SelectedPrefab.GetComponent<Rigidbody>();
        
        //add force to the selected prefab
        rb.velocity = direction.normalized * Random.Range(forcRange.x,forcRange.y); 


    }
}
