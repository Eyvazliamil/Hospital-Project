using HospitalProject.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.SoundPlayerMethod;

public class SoundPlayers
{
    public static void PlaySound(string soundPath, Exception exception)
    {
        SoundPlayer soundPlayer = new SoundPlayer(soundPath);
        soundPlayer.Play();
        throw exception;
    }
}
