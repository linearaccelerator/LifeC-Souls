using UnityEngine;

public class AppOpener : MonoBehaviour
{
    public string url;

    public void OpenDiscord()
    {
        Application.OpenURL(url);
    }
}
