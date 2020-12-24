using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{

  [SerializeField] private float dropSpeed;
  [SerializeField] private float speed;
  [SerializeField] private SpriteRenderer sr = null;
  [SerializeField] private Sprite[] sp = null;

    // Start is called before the first frame update
    void Start()
    {
      sr.sprite = sp[Random.Range(0, 2)];
      FindObjectOfType<AudioManager>().Play("PoopPop");
      dropSpeed = Random.Range(0.5f, 3.5f);
      speed = Random.Range(0.5f, 3.5f);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * dropSpeed * Time.deltaTime);
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.position.y <= -6.3f){
          GameObject gm = GameObject.Find("gameManager");
          if(gm != null){
            gm.GetComponent<PoopSpawner>().TakeDamage();
          }
          Destroy(this.gameObject);
        }

    }

    void OnMouseDown(){
      GameObject gm = GameObject.Find("gameManager");
      if(gm != null){
        gm.GetComponent<PoopSpawner>().score += 1;
        if(gm.GetComponent<PoopSpawner>().poopRate >= 1f)
          gm.GetComponent<PoopSpawner>().poopRate -= 0.01f;
      }

        Destroy(this.gameObject);
    }
}
