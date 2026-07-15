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

// https://yoyosound.com/sound/system-operation-error-sound_13273 => Error sound
// https://audio.com/vera-1838380171152570/audio/mixkit-software-interface-start-2574 => Message sound
