#version 330 core
in vec3 vPosition;

uniform mat4 uModel = mat4(1);

void main()
{
    gl_Position = uModel * vec4(vPosition.x, vPosition.y, vPosition.z, 1);
}