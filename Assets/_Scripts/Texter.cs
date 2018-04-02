using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


[System.Serializable]
public class Texter  {

	private string message;
	private Text text;
	private long startTime = 0;

	public Texter(Text text){
		this.text = text;
	}

	public bool TextTheString(){
		long diff = currMillis () - startTime;
		Debug.Log (diff);
		//every 0.10 seconds, 1 letter should appear. 100 millis
		int numLetters = (int) (diff/100);
		if (numLetters > message.Length)
			return true;
		
		text.text = message.Substring (0, numLetters);

		return false;
	}

	public void setText(string message){
		if (this.message != null && this.message.Equals (message))
			return; //to prevent timer from continually reseting.
		startTime = currMillis();
		this.message = message;
	}

	public long currMillis(){
		return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
	}
}

