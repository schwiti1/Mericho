using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    //private float tacos,industrie,robots,nukes,mexianos,wall, mexianosBonus,mexicanerHouseCap,mexicanosWorker, mexicanerFabrikCount,mexicanosWorkerWallCount,mexicanosHouses;

    [SerializeField] public GameObject prototypButton, prototypText, prototypKostenText;
    public class Einheit : Main
    {
        
        public float price;
        public float count;
        public float vol;

        private GameObject BtnLayout, TextLayout;


        public string btnText;
        public string textText;
        public string kostenTextText;

        public GameObject btn;
        public GameObject text;
        public GameObject kostenText;

        public Einheit( string _nameBtn, string _nameText,string _nameKostenText,float _price,float _count,float _vol)
        {
            
            BtnLayout = GameObject.FindGameObjectWithTag("Buttons");
            TextLayout = GameObject.FindGameObjectWithTag("Text");

            btn = Instantiate(Resources.Load("Prototyp Button")) as GameObject;
            text = Instantiate(Resources.Load("Prototyp Text")) as GameObject;
            kostenText = Instantiate(Resources.Load("Prototyp KostenText")) as GameObject;
            btnText = _nameBtn;
            textText = _nameText;
            kostenTextText = _nameKostenText;
            btn.GetComponentInChildren<Text>().text = btnText;
            text.GetComponent<Text>().text = textText;
            kostenText.GetComponent<Text>().text = kostenTextText;

            btn.transform.SetParent(BtnLayout.transform);
            kostenText.transform.SetParent(BtnLayout.transform);
            text.transform.SetParent(TextLayout.transform);


            //btn.GetComponent<Button>().onClick.AddListener(() => BtnClicked(btnText));
            
            price = _price;
            count = _count;
            vol = _vol;
        }

        private void BtnClicked(string _btn)
        {
            Debug.Log(_btn);
            btnClicked(_btn);
        }

        public void UpdateText()
        {
            


            text.GetComponent<Text>().text = textText + count;
            kostenText.GetComponent<Text>().text = kostenTextText + price;
        }


        
        
        
    }




    private int secPassedFabrik = 0;

    private Button AddMexico, AddWorker, AddHouse,AddFabrik,AddWorkerWall;
    private Text AddMexicoT, AddWorkerT, AddHouseT, AddFabrikT, AddWorkerWallT;
    private Text AddMexicoK, AddWorkerK, AddHouseK, AddFabrikK, AddWorkerWallK;

    Einheit mericho, workers, houses, factorys, wallWorkers,farms,farmWorkers;

    private GameObject[] buttons = new GameObject[20];
    private GameObject[] texts = new GameObject[20];
    private GameObject[] textKostens = new GameObject[20];

    
    

    private List<GameObject> clickerButton = new List<GameObject>();
    private List<GameObject> clickerText = new List<GameObject>();

    private List<Einheit> Einheiten = new List<Einheit>();

    private float wallStatus, wallLenght;

    //private GameObject button,text,textKosten;
    
    // Use this for initialization
    void Start () {

        InvokeRepeating("Tick", 1f, 1f);  //1s delay, repeat every 1s
        
       

        

       

        
        

        
        init();
    }
	
	// Update is called once per frame
	void Update () {
        foreach (Einheit e in Einheiten)
        {
            e.UpdateText();
        }
        
    }

    


    private void init()
    {
        wallStatus = 0;
        wallLenght = 0;
        mericho = new Einheit("Add Merchio","Merchio: ","Price Mericho:",0,0,0);
        workers = new Einheit("Add Workers", "Workers: ", "Price Workers:", 1,0,0);
        houses = new Einheit("Add Houses", "Houses: ", "Price Houses:", 50,1,20);
        factorys = new Einheit("Add Factorys", "Factorys: ", "Price Factorys:", 20,0,0);
        wallWorkers = new Einheit("Add WallWorkers", "WallWorkers: ", "Price WallWorkers:", 4,0,0);
        farms = new Einheit("Add Farms", "Farms: ", "Price Farms:", 100,1,100);
        farmWorkers = new Einheit("Add FarmWorkers", "FarmWorkers: ", "Price FarmWorkers:", 2,0,0);
        Einheiten.Add(mericho);
        Einheiten.Add(workers);
        Einheiten.Add(houses);
        Einheiten.Add(factorys);
        Einheiten.Add(wallWorkers);
        Einheiten.Add(farms);
        Einheiten.Add(farmWorkers);
        
        mericho.btn.GetComponent<Button>().onClick.AddListener(() => btnClicked("Add Merchio"));
        //DisplayRender();
        
    }


    public void btnClicked(string btn)
    {
        Debug.Log("btn clicked: "+btn);
        switch (btn)
        {
            case "Add Merchio":
                AddMericho();
                Debug.Log("mericho +++");
                break;
            case "Add Workers":
                AddWorkeres(); 
                break;
            case "Add Houses":
                AddHouses();
                break;
            case "Add Factorys":
                AddFabriks();
                break;
            case "Add WallWorkers":
                AddWorkerWalls();
                break;
            case "Add Farms":
                AddFarms();
                break;
            case "Add FarmWorkers":
                AddFarmWorkers();
                break;
            


        }
    }
    
    void AddMericho()
    {
        if (houses.count*houses.price >= mericho.count) {
            mericho.count += 1;
            
        }
    }

    private void AddHouses()
    {
        if (mericho.count >= houses.price) {

            mericho.count -= houses.price;
            houses.count++;
        }
    }

    private void AddWorkeres()
    {
        if (mericho.count >= workers.price) {
            int rand = Random.Range(0, 2);
            mericho.count-= workers.price;
            if (rand == 1)
            {
                workers.count++;
            }
        }
    }

    private void AddFabriks()
    {
        if (workers.count >= factorys.price)
        {
            factorys.count ++;
            workers.count -= factorys.price;
        }
    }

    private void AddWorkerWalls(){

        if (workers.count>=wallWorkers.price)
        {
            workers.count -= wallWorkers.price;
            wallWorkers.count++;
        }

    }

    private void AddFarms()
    {
        if (workers.count>= farms.price)
        {
            workers.count -= farms.price;
            farms.count++;
        }
    }

    private void AddFarmWorkers()
    {
        if (workers.count >= farmWorkers.price)
        {
            workers.count -= farmWorkers.price;
            farmWorkers.count++;
        }
    }
    


   
    /*
    private void DisplayRender()
    {
        foreach (einheit e in Einheiten)
        {
            e.btn.transform.SetParent(BtnLayout.transform);
            e.kostenText.transform.SetParent(BtnLayout.transform);
            e.text.transform.SetParent(TextLayout.transform);
            
        }
    }
    */
    private void Tick()
    {
        secPassedFabrik++;
        if (secPassedFabrik==30) {
            if (factorys.count > 0)
            {
                workers.count += 1 * factorys.count;

            }
            WallStatus();
            secPassedFabrik = 0;
        }
        


    }
    private void WallStatus()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("WallStatus");
        if (wallWorkers.count > 0)
        {
            wallStatus = gameObject.GetComponent<Slider>().value;

            wallStatus += 1*wallWorkers.count;

            

            if (wallStatus >= 10000)
            {
                Debug.Log("Wall is done");
            }
            else
            {
                GameObject.FindGameObjectWithTag("WallStatusText").GetComponent<Text>().text= "Wall Status: "+(wallStatus/10000)*100+"%";
                gameObject.GetComponent<Slider>().value = wallStatus;
            }

        }
    }

}
