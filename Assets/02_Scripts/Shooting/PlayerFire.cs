using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject muzzle;


    /// <summary>
    /// ������Ʈ Ǯ�� ����
    /// </summary>


    public GameObject bulletFactory;
    public GameObject bull;
    // ������Ʈ Ǯ�� ������ ������Ʈ
    public int poolSize = 10;
    // ������Ʈ Ǯ�� �� �뷮
    GameObject[] bulletObjectPool;
    // ������Ʈ Ǯ

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
        // Ǯ �뷮��ŭ �ݺ���Ű�� -> �뷮�� Ȯ���Ѵ�
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullets = Instantiate(bulletFactory,transform.position,transform.rotation);
            // �������� �޾� �Ѿ� ������Ʈ�� �����ؼ� bullets�� �����صΰ�
            bulletObjectPool[i] = bullets;
            // ������ƮǮ �迭�� bullets ���ӿ�����Ʈ�� ��´�.
            bulletObjectPool[i].SetActive(false);
            // ����� ������ƮǮ���� �迭���� ��Ȱ��ȭ�صд�.
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        // �߻� ��ư�� Ŭ���ϸ�
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
            // Ǯ���� ����� ũ�⸸ŭ �ݺ��Ѵ�
            for (int i = 0; i < poolSize; i++)
            {
                // Ǯ���� ����Ǿ��ִ� �Ѿ� ������Ʈ�� ���� �� ���ӿ�����Ʈ�� ���
                GameObject bullets = bulletObjectPool[i];

                //���ӿ�����Ʈ�� Ȱ��ȭ���ΰ� false �̸� -> ��Ȱ��ȭ �Ǿ�������
                if (bullets.activeSelf == false)
                {
                    bullets.SetActive(true);
                    // �Ѿ� ������Ʈ�� Ȱ��ȭ �ϰ�
                    bullets.transform.position = transform.position;
                    // ��ġ���� �÷��̾� ��ġ�������� ���� -> �� ���ܰ迡���� muzzle�� �߰��ؼ� �߻���ġ�� ����

                    break;
                    // Ŭ���Ҷ����� �ѹ��� �����ϸ� �ǹǷ� �ݺ��� Ż��
                }
            }
            */
        }
    }
}
