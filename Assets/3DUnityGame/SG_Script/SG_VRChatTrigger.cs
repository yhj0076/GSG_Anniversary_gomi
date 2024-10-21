using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_VRChatTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gosegu")
        {
            StartCoroutine(GoToURL());
        }
    }
    IEnumerator GoToURL()
    {
        SG_Camera.sgcamera.fadeColor = Color.white;
        SG_Camera.sgcamera.FadingOut();
        SG_Camera.sgcamera.speedSclae = 0.05f;
        yield return new WaitForSeconds(1.15f);
        Application.OpenURL("https://seguggang.com/fourth/?value=buyre3iTxfi2XGAOK7mTe9BuahhpSHSNBhdZlSXh7oC1eotG1JjWwgu73to9xXnP0eHhesWoXLwSw40NzIqVRqY4jYIiUcfr7moduX6WJWWTQp8lK9ayVTzlGzRFhFtNlYT1FfmqLy4VzZmvxZXTLQTquIpTOQ2MDYlTqqGBsBhEYTAMDLVc6ZSrTuvyYrmI8kBrCcgVCqA5rR7PzeOiOgY9szlZFh9bxO5GGjLFk9y2aeMr0cPAsQJeoXGGoVYmnC0tsImy6KJX6lUOhBPdqIxx0ZykvTr0cLNixEPkQRWIV4JoGUCAxP0D6I86KgPUFCbNkLrQqgjKKdXaY2f8QWzddKQve0dSYjRYAL17SKsh042XFDE020NwDTbanZhRvshCIZwydRwmd0xtnxCmF1Ln31I0zz6aZn5OhF78EffRvsXHr2S7uPIJC43EOAJMIUbG6Fmsl762TgIWR0w79Srbd5L2PJKHGK3h82GWWMeSScOafkaj");
        Application.Quit();
    }
}
