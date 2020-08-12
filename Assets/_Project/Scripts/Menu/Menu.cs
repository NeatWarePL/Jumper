using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject songList;

    private void OnEnable()
    {
        NW.EventsProvider.onSongDataChanged += OnSongChoosed;
    }

    private void OnDisable()
    {
        NW.EventsProvider.onSongDataChanged -= OnSongChoosed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (songList.active)
            {
                songList.SetActive(false);
            }
            else
            {
                songList.SetActive(true);
            }
        }
    }

    private void OnSongChoosed(SongData obj)
    {
        songList.SetActive(false);
    }
}
