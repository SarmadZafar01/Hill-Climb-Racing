using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class EnviromentGenrateScript : MonoBehaviour
{
     public SpriteShapeController SpriteShapeController;

    [ Range(3f, 100f)] public int levelLength = 50;
    [ Range(1f, 50f)] public float xMultipler = 4f;
    [ Range(1f, 50f)] public float YMultipler = 2f;
    [ Range(0f, 1f)] public float cruveSmoothness = 0.5f;
   public float noiseStrp = 0.5f;
     public float bottom = 10f;


    private Vector3 lastpos;


    private void OnValidate()
    {
        SpriteShapeController.spline.Clear();
        for (int i = 0; i < levelLength; i++)
        {
            lastpos = transform.position + new Vector3(i * xMultipler, Mathf.PerlinNoise(0, i * noiseStrp) * YMultipler);
            SpriteShapeController.spline.InsertPointAt(i,lastpos);

            if(i!=0&& i!= levelLength - 1)
            {
                SpriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                SpriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMultipler * cruveSmoothness);
                SpriteShapeController.spline.SetRightTangent(i, Vector3.right * xMultipler * cruveSmoothness);
            }
        }

        SpriteShapeController.spline.InsertPointAt(levelLength,new Vector3(lastpos.x,transform.position.y - bottom));

        SpriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));
    }
}
