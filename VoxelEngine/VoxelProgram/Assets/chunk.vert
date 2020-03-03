#version 330 core
in vec3 VPosition;

uniform vec3 UPosition = vec3(0);

void main()
{
    gl_Position =  vec4(VPosition + UPosition, 1);
}