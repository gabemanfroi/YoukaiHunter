using UnityEngine;


    public class EnemyAI : MonoBehaviour
    {
        public float speed = 3f;
        private Transform _player;
        
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        void Update()
        {
            if (_player != null)
            {
                Vector2 direction = (_player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
            }
        }
    }
