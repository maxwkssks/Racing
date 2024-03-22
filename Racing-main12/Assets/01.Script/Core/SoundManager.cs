using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable] // Ŭ���� ���� ����(����)���� �ν����Ϳ� ǥ�� �� �� �ֵ���
public class Sound  // ������Ʈ �߰� �Ұ���.  MonoBehaviour ��� �� �޾Ƽ�. �׳� C# Ŭ����.
{
    public string Name;  // �� �̸�
    public AudioClip Clip;  // ��
}

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;  // �ڱ� �ڽ��� ���� �ڿ�����. static�� ���� �ٲ� �����ȴ�.

    [SerializeField]
    private Sound[] SFXSounds;  // ȿ���� ����� Ŭ����

    [SerializeField]
    private Sound[] BgmSounds;  // BGM ����� Ŭ����

    [SerializeField]
    private AudioSource AudioSourceBgm;  // BGM �����. BGM ����� �� �������� �̷������ �ǹǷ� �迭 X 

    [SerializeField]
    private AudioSource[] AudioSourceSFX;  // ȿ�������� ���ÿ� �������� ����� �� �����Ƿ� 'mp3 �����'�� �迭�� ����

    private void Awake()  // ��ü ������ ���� ���� (�׷��� �̱����� ���⼭ ����)
    {
        if (instance == null)  // �� �ϳ��� �����ϰԲ�
        {
            instance = this;  // ��ü ������ instance�� �ڱ� �ڽ��� �־���
        }
        else
            Destroy(this.gameObject);
    }

    public void PlaySFX(string _name)
    {
        for (int i = 0; i < SFXSounds.Length; i++)
        {
            if (_name == SFXSounds[i].Name)
            {
                for (int j = 0; j < AudioSourceSFX.Length; j++)
                {
                    if (false == AudioSourceSFX[j].isPlaying)
                    {
                        AudioSourceSFX[j].clip = SFXSounds[i].Clip;
                        AudioSourceSFX[j].Play();
                        return;
                    }
                }
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
    }

    public void PlayBGM(string _name)
    {
        for (int i = 0; i < BgmSounds.Length; i++)
        {
            if (_name == BgmSounds[i].Name)
            {
                AudioSourceBgm.clip = BgmSounds[i].Clip;
                AudioSourceBgm.Play();
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
    }

    public void StopAllSFX()
    {
        for (int i = 0; i < AudioSourceSFX.Length; i++)
        {
            AudioSourceSFX[i].Stop();
        }
    }
}