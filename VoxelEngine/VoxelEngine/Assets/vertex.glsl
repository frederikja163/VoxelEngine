#version 330 core
in vec3 vPos;
in vec4 vColor;

out vec4 fColor;

void main()
{
    gl_Position = vec4(vPos, 1);
    fColor = (vec4(vPos, 1) + vColor) / 2.0f;
}