using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Music
{
    private List<Song> playlist;
    private int indexActualSong;

	public Music()
	{
        playlist = new List<Song>();
        indexActualSong = -1;
	}

    private int getSongIndex(Song music)
    {
        /*if (playlist.Exists(music))
        {
            return playlist.FindIndex(music);
        } else
        {
            return -1;
        }*/
        return -1;
    }

    public void addSong(Song music)
    {
        playlist.Add(music);
    }

    public void removeSong(int index)
    {
        playlist.RemoveAt(index);
    }

    public void play(Song song)
    {
        if (getSongIndex(song) != indexActualSong)//Verification: ce n'est pas le son actuellement en cour
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = false;
            indexActualSong = getSongIndex(song);
        }
    }
    public void playAndLoop(Song song)
    {
        if (getSongIndex(song) != indexActualSong)//Verification: ce n'est pas le son actuellement en cour
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            indexActualSong = getSongIndex(song);
        }
    }

    public void loopActualSong()
    {
        MediaPlayer.IsRepeating = true;
    }

    public void stopLooping()
    {
        MediaPlayer.IsRepeating = false;
    }
}
