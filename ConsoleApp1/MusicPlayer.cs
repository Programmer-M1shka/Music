using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class MusicPlayer
    {
        private List<Song> _songs = new List<Song>();
        private int _currentSongIndex = 0;
        private bool _isPlaying;
        private int _volume;

        public List<Song> Songs => _songs;

        public Song CurrentSong => _songs.Count > 0 ? _songs[_currentSongIndex] : null;

        public bool IsPlaying => _isPlaying;

        public int Volume
        {
            get => _volume;
            set => _volume = Math.Clamp(value, 0, 100); // Volume 0-100
        }

        public void AddSong(Song song)
        {
            _songs.Add(song);
            Console.WriteLine($"Added: {song.Title} - {song.Artist}");
        }

        public void RemoveSong(string title)
        {
            var song = _songs.Find(s => s.Title == title);
            if (song != null)
            {
                _songs.Remove(song);
                Console.WriteLine($"Removed: {song.Title} - {song.Artist}");
            }
            else
            {
                Console.WriteLine($"Song '{title}' not found.");
            }
        }

        public void Play()
        {
            if (_songs.Count == 0)
            {
                Console.WriteLine("No songs to play.");
                return;
            }

            _isPlaying = true;
            Console.WriteLine($"Now playing: {CurrentSong.Title} - {CurrentSong.Artist}");
        }

        public void NextMusic()
        {
            if (_songs.Count == 0) return;

            _currentSongIndex = (_currentSongIndex + 1) % _songs.Count;
            Console.WriteLine($"Next Song: {CurrentSong.Title} - {CurrentSong.Artist}");
        }

        public void PreviousMusic()
        {
            if (_songs.Count == 0) return;

            _currentSongIndex = (_currentSongIndex - 1 + _songs.Count) % _songs.Count;
            Console.WriteLine($"Previous Song: {CurrentSong.Title} - {CurrentSong.Artist}");
        }

        public void ShowAllSongs()
        {
            Console.WriteLine("\nAll Songs in Playlist:");
            foreach (var song in _songs)
            {
                Console.WriteLine($"{song.Title} - {song.Artist}");
            }
        }
    }
}
