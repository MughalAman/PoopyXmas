using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoopSpawner : MonoBehaviour
{

  //Variables

  [SerializeField] private GameObject poopSpawnPoint;
  [SerializeField] private GameObject poopGO;

  public float poopRate = 1f;
  public int score;

  public TextMeshProUGUI ScoreText;

  public bool GameOver = true;
  public bool IsPlaying = false;

    void Update(){
      //update the score | make a system for this
          ScoreText.text = "Score: " + score.ToString();
          if(Input.GetKey(KeyCode.Space))
          {
            GameOver = false;
          }

          if(GameOver == false)
          {
              if(IsPlaying == false)
              {
                  StartCoroutine(Poop());
              }
          }

    }

    public IEnumerator Poop()
     {
         IsPlaying = true;
         while (GameOver == false)
         {
             //spawn poop.
             Instantiate(poopGO, poopSpawnPoint.transform.position, Quaternion.identity);
             yield return new WaitForSeconds(poopRate);
         }
     }

}
