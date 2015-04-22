using UnityEngine;
using System.Collections;

public class Symptoms : MonoBehaviour {

	string answerRespMet,answerAcidAlk,answerCompensation;


	private string name,story;
	private float lowestPHValue = 7.24f, highestPHValue = 7.58f, lowNeutralPHValue = 7.35f, highNeutralPHValue = 7.45f, lowestCO2Value = 20f, lowNeutralCO2Value = 35f, highNeutralCO2Value = 45f, highestCO2Value = 64f, lowestHCO3Value = 14f, lowNeutralHCO3Value = 22f, highNeutralHCO3Value = 26f, highestHCO3Value = 42f;
	private float ph, co2, hco3;

	void Start() {

	}
	/// <summary>
	/// Generate a diagnosis. Either random, or a selected one.
	/// </summary>
	/// <param name="d">The diagnosis wanted. Providing no param returns a random diagnosis</param>
	private void GenerateDiagnosis(int d = -1)
	{
		if (d == -1)
		{
			d = Random.Range(0, 12);
		}
		
		switch (d)
		{
			//set the answer strings, and set the values.
			//respiratory acidosis
		case 0: answerRespMet = "Respiratory"; answerAcidAlk = "Acidosis"; answerCompensation = "Uncompensated"; ph = GenDiagnosisValues("PH",0); co2 = GenDiagnosisValues("CO2",2); hco3 = GenDiagnosisValues("HCO3",1); break;
		case 1: answerRespMet = "Respiratory"; answerAcidAlk = "Acidosis"; answerCompensation = "Partial Compensation"; ph = GenDiagnosisValues("PH", 0); co2 = GenDiagnosisValues("CO2", 2); hco3 = GenDiagnosisValues("HCO3", 2); break;
		case 2: answerRespMet = "Respiratory"; answerAcidAlk = "Acidosis"; answerCompensation = "Compensated"; ph = GenDiagnosisValues("PH", 1); co2 = GenDiagnosisValues("CO2", 2); hco3 = GenDiagnosisValues("HCO3", 2); break;
			//respiratory alkalosis
		case 3: answerRespMet = "Respiratory"; answerAcidAlk = "Alkalosis"; answerCompensation = "Uncompensated"; ph = GenDiagnosisValues("PH", 2); co2 = GenDiagnosisValues("CO2", 0); hco3 = GenDiagnosisValues("HCO3", 1); break;
		case 4: answerRespMet = "Respiratory"; answerAcidAlk = "Alkalosis"; answerCompensation = "Partial Compensation"; ph = GenDiagnosisValues("PH", 2); co2 = GenDiagnosisValues("CO2", 0); hco3 = GenDiagnosisValues("HCO3", 0); break;
		case 5: answerRespMet = "Respiratory"; answerAcidAlk = "Alkalosis"; answerCompensation = "Compensated"; ph = GenDiagnosisValues("PH", 1); co2 = GenDiagnosisValues("CO2", 0); hco3 = GenDiagnosisValues("HCO3", 0); break;
			//metabolic acidosis
		case 6: answerRespMet = "Metabolic"; answerAcidAlk = "Acidosis"; answerCompensation = "Uncompensated"; ph = GenDiagnosisValues("PH", 0); co2 = GenDiagnosisValues("CO2", 1); hco3 = GenDiagnosisValues("HCO3", 0); break;
		case 7: answerRespMet = "Metabolic"; answerAcidAlk = "Acidosis"; answerCompensation = "Partial Compensation"; ph = GenDiagnosisValues("PH", 0); co2 = GenDiagnosisValues("CO2", 0); hco3 = GenDiagnosisValues("HCO3", 0); break;
		case 8: answerRespMet = "Metabolic"; answerAcidAlk = "Acidosis"; answerCompensation = "Compensated"; ph = GenDiagnosisValues("PH", 1); co2 = GenDiagnosisValues("CO2", 0); hco3 = GenDiagnosisValues("HCO3", 0); break;
			//metabolic alkalosis
		case 9: answerRespMet = "Metabolic"; answerAcidAlk = "Alkalosis"; answerCompensation = "Uncompensated"; ph = GenDiagnosisValues("PH", 2); co2 = GenDiagnosisValues("CO2", 1); hco3 = GenDiagnosisValues("HCO3", 2); break;
		case 10: answerRespMet = "Metabolic"; answerAcidAlk = "Alkalosis"; answerCompensation = "Partial Compensation"; ph = GenDiagnosisValues("PH", 2); co2 = GenDiagnosisValues("CO2", 2); hco3 = GenDiagnosisValues("HCO3", 2); break;
		case 11: answerRespMet = "Metabolic"; answerAcidAlk = "Alkalosis"; answerCompensation = "Compensated"; ph = GenDiagnosisValues("PH", 1); co2 = GenDiagnosisValues("CO2", 2); hco3 = GenDiagnosisValues("HCO3", 2); break;
		}
	}

	private float GenDiagnosisValues(string value, int LowMedHigh)
	{
		float lowest = 0f, low = 0f, high = 0f, highest = 0f;
		if (value == "PH")
		{
			lowest = lowestPHValue; low = lowNeutralPHValue; high = highNeutralPHValue; highest = highestPHValue;
		}
		else if (value == "CO2")
		{
			lowest = lowestCO2Value; low = lowNeutralCO2Value; high = highNeutralCO2Value; highest = highestCO2Value;
		}
		else if (value == "HCO3")
		{
			lowest = lowestHCO3Value; low = lowNeutralHCO3Value; high = highNeutralHCO3Value; highest = highestHCO3Value;
		}
		
		
		if (LowMedHigh == 0)
		{
			return Random.Range(lowest, low);
		}
		else if (LowMedHigh == 1)
		{
			return Random.Range(low, high);
		}
		else if (LowMedHigh == 2)
		{
			return Random.Range(high, highest);
		}
		
		Debug.LogWarning("Gen CO2 Did not receive a valid Param");
		return -50f;
	}
}
