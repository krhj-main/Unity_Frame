using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject muzzle;


    /// <summary>
    /// 오브젝트 풀링 구현
    /// </summary>


    public GameObject bulletFactory;
    public GameObject bull;
    // 오브젝트 풀의 프리팹 오브젝트
    public int poolSize = 10;
    // 오브젝트 풀에 들어갈 용량
    GameObject[] bulletObjectPool;
    // 오브젝트 풀

    public List<GameObject> bulletListPool;

    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new GameObject[poolSize];
        bulletListPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullets = Instantiate(bulletFactory);
            bulletListPool.Add(bullets);
            bulletListPool[i].SetActive(false);
        }

        /*
        // 풀 용량만큼 반복시키기 -> 용량을 확보한다
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullets = Instantiate(bulletFactory,transform.position,transform.rotation);
            // 프리팹을 받아 총알 오브젝트를 생성해서 bullets에 저장해두고
            bulletObjectPool[i] = bullets;
            // 오브젝트풀 배열에 bullets 게임오브젝트를 담는다.
            bulletObjectPool[i].SetActive(false);
            // 저장된 오브젝트풀에서 배열마다 비활성화해둔다.
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        // 발사 버튼을 클릭하면
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletListPool.Count > 0)
            {
                GameObject bullets = bulletListPool[0];
                bullets.SetActive(true);

                bulletListPool.Remove(bullets);

                bullets.transform.position = transform.position;
            }
            /*
            // 풀링에 저장된 크기만큼 반복한다
            for (int i = 0; i < poolSize; i++)
            {
                // 풀링에 저장되어있는 총알 오브젝트를 꺼내 새 게임오브젝트에 담고
                GameObject bullets = bulletObjectPool[i];

                //게임오브젝트의 활성화여부가 false 이면 -> 비활성화 되어있으면
                if (bullets.activeSelf == false)
                {
                    bullets.SetActive(true);
                    // 총알 오브젝트를 활성화 하고
                    bullets.transform.position = transform.position;
                    // 위치값을 플레이어 위치에서부터 생성 -> 실 사용단계에서는 muzzle을 추가해서 발사위치를 조정

                    break;
                    // 클릭할때마다 한번만 생성하면 되므로 반복문 탈출
                }
            }
            */
        }
    }
}
