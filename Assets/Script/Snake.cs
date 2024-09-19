using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
   private Vector2 _direction = Vector2.right;
   private List<Transform> _segment;
   public Transform segementPrefab;

   private void Start() 
   {
        _segment = new List<Transform>();
        _segment.Add(this.transform); 
   }

   private void Update() 
   {
        if (Input.GetKeyDown(KeyCode.W)){
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            _direction = Vector2.right;
        }
   }

   private void FixedUpdate() 
   {
        for (int i = _segment.Count - 1 ; i > 0; i--)
        {
            _segment[i].position = _segment[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y, 
            0f
        );
   }

   private void Grow()
   {
        Transform segmnet = Instantiate(this.segementPrefab);
        segmnet.position = _segment[_segment.Count - 1].position;

        _segment.Add(segmnet);
        Debug.Log(segmnet);
   }

     private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Food") {
            Grow();
        }
       
    }
   
}
