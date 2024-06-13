using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoreDisplay : MonoBehaviour {

	public byte index;
	public Text name;
	public Text score;

	void Awake () {
		name.text = managerdata.manager.getHighscoreName (index);
		score.text = managerdata.manager.getHighscoreScore (index).ToString("D7");
	}
}