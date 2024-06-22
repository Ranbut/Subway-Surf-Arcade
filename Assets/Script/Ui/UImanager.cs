using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    
	public GameObject showPlayeronlost;
	public Text cointxt;
	public Text yourcoinmuvingnow;
	public Text yourcoinnow;
	public Text yourkey;
	public Text yourkeyneed;
	int needkey = 0;
	public GameObject showieffcts;
	public Text coinmain;
	float Slidertimerdowload;
	public static int coinmuving;
	public static int coin;
	public int credits;
	public Text creditsTxt;
	public bool selectingCharacter = false;
	public byte selectCharacter = 0;
	public GameObject characterSelect;
	public GameObject characterSelectArrow;
	public GameObject camerafolow;
	public static UImanager uimanager;
	private bool played = false;
	private bool lose = false;
	public GameObject paneloading;
	public GameObject panellost;
	public GameObject panelseleckey;
	public GameObject panelcoin;
	public GameObject panelshowitem;
	public Slider timerforkey;
	public Slider Ontheloading;
	public Slider timer;
	public Slider timeriteam;
	public Slider timeriteamhut;
	public Slider timeriteamx2;
	public Slider timeriteamgiay;
	public Slider timeriteambay;

	public GameObject panelslidervan;
	public GameObject panelsliderhut;
	public GameObject panelsliderx2;
	public GameObject panelslidergiay;
	public GameObject panelsliderbay;
	private int checkthedie;

	[Header("Highscore")]
	public GameObject highScoreScreen;
	public Text[] letters;
	private int newHighscore = -1;
	private char letter = (char)65;
	public static bool selectkey;
	public List<Highscore> highscores;

	[Header("Registry")]
	public bool isInRegistry = false;
	public GameObject registry;
	public Text entryIN;
	public Text entryOUT;


	public Text ShowHighscor3D;

	public int frameRate = 60;

	void Awake ()
	{
		Application.targetFrameRate = frameRate;
	}

	void Start ()
	{
		ShowHighscor3D.text = managerdata.manager.getmuving ().ToString ();
		if (managerdata.manager.getmuving () == 0) {
			ShowHighscor3D.text = "High score\n" + managerdata.manager.getHighscoreName(1) + "\n" +  managerdata.manager.getHighscoreScore(1).ToString("D7");
		}
		SetingInStart ();
		getvan = true;

		for (int i = 1; i < 7; i++) {
			Debug.Log ("Name: " + managerdata.manager.getHighscoreName (i) + "; Score: " + managerdata.manager.getHighscoreScore (i));
			Highscore highscore = new Highscore (managerdata.manager.getHighscoreName (i), managerdata.manager.getHighscoreScore (i));
			highscores.Add (highscore);
			Debug.Log (highscore.ToString());
		}
	}

	public void SetingInStart ()
	{
		credits = managerdata.manager.getCredits ();
		creditsTxt.text = "Creditos: " + managerdata.manager.getCredits().ToString("D2");
		yourkey.text = managerdata.manager.getkey ().ToString ();
		coin = 0;
		coinmuving = 0;
		uimanager = this;
		// tắt các timer item
		panellost.gameObject.SetActive (false);
		panelseleckey.gameObject.SetActive (false);
		timeriteam.gameObject.SetActive (false);
		timeriteamhut.gameObject.SetActive (false);
		timeriteamx2.gameObject.SetActive (false);
		timeriteamgiay.gameObject.SetActive (false);
		timeriteambay.gameObject.SetActive (false);
		panelcoin.SetActive (false);
		paneloading.gameObject.SetActive (true);
		StartCoroutine (Loadingonthestart ());
		alowcall = true;
		selectkey = false;
		showthenewsocore = false;
		calll = true;
	}

	public void Again ()
	{
		yourkey.text = managerdata.manager.getkey ().ToString ();
		coin = 0;
		coinmuving = 0;
		uimanager = this;
		panellost.gameObject.SetActive (false);
		panelseleckey.gameObject.SetActive (false);
		timeriteam.gameObject.SetActive (false);
		timeriteamhut.gameObject.SetActive (false);
		timeriteamx2.gameObject.SetActive (false);
		timeriteamgiay.gameObject.SetActive (false);
		timeriteambay.gameObject.SetActive (false);
		panelcoin.SetActive (false);
		paneloading.gameObject.SetActive (false);
		alowcall = true;
		selectkey = false;
		showthenewsocore = false;
		calll = true;
	}

	public  void playAgain ()
	{
		if (calll) {
			//  Evensystem.SetActive(false);
			Playermuving.player.GetComponent<CapsuleCollider> ().center = new Vector3 (0, -0.08f, 0);
			Playermuving.player.GetComponent<CapsuleCollider> ().radius = 0.46f;
			Playermuving.player.GetComponent<CapsuleCollider> ().height = 1.77f;
			showPlayeronlost.SetActive (false);
			Time.timeScale = 0.8F;
			Playermuving.speedmuving = 15;
			inthepanelpause.playagain = true;
			calll = false;
			coin = 0;
			coinmuving = 0;
			panellost.gameObject.SetActive (false);
			panelseleckey.gameObject.SetActive (false);
			timeriteam.gameObject.SetActive (false);
			paneloading.gameObject.SetActive (false);
			Perencamera.managerscen.playallgame ();
			// Camerafolow.camfolowplayer.Intanceectff(); // tạo hiệu ứng
			StartCoroutine (playagain ());
			emty.emtyplayer.ResutTranformemty ();
            
		}

	}
		
	bool calll;

	IEnumerator  playagain ()
	{
		Playermuving.isplay = true;
		yield return new WaitForSeconds (0.5f);
		calll = true;
		Playermuving.player.clicontheplayagainseleckey ();
		for (int j = 0; j < 4; j++) {
			yield return new WaitForSeconds (0.5f);
			Playermuving.player.clicontheplayagainseleckey (); // lod lại animation
		}
	}
		
	IEnumerator Loadingonthestart ()
	{
		paneloading.gameObject.SetActive (true);
		for (int i = 0; i < 100; i++) {
			yield return new WaitForSeconds (0.05f);
			Ontheloading.value = i;
			if (i == 99) {
				paneloading.gameObject.SetActive (false);
				Perencamera.managerscen.GetComponent<Animator> ().enabled = true;
				Soundmanager.soundmanager.PlayBackgroudSound ();
			}
		}
	}

	public void Ontherchangetimer ()
	{
		Slidertimerdowload = timer.value;
		Slidertimerdowload = Slidertimerdowload / 100;
		Time.timeScale = Slidertimerdowload;

	}
		
	public void play ()
	{
		panelcoin.SetActive (true);
		StartCoroutine (Playdelay ());
		Soundmanager.soundmanager.PlayPoliceSound ();
	}

	IEnumerator Playdelay ()
	{
		mapitro.instance.Muvingship ();
		emty.emtyplayer.StartCoroutine (emty.emtyplayer.intheplay ());
		yield return new WaitForSeconds (0.3f);
		// Debug.Log("chơi lại");
		Perencamera.managerscen.GetComponent<Animator> ().SetBool ("play", true);
		folow.distance = 10;
		yield return new WaitForSeconds (0.5f);
		Playermuving.isplay = true;
		Playermuving.speedmuving = 5;
		Playermuving.player.muvingtomodelonthestart (); // chạy model về phía tâm tọa độ
		emty.emtyplayer.actac ();
		emty.emtyplayer.animationrunplay ();
		emty.die = 1;
		if (managerdata.manager.GetFly () >= 1) {
			yield return new WaitForSeconds (2f);
		}
      
	}


	#region hệ thống các thanh slider


	public IEnumerator delayslideritem (int value, string nameitem)
	{


		if (Manageritem.van == false) {
			Manageritem.van = true;
			timeriteam.gameObject.SetActive (true);
			panelslidervan.SetActive (true);
			timeriteam.maxValue = 300;
			int vl = 0;
			timeriteam.value = vl;
			for (int i = 0; i < 300; i++) {
				timeriteam.gameObject.GetComponent<Slider> ().enabled = true;
				timeriteam.gameObject.SetActive (true);
				panelslidervan.SetActive (true);
				vl++;
				timeriteam.value = vl;
				yield return new WaitForSeconds (0.1f);
				if (Manageritem.van == false || Manageritem.baylongcoin == true) {
					timeriteam.gameObject.SetActive (false);
					panelslidervan.SetActive (false);
					if (alowdelay) {
						Playermuving.player.stopanimationitem ("van", "van");
					}
                   
					break;
				}
			}
			panelslidervan.SetActive (false);
			timeriteam.gameObject.SetActive (false);
			if (alowdelay) {
				Playermuving.player.stopanimationitem ("van", "van");
			}
		} else {
           
			alowdelay = false;
			Manageritem.van = false;
			yield return new WaitForSeconds (0.2f);
			alowdelay = true;

			StartCoroutine (delayslideritem (1, ""));
			Playermuving.player.setalowvan ();
		}

	}

	bool alowdelay = true;

	int Getvalueslider (int value)
	{
		int valueoffitem = 10;
		valueoffitem = valueoffitem + value * 3;
		valueoffitem = valueoffitem * 10;
		return valueoffitem;

	}

	int valuex2;

	public IEnumerator delayslideritemhut (int value)
	{
		Debug.Log (timeriteamhut.maxValue);
		if (Manageritem.hutcoin == false) {
			Manageritem.hutcoin = true;
			timeriteamhut.gameObject.SetActive (true);
			panelsliderhut.gameObject.SetActive (true);
			timeriteamhut.maxValue = Getvalueslider (managerdata.manager.GetDataItemMagnet ());
			timeriteamhut.value = 0;
			timeriteamhut.gameObject.GetComponent<Slider> ().enabled = true;
			valuex2 = 0;
			for (int i = 0; i < timeriteamhut.maxValue; i++) {
				valuex2++;
				timeriteamhut.value = valuex2;
				yield return new WaitForSeconds (0.1f);
				if (Manageritem.hutcoin == false) {
					panelsliderhut.gameObject.SetActive (false);
					timeriteamhut.gameObject.SetActive (false);
					break;
				}
			}
			timeriteamhut.gameObject.SetActive (false);
			panelsliderhut.gameObject.SetActive (false);
			Playermuving.player.stopanimationitem ("hutcoin", "hutcoin");
		} else {
			Manageritem.hutcoin = false;
			yield return new WaitForSeconds (0.2f);
			Playermuving.player.GetIkmagnet ();
			StartCoroutine (delayslideritemhut (1));
		}
	}
		
	public IEnumerator delayslideritemx2 (int value)
	{
		if (Manageritem.x2coin == false) {


			Manageritem.x2coin = true;
			timeriteamx2.gameObject.SetActive (true);
			panelsliderx2.gameObject.SetActive (true);
			//timeriteamx2.maxValue = value * 5;
			timeriteamx2.maxValue = Getvalueslider (managerdata.manager.GetDataItemX2 ());
			timeriteamx2.value = 0;
			int vl = 0;
			timeriteamx2.value = vl;
			for (int i = 0; i < timeriteamx2.maxValue; i++) {
				timeriteamx2.gameObject.GetComponent<Slider> ().enabled = true;

				vl++;
				timeriteamx2.value = vl;
				if (Manageritem.x2coin == false) {
					panelsliderx2.gameObject.SetActive (false);
					break;
				}
				yield return new WaitForSeconds (0.1f);
			}
			panelsliderx2.gameObject.SetActive (false);
			timeriteamx2.gameObject.SetActive (false);
			Playermuving.player.stopanimationitem ("x2coin", "x2coin");
		} else if (Manageritem.x2coin) {
			Manageritem.x2coin = false;
			yield return new WaitForSeconds (0.2f);
			StartCoroutine (delayslideritemx2 (1));

		}


	}

	public void updateCreditTxt ()
	{
		creditsTxt.text = "Creditos: " + credits.ToString ("D2");
	}
		
	public IEnumerator delayslideritemgiay (int value)
	{
		if (Manageritem.giay == false) {
			Manageritem.giay = true;
			timeriteamgiay.gameObject.SetActive (true);
			panelslidergiay.gameObject.SetActive (true);
			timeriteamgiay.maxValue = Getvalueslider (managerdata.manager.GetDataItemGiay ());
			timeriteamgiay.value = 0;
			// timeriteamgiay.maxValue = value * 10;
			int vl = 0;
			timeriteamgiay.value = vl;
			for (int i = 0; i < timeriteamgiay.maxValue; i++) {
				timeriteamgiay.gameObject.GetComponent<Slider> ().enabled = true;
				vl++;
				timeriteamgiay.value = vl;
				yield return new WaitForSeconds (0.1f);
				if (Manageritem.giay == false) {
					panelslidergiay.gameObject.SetActive (false);
					timeriteamgiay.gameObject.SetActive (false);
					Playermuving.player.stopanimationitem ("giay", "giay");
					break;
				}
			}
			panelslidergiay.gameObject.SetActive (false);
			timeriteamgiay.gameObject.SetActive (false);
			Playermuving.player.stopanimationitem ("giay", "giay");
		} else if (Manageritem.giay) {
			Manageritem.giay = false;
			yield return new WaitForSeconds (0.2f);
			Playermuving.player.GetGiay ();
			StartCoroutine (delayslideritemgiay (1));

		}

	}
		
	public IEnumerator delayslideritembay (int value)
	{
         
		Perencamera.managerscen.GetItemFly ();
		timeriteambay.gameObject.SetActive (true);
		panelsliderbay.gameObject.SetActive (true);
		timeriteambay.maxValue = 100 + managerdata.manager.GetDataItemFly () * 30;
		timeriteam.gameObject.SetActive (false);
		panelslidervan.SetActive (false);
		int vl = 0;
		timeriteambay.value = vl;
		for (int i = 0; i < timeriteambay.maxValue; i++) {
			if (inthepanelpause.fixFlylong) {
				yield return new WaitForSeconds (3);
				inthepanelpause.fixFlylong = false;
			}
			timeriteambay.gameObject.GetComponent<Slider> ().enabled = true;
			vl++;
			timeriteambay.value = vl;
			yield return new WaitForSeconds (0.1f);
			if (Manageritem.baylongcoin == false) {
				panelsliderbay.gameObject.SetActive (false);
				timeriteambay.gameObject.SetActive (false);
				break;
			}
		}
		if (Manageritem.baylongcoin) {
			yield return new WaitForSeconds (3f);
			Playermuving.player.StartCoroutine (Playermuving.player.exitdelaydestroiitemlong ());
		}
		timeriteambay.gameObject.SetActive (false);

	}

	#endregion

	bool alowcall;
	private bool showthenewsocore;

	public void Lost ()
	{
		if (PlayerPrefs.HasKey ("hd") == false) {
			PlayerPrefs.SetInt ("hd", 1);
			Makesupway.isnewgame = false;
		}

		PlayerPrefs.Save ();
		managerdata.manager.savemuving (coinmuving);
		managerdata.manager.savecoin (coin);
		if (alowcall) {
			alowcall = false;
			checkthedie++;
			yourkey.text = managerdata.manager.getkey ().ToString ();
			yourkeyneed.text = needkey.ToString ();
			StartCoroutine (delayforAgain ());
		}
	}

	public static bool getvan;

	IEnumerator Delayvankey ()
	{
		getvan = false;
		yield return new WaitForSeconds (3);
		getvan = true;

	}
		
	public IEnumerator delayforAgain ()
	{
		yield return new WaitForSeconds (0.25f);
		panelseleckey.gameObject.SetActive (true);
		Manageritem.mngitem.DeleteAllItemWendie ();
		if (checkthedie > 2) {
			needkey = 1;
		} else if (checkthedie == 1) {
			needkey = 1;
		} else if (checkthedie == 2) {
			needkey = 1;
		}
		yourkeyneed.text = needkey.ToString ();
		selectkey = false;
		Playermuving.player.Enterdieinfart ();
		panellost.gameObject.SetActive (false);
		DeleteAllSlider ();
		for (int i = 0; i < 100; i++) {
			yield return new WaitForSeconds (0.001f);
			timerforkey.value -= 1;
			if (i == 99 && managerdata.manager.getkey () > 0) {
				Soundmanager.soundmanager.PlayAgain ();
				if (getvan) {
					StartCoroutine (Delayvankey ());
				}
				alowcall = true;
				Playermuving.player.StartCoroutine (Playermuving.player.EffectWenHavaeItem ());
				Playermuving.player.OurtCut (); 
				Makesupway.makemap.StartCoroutine (Makesupway.makemap.MuvingbackAllemtyWenhaveitemVan (false));
				StartCoroutine (playnowintheseleckey ());
				Camerafolow.camfolowplayer.Intanceectff (); 
				Playermuving.player.backtodie (); 
				yourkey.text = managerdata.manager.getkey ().ToString ();
				managerdata.manager.setkey (managerdata.manager.getkey () - 1);
				emty.emtyplayer.ResutTranformemty ();
				Perencamera.managerscen.height = 3;
				break;
			} else if (managerdata.manager.getkey () == 0) {
				goodCPU.intance.GetStartrotay (false);
				Camerafolow.camfolowplayer.gameObject.GetComponent<Camera> ().farClipPlane = 3;
				Playermuving.player.OurtCut ();
				inthepanelpause.playagain = true;
				Playermuving.isplay = false;
				needkey = 0;
				checkthedie = 0;
				coinforuplv = 5000;
				Playermuving.player.StartCoroutine (Playermuving.player.playagain (0));
				if (Manageritem.box == false) {
					if (Playermuving.isplay == false) {
						if (checkedIfNewScore()) {
							newHighscore = 0;
						} else {
							newHighscore = -1;
							panelseleckey.SetActive (false);
							StartCoroutine (WaitForToEnd ());
							if (!lose) {
								playopenmenumainsocore ();
								lose = true;
							}
						}
					}
				}
				if (showthenewsocore == false) {
					panelseleckey.gameObject.SetActive (false);
				}
			}
		}
		yield return new WaitForSeconds (1);
		if (selectkey == false) {
			Perencamera.managerscen.StartCoroutine (Perencamera.managerscen.delayfolowcameradie ());
		}
		alowcall = true;
		timerforkey.value = 100;
	}
	// xóa toàn bộ slider item
	void DeleteAllSlider ()
	{
		timeriteam.enabled = false;  //
		timeriteamhut.enabled = false;
		timeriteamx2.enabled = false;
		timeriteamgiay.enabled = false;
		timeriteambay.enabled = false;
	}
	// bật tắt menu chọn khóa
	public GameObject notinapkey;

	public void showNorinnapkey ()
	{
		notinapkey.SetActive (true);
	}

	public void Hidenotinnapkey ()
	{
		notinapkey.SetActive (false);
	}

	public static bool Playnowintheseleckey;

	private IEnumerator playnowintheseleckey ()
	{
		Playnowintheseleckey = true;
		panelseleckey.gameObject.SetActive (false); // ẩn menu chọn khóa
		Playermuving.player.playnowthehere ();
		Playnowintheseleckey = false;
		yield return new WaitForSeconds (0.5f);

	}
		
	private void playopenmenumainsocore ()
	{
		if (showthenewsocore == false) {
			Playermuving.isplay = false;
			panellost.gameObject.SetActive (true);
			StartCoroutine (delayforcoinmuving (coinmuving, coin));
			coinmuving = 0;
			coin = 0;
			if (coinmuving >= managerdata.manager.getmuving ()) {
				managerdata.manager.savemuving (coinmuving);
			}
		}
		panelseleckey.gameObject.SetActive (false);
		alowcall = true;

		notinapkey.SetActive (false);
       
	}

	public void tabtabcontinued ()
	{
		StartCoroutine (taptocontinuedinthenewsocore ());
	}

	public Transform Lischaracter;
	List<GameObject> showlisChaRacTer = new List<GameObject> ();
	public GameObject opennewHideSocore;

	void LoaDingcharacterOnshowNewHideSocore ()
	{
		Playermuving.isplay = false;
		panelcoin.SetActive (false); // tắt các coin
		opennewHideSocore.gameObject.SetActive (true);
		foreach (Transform item in Lischaracter) {
			showlisChaRacTer.Add (item.gameObject);
		}
        
		for (int i = 0; i < showlisChaRacTer.Count; i++) {
			if (showlisChaRacTer [i].gameObject.name == managerdata.manager.Getnowcharacter ()) {
				showlisChaRacTer [i].SetActive (true);
			} else {
				showlisChaRacTer [i].SetActive (false);
			}
		}
	}

	public void ShowCharacterLost (bool value)
	{
		if (value) {
			showPlayeronlost.SetActive (true);
		} else {
			showPlayeronlost.SetActive (false);

		}
	}
		
	public IEnumerator taptocontinuedinthenewsocore ()
	{
		NewHighscore.newhigh.backtotranform ();
		panelcoin.SetActive (true);
		opennewHideSocore.gameObject.SetActive (false);
		panellost.gameObject.SetActive (true);
		yield return new WaitForSeconds (1);
		StartCoroutine (delayforcoinmuving (coinmuving, coin));
		coinmuving = 0;
		coin = 0;
		panellost.gameObject.SetActive (true);
		if (coinmuving >= managerdata.manager.getmuving ()) {
			managerdata.manager.savemuving (coinmuving);
		}
	}
		
	private IEnumerator delayforcoinmuving (int  value, int value1)
	{
		int valuefodelay = value / 20;
		int valuefodelay1 = value1 / 20;
		int valuefordelaysecon = 0;
		int valuefordelaysecon1 = 0;
		for (int i = 0; i < 20; i++) {
			yield return new WaitForSeconds (0.06f);
			valuefordelaysecon += valuefodelay;
			valuefordelaysecon1 += valuefodelay1;
			yourcoinmuvingnow.text = valuefordelaysecon.ToString ();
			yourcoinnow.text = valuefordelaysecon1.ToString ();
		}
		yourcoinmuvingnow.text = value.ToString ();
		yourcoinnow.text = value1.ToString ();
	}

	public void gotohome ()
	{
		Time.timeScale = 1;
		IkEmty.iklegth1 = 0;
		IkEmty.iklegth = 0;
		IKanimation.iklegth = 0;
		Playermuving.backnowmuvingship = true;
		SceneManager.LoadScene("mainlv");
	}
		
	public void ExitGame ()
	{
		Application.Quit ();
	}
		
	public void Geetcoin ()
	{
		cointxt.text = "" + coinmuving;
		coinmain.text = "" + coin;
	}

	float cahe = 0;

	void getRegistry(){
		entryIN.text = "Entrada\n" + managerdata.manager.getRegistryIN ().ToString("D6");
		entryOUT.text = "Saída\n" + managerdata.manager.getRegistryOUT ().ToString("D6");
	}
		

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Credit") && credits < 99) {
			credits++;
			managerdata.manager.setCredits(credits);
			managerdata.manager.saveRegistryIN(1);
			updateCreditTxt ();
		}

		switch (selectCharacter) {
		case 1:
			characterSelectArrow.transform.position = new Vector3(0.346f, 2.612f, -6.517f);
			break;
		case 2:
			characterSelectArrow.transform.position = new Vector3(-0.63f, 2.612f, -7.177f);
			break;
		case 3:
			characterSelectArrow.transform.position = new Vector3(-0.63f, 2.612f, -5.377f);
			break;
		default:
			break;
		}
		if (Input.GetKeyDown (KeyCode.A) && !Playermuving.isplay) {
			selectCharacter++;
			if(selectCharacter == 4){
				selectCharacter = 1;
			}
		}

		if (Input.GetKeyDown (KeyCode.D) && !Playermuving.isplay) {
			selectCharacter--;
			if(selectCharacter == 0){
				selectCharacter = 3;
			}
		}

		if (selectCharacter > 0 && Input.GetButtonDown("Start") && !Playermuving.isplay && newHighscore < 0) {
			switch (selectCharacter) {
			case 1:
				managerdata.manager.Setnowcharacter("nvchinh");
				break;
			case 2:
				managerdata.manager.Setnowcharacter("nvgau");
				break;
			case 3:
				managerdata.manager.Setnowcharacter("nvgirl");
				break;
			default:
				break;
			}
			selectCharacter = 0;
			selectingCharacter = false;
			Playermuving.player.gameObject.SetActive (true);
			camerafolow.transform.position = new Vector3(0f, 4.495f, -8.902f);
			camerafolow.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			Playermuving.player.setTranformitem();
			play ();
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			isInRegistry = !isInRegistry;
			getRegistry();
		}

		registry.SetActive (isInRegistry);

		if (selectCharacter == 0) {
			characterSelect.SetActive (false);
			characterSelectArrow.SetActive (false);
		}
		else if (selectCharacter > 0 && selectingCharacter){
			Playermuving.player.gameObject.SetActive (false);
			camerafolow.transform.position = new Vector3(-2.62f, 4.5f, -8.2f);
			camerafolow.transform.localRotation = Quaternion.Euler(0f, 70f, 0f);
			characterSelect.SetActive(true);
			characterSelectArrow.SetActive (true);
		}

		if (Input.GetButtonDown("Start") && credits > 0 && !Playermuving.isplay && newHighscore < 0 && !played) {
			selectCharacter = 1;
			selectingCharacter = true;
			played = true;
			credits--;
			managerdata.manager.setCredits(credits);
			managerdata.manager.saveRegistryOUT (1);
			updateCreditTxt ();
		}

		if (newHighscore >= 7) {
			highScoreScreen.SetActive (false);
			newHighscore = -1;
			panelseleckey.SetActive (false);
			string name = "";
			for (int i = 0; i < letters.Length; i++) {
				name += letters [i].text.ToString();
			}

			Highscore highscore = new Highscore (name, ((coin * 10) + coinmuving));
			highscores.Add (highscore);
			highscores = highscores.OrderByDescending(h => h.Score).ToList();

			if (highscores.Count > 6) {
				highscores.RemoveAt (highscores.Count - 1);
			}
				
			for (int i = 0; i < 6; i++) {
				managerdata.manager.deleteHighscoreScore(i + 1);
				managerdata.manager.saveHighscoreName (i + 1, highscores[i].PlayerName);
				managerdata.manager.saveHighscoreScore (i + 1, highscores[i].Score);
			}

			StartCoroutine (WaitForToEnd ());
			if (!lose) {
				playopenmenumainsocore ();
				lose = true;
			}
		}

		if (newHighscore > -1 && !Playermuving.isplay) {
			if (Input.GetButtonDown("Start")) {
				letter = (char)65;
				newHighscore++;
			}
			if (Input.GetButtonDown("Up")) {
				letter--;
				if (letter < 65) {
					letter = (char)95;
				}
				else if (letter == 94) {
					letter = (char)90;
				}
				letters [newHighscore].text = letter.ToString ();
			}
			if (Input.GetButtonDown("Down")) {
				letter++;
				if (letter == 91) {
					letter = (char)95;
				}
				else if (letter >= 96) {
					letter = (char)65;
				}
				letters [newHighscore].text = letter.ToString ();
			}
		}

		if (newHighscore > -1) {
			highScoreScreen.SetActive (true);
			switch (newHighscore) {
			case 0:
				letters [0].color = new Color (255, 0, 0);
				break;
			case 1:
				letters [0].color = new Color (255, 255, 0);
				letters [1].color = new Color (255, 0, 0);
				break;
			case 2:
				letters [1].color = new Color (255, 255, 0);
				letters [2].color = new Color (255, 0, 0);
				break;
			case 3:
				letters [2].color = new Color (255, 255, 0);
				letters [3].color = new Color (255, 0, 0);
				break;
			case 4:
				letters [3].color = new Color (255, 255, 0);
				letters [4].color = new Color (255, 0, 0);
				break;
			case 5:
				letters [4].color = new Color (255, 255, 0);
				letters [5].color = new Color (255, 0, 0);
				break;
			case 6:
				letters [5].color = new Color (255, 255, 0);
				letters [6].color = new Color (255, 0, 0);
				break;
			}
		}

		cahe += Time.deltaTime;
		if (cahe > 60) {
			Caching.CleanCache ();
			cahe = 0;
		}
		if (Playermuving.player != null) {
			if (Playermuving.isplay) {
				panellost.gameObject.SetActive (false);
				Geetcoin ();
				if (Time.timeScale <= 1.1f) {
					if (coinmuving > coinforuplv) {
						coinforuplv = coinforuplv * 2;
						Time.timeScale += 0.05f;
					}
				}
			}
 
		}
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}
		
	float deltaTime = 0.0f;
	float time;
	public static  int coinforuplv = 5000;
		
	public IEnumerator WaitForToEnd(){
		yield return new WaitForSeconds(20);
		gotohome();
	}

	private bool checkedIfNewScore(){
		for (int i = 1; i < 7; i++) {
			if (coinmuving + (coin * 10) > managerdata.manager.getHighscoreScore (i)) {
				return true;
			}
		}
		return false;
	}
}
