using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WavUtility
{
    public static AudioClip ToAudioClip(byte[] wavData, string name = "audioClip")
    {
        int channels = wavData[22];
        int frequency = System.BitConverter.ToInt32(wavData, 24);

        int dataIndex = 44;
        int samples = (wavData.Length - dataIndex) / 2;

        float[] audioData = new float[samples];

        int offset = 0;
        for (int i = dataIndex; i < wavData.Length; i += 2)
        {
            short sample = System.BitConverter.ToInt16(wavData, i);
            audioData[offset++] = sample / 32768f;
        }

        AudioClip audioClip = AudioClip.Create(name, samples, channels, frequency, false);
        audioClip.SetData(audioData, 0);
        return audioClip;
    }

    public static void SaveWavFromBase64(string base64, string filePath)
    {
        // data:audio/wav;base64, 제거
        if (base64.StartsWith("data:"))
            base64 = base64.Split(',')[1];

        byte[] wavBytes = System.Convert.FromBase64String(base64);

        System.IO.File.WriteAllBytes(filePath, wavBytes);

        Debug.Log("WAV 파일 저장 완료: " + filePath);
    }

}

