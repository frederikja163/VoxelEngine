#version 330 core
in vec3 vPos;
in vec4 vColor;

uniform mat4 uModel;
uniform mat4 uProjection;
uniform mat4 uView;

out vec4 fColor;

void main()
{
    gl_Position = uProjection * uView * uModel * vec4(vPos, 1);
    fColor = (vec4(vPos, 1) + vColor) / 2.0f;
}