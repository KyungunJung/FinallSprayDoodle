using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePainterRed : MonoBehaviour
{
    public GameObject brushCursor, brushContainer, brushContainer2;
    public Camera sceneCamera, canvasCam, canvasCam2;
    public RenderTexture canvasTexture, canvasTexture2;
    public Material baseMaterial;
    public Material baseMaterial2;
    float brushSize = 1.0f;
    Color brushColor;
    int brushCounter = 0, MAX_BRUSH_COUNT = 10;
    bool saving = false;

   public GameObject nozzle;
    public GameObject paticle;
    bool Yesquad = false;
  
    void Update()
    {
        nozzle = GameObject.Find("ButtonRed");
        paticle = GameObject.Find("Red").transform.GetChild(0).gameObject;
        brushColor = Color.red;
        if (Input.GetMouseButton(0))
        {
            DoAction();
        }
        UpdateBrushCursor();
        if (rayOn == true && handOn == true) paticle.SetActive(true);
        else paticle.SetActive(false);

    }

    public void Click()
    {
        DoAction();
    }
    public bool handOn;


    public void DoAction()
    {

        if (saving)
            return;
        Vector3 uvWorldPosition = Vector3.zero;
        Vector3 uvWorldPosition2 = Vector3.zero;
        if (HitTestUVPosition(ref uvWorldPosition, ref uvWorldPosition2))
        {
            GameObject brushObj;

            brushObj = (GameObject)Instantiate(Resources.Load("TexturePainter-Instances/BrushEntity"));
            brushObj.GetComponent<SpriteRenderer>().color = brushColor;
            brushColor.a = brushSize * 2.0f;
            if (Yesquad == false) //고래
            {
                brushObj.transform.parent = brushContainer.transform;
                brushObj.transform.localPosition = uvWorldPosition;
                brushObj.transform.localScale = Vector3.one * brushSize;
            }
            else
            {
                brushObj.transform.parent = brushContainer2.transform;
                brushObj.transform.localPosition = uvWorldPosition2;
                brushObj.transform.localScale = Vector3.one * brushSize;
            }

        }

        brushCounter++;
        if (brushCounter >= MAX_BRUSH_COUNT)
        {
            brushCursor.SetActive(false);
            saving = true;
            Invoke("SaveTexture", 0.1f);
            Invoke("SaveTexture2", 0.1f);
        }
    }
    void UpdateBrushCursor()
    {
        Vector3 uvWorldPosition = Vector3.zero;
        Vector3 uvWorldPosition2 = Vector3.zero;
        if (HitTestUVPosition(ref uvWorldPosition, ref uvWorldPosition2) && !saving)
        {
            brushCursor.SetActive(true);
            if (Yesquad == false)
                brushCursor.transform.position = uvWorldPosition + brushContainer.transform.position;
            else brushCursor.transform.position = uvWorldPosition2 + brushContainer2.transform.position;
        }
        else
        {
            brushCursor.SetActive(false);
        }
    }
    public bool rayOn;
    RaycastHit hit;

    bool HitTestUVPosition(ref Vector3 uvWorldPosition, ref Vector3 uvWorldPosition2)
    {
        Vector3 cursorPos = new Vector3(sceneCamera.transform.position.x, sceneCamera.transform.position.y, 0.0f);

        Ray cursorRay = new Ray(nozzle.transform.position, nozzle.transform.forward);
        if (Physics.Raycast(cursorRay, out hit, 1, 1 << LayerMask.NameToLayer("Canvas")))
        {
            if (hit.transform.gameObject.name.Contains("Quad"))
            {
                Yesquad = true;
            }
            else
            {
                Yesquad = false;
            }

            MeshCollider meshCollider = hit.collider as MeshCollider;
            if (meshCollider == null || meshCollider.sharedMesh == null)
                return false;
            if (Yesquad == true)
            {
                Vector2 pixelUV = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
                uvWorldPosition2.x = pixelUV.x - canvasCam2.orthographicSize;
                uvWorldPosition2.y = pixelUV.y - canvasCam2.orthographicSize;
                uvWorldPosition2.z = 0.0f;
                float a = Vector3.Distance(nozzle.transform.position, hit.point);
                SetBrushSize(a * 0.3f);

                rayOn = true;

                print("레이온");
                return true;
            }
            else
            {

                Vector2 pixelUV = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
                uvWorldPosition.x = pixelUV.x - canvasCam.orthographicSize;
                uvWorldPosition.y = pixelUV.y - canvasCam.orthographicSize;
                uvWorldPosition.z = 0.0f;
                float a = Vector3.Distance(nozzle.transform.position, hit.point);
                SetBrushSize(a * 0.3f);

                rayOn = true;

                print("레이온");
                return true;
            }
        }
        else
        {
            rayOn = false;
            print("레이오프");
            return false;
        }

    }
    //포톤용
    void SaveTexture()
    {
        brushCounter = 0;
        System.DateTime date = System.DateTime.Now;
        RenderTexture.active = canvasTexture;
        Texture2D tex = new Texture2D(canvasTexture.width, canvasTexture.height, TextureFormat.ARGB32, false);
        tex.ReadPixels(new Rect(0, 0, canvasTexture.width, canvasTexture.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;

        var bytes = tex.EncodeToPNG();
        TextureShare.instance.TextureSharing(bytes);

        //baseMaterial.mainTexture = tex;
        foreach (Transform child in brushContainer.transform)
        {
            Destroy(child.gameObject);
        }
        Invoke("ShowCursor", 0.1f);
    }
    //void SaveTexture()
    //{
    //    brushCounter = 0;
    //    System.DateTime date = System.DateTime.Now;
    //    RenderTexture.active = canvasTexture;
    //    Texture2D tex = new Texture2D(canvasTexture.width, canvasTexture.height, TextureFormat.RGB24, false);
    //    tex.ReadPixels(new Rect(0, 0, canvasTexture.width, canvasTexture.height), 0, 0);
    //    tex.Apply();
    //    RenderTexture.active = null;
    //    baseMaterial.mainTexture = tex;


    //    foreach (Transform child in brushContainer.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }

    //    Invoke("ShowCursor", 0.1f);
    //}

    void SaveTexture2()
    {
        brushCounter = 0;
        System.DateTime date = System.DateTime.Now;
        RenderTexture.active = canvasTexture2;
        Texture2D tex = new Texture2D(canvasTexture2.width, canvasTexture2.height, TextureFormat.ARGB32, false);
        tex.ReadPixels(new Rect(0, 0, canvasTexture2.width, canvasTexture2.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;

        var bytes = tex.EncodeToPNG();
        TextureShare.instance.TextureSharing2(bytes);

        //baseMaterial.mainTexture = tex;
        foreach (Transform child in brushContainer.transform)
        {
            Destroy(child.gameObject);
        }
        Invoke("ShowCursor", 0.1f);
    }
    //void SaveTexture2()
    //{
    //    brushCounter = 0;
    //    System.DateTime date = System.DateTime.Now;
    //    RenderTexture.active = canvasTexture2;
    //    Texture2D tex = new Texture2D(canvasTexture2.width, canvasTexture2.height, TextureFormat.RGB24, false);
    //    tex.ReadPixels(new Rect(0, 0, canvasTexture2.width, canvasTexture2.height), 0, 0);
    //    tex.Apply();
    //    RenderTexture.active = null;
    //    baseMaterial2.mainTexture = tex;


    //    foreach (Transform child in brushContainer2.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //    Invoke("ShowCursor", 0.1f);

    //}
    void ShowCursor()
    {
        saving = false;
    }


    public void SetBrushSize(float newBrushSize)
    {
        brushSize = newBrushSize;
        brushCursor.transform.localScale = Vector3.one * brushSize;
    }



#if !UNITY_WEBPLAYER
    IEnumerator SaveTextureToFile(Texture2D savedTexture)
    {
        brushCounter = 0;
        string fullPath = System.IO.Directory.GetCurrentDirectory() + "\\UserCanvas\\";
        System.DateTime date = System.DateTime.Now;
        string fileName = "CanvasTexture.png";
        if (!System.IO.Directory.Exists(fullPath))
            System.IO.Directory.CreateDirectory(fullPath);
        var bytes = savedTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath + fileName, bytes);
        Debug.Log("<color=orange>Saved Successfully!</color>" + fullPath + fileName);
        yield return null;
    }
#endif
}
