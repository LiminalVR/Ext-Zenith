// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:3,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|custl-4609-OUT,clip-3466-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:30669,y:32234,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Fresnel,id:8887,x:30901,y:33133,varname:node_8887,prsc:2|EXP-5561-OUT;n:type:ShaderForge.SFN_Multiply,id:4818,x:31298,y:33146,varname:node_4818,prsc:2|A-780-OUT,B-952-OUT,C-1050-OUT,D-6476-OUT;n:type:ShaderForge.SFN_OneMinus,id:952,x:31075,y:33133,varname:node_952,prsc:2|IN-8887-OUT;n:type:ShaderForge.SFN_Slider,id:5561,x:30581,y:33160,ptovrint:False,ptlb:Fresnel Power,ptin:_FresnelPower,varname:node_5561,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Slider,id:780,x:30918,y:33058,ptovrint:False,ptlb:Opacity Strength,ptin:_OpacityStrength,varname:node_780,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Set,id:6218,x:31645,y:33129,varname:opacityClip,prsc:2|IN-502-OUT;n:type:ShaderForge.SFN_Get,id:3466,x:32523,y:33018,varname:node_3466,prsc:2|IN-6218-OUT;n:type:ShaderForge.SFN_Get,id:4609,x:32523,y:32945,varname:node_4609,prsc:2|IN-2560-OUT;n:type:ShaderForge.SFN_Set,id:2560,x:31696,y:32145,varname:mainColour,prsc:2|IN-1495-OUT;n:type:ShaderForge.SFN_LightColor,id:1995,x:30856,y:33461,varname:node_1995,prsc:2;n:type:ShaderForge.SFN_Color,id:824,x:30856,y:33308,ptovrint:False,ptlb:Light Color Mask,ptin:_LightColorMask,varname:node_824,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:502,x:31495,y:33129,varname:node_502,prsc:2|A-1467-OUT,B-4818-OUT,T-1839-OUT;n:type:ShaderForge.SFN_Vector1,id:1467,x:31298,y:33084,varname:node_1467,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:1495,x:31552,y:32145,varname:node_1495,prsc:2|A-8048-OUT,B-8005-OUT,T-6785-OUT;n:type:ShaderForge.SFN_Vector1,id:8048,x:31383,y:32108,varname:node_8048,prsc:2,v1:0;n:type:ShaderForge.SFN_LightAttenuation,id:6785,x:31383,y:32289,varname:node_6785,prsc:2;n:type:ShaderForge.SFN_ChannelBlend,id:3462,x:31075,y:33377,varname:node_3462,prsc:2,chbt:0|M-824-RGB,R-1995-R,G-1995-G,B-1995-B;n:type:ShaderForge.SFN_Tex2d,id:8452,x:30669,y:32059,ptovrint:False,ptlb:Texture Map,ptin:_TextureMap,varname:node_8452,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5373,x:30874,y:32161,varname:node_5373,prsc:2|A-8452-RGB,B-7241-RGB,C-3158-OUT;n:type:ShaderForge.SFN_Tex2d,id:8273,x:31142,y:31730,ptovrint:False,ptlb:Ambient Occlusion,ptin:_AmbientOcclusion,varname:node_8273,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:2199,x:31343,y:31832,varname:node_2199,prsc:2|A-8273-R,B-4959-OUT;n:type:ShaderForge.SFN_Slider,id:5547,x:30827,y:31898,ptovrint:False,ptlb:Ambient Occlusion Strength,ptin:_AmbientOcclusionStrength,varname:node_5547,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Set,id:4160,x:31648,y:31832,varname:ambientOcclusion,prsc:2|IN-3453-OUT;n:type:ShaderForge.SFN_Get,id:3158,x:30648,y:32378,varname:node_3158,prsc:2|IN-4160-OUT;n:type:ShaderForge.SFN_Clamp01,id:3453,x:31498,y:31832,varname:node_3453,prsc:2|IN-2199-OUT;n:type:ShaderForge.SFN_Get,id:1050,x:31054,y:33258,varname:node_1050,prsc:2|IN-4160-OUT;n:type:ShaderForge.SFN_OneMinus,id:4959,x:31142,y:31898,varname:node_4959,prsc:2|IN-5547-OUT;n:type:ShaderForge.SFN_Clamp01,id:1839,x:31298,y:33287,varname:node_1839,prsc:2|IN-3462-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5113,x:30874,y:32307,ptovrint:False,ptlb:Emission Strength,ptin:_EmissionStrength,varname:node_5113,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:8005,x:31383,y:32165,varname:node_8005,prsc:2|A-5373-OUT,B-4149-OUT;n:type:ShaderForge.SFN_Abs,id:4149,x:31212,y:32217,varname:node_4149,prsc:2|IN-7910-OUT;n:type:ShaderForge.SFN_Multiply,id:7910,x:31057,y:32217,varname:node_7910,prsc:2|A-5373-OUT,B-5113-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:9491,x:30796,y:32538,varname:node_9491,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7352,x:31155,y:32559,varname:node_7352,prsc:2|A-8911-OUT,B-9211-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8911,x:30981,y:32538,ptovrint:False,ptlb:Scanline Scale,ptin:_ScanlineScale,varname:node_8911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:128;n:type:ShaderForge.SFN_Add,id:9211,x:30981,y:32597,varname:node_9211,prsc:2|A-9491-Y,B-2808-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8583,x:30612,y:32760,ptovrint:False,ptlb:Animation Strength,ptin:_AnimationStrength,varname:node_8583,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:2808,x:30796,y:32672,varname:node_2808,prsc:2|A-5586-TSL,B-8583-OUT;n:type:ShaderForge.SFN_Time,id:5586,x:30612,y:32620,varname:node_5586,prsc:2;n:type:ShaderForge.SFN_Sin,id:6482,x:31311,y:32559,varname:node_6482,prsc:2|IN-7352-OUT;n:type:ShaderForge.SFN_Slider,id:6213,x:31154,y:32705,ptovrint:False,ptlb:Scanline Strength,ptin:_ScanlineStrength,varname:node_6213,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:9446,x:31526,y:32559,varname:node_9446,prsc:2|A-969-OUT,B-6482-OUT,T-6213-OUT;n:type:ShaderForge.SFN_Vector1,id:969,x:31311,y:32502,varname:node_969,prsc:2,v1:1;n:type:ShaderForge.SFN_Set,id:9513,x:31693,y:32559,varname:scanLineWorldUV,prsc:2|IN-9446-OUT;n:type:ShaderForge.SFN_Get,id:6476,x:31054,y:33308,varname:node_6476,prsc:2|IN-9513-OUT;proporder:8452-7241-5113-824-5561-780-8273-5547-8911-8583-6213;pass:END;sub:END;*/

Shader "Shader Forge/Holographic" {
    Properties {
        _TextureMap ("Texture Map", 2D) = "white" {}
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _EmissionStrength ("Emission Strength", Float ) = 0
        _LightColorMask ("Light Color Mask", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Range(0, 4)) = 1
        _OpacityStrength ("Opacity Strength", Range(0, 1)) = 0.8
        _AmbientOcclusion ("Ambient Occlusion", 2D) = "white" {}
        _AmbientOcclusionStrength ("Ambient Occlusion Strength", Range(0, 1)) = 0
        _ScanlineScale ("Scanline Scale", Float ) = 128
        _AnimationStrength ("Animation Strength", Float ) = 0
        _ScanlineStrength ("Scanline Strength", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 4x4 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither4x4( float value, float2 sceneUVs ) {
                float4x4 mtx = float4x4(
                    float4( 1,  9,  3, 11 )/17.0,
                    float4( 13, 5, 15,  7 )/17.0,
                    float4( 4, 12,  2, 10 )/17.0,
                    float4( 16, 8, 14,  6 )/17.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,4);
                int ySmp = fmod(px.y,4);
                float4 xVec = 1-saturate(abs(float4(0,1,2,3) - xSmp));
                float4 yVec = 1-saturate(abs(float4(0,1,2,3) - ySmp));
                float4 pxMult = float4( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec), dot(mtx[3],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _Color;
            uniform float _FresnelPower;
            uniform float _OpacityStrength;
            uniform float4 _LightColorMask;
            uniform sampler2D _TextureMap; uniform float4 _TextureMap_ST;
            uniform sampler2D _AmbientOcclusion; uniform float4 _AmbientOcclusion_ST;
            uniform float _AmbientOcclusionStrength;
            uniform float _EmissionStrength;
            uniform float _ScanlineScale;
            uniform float _AnimationStrength;
            uniform float _ScanlineStrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 _AmbientOcclusion_var = tex2D(_AmbientOcclusion,TRANSFORM_TEX(i.uv0, _AmbientOcclusion));
                float ambientOcclusion = saturate((_AmbientOcclusion_var.r+(1.0 - _AmbientOcclusionStrength)));
                float4 node_5586 = _Time;
                float scanLineWorldUV = lerp(1.0,sin((_ScanlineScale*(i.posWorld.g+(node_5586.r*_AnimationStrength)))),_ScanlineStrength);
                float opacityClip = lerp(0.0,(_OpacityStrength*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelPower))*ambientOcclusion*scanLineWorldUV),saturate((_LightColorMask.rgb.r*_LightColor0.r + _LightColorMask.rgb.g*_LightColor0.g + _LightColorMask.rgb.b*_LightColor0.b)));
                clip( BinaryDither4x4(opacityClip - 1.5, sceneUVs) );
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_8048 = 0.0;
                float4 _TextureMap_var = tex2D(_TextureMap,TRANSFORM_TEX(i.uv0, _TextureMap));
                float3 node_5373 = (_TextureMap_var.rgb*_Color.rgb*ambientOcclusion);
                float3 mainColour = lerp(float3(node_8048,node_8048,node_8048),(node_5373+abs((node_5373*_EmissionStrength))),attenuation);
                float3 finalColor = mainColour;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 4x4 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither4x4( float value, float2 sceneUVs ) {
                float4x4 mtx = float4x4(
                    float4( 1,  9,  3, 11 )/17.0,
                    float4( 13, 5, 15,  7 )/17.0,
                    float4( 4, 12,  2, 10 )/17.0,
                    float4( 16, 8, 14,  6 )/17.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,4);
                int ySmp = fmod(px.y,4);
                float4 xVec = 1-saturate(abs(float4(0,1,2,3) - xSmp));
                float4 yVec = 1-saturate(abs(float4(0,1,2,3) - ySmp));
                float4 pxMult = float4( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec), dot(mtx[3],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _Color;
            uniform float _FresnelPower;
            uniform float _OpacityStrength;
            uniform float4 _LightColorMask;
            uniform sampler2D _TextureMap; uniform float4 _TextureMap_ST;
            uniform sampler2D _AmbientOcclusion; uniform float4 _AmbientOcclusion_ST;
            uniform float _AmbientOcclusionStrength;
            uniform float _EmissionStrength;
            uniform float _ScanlineScale;
            uniform float _AnimationStrength;
            uniform float _ScanlineStrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 _AmbientOcclusion_var = tex2D(_AmbientOcclusion,TRANSFORM_TEX(i.uv0, _AmbientOcclusion));
                float ambientOcclusion = saturate((_AmbientOcclusion_var.r+(1.0 - _AmbientOcclusionStrength)));
                float4 node_5586 = _Time;
                float scanLineWorldUV = lerp(1.0,sin((_ScanlineScale*(i.posWorld.g+(node_5586.r*_AnimationStrength)))),_ScanlineStrength);
                float opacityClip = lerp(0.0,(_OpacityStrength*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelPower))*ambientOcclusion*scanLineWorldUV),saturate((_LightColorMask.rgb.r*_LightColor0.r + _LightColorMask.rgb.g*_LightColor0.g + _LightColorMask.rgb.b*_LightColor0.b)));
                clip( BinaryDither4x4(opacityClip - 1.5, sceneUVs) );
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_8048 = 0.0;
                float4 _TextureMap_var = tex2D(_TextureMap,TRANSFORM_TEX(i.uv0, _TextureMap));
                float3 node_5373 = (_TextureMap_var.rgb*_Color.rgb*ambientOcclusion);
                float3 mainColour = lerp(float3(node_8048,node_8048,node_8048),(node_5373+abs((node_5373*_EmissionStrength))),attenuation);
                float3 finalColor = mainColour;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 4x4 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither4x4( float value, float2 sceneUVs ) {
                float4x4 mtx = float4x4(
                    float4( 1,  9,  3, 11 )/17.0,
                    float4( 13, 5, 15,  7 )/17.0,
                    float4( 4, 12,  2, 10 )/17.0,
                    float4( 16, 8, 14,  6 )/17.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,4);
                int ySmp = fmod(px.y,4);
                float4 xVec = 1-saturate(abs(float4(0,1,2,3) - xSmp));
                float4 yVec = 1-saturate(abs(float4(0,1,2,3) - ySmp));
                float4 pxMult = float4( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec), dot(mtx[3],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float _FresnelPower;
            uniform float _OpacityStrength;
            uniform float4 _LightColorMask;
            uniform sampler2D _AmbientOcclusion; uniform float4 _AmbientOcclusion_ST;
            uniform float _AmbientOcclusionStrength;
            uniform float _ScanlineScale;
            uniform float _AnimationStrength;
            uniform float _ScanlineStrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float4 projPos : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 _AmbientOcclusion_var = tex2D(_AmbientOcclusion,TRANSFORM_TEX(i.uv0, _AmbientOcclusion));
                float ambientOcclusion = saturate((_AmbientOcclusion_var.r+(1.0 - _AmbientOcclusionStrength)));
                float4 node_5586 = _Time;
                float scanLineWorldUV = lerp(1.0,sin((_ScanlineScale*(i.posWorld.g+(node_5586.r*_AnimationStrength)))),_ScanlineStrength);
                float opacityClip = lerp(0.0,(_OpacityStrength*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelPower))*ambientOcclusion*scanLineWorldUV),saturate((_LightColorMask.rgb.r*_LightColor0.r + _LightColorMask.rgb.g*_LightColor0.g + _LightColorMask.rgb.b*_LightColor0.b)));
                clip( BinaryDither4x4(opacityClip - 1.5, sceneUVs) );
                float3 lightColor = _LightColor0.rgb;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
