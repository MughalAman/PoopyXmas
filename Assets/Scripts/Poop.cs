using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{

  [SerializeField] private float speed = 0.5f;
  [SerializeField] private SpriteRenderer sr = null;
  [SerializeField] private Sprite[] sp = null;

    // Start is called before the first frame update
    void Start()
    {
      sr.sprite = sp[Random.Range(0, 2)];
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnMouseDown(){
      GameObject gm = GameObject.Find("gameManager");
      if(gm != null){
        gm.GetComponent<PoopSpawner>().score += 1;
        if(gm.GetComponent<PoopSpawner>().poopRate >= 0.6f)
          gm.GetComponent<PoopSpawner>().poopRate -= 0.1f;
      }

        Destroy(this.gameObject);
    }
}
