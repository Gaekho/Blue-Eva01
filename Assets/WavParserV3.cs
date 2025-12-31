using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WavParserV3
{
    public static AudioClip ParseWav(byte[] bytes, string name = "audio")
    {
        int channels = BitConverter.ToInt16(bytes, 22);
        int sampleRate = BitConverter.ToInt32(bytes, 24);
        int format = BitConverter.ToInt16(bytes, 20);  // 1 = PCM, 3 = IEEE float
        int bitsPerSample = BitConverter.ToInt16(bytes, 34);

        // data chunk Ã£±â
        int pos = 12;
        while (!(bytes[pos] == 'd' && bytes[pos + 1] == 'a' && bytes[pos + 2] == 't' && bytes[pos + 3] == 'a'))
        {
            pos += 4;
            int chunkSize = BitConverter.ToInt32(bytes, pos);
            pos += 4 + chunkSize;
        }

        int dataStart = pos + 8;
        int dataLength = bytes.Length - dataStart;

        float[] samples;

        // PCM 16-bit
        if (format == 1 && bitsPerSample == 16)
        {
            int sampleCount = dataLength / 2;
            samples = new float[sampleCount];
            int index = 0;

            for (int i = dataStart; i < bytes.Length; i += 2)
            {
                short s = BitConverter.ToInt16(bytes, i);
                samples[index++] = s / 32768f;
            }
        }
        // IEEE float 32-bit
        else if (format == 3 && bitsPerSample == 32)
        {
            int sampleCount = dataLength / 4;
            samples = new float[sampleCount];
            int index = 0;

            for (int i = dataStart; i < bytes.Length; i += 4)
            {
                float f = BitConverter.ToSingle(bytes, i);
                samples[index++] = f;
            }
        }
        else
        {
            Debug.LogError($"Unsupported WAV format: format={format}, bits={bitsPerSample}");
            return null;
        }

        AudioClip clip = AudioClip.Create(name, samples.Length / channels, channels, sampleRate, false);
        clip.SetData(samples, 0);

        return clip;
    }
}
