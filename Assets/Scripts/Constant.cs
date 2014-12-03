using UnityEngine;

/* A lovely class that contains useful constants for other classes to access.
 * Unity does not seem to support "const", so we have to make do with public static variables.
 * Please use them as if their were constants.
 */
public class Constant {
	public static float SCREEN_WIDTH_HALF = Camera.main.aspect * Camera.main.orthographicSize;
	public static float SCREEN_HEIGHT_HALF = Camera.main.orthographicSize;
}
