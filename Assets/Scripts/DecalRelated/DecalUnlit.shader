Shader "MyUnlit/DecalUnlit"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DecalTex ("Texture", 2D) = "blue" {}
        _PointsCount("Point count", Int) = 2
//        _Points("Points", Int) ={}
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
// Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
// #pragma exclude_renderers d3d11 gles
// Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
// #pragma exclude_renderers d3d11 gles
// Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
// #pragma exclude_renderers d3d11 gles
            // Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
            // #pragma exclude_renderers d3d11 gles
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            // #pragma multi_compile_fog

            #include "UnityCG.cginc"
            int1 _PointsCount;
            float4 _Points[100];

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _DecalTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }
           
            bool isDecal(float2 uv, float4 poinT, float size)
            {
                return uv.x >= poinT.x - size/2 &&
                    uv.x <= poinT.x + size/2 &&
                        uv.y >= poinT.y - size/2 &&
                            uv.y <= poinT.y + size/2;
            }
             bool isDecal(float2 uv, int i, float size)
            {
                return isDecal(uv, _Points[i], size);
            }
            float2 GetDecalUV(float2 uv, float size, int i)
            {
                float2 decalPos = _Points[i].xy;
                return (uv - decalPos + size.xx/2)/size;
            }
            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                // fixed4 col = tex2D(_MainTex, i.uv);
                // // apply fog
                // UNITY_APPLY_FOG(i.fogCoord, col);
                float4 col = col = tex2D(_MainTex, i.uv);
                if (_PointsCount > 0)
                {
                   if(isDecal(i.uv, 0, .1))
                   {
                       col = tex2D(_DecalTex, GetDecalUV(i.uv, .1, 0));
                       if(col.w < 0.001)
                       {
                           col = tex2D(_MainTex, i.uv);
                       }
                   }
                }
                else
                {
                    
                }
                return col;
            }
            ENDCG
        }
    }
}