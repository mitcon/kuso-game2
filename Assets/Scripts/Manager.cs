using UnityEngine;

public class Manager : MonoBehaviour
{
    //プレイヤープレハブ
    public GameObject playerPrefab;

    //プレイヤー
    private GameObject player;

    //タイトル
    private GameObject title;

    //クリア
    private GameObject clear;

    //タイトル時カメラ
    private GameObject titleCamera;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        title = GameObject.Find("Title");
        clear = GameObject.Find("Clear");
        clear.SetActive(false);
        titleCamera = GameObject.Find("TitleCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlaying() == false && Input.GetKeyDown(KeyCode.Z)) {
            GameStart();
        }
    }

    void GameStart()
    {
        Debug.Log("GameStart");

        if(clear.activeSelf){
            clear.SetActive(false);
        }
        if(title.activeSelf){
            title.SetActive(false);
        }

        player = Instantiate(playerPrefab,playerPrefab.transform.position,playerPrefab.transform.rotation);
        
        if(titleCamera.activeSelf){
            titleCamera.SetActive(false);
        }
    }

    public void GameOver(){
        Debug.Log("GameOver");

        title.SetActive(true);
        titleCamera.SetActive(true);
        Destroy(player);
    }

    public void GameClear(){
        Debug.Log("GameClear");

        clear.SetActive(true);
        titleCamera.SetActive(true);

        if(player.activeSelf){
            Destroy(player);
        }
    }
    public bool IsPlaying(){
        return title.activeSelf == false && clear.activeSelf == false;
    }
}
