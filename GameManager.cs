using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject[] obs;
    public Transform[] spawnPoints;
    public float curSpawnDelay; 
    public float nextSpawnDelay;

    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;

    void Awake()
    {
        spawnList = new List<Spawn>();
        ReadSpawnFile();
    }
    void ReadSpawnFile()
    {
        //변수 초기화
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        //리스폰 파일 읽기
        TextAsset textFile = Resources.Load("Stage 0") as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);

        while(stringReader != null){
            string line = stringReader.ReadLine();

            if(line == null)
                break;
            
            //리스폰 데이터 생성
            Spawn spawnData = new Spawn();
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.type = line.Split(',')[1];
            spawnList.Add(spawnData);
        }

        //파일 닫기
        stringReader.Close();

        //첫번째 스폰 딜레이
        nextSpawnDelay = spawnList[0].delay;
    }

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > nextSpawnDelay && !spawnEnd){
            SpawnObs();
            curSpawnDelay = 0;
        }
    }

    void SpawnObs() //Obs 생성
    {
        int obsIndex = 0;
        switch(spawnList[spawnIndex].type)
        {
            case "H":
                obsIndex = 1;
                break;
            case "L":
                obsIndex = 0;
                break;
        }
        
        Instantiate(obs[obsIndex], spawnPoints[obsIndex].position, spawnPoints[obsIndex].rotation);

        //리스폰 인덱스 증가
        spawnIndex++;
        if(spawnIndex == spawnList.Count)
        {
            spawnEnd = true;
            return;
        }

        //다음 리스폰 딜레이 갱신
        nextSpawnDelay = spawnList[spawnIndex].delay;
    }
}
