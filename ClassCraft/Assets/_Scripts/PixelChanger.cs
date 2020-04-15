// Write black pixels onto the GameObject that is located
// by the script. The script is attached to the camera.
// Determine where the collider hits and modify the texture at that point.
//
// Note that the MeshCollider on the GameObject must have Convex turned off. This allows
// concave GameObjects to be included in collision in this example.
//
// Also to allow the texture to be updated by mouse button clicks it must have the Read/Write
// Enabled option set to true in its Advanced import settings.

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PixelChanger : MonoBehaviour
{
    private Camera cam;
    public GvrTrackedController Controller;
    public GameObject Reticle;
    public int widthMod = 0;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        var device = Controller.ControllerInputDevice;

        if (!device.GetButton(GvrControllerButton.TouchPadButton))
        {
            return;
        }

        RaycastHit hit;

        var ry = new Ray(Reticle.transform.position, Reticle.transform.forward);

        if (!Physics.Raycast(ry, out hit))
        {
            return;
        }

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            return;
        }

        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        for (int x = -widthMod; x <= widthMod; x++ )
        {
            for (int y = -widthMod; y <= widthMod; y++)
            {
                tex.SetPixel(
                    (int)pixelUV.x + x,
                    (int)pixelUV.y + y,
                    Color.white
                );
            }
        }
        tex.Apply();
    }
}