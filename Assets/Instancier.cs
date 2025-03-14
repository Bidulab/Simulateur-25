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
    public GameObject Stockprefab;
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

            Vector3 mirrorrotation = t.eulerAngles;
            mirrorrotation.y += 90;
            mirrorrotation.y *= -1;
            mirrorrotation.y -= 90;



            GameObject stock1 = Instantiate(Stockprefab, t.position, t.rotation, this.transform);
            GameObject stock2 = Instantiate(Stockprefab, mirrorPos,Quaternion.Euler(mirrorrotation), this.transform);
            //Platforms.Add(platform2B);
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
