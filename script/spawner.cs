using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject notePrefab;    // 노트 프리팹
    public float bpm = 60;           // BPM 설정 (60 = 초당 1개 생성)
    private float timer;

    // 패턴: 각 줄은 1비트, 각 열은 4키(왼, 아래, 위, 오)
    public int[,] notePattern = new int[,]
    {
        { 1, 0, 0, 0 },
        { 1, 0, 0, 0 },
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 },
        { 0, 0, 0, 1 },
        { 0, 0, 0, 1 },
        { 0, 0, 1, 0 },
        { 0, 1, 0, 0 },
        { 1, 0, 0, 0 }
    };

    private int currentPatternIndex = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 60f / bpm)
        {
            SpawnNote();
            timer = 0f;
        }
    }

    void SpawnNote()
    {
        for (int i = 0; i < 4; i++)
        {
            if (notePattern[currentPatternIndex, i] == 1)
            {
                float x = i*2 - 3f;
                Vector3 spawnPos = new Vector3(x, transform.position.y, transform.position.z);
                Instantiate(notePrefab, spawnPos, Quaternion.identity);
            }
        }
        currentPatternIndex++;
    }
}
