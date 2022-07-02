//A "Pirate Game" v 1.0
//Programmed by Richard Snider
//Finished November 21, 2012 (About 40 hours of total work, including learning the library)
//Description: This is a personal project in C++ I did all on my own using the fantastic Irrlicht graphics engine.
//THIS CODE IS ANYTHING BUT EFFICIENT.  I didn't go in depth with the engine's possibilities, however it is thoroughly commented.
//There isn't a whole lot of gameplay, just a ship that can sail around on a large water surface.  
//The ship can be controlled using A and D keys to steer, and W to go forward (the ship also slides across the water instead of immediately stopping).
//The ship model was a free 3d Blender file that I converted into a .x file for my use.
//I also used the "bass" library to play a version of the song "Drunken Sailor".

#include <irrlicht.h> //3d graphics engine
#include <cmath> //for trig functions used in movement
#include "bass.h" //for all audio
using namespace irr; using namespace core; using namespace scene; using namespace video; using namespace io; using namespace gui; //irrlicht namespaces
#pragma comment(linker, "/subsystem:windows /ENTRY:mainCRTStartup") //kills the console pop-up
#pragma comment(lib, "Bass.lib") //links bass library to project
#pragma comment(lib, "Irrlicht.lib") //link irrlicht library

class MyEventReceiver : public IEventReceiver
{
public:
        virtual bool OnEvent(const SEvent& event) // This is the one method that we have to implement
        {
			if (event.EventType == irr::EET_KEY_INPUT_EVENT) { KeyIsDown[event.KeyInput.Key] = event.KeyInput.PressedDown; } // Remember whether each key is down or up
            return false; 
		}

        virtual bool IsKeyDown(EKEY_CODE keyCode) const //This is used to check whether a key is being held down
        { return KeyIsDown[keyCode]; }
        
        MyEventReceiver()
        { for (u32 i=0; i<KEY_KEY_CODES_COUNT; ++i) KeyIsDown[i] = false; }

private:
       bool KeyIsDown[KEY_KEY_CODES_COUNT];  // We use this array to store the current state of each key
};

int main ()
{ 
	MyEventReceiver receiver; //Declare a receiver to handle events (specifically keyboard input in this case).  It has to be up here because the createDevice funtion uses it.

	/*The most important function of the engine is the createDevice() function. The IrrlichtDevice is created by it, which is the root object for doing anything with the engine. createDevice() has 7 parameters:
    deviceType: Type of the device. This can currently be the Null-device, one of the two software renderers, D3D8, D3D9, or OpenGL. In this example we use EDT_SOFTWARE, but to try out, you might want to change it to EDT_BURNINGSVIDEO, EDT_NULL, EDT_DIRECT3D8, EDT_DIRECT3D9, or EDT_OPENGL.
    windowSize: Size of the Window or screen in FullScreenMode to be created. In this example we use 640x480.
    bits: Amount of color bits per pixel. This should be 16 or 32. The parameter is often ignored when running in windowed mode.
    fullscreen: Specifies if we want the device to run in fullscreen mode or not.
    stencilbuffer: Specifies if we want to use the stencil buffer (for drawing shadows)
    vsync: Specifies if we want to have vsync enabled, this is only useful in fullscreen mode.
    eventReceiver: An object to receive events. We do not want to use this parameter here, and set it to 0.
	Always check the return value to cope with unsupported drivers, dimensions, etc. */
	IrrlichtDevice *device = createDevice( video::EDT_OPENGL, dimension2d<u32>(1366, 728), 16, true, false, true, &receiver); if (!device) return 1;

	device->getFileSystem()->changeWorkingDirectoryTo("C:/Users/Richard/Documents/Pirate Game/Pirates/Debug"); //Set the working directory for models, etc.

	IVideoDriver* driver = device->getVideoDriver(); //So that we do not always have to write device->getVideoDriver(), device->getSceneManager(), or device->getGUIEnvironment(). 
    ISceneManager* smgr = device->getSceneManager();
    IGUIEnvironment* guienv = device->getGUIEnvironment();

	IAnimatedMesh* ship_mesh = smgr->getMesh("ship_finished.x"); //To show something interesting, we load a Quake 2 model and display it. We only have to get the Mesh from the Scene Manager with getMesh() and add a SceneNode to display the mesh with addAnimatedMeshSceneNode(). We check the return value of getMesh() to become aware of loading problems and other errors.
    IAnimatedMeshSceneNode* ship_node = smgr->addAnimatedMeshSceneNode( ship_mesh );
	ship_node->setMaterialFlag(EMF_LIGHTING, false); //We disable lighting because we do not have a dynamic light in here, and the mesh would be totally black otherwise.
	ship_node->setScale(vector3df(50,30,30)); //Scale the ship

	IAnimatedMesh* water_mesh = smgr->getMesh("mywatermesh.x");
	IAnimatedMeshSceneNode* water_node = smgr->addAnimatedMeshSceneNode( water_mesh );
	water_node->setMaterialFlag(EMF_LIGHTING, false);
	water_node->setScale(vector3df(100, 1, 100));
	water_node->setPosition(vector3df(0,5,0));

	ISceneNode* SkyBox = 0; //Add a skybox
	SkyBox = smgr->addSkyBoxSceneNode(driver->getTexture("skyup.bmp"), driver->getTexture("skydn.bmp"), driver->getTexture("sky0.bmp"), driver->getTexture("sky1.bmp"), driver->getTexture("sky2.bmp"), driver->getTexture("sky3.bmp"));
	
	ICameraSceneNode* camera_node = smgr->addCameraSceneNodeFPS(); //create another scene node for the camera so that is stays seperate from alterations to ship and water nodes.
	smgr->addCameraSceneNodeFPS(camera_node, 100.0F, 0.1F); //camera_node, and 100F are not , third variable is camera speed (normally 0.5F)
	device->getCursorControl()->setVisible(false); //The mouse cursor needs not to be visible, so we make it invisible.
	smgr->getActiveCamera()->setPosition(vector3df(0, 75, -100)); //Start camera off behind the ship

	//Using Bass library, play spongebob song
	HWND handle = GetActiveWindow(); //Get a handle of current window to play Bass sound
	BASS_Init(-1, 44100, 0, handle, 0); // initialize default output device
	HSTREAM stream = BASS_StreamCreateFile(FALSE, "drunken_sailor.mp3", 0, 0, 0); // create a stream to play an audio file
	BASS_ChannelPlay(stream, FALSE); // start playing it

	float speed = 0; //Move speed of the ship
	vector3df v; //A simple vector used in for moving and rotation the ship and camera
	bool rising_valueX = true; //variable for rocking ship in x rotational direction
	bool rising_valueZ = true; //variable for rocking ship in z rotational direction

	//Create an array of textures for the water to go through, these should never be bitmaps because they are weird for this effect
	ITexture* img[21]; img[1] = driver->getTexture("water1.png"); img[2] = driver->getTexture("water2.png"); img[3] = driver->getTexture("water3.png"); img[4] = driver->getTexture("water4.png"); img[5] = driver->getTexture("water5.png"); img[6] = driver->getTexture("water6.png"); img[7] = driver->getTexture("water7.png"); img[8] = driver->getTexture("water8.png"); img[9] = driver->getTexture("water9.png"); img[10] = driver->getTexture("water10.png"); img[11] = driver->getTexture("water11.png"); img[12] = driver->getTexture("water12.png"); img[13] = driver->getTexture("water13.png"); img[14] = driver->getTexture("water14.png"); img[15] = driver->getTexture("water15.png"); img[16] = driver->getTexture("water16.png"); img[17] = driver->getTexture("water17.png"); img[18] = driver->getTexture("water18.png"); img[19] = driver->getTexture("water19.png"); img[20] = driver->getTexture("water20.png");

	u32 time = 0; u32 now = device->getTimer()->getRealTime(); //variables for calculating the amount of time that has passed
	
	while(device->run())
    {
		//Based on the amount of time passed, apply a texture from the img array to the water_node
		u32 oldNow = now; now = device->getTimer()->getRealTime(); u32 elapsed = now - oldNow; time += elapsed; int i = 1;
		if(time < 100) { i = 1; } if(time > 100) { i = 2; } if(time > 200) { i = 3; } if(time > 300) { i = 4; } if(time > 400) { i = 5; } if(time > 500) { i = 6; } if(time > 600) { i = 7; } if(time > 700) { i = 8; } if(time > 800) { i = 9; } if(time > 900) { i = 10; } if(time > 1000) { i = 11; } if(time > 1100) { i = 12; } if(time > 1200) { i = 13; } if(time > 1300) { i = 14; } if(time > 1400) { i = 15; } if(time > 1500) { i = 16; } if(time > 1600) { i = 17; } if(time > 1700) { i = 18; } if(time > 1800) { i = 19; } if(time > 1900) { i = 20; } if(time > 2000) { time = 0; }
		water_node->setMaterialTexture(0,img[i]);

		if(receiver.IsKeyDown(KEY_ESCAPE)) { device->closeDevice(); } //Close the program if you hit escape so YOU CAN ATUALLY CLOSE THE PROGRAM!!!
		if(receiver.IsKeyDown(KEY_KEY_M)) { device->minimizeWindow(); }
		if(receiver.IsKeyDown(KEY_KEY_W)) { if(speed > 3) { speed = 3; } else { speed += 0.05; } } //This is the forward key, it adds speed to the boat.  Maximum speed is 3, acceleration is 0.05.

		if(speed > 0) //if there is some speed, move ship (direction is based on current rotation of the ship)
		{
			v = ship_node->getPosition();  //Set vector to current position of ship
			v.Z += speed*cos((ship_node->getRotation().Y)*0.017453); //add to z and x directions of that vector (z and x are on the plane of the water, y is essentially vertical)
			v.X += speed*sin((ship_node->getRotation().Y)*0.017453); //0.017453 = pi/180, because function operates on radians, not degrees
			ship_node->setPosition(v); //Set new postion of the ship to the modified vector

			//I want to keep the camera 100 behind the ship, so when we move the ship, we need to move the camera as well
			v = smgr->getActiveCamera()->getPosition(); v.Y = 75; //Set vector to current position of camera, v.y keeps it at a certain height level
			v.Z += speed*cos((ship_node->getRotation().Y)*0.017453); //Modify vectors in same exact way as before.
			v.X += speed*sin((ship_node->getRotation().Y)*0.017453);
			smgr->getActiveCamera()->setPosition(v); //Set new postion of the camera to the modified vector

			speed -= 0.02; //Lower the speed, even if W key was pressed because this subtraction is rather small in comparison.
		}

		if(receiver.IsKeyDown(KEY_KEY_A)) //If A key is pressed, rotate ship counterclockwise (looking from above).  (rotate to the left)
		{ 
			v = ship_node->getRotation(); v.Y -= 1; ship_node->setRotation( v ); //Rotate ship

			v = ship_node->getPosition(); v.Y = 75; //Set vector to position of ship, then we add to those vector values
			v.Z -= 100*(cos(ship_node->getRotation().Y*0.017453)); //Keep camera around the back of the ship.  Keep at a distance of 100.
			v.X -= 100*(sin(ship_node->getRotation().Y*0.017453)); 
			smgr->getActiveCamera()->setPosition(v); //Set new postion of camer to modified vector
		}

		if(receiver.IsKeyDown(KEY_KEY_D)) //If D key is pressed, rotate ship clockwise (looking from above). (rotate to the right)
		{ 
			v = ship_node->getRotation(); v.Y += 1; ship_node->setRotation(v);  //Rotate ship

			v = ship_node->getPosition(); v.Y = 75;
			v.Z -= 100*(cos(ship_node->getRotation().Y*0.017453)); //we move the camera in the same direction, even though the ship is rotating clockwise now
			v.X -= 100*(sin(ship_node->getRotation().Y*0.017453));
			smgr->getActiveCamera()->setPosition(v);
		}
  
		//Rock the ship from front to back on x rotational axis
		v = ship_node->getRotation(); //Set the vector to the ships rotation
		if(v.X >= 3) { rising_valueX = false; } if(v.X <= -3) { rising_valueX = true; } //Rock the ship from 3 degrees to -3 degrees . . .
		if(rising_valueX) { v.X += 0.02; } else { v.X -= 0.02; } // . . . at a speed of 0.02
		ship_node->setRotation(v); //Set ship's new rotational vector to the modified vector

		//Rock the ship from side to side on z rotational axis
		v = ship_node->getRotation();
		if(v.Z >= 4) { rising_valueZ = false; } if(v.Z <= -4) { rising_valueZ = true; } //Rock the ship from 4 degrees to -4 degrees . . .
		if(rising_valueZ) { v.Z += 0.05; } else { v.Z -= 0.05; } // . . . at a speed of 0.02
		ship_node->setRotation(v);

		//Now we actually draw everything
		driver->beginScene(true, true, SColor(255,100,101,140));
		smgr->drawAll();
		driver->endScene(); //With the endScene() call everything is presented on the screen.
	}

	BASS_StreamFree(stream); // free the audio stream from spongbob
	BASS_Free(); // free the audio output device
	device->drop(); //After we are done with the render loop, we have to delete the Irrlicht Device created before with createDevice().
}