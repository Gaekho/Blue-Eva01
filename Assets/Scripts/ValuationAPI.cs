using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using TMPro;

public class ValuationAPI : MonoBehaviour
{

    [SerializeField] private string apiKey = "YOUR_API_KEY";
    [SerializeField] private string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash-lite:generateContent";
    [SerializeField] private TMP_InputField input_field;
    // 분석 요청 함수
    //
    public static Dictionary<string, object> valuationJSON { get; private set; }
    public void ButtonActor()
    {
        RequestValueAnalysis(input_field.text);
    }
    public void RequestValueAnalysis(string playerInput)
    {
        StartCoroutine(PostToGemini(playerInput));
    }

    private IEnumerator PostToGemini(string playerInput)
    {
        // 1. 요청 데이터 생성
        var requestObj = new
        {
            contents = new[] { new { parts = new[] { new { text = playerInput } } } },
            system_instruction = new { parts = new[] { new { text = "Input a YouTube script, read and analyze the content, and provide a score for each when the video is actually uploaded to YouTube.\r\n\r\nBuzziness, Content Entertaining, and Writing Style\r\nAnalyze these parameters and send me three answers.\r\nPlease be strict in your judgment.\r\n\r\n1. Subscriber Growth: Focus on the content's enjoyment. Increase if it's entertaining, decrease if it's not. Please set the value to a maximum of 1,000. Average range is 100~200.\r\n2. Views: Focus on topicality. Increase if it's highly topical, decrease if it's low. Limit the value to a maximum of 10,000. Average range is 5000~10000.\r\n3. Revenue: Calculate the number of views * 2 + the subscriber growth.\r\n\r\nCreate each item as a <string, integer> dictionary and send it as a JSON file. Just send the JSON file without any further explanation." } } },
            generationConfig = new { response_mime_type = "application/json" }
        };

        string jsonPayload = JsonConvert.SerializeObject(requestObj);

        // 2. 요청 설정
        using (UnityWebRequest request = new UnityWebRequest($"{url}?key={apiKey}", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                ParseGeminiResponse(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("API 요청 실패: " + request.error);
            }
        }
    }

    private void ParseGeminiResponse(string rawJson)
    {
        // 제미나이 전체 응답에서 텍스트 부분만 추출
        //var responseObj = JsonConvert.DeserializeObject<dynamic>(rawJson);
        //string innerJson = responseObj.candidates[0].content.parts[0].text;
        JObject responseObj = JObject.Parse(rawJson);
        string innerJson = responseObj["candidates"][0]["content"]["parts"][0]["text"].ToString();

        // 실제 보상 데이터 파싱
        var resultData = JsonConvert.DeserializeObject<Dictionary<string, object>>(innerJson);

        Debug.Log("Subscriber : " + resultData["Subscriber Growth"]);
        Debug.Log($"[분석 완료] 조회수 예상: {resultData["Views"]}");
        Debug.Log("Revenue : " + resultData["Revenue"]);
        // 여기서 유니티 게임 보상 로직 실행
        valuationJSON = resultData;
    }

}

