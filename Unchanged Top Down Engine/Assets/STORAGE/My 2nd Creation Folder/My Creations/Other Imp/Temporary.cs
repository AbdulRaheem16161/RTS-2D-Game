//using unityengine;

//public class visualrays : monobehaviour
//{
//    // define the ray's length
//    public float raylength = 5f;

//    public int x = 1;
//    public int y = 1;
//    public int z = 1;

//    public int numberofrays;

//    void update()
//    {
//        // iterate through and create rays
//        for (int i = 0; i < numberofrays; i++)
//        {
//            // construct the direction vector
//            vector3 myvector1 = new vector3(x, y + i, z).normalized;

//            // draw the ray with the calculated direction
//            debug.drawray(transform.position, myvector1 * raylength, color.red);

//            if (i == 5)  // logs every 5th iteration
//            {
//                debug.log("o");
//            }
//        }
//        debug.log("p");
//    }
//}
