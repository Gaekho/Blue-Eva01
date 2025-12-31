using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine.UI;


public class APITester : MonoBehaviour
{
    [SerializeField] private string apiKey = "API-KEY";
    private const string apiUrl = "https://openapi.ai.nc.com/tts/standard/v1/api/synthesize";

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Button playButton;
    [SerializeField] private AudioClip receivedClip;

    private void Start()
    {
        playButton.interactable = false;
    }
    public void StartRequestRoutine()
    {
        StartCoroutine(SendRequest(input.text));
    }

    public void PlayReceivedClip()
    {
        if(receivedClip == null)
        {
            Debug.Log("Error : No Received clip");
            return;
        }

        audioSource.clip = receivedClip;
        audioSource.Play();
        Debug.Log("Audio play!");
    }

    IEnumerator SendRequest(string text)
    {
        // Compose request body (JSON)
        Dictionary<string, object> requestBody = new Dictionary<string, object> {
            {"text", text }, {"language", "korean"}, {"voice", "멀더"}
        };

        //Debug.Log(requestBody["text"]);                                    Can Erase these two lines.
        //Debug.Log(requestBody["voice"]);
        string jsonData = JsonConvert.SerializeObject(requestBody);
        byte[] jasonByte = Encoding.UTF8.GetBytes(jsonData);

        // Generate request
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(jasonByte);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("OPENAPI_KEY", apiKey);
        request.SetRequestHeader("Content-Type", "application/json");


        // Send request
        yield return request.SendWebRequest();

        // Response proceed
        Debug.Log("response code : " + request.responseCode);

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error : request fail");
            Debug.LogError("Server Response : " + request.downloadHandler.text);
            yield break;
        }

        string responseJson = request.downloadHandler.text;
        //Debug.Log("Raw response Json : " + responseJson);
        
        // Convert Json to Dictionarty and get Audio string
        Dictionary<string, object> resultDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson);
        string base64Audio = resultDict["audio"].ToString();

        //foreach (var key in resultDict.Keys)
        //    Debug.Log("JSON Key: " + key);

        //Debug.Log("Length of Base64Audio : " + base64Audio.Length);
        //Debug.Log("Extracted Base64Audio : " + base64Audio.Substring(0, 60) + "...");
        /*
        // Extract Audioclip in json file
        JObject obj = JObject.Parse(responseJson);
        if (obj["audio"] == null)
        {
            Debug.LogWarning("Error : null audio in Json");
            yield break;
        }
        string base64Audio = obj["audio"].ToString();
       */

        // Change base64 -> byte[ ]
        byte[] wavBytes;
        try
        {
            wavBytes = System.Convert.FromBase64String(base64Audio);
        }
        catch
        {
            Debug.LogWarning("Error : Fail to change Base64 -> Byte [ ]");
            yield break;
        }

            // Change byte[ ] -> audioclip
        //receivedClip = WavUtility.ToAudioClip(wavBytes, "TEST_CLIP");
        receivedClip = WavParserV3.ParseWav(wavBytes, "tts_test");

        Debug.Log("AudioClip Ready!");
        playButton.interactable = true;
        //WavUtility.SaveWavFromBase64(base64Audio, Application.dataPath + "/test_output.wav");
    }
}






/*
 header : API KEY value,
Body : Json file,
URL : model url.

in Python :
reques.post(URL, header, Body) 순으로 요청해서 response에 대입한다.
*/
