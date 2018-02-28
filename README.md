# unity-advanced-vector-opperations
A static class containing a number of trigonometry-based methods for use in the Unity 3d engine.

Methods:

RotateVector3_90Degrees:
Executes a "perfect" 90 rotation by swapping the x, y and z coords as needed. Paramiters are the vector to be rotated, the axis to be rotated around, and wether or not to rotate clockwise.

RotateVector3:
Executes a not so perfect rotation using Unity's Mathf.Sin and Mathf.Con methods. Paramiters are the vector to be rotated, the axis to be rotated around, and the number of degrees to be rotated.

CircleTheSquare:
Transforms a vector2 to constrain x and y coords within a circle based off the vectors normalized value.

TrackPointAroundAxis:
Returns a rotation quaternion for a GameObject to aim at a location. The rotationAxis and faceToAlignWithTarget parmiters determin which axis to rotate around and which should face the target point.
