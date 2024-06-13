using System;
using System.Collections.Generic;

[System.Serializable]
public class Highscore {

	public string PlayerName { get; set; }
	public int Score { get; set; }

	public Highscore (string playerName, int score) {
		PlayerName = playerName;
		Score = score;
	}

	public string ToString() {
		return PlayerName + ": " + Score;
	}
}
