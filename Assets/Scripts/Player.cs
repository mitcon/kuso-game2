using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float rotateSpeed = 3f;
    public float yLimit = -3f;

    private CharacterController controller;
    private Vector3 vector;
    private GameObject manager;

    void Start() {
        //コンポーネントの取得
        controller = GetComponent<CharacterController>();
        manager = GameObject.Find("Manager");
    }

    void Update(){
        //回転
        transform.Rotate(0,Input.GetAxis("Mouse X"),0);

        //キャラクターのローカル空間での方向
        Vector3 forward = transform.transform.forward * Input.GetAxis("Vertical");
        Vector3 right = transform.transform.right * Input.GetAxis("Horizontal");
        
        vector = forward + right;

        //SimpleMove関数で移動させる
        controller.SimpleMove(vector * speed);

        if(transform.position.y < yLimit){
            manager.GetComponent<Manager>().GameOver();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag == "Finish") {
            manager.GetComponent<Manager>().GameClear();
        }
    }
}
