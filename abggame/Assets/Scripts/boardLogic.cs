using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class boardLogic : MonoBehaviour {

	// removed by ron due to the UI public Text topL,topM,topR,botL,botM,botR, phVal, co2Val, hcoval;
	public Slider phSlider, coSlider, hcoSlider;
    public Text metresp,compensation,acidbase;
    float ph, co, hco;
	//Text[] boardArray;
	
    // Use this for initialization
	void Start () {
		//boardArray = new Text[6]{topL,topM,topR,botL,botM,botR};
		//clearText ();
		//topL.text = "hi";
	}
	
	// Update is called once per frame
	void Update () {
        /*
        phVal.text = phSlider.value.ToString ("F2");
        co2Val.text = coSlider.value.ToString();
        hcoval.text = hcoSlider.value.ToString();
        checkCondition();
        clearText ();
         */



        /*
        Debug.Log (phSlider.value);
		////place ph/////
		if(phSlider.value < 7.35) {//the ph is acidic
			place ("PH",0);
		}

		else if(phSlider.value >7.45){//the ph is basic
			place ("PH",2);
		}
		else {//ph is neutral
			place ("PH",1);
		}
        */

		///place co////
        /*
		if(coSlider.value > 45) {//the co is acidic
			place ("CO",0);
		}
		
		else if(coSlider.value < 35){//the co is basic
			place ("CO",2);
		}
		else {//co is neutral
			place ("CO",1);
		}

		///place hco////
		if(hcoSlider.value < 22) {//the hco is acidic
			place ("HCO",0);
		}
		
		else if(hcoSlider.value >26){//the hco is basic
			place ("HCO",2);
		}
		else {//hco is neutral
			place ("HCO",1);
		}
        */
	}

	void clearText() {
        //for(int i = 0; i < boardArray.Length; i++) {
        //    boardArray[i].text = "";
        //}
	}

    public void randomAlive() //randoms a living condition
    {
        phSlider.value = Random.Range(7.25f, 7.55f);
        hcoSlider.value= Random.Range(16, 34);
        coSlider.value = Random.Range(25, 55);




       /*hcothree.text = "hco3: " + hco.ToString();
        cotwo.text = "co2: " + co.ToString();
        pht.text = "ph: " + ph.ToString();*/

    }

    void checkCondition()
    {
        //first two levels
        ph = phSlider.value;
        co = coSlider.value;
        hco = hcoSlider.value;
				//Respiratory Acidosis
				if (ph < 7.35 && (hco <= 28 && hco >= 22) && co > 45) {
						metresp.text = "Respiratory";
						acidbase.text = "Acidosis";
						compensation.text = "Uncompensated";
						//rightAnswer = "Uncompensated" + metresp.text + acidbase.text;
				} else if (ph < 7.35 && hco > 26 && co > 45) {
						metresp.text = "Respiratory";
						acidbase.text = "Acidosis";
						compensation.text = "Partly-Compensated";
						//rightAnswer = "Partly-Compensated" + metresp.text + acidbase.text;
				} else if ((ph <= 7.45) && (ph >= 7.35) && hco > 26 && co > 45) {
						metresp.text = "Respiratory";
						acidbase.text = "Acidosis";
						compensation.text = "Compensated";
						//rightAnswer = "Compensated" + metresp.text + acidbase.text;
				}

			///Respiratory Alkalosis

			else if (ph > 7.45 && (hco <= 28 && hco >= 22) && co < 35) {
						metresp.text = "Respiratory";
						acidbase.text = "Alkalosis";
						compensation.text = "Uncompensated";
						//rightAnswer = "Uncompensated" + metresp.text + acidbase.text;
				} else if (ph > 7.45 && hco < 22 && co < 35) {
						metresp.text = "Respiratory";
						acidbase.text = "Alkalosis";
						compensation.text = "Partly-Compensated";
						//rightAnswer = "Partly-Compensated" + metresp.text + acidbase.text;
				} else if ((ph <= 7.45) && (ph >= 7.35) && hco < 22 && co < 35) {
						metresp.text = "Respiratory";
						acidbase.text = "Alkalosis";
						compensation.text = "Compensated";
						//rightAnswer = "Compensated" + metresp.text + acidbase.text;
				}
			//METABOLIC Acidosis

			else if (ph < 7.35 && hco < 22 && (co >= 35 && co <= 45)) {
						metresp.text = "Metabolic";
						acidbase.text = "Acidosis";
						compensation.text = "Uncompensated";
						//rightAnswer = "Uncompensated" + metresp.text + acidbase.text;
				} else if (ph < 7.35 && hco < 22 && co < 35) {
						metresp.text = "Metabolic";
						acidbase.text = "Acidosis";
						compensation.text = "Partly-Compensated";
						//rightAnswer = "Partly-Compensated" + metresp.text + acidbase.text;
				} else if ((ph <= 7.45) && (ph >= 7.35) && hco < 22 && co < 35) {
						metresp.text = "Metabolic";
						acidbase.text = "Acidosis";
						compensation.text = "Compensated";
						//rightAnswer = "Compensated" + metresp.text + acidbase.text;
				}

			//METABOLIC Alkalosis
			else if (ph > 7.45 && hco > 26 && (co >= 35 && co <= 45)) {
						metresp.text = "Metabolic";
						acidbase.text = "Alkalosis";
						compensation.text = "Uncompensated";
						//rightAnswer = "Uncompensated" + metresp.text + acidbase.text;
				}

			else if (ph > 7.45 && hco > 26 && co > 45) {
						metresp.text = "Metabolic";
						acidbase.text = "Alkalosis";
						compensation.text = "Partly-Compensated";
						//rightAnswer = "Partly-Compensated" + metresp.text + acidbase.text;
				} 
			
			else if ((ph <= 7.45) && (ph >= 7.35) && hco > 26 && co > 45) {
						metresp.text = "Metabolic";
						acidbase.text = "Alkalosis";
						compensation.text = "Compensated";
						//rightAnswer = "Compensated" + metresp.text + acidbase.text;
				} 

			else {//impossible value
					randomAlive();
                //metresp.text = "Is";
               // acidbase.text = "Impossible";
                //compensation.text = "This";

			}

			
	}


	void place(string tempText, int ANB) {// 0 = acid, 1 = neutral, 2 = basic
        /*
        if(ANB == 0) {//dealing with an acid
            if(topL.text.Equals("")) {
                topL.text = tempText;
            }
            else {
                botL.text = tempText;
            }
        }

        else if(ANB == 1) {//dealing with a neutral
            if( topM.text.Equals("")) {
                topM.text = tempText;
            }
            else {
                botM.text = tempText;
            }
        }

        else {//dealing with a base
            if(topR.text.Equals("")) {
                topR.text = tempText;
            }
            else {
                botR.text = tempText;
            }
        }
       */
    }
    
}

/**************************
 * 						  *
 * 		Below code is	  *
 * 		for generator	  *
 * 						  *
 * 						  *
 * ************************/

/*
  void randomAlive() {
		ph = Random.Range (7.25f, 7.55f);
		hco = Random.Range (16, 34);
		co = Random.Range (25, 55);
		hcothree.text = "hco3: " + hco.ToString ();
		cotwo.text = "co2: " + co.ToString ();
		pht.text = "ph: " + ph.ToString ();

	}

	void checkCondition(int hardness) {
				//first two levels
				//Respiratory Acidosis
				if (ph < 7.35 && (hco <= 28 && hco >= 22) && co > 45) {
						metresp.text = "Respiratory";
						acidbase.text = "Acidosis";
						compensation.text = "Uncompensated";
						rightAnswer = "Uncompensated" + metresp.text + acidbase.text;
				} else if (ph < 7.35 && hco > 26 && co > 45) {
						metresp.text = "Respiratory";
						acidbase.text = "Acidosis";
						compensation.text = "Partly-Compensated";
						rightAnswer = "Partly-Compensated" + metresp.text + acidbase.text;
				} else if ((ph <= 7.45) && (ph >= 7.35) && hco > 26 && co > 45) {
						metresp.text = "Respiratory";
						acidbase.text = "Acidosis";
						compensation.text = "Compensated";
						rightAnswer = "Compensated" + metresp.text + acidbase.text;
				}

			///Respiratory Alkalosis

			else if (ph > 7.45 && (hco <= 28 && hco >= 22) && co < 35) {
						metresp.text = "Respiratory";
						acidbase.text = "Alkalosis";
						compensation.text = "Uncompensated";
						rightAnswer = "Uncompensated" + metresp.text + acidbase.text;
				} else if (ph > 7.45 && hco < 22 && co < 35) {
						metresp.text = "Respiratory";
						acidbase.text = "Alkalosis";
						compensation.text = "Partly-Compensated";
						rightAnswer = "Partly-Compensated" + metresp.text + acidbase.text;
				} else if ((ph <= 7.45) && (ph >= 7.35) && hco < 22 && co < 35) {
						metresp.text = "Respiratory";
						acidbase.text = "Alkalosis";
						compensation.text = "Compensated";
						rightAnswer = "Compensated" + metresp.text + acidbase.text;
				}
			//METABOLIC Acidosis

			else if (ph < 7.35 && hco < 22 && (co >= 35 && co <= 45)) {
						metresp.text = "Metabolic";
						acidbase.text = "Acidosis";
						compensation.text = "Uncompensated";
						rightAnswer = "Uncompensated" + metresp.text + acidbase.text;
				} else if (ph < 7.35 && hco < 22 && co < 35) {
						metresp.text = "Metabolic";
						acidbase.text = "Acidosis";
						compensation.text = "Partly-Compensated";
						rightAnswer = "Partly-Compensated" + metresp.text + acidbase.text;
				} else if ((ph <= 7.45) && (ph >= 7.35) && hco < 22 && co < 35) {
						metresp.text = "Metabolic";
						acidbase.text = "Acidosis";
						compensation.text = "Compensated";
						rightAnswer = "Compensated" + metresp.text + acidbase.text;
				}

			//METABOLIC Alkalosis
			else if (ph > 7.45 && hco > 26 && (co >= 35 && co <= 45)) {
						metresp.text = "Metabolic";
						acidbase.text = "Alkalosis";
						compensation.text = "Uncompensated";
						rightAnswer = "Uncompensated" + metresp.text + acidbase.text;
				}

			else if (ph > 7.45 && hco > 26 && co > 45) {
						metresp.text = "Metabolic";
						acidbase.text = "Alkalosis";
						compensation.text = "Partly-Compensated";
						rightAnswer = "Partly-Compensated" + metresp.text + acidbase.text;
				} 
			
			else if ((ph <= 7.45) && (ph >= 7.35) && hco > 26 && co > 45) {
						metresp.text = "Metabolic";
						acidbase.text = "Alkalosis";
						compensation.text = "Compensated";
						rightAnswer = "Compensated" + metresp.text + acidbase.text;
				} 

			else {//impossible value
					generate (hardness);
			}

			if (hardness < 1) {
				acidbase.text = "?????";
			}
	
			else if (hardness < 2) {
				acidbase.text = "?????";
				compensation.text = "?????";
			}
				
			else {
				metresp.text = "?????";
				acidbase.text = "?????";
				compensation.text = "?????";
			}

			answer.text = rightAnswer;
	}

*/