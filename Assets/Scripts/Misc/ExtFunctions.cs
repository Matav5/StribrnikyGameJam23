using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace SpsResslova.General
{
    public static class ExtFunctions
    {
        public static void SetTextureImporterFormat(Texture2D texture, bool isReadable)
        {
            if (null == texture) return;

#if UNITY_EDITOR

            string assetPath = AssetDatabase.GetAssetPath(texture);
            var tImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (tImporter != null)
            {
                tImporter.textureType = TextureImporterType.Default;

                tImporter.isReadable = isReadable;

                AssetDatabase.ImportAsset(assetPath);
                AssetDatabase.Refresh();
            }

#endif
        }
        public static void ChangeAlpha(this Material mat, float alphaValue)
        {
            Color oldColor = mat.color;
            Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
            mat.SetColor("_BaseColor", newColor);
        }
        public static List<T> FindInterfaces<T>()
        {
            List<T> interfaces = new List<T>();
            GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var rootGameObject in rootGameObjects)
            {
                T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>(true);
                foreach (var childInterface in childrenInterfaces)
                {
                    interfaces.Add(childInterface);
                }
            }
            return interfaces;
        }
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
    public class UnityWebRequestExt : UnityWebRequest
    {
        public static UnityWebRequest PostJSON(string uri, string json)
        {
            var request = UnityWebRequest.Post(uri, "");
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            return request;

        }
    }
    public static class RectTransformExtensions
    {
        public static void SetDefaultScale(this RectTransform trans)
        {
            trans.localScale = new Vector3(1, 1, 1);
        }
        public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec)
        {
            trans.pivot = aVec;
            trans.anchorMin = aVec;
            trans.anchorMax = aVec;
        }

        public static Vector2 GetSize(this RectTransform trans)
        {
            return trans.rect.size;
        }
        public static float GetWidth(this RectTransform trans)
        {
            return trans.rect.width;
        }
        public static float GetHeight(this RectTransform trans)
        {
            return trans.rect.height;
        }

        public static void SetPositionOfPivot(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x, newPos.y, trans.localPosition.z);
        }

        public static void SetLeftBottomPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
        }
        public static void SetLeftTopPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
        }
        public static void SetRightBottomPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
        }
        public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos)
        {
            trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
        }

        public static void SetSize(this RectTransform trans, Vector2 newSize)
        {
            Vector2 oldSize = trans.rect.size;
            Vector2 deltaSize = newSize - oldSize;
            trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
            trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
        }
        public static void SetWidth(this RectTransform trans, float newSize)
        {
            SetSize(trans, new Vector2(newSize, trans.rect.size.y));
        }
        public static void SetHeight(this RectTransform trans, float newSize)
        {
            SetSize(trans, new Vector2(trans.rect.size.x, newSize));
        }
        public static void SingleStartCoroutine(this MonoBehaviour monoBehaviour, IEnumerator enumerator)
        {
            monoBehaviour.StartCoroutine(enumerator);
        }
        /* public static Color HexToColor(string hex)
         {
             int argb = Int32.Parse(hex.Replace("#", ""), NumberStyles.HexNumber);
             Color clr = ToColor(argb);
         }
         public static Color ToColor(this uint argb)
         {
             return Color.FromArgb((byte)((argb & -16777216) >> 0x18),
                                   (byte)((argb & 0xff0000) >> 0x10),
                                   (byte)((argb & 0xff00) >> 8),
                                   (byte)(argb & 0xff));
         }*/
    }
}
public static class ExtFunctions
{
    public static T Random<T>(this List<T> list)
    {
        if (list != null && list.Count > 0)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        return default(T);
    }
    public static List<T> Shuffle<T>(this List<T> list)
    {
        System.Random rand = new System.Random();
        if (list != null && list.Count > 0)
        {
            return list.OrderBy(x => rand.Next()).ToList();
        }
        return default(List<T>);
    }

}