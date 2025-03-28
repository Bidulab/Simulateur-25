using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Instancier : MonoBehaviour
{
    public List<Transform> StockPos;

    public GameObject ColumnPrefab;
    public List<GameObject> Columns = new List<GameObject>();

    public GameObject PlatformPrefab;
    public List<GameObject> Platforms = new List<GameObject>();

    public Recorder rec;
    // Start is called before the first frame update
    void Start()
    {
        setupScene();
    }
    public void setupScene()
    {
        foreach (Transform t in StockPos)
        {
            Vector3 mirrorPos = t.position;
            mirrorPos.z *= -1;
            Vector3 mirrorRot = t.eulerAngles;
            mirrorRot.y *= -1;

            for (int i = 0; i < 4; i++)
            {
                // Random Y-axis rotation
                float randomRotationY1 = UnityEngine.Random.Range(0f, 360f);
                float randomRotationY2 = UnityEngine.Random.Range(0f, 360f);

                GameObject column1 = Instantiate(ColumnPrefab, t.position + new Vector3(0, 0, i * 0.1f), Quaternion.Euler(0, randomRotationY1, 0), this.transform);
                Columns.Add(column1);

                GameObject column2 = Instantiate(ColumnPrefab, mirrorPos - new Vector3(0, 0, i * 0.1f), Quaternion.Euler(0, randomRotationY2, 0), this.transform);
                Columns.Add(column2);
            }

            GameObject platform1A = Instantiate(PlatformPrefab, t.position + new Vector3(0, 0.12f, 0.15f), Quaternion.Euler(0, 90, 0), this.transform);
            Platforms.Add(platform1A);

            GameObject platform2A = Instantiate(PlatformPrefab, mirrorPos + new Vector3(0, 0.12f, -0.15f), Quaternion.Euler(0, 90, 0), this.transform);
            Platforms.Add(platform2A);

            GameObject platform1B = Instantiate(PlatformPrefab, t.position + new Vector3(0, 0.135f, 0.15f), Quaternion.Euler(0, 90, 0), this.transform);
            Platforms.Add(platform1B);

            GameObject platform2B = Instantiate(PlatformPrefab, mirrorPos + new Vector3(0, 0.135f, -0.15f), Quaternion.Euler(0, 90, 0), this.transform);
            Platforms.Add(platform2B);
        }

        if (rec != null)
            AddTransToRec();
    }
    void AddTransToRec()
    {
        foreach(GameObject go in Columns)
            rec.transforms.Add(go.transform);
        foreach (GameObject go in Platforms)
            rec.transforms.Add(go.transform);
    }
    void RemoveTransToRec()
    {
        foreach (GameObject go in Columns)
            rec.transforms.Remove(go.transform);
        foreach (GameObject go in Platforms)
            rec.transforms.Remove(go.transform);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void deleteObjects()
    {
        RemoveTransToRec();

        foreach (GameObject obj in Platforms)
            Destroy(obj);
        Platforms.Clear();

        foreach (GameObject obj in Columns)
            Destroy(obj);
        Columns.Clear();

    }
}
