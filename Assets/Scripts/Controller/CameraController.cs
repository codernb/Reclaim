using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float scrollFactor = 0.5f;
    public float rotateFactor = 0.5f;
    public float zoomFactor = 0.5f;
    public Transform cameraContainer;

    private bool xInverted;
    private bool yInverted;
    private bool zoomInverted;
    private Vector3 translation = new Vector3();
    private Vector3 mousePosition;
    private Vector3 rotation = new Vector3();
    private Vector3 containerRotation = new Vector3();

    public void invertX()
    {
        xInverted = !xInverted;
    }

    public void invertY()
    {
        yInverted = !yInverted;
    }

    public void invertZoom()
    {
        zoomInverted = !zoomInverted;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            up();
        else if (Input.GetKey(KeyCode.S))
            down();
        else
            zeroVertical();
        if (Input.GetKey(KeyCode.A))
            left();
        else if (Input.GetKey(KeyCode.D))
            right();
        else
            zeroHorizontal();
        transform.Translate(translation);
        if (Input.mousePosition.x < 200)
            return;
        if (Input.GetMouseButtonDown(1))
            resetMousePosition();
        if (Input.GetKey(KeyCode.Mouse1))
            rotate();
        if (Input.mouseScrollDelta.magnitude > 0)
            zoom();
    }

    private void up()
    {
        translation.z += scrollFactor;
    }

    private void down()
    {
        translation.z -= scrollFactor;
    }

    private void zeroVertical()
    {
        translation.z = 0;
    }

    private void left()
    {
        translation.x -= scrollFactor;
    }

    private void right()
    {
        translation.x += scrollFactor;
    }

    private void zeroHorizontal()
    {
        translation.x = 0;
    }

    private void resetMousePosition()
    {
        mousePosition = Input.mousePosition;
    }

    private void rotate()
    {
        var newMousePosition = Input.mousePosition;
        if (yInverted)
            containerRotation.x = (newMousePosition.y - mousePosition.y) * rotateFactor;
        else
            containerRotation.x = (mousePosition.y - newMousePosition.y) * rotateFactor;
        if (xInverted)
            rotation.y = (mousePosition.x - newMousePosition.x) * rotateFactor;
        else
            rotation.y = (newMousePosition.x - mousePosition.x) * rotateFactor;
        transform.Rotate(rotation);
        cameraContainer.transform.Rotate(containerRotation);
        mousePosition = newMousePosition;
    }

    private void zoom()
    {
        var position = transform.position;
        if (zoomInverted)
            position -= cameraContainer.forward * zoomFactor * Input.mouseScrollDelta.y;
        else
            position += cameraContainer.forward * zoomFactor * Input.mouseScrollDelta.y;
        transform.position = position;
    }

}
