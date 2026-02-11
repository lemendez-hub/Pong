using UnityEngine;

public class ResManager : MonoBehaviour
{
    public int width;
    public int height;

    public void SetWidth(int newWidth) {
        width = newWidth;
    }

    public void SetHeight(int newHeight) {
        height = newHeight;
    }

    public void setResolution() {
        Screen.SetResolution(width, height, false);
    }
}
