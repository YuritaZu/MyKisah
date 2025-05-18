using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [System.Serializable]
    public class StageData
    {
        public int id;
        public string stageName;
        public int price;
    }
}
