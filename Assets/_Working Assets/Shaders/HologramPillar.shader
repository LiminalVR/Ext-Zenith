// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:7539,x:32719,y:32712,varname:node_7539,prsc:2|diff-8251-OUT,emission-2481-OUT,clip-2974-A;n:type:ShaderForge.SFN_Tex2d,id:2974,x:32112,y:32628,ptovrint:False,ptlb:maintex,ptin:_maintex,varname:node_2974,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:eefcc64af28fea9498d66047252ced0e,ntxv:0,isnm:False|UVIN-4870-OUT;n:type:ShaderForge.SFN_Color,id:1792,x:32065,y:32813,ptovrint:False,ptlb:tint,ptin:_tint,varname:node_1792,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:8251,x:32356,y:32779,varname:node_8251,prsc:2|A-2974-RGB,B-1792-RGB;n:type:ShaderForge.SFN_Tex2d,id:2849,x:32065,y:33009,ptovrint:False,ptlb:emissionTexture,ptin:_emissionTexture,varname:_node_2974_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:eefcc64af28fea9498d66047252ced0e,ntxv:0,isnm:False|UVIN-4870-OUT;n:type:ShaderForge.SFN_Color,id:4713,x:32065,y:33214,ptovrint:False,ptlb:EmissionColor,ptin:_EmissionColor,varname:_node_1792_copy,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2481,x:32323,y:33089,varname:node_2481,prsc:2|A-2849-RGB,B-4713-RGB;n:type:ShaderForge.SFN_TexCoord,id:6539,x:31187,y:32468,varname:node_6539,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:9945,x:31466,y:32468,varname:node_9945,prsc:2,spu:0,spv:1|UVIN-6539-UVOUT,DIST-5707-OUT;n:type:ShaderForge.SFN_Time,id:5343,x:31035,y:32755,varname:node_5343,prsc:2;n:type:ShaderForge.SFN_Slider,id:5370,x:31078,y:32661,ptovrint:False,ptlb:pannerVertSpeed,ptin:_pannerVertSpeed,varname:node_5370,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:5707,x:31260,y:32778,varname:node_5707,prsc:2|A-5370-OUT,B-5343-T;n:type:ShaderForge.SFN_TexCoord,id:9561,x:31038,y:32945,varname:node_9561,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:4296,x:30929,y:33138,ptovrint:False,ptlb:pannerHorizSpeed,ptin:_pannerHorizSpeed,varname:_pannerVertSpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:8118,x:31113,y:33253,varname:node_8118,prsc:2|A-4296-OUT,B-342-T;n:type:ShaderForge.SFN_Time,id:342,x:30886,y:33232,varname:node_342,prsc:2;n:type:ShaderForge.SFN_Panner,id:1588,x:31317,y:32945,varname:node_1588,prsc:2,spu:1,spv:0|UVIN-9561-UVOUT,DIST-8118-OUT;n:type:ShaderForge.SFN_Add,id:4870,x:31633,y:32737,varname:node_4870,prsc:2|A-9945-UVOUT,B-1588-UVOUT;proporder:2974-1792-2849-4713-5370-4296;pass:END;sub:END;*/

Shader "Custom/HologramPillar" {
    Properties {
        _maintex ("maintex", 2D) = "white" {}
        _tint ("tint", Color) = (0.5,0.5,0.5,1)
        _emissionTexture ("emissionTexture", 2D) = "white" {}
        [HDR]_EmissionColor ("EmissionColor", Color) = (0.5,0.5,0.5,1)
        _pannerVertSpeed ("pannerVertSpeed", Range(-1, 1)) = 0
        _pannerHorizSpeed ("pannerHorizSpeed", Range(-1, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _maintex; uniform float4 _maintex_ST;
            uniform float4 _tint;
            uniform sampler2D _emissionTexture; uniform float4 _emissionTexture_ST;
            uniform float4 _EmissionColor;
            uniform float _pannerVertSpeed;
            uniform float _pannerHorizSpeed;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 node_5343 = _Time;
                float4 node_342 = _Time;
                float2 node_4870 = ((i.uv0+(_pannerVertSpeed*node_5343.g)*float2(0,1))+(i.uv0+(_pannerHorizSpeed*node_342.g)*float2(1,0)));
                float4 _maintex_var = tex2D(_maintex,TRANSFORM_TEX(node_4870, _maintex));
                clip(_maintex_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = (_maintex_var.rgb*_tint.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _emissionTexture_var = tex2D(_emissionTexture,TRANSFORM_TEX(node_4870, _emissionTexture));
                float3 emissive = (_emissionTexture_var.rgb*_EmissionColor.rgb);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _maintex; uniform float4 _maintex_ST;
            uniform float4 _tint;
            uniform sampler2D _emissionTexture; uniform float4 _emissionTexture_ST;
            uniform float4 _EmissionColor;
            uniform float _pannerVertSpeed;
            uniform float _pannerHorizSpeed;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 node_5343 = _Time;
                float4 node_342 = _Time;
                float2 node_4870 = ((i.uv0+(_pannerVertSpeed*node_5343.g)*float2(0,1))+(i.uv0+(_pannerHorizSpeed*node_342.g)*float2(1,0)));
                float4 _maintex_var = tex2D(_maintex,TRANSFORM_TEX(node_4870, _maintex));
                clip(_maintex_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = (_maintex_var.rgb*_tint.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform sampler2D _maintex; uniform float4 _maintex_ST;
            uniform float _pannerVertSpeed;
            uniform float _pannerHorizSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_5343 = _Time;
                float4 node_342 = _Time;
                float2 node_4870 = ((i.uv0+(_pannerVertSpeed*node_5343.g)*float2(0,1))+(i.uv0+(_pannerHorizSpeed*node_342.g)*float2(1,0)));
                float4 _maintex_var = tex2D(_maintex,TRANSFORM_TEX(node_4870, _maintex));
                clip(_maintex_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
