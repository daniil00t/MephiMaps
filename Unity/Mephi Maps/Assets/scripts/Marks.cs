using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Marks : Structions
{
    private GameObject templateMarkLabel;
    private GameObject templateMarkPanel;
    public void init(GameObject _templateMarkLabel, GameObject _templateMarkPanel)
    {
        this.templateMarkLabel = _templateMarkLabel;
        this.templateMarkPanel = _templateMarkPanel;
    }

    private struct PositionMark
    {
        public Vector3 Pos;
        public Vector3 Size;
        public PositionMark(Vector3 Pos, Vector3 Size)
        {
            this.Pos = Pos;
            this.Size = Size;
        }
        public Vector3 getPosition()
        {
            Vector3 res = new Vector3(0, 0, 0);
            res.y = Pos.y * 2f + 10f;
            res = new Vector3(Pos.x, res.y, Pos.z);
            return res;
        }
    
    }
    public void renderMark(int count, int i, Mark mark, Dictionary<string, int> cors, Dictionary<string, int> corsCount)
    {
        
        string _str = System.Text.RegularExpressions.Regex.Split(mark.place, "-")[0];
        GameObject building = GameObject.Find(_str);
        PositionMark pos_building = new PositionMark(building.transform.position, building.transform.localScale);


        if(corsCount[mark.corpus] == i)
        {
            GameObject go = Instantiate(this.templateMarkLabel, pos_building.getPosition(), templateMarkLabel.transform.rotation).gameObject;
            go.GetComponentsInChildren<Transform>()[1].GetComponent<TextMeshPro>().SetText(mark.cnt);
            go.GetComponentsInChildren<Transform>()[2].GetComponent<TextMeshPro>().SetText($"From: {mark.login}");
            if (mark.marksCount > 1) go.GetComponentsInChildren<Transform>()[3].GetComponent<TextMeshPro>().SetText($"+{mark.marksCount}");
            go.name = $"Mark_{mark.id}";
            go.transform.parent = GameObject.Find("Mark_Labels").transform;
        }
        

        if (i == count - 1) this.templateMarkLabel.SetActive(false);
    }
    public void renderMarkPanel(int count, int i, Mark mark, Dictionary<string, int> cors)
    {
        GameObject goCnt = Instantiate(this.templateMarkPanel).gameObject;
        goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[2].GetComponent<Text>().text = $"{mark.cnt}";
        goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[3].GetComponent<Text>().text = $"From user: {mark.login}";
        goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[4].GetComponent<Text>().text = $"Date: {mark._date}";
        goCnt.GetComponentsInChildren<Transform>()[1].GetComponentsInChildren<Transform>()[5].GetComponent<Text>().text = $"Place: {mark.place}";

        goCnt.name = $"Mark_Panel_{mark.id}";

        goCnt.transform.parent = GameObject.Find("Mark_Panels").transform;
        
        goCnt.SetActive(false);

        if (i == count - 1) this.templateMarkPanel.SetActive(false);
    }
}