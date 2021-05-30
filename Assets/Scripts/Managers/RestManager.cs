using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System.Threading.Tasks;
using Models;
public static class RestManager
{
    private static readonly string basePath = "http://51.158.72.4:8000/api-auth";
	private static RequestHelper currentRequest;
    public static async Task RestScore(string token, int score){

        bool completed = false;
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer " + token;
		RestClient.Post(basePath + "/update-rating/", new Sample(score))
		.Then(res => {
            completed = true;
			RestClient.ClearDefaultParams();
			RestManager.LogMessage("Success", JsonUtility.ToJson(res, true));
		})
		.Catch(err => {
            RestManager.LogMessage("Error", err.Message);
            completed = true;
        }
        );
        while(!completed){
            await Task.Yield();
        }
        return;
    }

    
    private static void LogMessage(string title, string message) {
		Debug.Log(message);
	}
}

