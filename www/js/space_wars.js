//   SpaceWars
//
//   Version info
version = "version 0.1 - 10/29/09 - Abram Adams";
// DISCLAIMER: Though most of this code is unique, I did "borrow" some code from StarGates
// namely the CalibrateDelay, ShowHighScores and GetHighScores subs


// =========================================================================
//  INTRODUCTION TO THIS CODE/GUIDE
// =========================================================================
// This program was written as a teaching tool to expose students
// to the various aspects of programming.  SmallBasic is a great
// starter tool that is simple and easy to use, but still allows you
// to create some pretty cool things.
//
// Throughout the code you will find comments (like this one) that will
// describe the section of code around it.  Key topics such will be
// explained such as:
//      Comments
//                                 Variables
//      Constants
//      function Routines
//      Function
//      Class
//      Properties
//      Data Types
//      Loops, Logic Control and Program Flow
//      Events and Event Handlers
//      Some basic "Best Practices" to become familiar with
//
// When these topics are discussed, you will see a heading such as:
// =========================================================================
//  KEY TOPIC:
//  Variables
// =========================================================================
//  Once the key topics have been covered, there will be much less descriptive
//  commentary, so if you see something later you don't recall, look back toward
//  the top of the file and see if it is explained (otherwise ask your instructor)
//
//  This game uses basic and advanced techniques.  Depending on your
//  programming experience you may be able to fully understand all that is
//  going on, but if you don't that's OK.  Most programmers start out "playing"
//  with code they don't understand.  Tweek a value here or change a formula
//  there and watch how it changes the program (or breaks it!). Trial and error
//  is a very good way to learn programming.

// =========================================================================
//    FILE/FOLDER STRUCTURE
// =========================================================================
// This game uses several image and audio files, such as images for the
// background, enemy ships, asteroids, etc... as well as explosion, shot, and intro
// sounds.  Many of the images/sounds used are level specific, and can be changed
// without changing any of the code.  Simply add an image file to the appropriate
// directory and a new enemy/asteroid will be added to that level.
// The structure looks like
//    --space_wars/
//      scores.txt <-- used to keep high scores
//      SmallBasicLibrary.dll <-- required, SmallBasic file
//      space_wars.exe <-- the game, compiled to execute.  This will run the game without the need for SmallBasic
//      space_wars.pdb <-- SmallBasic generated file
//      space_wars.sb <-- the uncompilled code (this file)
//      |-- audio/
//          |--levels/
//              |--1/
//                  |--bgm/
//                        <mp3 files to play as background music for level 1>
//              |--2/
//                  |--bgm/
//                        <mp3 files to play as background music for level 2>
//              This repeats up to level 10
//      |-- images/
//          |--levels/
//              |--1/
//                  |--background/
//                        <image file for background for level 1>
//                  |--enemies/
//                        <image files for enemy ships for level 1>
//                  |--objects/
//                        <image files for objects (i.e. asteroids) for level 1>
//              |--2/
//                  |--background/
//                        <image file for background for level 2>
//                  |--enemies/
//                        <image files for enemy ships for level 2>
//                  |--objects/
//                        <image files for objects (i.e. asteroids) for level 2>
//              This repeats up to level 10
//          |--objects/
//
//  So try to add a few enemy ships or asteroid objects into a level and see it in action.

// =========================================================================
//    DISCLAIMER ABOUT THE GAME PLAY
// =========================================================================
//  This game was kept fairly basic, and does contain a few glitches due to both
//  the current limitations of SmallBasic and some oversimplified mathematics
//  used (i.e. to detect collisions,etc...).  So while you play the game you may
//  notice your fireball may seem to pass through an enemy, or attimes you may
//  also see objects "freeze" or the game might crash altogether.  If any of this
//  happens to you, sorry.  Hopefully some day you can fix these bugs!
//

// Now, on with the program.

// =========================================================================
//  KEY TOPIC:
//  Comments
//   One of the most important things to learn in any programming languages
//   is how to write comments.  Comments are meant to describe or explain
//   a section of code, or to temporarily disable a line or section of code. When
//   the program runs it will skip all comments.
//   In small basic you create a comment by preceeding the text with a single
//   quote ( //  ).  Each line of your comment must begin with the single qoute and
//   everything following that quote will be skipped.
// =========================================================================
windowWidth = 1280;
windowHeight = 800;
var bgCanvas = document.createElement( "canvas" );
bgCanvas.setAttribute( "id", "bgCanvas" );
bgCanvas.setAttribute( "style", "position:absolute;width:" + windowWidth + "px;height:" + windowHeight + "px;z-index:0" );
document.body.appendChild( bgCanvas );
var bgCtx = bgCanvas.getContext( '2d' );
// bgCanvas.globalCompositeOperation = 'destination-over';
bgCtx.clearRect( 0, 0, windowHeight, windowWidth ); // clear canvas

var canvas = document.createElement( "canvas" );
canvas.setAttribute( "id", "GraphicsWindow" );
canvas.setAttribute( "style", "position:absolute;width:" + windowWidth + "px;height:" + windowHeight + "px;z-index:1" );
document.body.appendChild( canvas );
var GraphicsWindow = canvas.getContext( '2d' );
// GraphicsWindow.globalCompositeOperation = 'destination-over';
GraphicsWindow.clearRect( 0, 0, windowHeight, windowWidth ); // clear canvas

// Add HTML5 Audio tag
var Sound = document.createElement( "audio" );
Sound.setAttribute( "id", "sound" );
document.body.appendChild( Sound );
// another audio tag for the background music
var BGM = document.createElement( "audio" );
BGM.setAttribute( "id", "BGM" );
document.body.appendChild( BGM );
// =========================================================================
//  KEY TOPIC:
//  Program Flow
//  Programming is much like writing a story.  First you set the stage,
//  describe the environment, set boundaries then you proceed in the telling
//   of the story.  In this case, we are setting up the window that will
//  contain our game.
// =========================================================================
// Setup the game window
// GraphicsWindow.CanResize = "false"
// =========================================================================
//  KEY TOPIC:
//  Variables
//  Variables are placeholders used in programming to represent a specific
//  value.  These are typically used to inform a part of the program how
//  behave.
//  For instance, the below variables will define the width and height
//  of our window.  We are using Properties of the Desktop class (more on
//  classes and properties later) to calculate how wide and high to draw
//  our window and where to place it.  Notice the usage of simple mathematics
//  to dynamically size the window.  Our program window height will be the
//  height of the computer's desktop height less 100 pixels and the width
//  will be 10 pixels narrower than the desktop.
//  Note: Variable names cannot have spaces or punctuation.
// =========================================================================

centerX = windowWidth / 2;
centerY = windowHeight / 2; // This (and centerX) is used later to find the center of the window
// GraphicsWindow.width = windowWidth;
// GraphicsWindow.height = windowHeight;
// =========================================================================
// Some more variables
window.document.title = "Abram's Space Wars"; // Sets the text in the title bar of the window.
// GraphicsWindow.Left = ( Desktop.Width - windowWidth ) / 2 GraphicsWindow.Top = 10 GraphicsWindow.BackgroundColor = "black"
// Now show the window.  This is the Function SmallBasic provides to display the window.
// More on Functions later.
// GraphicsWindow.Show()

// =========================================================================
//  KEY TOPIC:
//  Events and Event Handlers
//  Events are actions that happen, either automated by the system or
//  generated by a user interaction, such as pressing down a key
//  In this case, when the key is pressed down we will execute the
//  function routine called "onKeyDown" which we define later.  This function routine
//  is known as the Event Handler, as it Handles the Event action
// =========================================================================
GraphicsWindow.KeyDown = onKeyDown;
// The onKeyUp function will fire when the user releases the key.
// This is also defined later
GraphicsWindow.KeyUp = onKeyUp;
// =========================================================================

// Key controls
// These are variables that will make it easier to program
// later when we are using directional inputs to navigate
// our game.  Since in SmallBasic when we start typing a
// word it gives us a drop down list of options that match
// what we// ve typed, we can use that to be sure that we
// don't mispell a variable name.  It also allows us to assign
// a meaningful name to the actual key code, so instead of
// remembering what key makes the ship fire a bullet, we
// just need to use the fireKey variable.
var leftKey = "Left",
    rightKey = "Right",
    upKey = "Up",
    downKey = "Down",
    fireKey = "Space",
    pauseKey = "P",
    quitKey = "Escape",
    hyperspaceKey = "RightCtrl",
    changeWeaponKey = "G",
    // Now we'll setup some more convenience variables that we'll
    // use later to determine what key was pressed, and in which order.
    leftKeyPressed = false,
    rightKeyPressed = false,
    upKeyPressed = false,
    downKeyPressed = false,
    fireKeyPressed = false,
    hyperspaceKeyPressed = false,
    changeWeaponKeyPressed = false,
    leftRightPriority = rightKey,
    upDownPriority = upKey,


    //  Dec2Hex conversion string
    hexaDecimal = "0123456789ABCDEFFEDCBA9876543210",
    // Since we will use external files for images and sound, we'll set up a
    // couple variables to point to these directories.  This makes it easier
    // to reference the directory paths (less typing) and it also makes it
    // easier to move or rename the folders if need be.  In those cases
    // we// d just need to update the new folder in one place and everywhere
    // in our program that uses those directories will automatically use
    // the new ones.
    imagePath = "/images/",
    audioPath = "/audio/";

// =========================================================================
//  KEY TOPIC:
//  function Routines
//  In this section we introduce the use of function routines.  function routines are a
//  pre-defined set of steps or actions that are grouped into a single name
//  that can be executed anywhere in our program.  This will allow us to
//  easily reproduce the results at any time in our program.
//  Before we create a function routine, look at the following lines to see how a
//  function routine is executed (otherwise known as "called" or "fired").  In the
//  following lines we execute function routines that are defined later in the
//  code.
// =========================================================================
// Load images
initImages();
// Load sounds
initSounds();
//  Determine speed of computer
CalibrateDelay();
// =========================================================================
//  You will notice that there are just three lines of code (not counting the
//  comments) that actually do all the work to load the images and sounds
//  used in our program.  You'll also notice they end with (), this tells SmallBasic
//  that these are calls to a function routine and they are to be executed as soon as
//  they are encountered.  In general terms, SmallBasic will execute your code
//  from top to bottom, left to right (just like you would read it).  When
//  it encounters a function routine call, it replaces the name() with the actual
//  code that that function represents.
//
//  Note:
//  You may recall from above that we assigned function routines to the KeyDown
//  and KeyUp events.  When we did we did not include the () at the end.  That
//  is because we don't want the function routines to execute when that line is
//  interpreted by SmallBasic, rather we want them to execute when the event
//  they are assigned to occurs.
// =====================================================================*

// =========================================================================
//  KEY TOPIC:
//  Constants
//  Programmers often use techniques that help them be more efficient, as well
//  as to help those that may work on the code in the future.  One of the ways we
//  do this is to use "constants".  Constants are a basically a variable that will
//  not change during the life of the application run.  These are typically used
//  to store numeric values that are used as pointers into user friendly variable
//  names.  In this particular section we are setting up named indicies to use
//  when referencing specific positions in an array.
// =========================================================================
//  KEY TOPIC:
//  Data Types
//  Information stored in variables can be many different data types.  Some of
//  the typical data types are "String" types.  These are simple plain text
//  values such as numbers, or letters/words.  Other data types are more complex
//  and can store more information than just numbers and words.  Arrays for instance
//               gives us a special way to store data in a single variable.  Arrays are sort
//  of like a list of values, each item in the list is numbered sequentially.
//  So if the array had the following values:
//     hat, shoes, shirt
//  and you wanted the value of the shoes you// d ask for the 2nd position (or
//  index) of the array.  In SmallBasic that would look like:
//     myArray[2]
//  The number in the square brackets tell the myArray variable which position
//  to return.
//  Of course there are many other data types, such as objects which can
//  themselves contain simple and complex data.
// =====================================================================*
//
//  Back to this set of variables...  Each position in the arrays used in
//  this program store different type of information, for instance the first
//  position in the array stores the size, the second and third store the X
//  and Y coordinates.  When you are programming it is impossible to remember
//  all of these positions by number, especially when there could be thousands.
//  Therefore we use these constants for clarity and easy reference, and set
//  their values to the position in the index we wish to reference.
var _size = 1,
    _x = 2,
    _y = 3,
    _shape = 4,
    _isVisible = 5,
    _angle = 6,
    _speed = 7,
    _maxSpeed = 8,
    _startPos = 9,
    _width = 10,
    _height = 11,
    _hits = 12,
    _direction = 13,
    _totalHits = 14,
    _maxSpritePoints = 15,
    _completePoints = 16,
    _shots = 17,
    _hasWeapons = 18,
    _shotTicker = 19,
    _bulletColor = 20,
    // level constants
    _maxSprites = 1,
    _spritesToLevelUp = 2,
    _pointWorth = 3,
    _minSpriteSpeed = 4,
    _maxSpriteSpeed = 5,
    _shotInterval = 6,
    _backgroundImage = 7,
    _objectImages = 8,
    _enemyImages = 9,
    _EnemyRatio = 10,
    _maxHits = 11,
    _hasBoss = 12,
    _BGMusic = 13;

// =========================================================================
//  KEY TOPIC:
//  Best Practice
//  Notice in the above section I prefix variables with an underscore (_).
//  This is a simple way to identify that these are array index variables.
//  Having the underscore in the name does not change anything about how
//  it works, it just stands out when you a reading it.  Various techniques
//  like this are used (and sometimes vary between languages).  For instance
//  I use what is called Lower Camel Case to name my Functions, Subs, variables,
//  etc... Since you cannot have spaces in variable names it makes it easier
//  to read something like: thisIsLowerCamelCase than it is to read
//  thisislowercamelcase.
// =========================================================================

// Some other constants
// true = 1
// false = 0
var play = true,
    pause = false,
    alive = true,
    gameEnd = false;

// Desired frames per second (but will be lower on slower computers)
var fpsTarget = 30;
var shipHeight = 20;
var levels = [];
var highScoreNames = [];
var spriteImage = [];
var enemyImage = [];
var explodeImage = [];
var shipImages = [];
var enemyBulletColors = [];
var Shapes = new Image();
var bgImage = new Image();
// Here we are ready to start the actual game.  Our window is setup and visible,
// our images and sounds are loaded, our variables that we will be using are
// initialized and we are ready to go.
// Here we will begin to appreciate the use of function routines.  Each one of these
// function routines do a lot of work.  If we didn't have function routines we// d have to
// type all of that work out right here.  Ok, not convincing, but what if you
// wanted to perform the same set of actions again.  Without subs you// d have
// to re-write those steps every time you wanted to use them.  But there's more,
// now consider if you wanted to add a feature, or change the way something
// worked.  You// d have to make sure you change it in each location exactly the same.
// Many of the below subs are used in other places in this program, such as the
// initGame() function is used to restart the game (such as after a game over)
initGame();
initLevels();
GetHighScores();
initBackground();
intro();
// drawPanel();
// updateScoreBoard();
// initBackground();
// initSprites();
// initExplosion();
// initShip();
// initWeapons();

// //  The game loop
// MainLoop();

//  Exit game
// Program.End();

// =========================================================================
//  KEY TOPIC:
//  function Routines
//  Our first function routine
//  function routines are defined by using the function keyword followed by the name
//  (no spaces/punctuation) and the definition is completed by the }
//  keyword.  The code between function and } will execute when the function is
//  called using name() (replacing "name" with the actual name)
//
//  Note that function routines can reside anywhere in the applicaiton, even at
//  a later point than when they are called.  This is because SmallBasic will
//  compile your code before it runs.
//  As a personal preference I prefer (as you see in this program) to place
//  all my application variable setup and declaration at the top of the file
//  and place the function routines at the bottom.  You'll also notice that I don't
//  declare (or create) any variables outside of function routines beyond this point.
//  I could, but it makes it difficult to debug (or figure out what went wrong)
//  later.
// =========================================================================*

function initGame() {
    // Setup Game
    // All this function really does is set/reset all the neccessary variables to
    // a predefined "starting" point.  This makes it easy to reset the game.
    play = 1;
    level = 1;
    maxLevels = 10;
    score = 0;
    lives = 5;
    curPoints = 0;
    pointsForOneUp = 0;

    curX = centerX;
    curY = windowHeight - shipHeight;

    // Setup Sprites;
    spritesOnScreen = 0;
    currentSprite = 1;
    spritesDestroyed = 0;

}

function intro() {
    // =========================================================================
    //  KEY TOPIC:
    //  Classes
    //  "Sound" is a SmallBasic class that provides some basic tools to play
    //  music and/or sounds.  In programming languages, classes are collections
    //  of properties and functions that are in some way related.  The Sound
    //  class for instance has functions to play, pause and stop music files
    //  such as mp3 files.  It also has functions to play chimes, click sounds
    //  and musical notes.
    //  To use a function provided by a class you use what is called the dot notation.
    //  That is done by typing the name of the class (Sound in this case), then followed
    //  by a period.  In SmallBasic (and most modern programming language editors) once
    //  you type the period you will be presented with a drop-down list of available
    //  functions and properties inside of that class to choose from.
    // =========================================================================

    bgCtx.canvas.style.backgroundImage = "url('" + imagePath + "background.jpg')";
    sSound = new Audio( audioPath + "introduction.mp3" );
    sSound.loop = true;
    sSound.play();

    // var SoundEf = new Audio( audioPath + "fireball.mp3" );
    // sSound.loop = true;
    // SoundEf.play();
    // sleep( 150 );

    // SoundEf.currentTime = 0;
    // SoundEf.play();

    // =========================================================================
    //  KEY TOPIC:
    //  Functions
    //  Functions are very similar to function routines in that they group a section of
    //  instructions to execute whenever the program encounters the function's name.  The
    //  difference between a function and a Function is that Functions can accept arguments.
    //  Arguments allow the function to receive information from the program that calls
    //  the function, which can be used to alter the behaviour of the function.  Using
    //  the Sound.Play() function for example.  This function accepts a file path argument
    //  which tells it what file to play.  Unfortunately, in SmallBasic (at least the
    //  current version at the time of this writing) you cannot create your own Functions,
    //  only function routines.  In this program, I use variables to store information that
    //  alter the function routines behaviour, so before a function is executed I set the value that
    //  changes the behaviour.  This works well enough in this program, but can (and does)
    //  create conflicts when a variable gets overridden before the function executes.


    // bgCanvas.drawImage( bgImage, 1, 1 );

    // =========================================================================
    //  KEY TOPIC:
    //  Properties
    //  Properties store information about the class it belongs to.  For instance, the
    //  GraphicsWindow class has FontName and FontSize properties which change the
    //  way text is drawn on the screen.
    // =========================================================================*

    // =========================================================================
    //  KEY TOPIC:
    //  Loops
    //  Loops are powerful tools, and can really reduce the amount of code you have to
    //  manually write (among other benefits).  In SmallBasic there are two types of
    //  loops: For Loop and While Loop.
    //  For loops will loop a set number of times and While loops will continually loop
    //  until a certain condition is met.
    //  This particular loop is a For type loop and is going to loop 14 times, and
    //  execute the code inside of the "For" and "}" lines each time. The goal of
    //  this loop is trivial, we are transitioning the text color of the high scores
    //  from red to white by slowly changing the color value on each iteration of the
    //  loop.  This loop is a reverse loop in that it will start at 15 and count backwards
    //  by 1 to 1.  Each time the loop completes an iteration, the "i" variable will be
    //  reduced by 1 until it reaches the "to" value, which in this case is 1
    var i = 15;
    var link = document.createElement( 'link' );
    link.rel = 'stylesheet';
    link.type = 'text/css';
    link.href = '/fonts/stylesheet.css';
    document.getElementsByTagName( 'head' )[ 0 ].appendChild( link );
    setInterval( function() {
        i = i === 0 ? 30 : --i;
        // for( var i = 1; i <= 15; i++ ) {
        // GraphicsWindow.clearRect( 0, 0, windowWidth, windowHeight );
        // Animate intro color from white to red - hex conversion technique borrowed from Rushworks "Gorillas"

        // This technique will grab a single character from the hexaDecimal variable set earlier starting from the
        // end of the value and working its way to the beginning on each iteration.  This will build the hex color
        // value which will start at white "#FFF", and ease its way to red "#FF0"
        // temp = Text.Append( Text.GetSubText( hexaDecimal, i, 1 ), "0" )
        // temp2 = Text.Append( "#FF", temp )
        // temp2 = Text.Append( temp2, temp )
        // Now that we have the color, we'll set the BrushColor to use when drawing the text;
        // var r = Math.random() * 255,
        //     g = Math.random() * 255,
        //     b = Math.random() * 255;

        // Now draw the text to the screen.  I// m using a little math to center the text in the screen
        // This is a typical scenario that a little bit of simple math will help with.  To explain, look at the
        // first argument passed to the DrawText function.  This argument is the X position or the horizontal
        // position in which to start drawing.  The variable windowWidth holds the value of the actual window
        // width.  If we divide that by 2 we get exactly half the window width.  However, that is where DrawText
        // will start drawing, so the text won't be truely centered.  That is why we reduce that value by 210, which
        // is the actual pixel width of the text to be drawn.  Now we have our exact left edge, we do somethinge very
        // similar to determine the Y or vertical coordinate.  With these to plot points we now have our top left corner
        // where our text will start from.
        var image = new Image;
        image.src = link.href;
        image.onerror = function() {
            GraphicsWindow.font = '2em "virgo_01regular"';
            GraphicsWindow.textBaseline = 'top';
            // GraphicsWindow.fillStyle = 'rgb(' + r + ',' + g + ',' + b + ')';
            GraphicsWindow.fillStyle = '#FF' + hexaDecimal.split( '' )[ i ];
            GraphicsWindow.fillText( "SPACE WARS", 70, 30 );
        };
        // GraphicsWindow.fillText( "TEST", 70, 30 );
        // console.log( GraphicsWindow.fillStyle );
        // sleep( 50 );


        // }
        // Loops are very fast, so if we just did a loop changing the color you// d likely not see any transition, you// d
        // probably only see blinking text randomly changing from white directly to red with no transition.  This is
        // where a Delay() funciton comes in real handy.  This will tell the program to wait for 150 milliseconds before
        // continuing to the next iteration of the loop.
        // sleep( 150 )

    }, 100 );
    // GraphicsWindow.fillStyle = "#000";
    // =====================================================================*
    //    Notice that we can call function rotuines from within a function routine.  This
    //    opens a lot of possibilities
    ShowHighScores();

}

function sleep( milliseconds ) {
    var start = new Date()
        .getTime();
    for( var i = 0; i < 1e7; i++ ) {
        if( ( new Date()
            .getTime() - start ) > milliseconds ) {
            break;
        }
    }
}

function initImages() {
    //  Load various images that will be used in the game.
    // =========================================================================
    //  KEY TOPIC:
    //  Data Types
    //  This is another example of a complex data type.  These variables will
    //  store the actual image loaded from a file.  We can then use these later
    //  to change the background, or display various objects on the screen.
    // =========================================================================
    bgImage = new Image( imagePath + "background.jpg" );
    menuBg = new Image( imagePath + "menu-background.jpg" );
    gameOverBg = new Image( imagePath + "gameover.jpg" );
    warpbg = new Image( imagePath + "warp.jpg" );
    fireBallImage = new Image( imagePath + "fireball.png" );
    fireBallSmallImage = new Image( imagePath + "fireball-small.png" );
    blueFireBallImage = new Image( imagePath + "blue-fireball.png" );
    blueFireBallSmallImage = new Image( imagePath + "blue-fireball-small.png" );

}

//  Preload all sounds in game by loading then immediately stopping them.
//  Makes it quick to play later since retained in memory.
function initSounds() {
    // By playing then immediately stopping the music files we are
    // loading them into memory
    // Sound.src = audioPath + "scores.mp3";
    // Sound.play();
    // Sound.src = audioPath + "score_entered.mp3";
    // Sound.play();
    // Sound.src = audioPath + "destruction.mp3";
    // Sound.play();
    // Sound.src = audioPath + "destruction.mp3";
    // Sound.Stop( audioPath + "destruction.mp3" )
    // Sound.play( audioPath + "introduction.mp3" )
    // Sound.Stop( audioPath + "introduction.mp3" )
    // Sound.play( audioPath + "battle.mp3" )
    // Sound.Stop( audioPath + "battle.mp3" )
    // Sound.play( audioPath + "small-explosion.wav" )
    // Sound.Stop( audioPath + "small-explosion.wav" )
    // Sound.play( audioPath + "warp.mp3" )
    // Sound.Stop( audioPath + "warp.mp3" )

    //  play and wait for a quiet sound to finish.  When done
    //  all sounds are loaded & ready to go
    Sound.src = audioPath + "quiet.mp3";
    Sound.play();
    console.log( 'played quite' );

}

// The "callback" argument is called with either true or false
// depending on whether the image at "url" exists or not.
function imageExists( url ) {
    var img = new Image();
    img.onload = function() {
        return img;
    };
    img.onerror = function() {
        return false;
    };
    img.src = url;

}

function initLevels() {
    // Here we will loop from 1 to the maximum levels described in maxLevels
    for( var level_count = 1; level_count <= maxLevels; level_count++ ) {
        // Grab the images for this level
        // Each level has its own folder, so we can swap out the images per level.
        // So far we've only assinged plain text or numeric values to variables.  Here, we are going
        // to assign an array to the levelObjectImages.  The File.GetFiles() function returns an array
        // of files in the specified directory
        var levelBGImage = new Image( "/levels/" + level_count + "/background/bg.jpg" );
        var levelEnemyImages = [];
        var levelObjectImages = [];
        for( var i = 1; i <= 10; i++ ) {
            var tmpImg = imageExists( "/levels/" + level_count + "/enemies/enemy" + i + ".png" );
            if( tmpImg === false ) {

            } else {
                levelEnemyImages.push( tmpImg );
            }
            tmpImg = imageExists( "/levels/" + level_count + "/objects/object" + i + ".png" );
            if( tmpImg === false ) {

            } else {
                levelObjectImages.push( tmpImg );

            }
        }


        // =========================================================================
        //  KEY TOPIC:
        //  Logic Control
        //  Often we need to make decisions in our applications based on the current
        //  state of "things".  For instance, based on what the current value of
        //  a variable is set to, or the number of items in an array (see below
        //  about arrays)
        //  "If" statements are used to make decisions.  The format is:
        //  If (expression === true ){
        //      do something
        //  }
        //  The expression === true can be anything that can result in a true/false answer.
        //  This logic block is checking to see if the variable levelObjectImages is
        //  of data type "Array "OR if levelObjectImages has zero items. If not, then
        //  it will execute the code between "{" and "}", if so, then it will skip
        //  it.
        // if( !Array.isArray( levelObjectImages ) || levelObjectImages.length >= 0 ) {
        //     levelObjectImages = File.GetFiles( "/images/objects/" )
        // }

        levelBGMusic = BGM.src = "/levels/" + level_count + "/bgm/bgm.mp3";
        // =========================================================================
        //  KEY TOPIC:
        //  Data Types - Arrays
        //  Here's were things get interesting with arrays.
        //  The levels array is what is called a two dimensional array.  This simply
        //  means it is an array that contains a list of arrays inside of it.  The
        //  array inside the array is typically closely related to the parent array.
        //  Consider the game's levels. Say there are 10 levels, and on each level
        //  you want to change how many points you get for hitting an enemy target.
        //  The fastest way in SmallBasic to do that is to create a two dimensional
        //  array. The first dimension of the array is a sequential number from 1,
        //  to the number of levels. The second dimension of the array contains the
        //  values of various aspects of that level.
        //  See the following example:
        //  levels[1][_pointWorth] = 100
        //  levels[1][_maxSprites] = 5
        //  levels[2][_pointWort] = 200
        //  levels[2][_maxSprites] = 10
        //  This would mean that on level 1, the point for hitting a target would
        //  be 100 and ther will be no more than 5 enemies on the screen at a time,
        //  level 2 would give 200 points per hit and show up to 10 enemies on the
        //  screen at a time.
        //
        //  Notice the use of variables in the [], the level_count variable is the
        //  iteration count of the loop, so will be 1 to the number of levels.  The
        //  second dimension uses the constants we setup earlier.
        //
        //  Two dimensional arrays not only give us a convenient way to store related
        //  data, but it also allows us to retrieve the data dynamically based on the
        //  state of the application at any given point.  For instance, when the user
        //  reaches the next level, the global variable " level " is incremented by 1
        //  (i.e. from level 1 to level 2).  Now to reference level specific
        //  information we just pass that in as the first dimension of the levels[]
        //  array and we get back level 2 data. The alternative would be to have a
        //  variable for each aspect of each level (130 just in this function routine if
        //  there are 10 levels) and a whole bunch of if statements to determine
        //  which variable to use
        // =========================================================================
        levels[ level_count ] = {};
        levels[ level_count ].maxSprites = 3 + Math.ceil( ( level_count / 2 ) ) * 1.5 //  number of sprites at a time
        levels[ level_count ].spritesToLevelUp = 5 + Math.round( 2 * level_count ) //  number of enemy sprites (not asteroids) needed to beat level
        levels[ level_count ].maxSpriteSpeed = level_count * .75 //  max speed of sprites
        levels[ level_count ].minSpriteSpeed = levels[ level_count ].maxSpriteSpeed / 2 //  min speed of sprites
        levels[ level_count ].pointWorth = level_count * 55 //  point value for sprite
        levels[ level_count ].completePoints = level_count * 1000 // bonus points for completing a level
        levels[ level_count ].shotInterval = ( maxLevels - ( level_count + 2 ) ) * 7 //   interval of enemy shots
        levels[ level_count ].enemyImages = levelEnemyImages
        levels[ level_count ].objectImages = levelObjectImages
        levels[ level_count ].backgroundImage = levelBGImage
        levels[ level_count ].EnemyRatio = .01 * level_count
        levels[ level_count ].maxHits = Math.round( level_count / 2 )
        levels[ level_count ].hasBoss = level_count % 5;
        levels[ level_count ].BGMusic = levelBGMusic[ 1 ]
    }

}

function initSprites() {
    // ====================================================================================
    //    This function initializes all the sprites that will appear in the game.  In game programming
    //    and movie/animation programming sprites are any visible object that has behavior
    //    in this game, sprites are things like asteroids and space ships.  They have properties
    //    such as they can move, space ships can fire bullets, they can take various hits before
    //    being destroyed, asteroids change direction and get smaller when you shoot them,
    //    ships bounce of the edges of the screen, etc...

    // setup sprites
    // Recall how we setup the levels array in the initLevels sub?  This is one of the uses for it
    // We are now seting up how many asteroids will appear on the screen, and what images
    // we use for them.  Each level can have its own asteroid image, it doesn't even have to be
    // an asteroid, it could be a image of a hairless chiuaua if you so desired.
    for( var i = 1; i <= levels[ level ].objectImages.length; i++ ) {
        spriteImage[ i ] = levels[ level ].objectImages[ i ]
    }

    // spriteImage[1] = imagePath + "sprite1.gif "
    for( var i = 1; i <= levels[ level ].enemyImages.length; i++ ) {
        enemyImage[ i ] = levels[ level ].enemyImages[ i ]
    }

}



function initStars() {

    // Setup stars.  Thes are random sized/colored dots that we draw randomly on the screen
    // during warp to give the impression of a star field.
    starCount = 300
    starColors[ 1 ] = "white";
    starColors[ 2 ] = "red";
    starColors[ 3 ] = "LightCyan";
    stars = "";
    for( var i = 1; i <= starCount; i++ ) {
        GraphicsWindow.fillStyle = starColors[ Math.GetRandomNumber( 3 ) ]
        GraphicsWindow.BrushColor = GraphicsWindow.fillStyle
        starSize = Math.GetRandomNumber( 3 )
        starX = Math.GetRandomNumber( Desktop.Width )
        starY = Math.GetRandomNumber( windowHeight )
        // GraphicsWindow.FillEllipse(starX,starY,starSize,starSize)
        stars[ stars.length + 1 ] = Shapes.AddEllipse( starSize, starSize )
        // Shapes.Move( stars[ stars.length ], starX, starY )
    }

}

function initBackground() {
    // bgImage = new Image();
    bgImage = levels[ level ].backgroundImage;
    // , windowWidth, windowHeight
    bgCtx.drawImage( bgImage, 0, 0 );

}


function initShip() {
    // Load ship
    EastWest = "";
    NorthSouth = "";
    curShipName = "ship";
    // Here's an example of a two dimensional array without using constants.  Since
    // there were only two indexes in this array it was ok to just use the numbers, though
    // it would still be best practice to use constants for clarity.
    shipImages.push( [ new Image( imagePath + "ship.png" ), "ship" ] );
    shipImages.push( [ new Image( imagePath + "ship-north.png" ), "ship-north" ] );
    shipImages.push( [ new Image( imagePath + "ship-east.png" ), "ship-east" ] );
    shipImages.push( [ new Image( imagePath + "ship-south.png" ), "ship-south" ] );
    shipImages.push( [ new Image( imagePath + "ship-west.png " ), "ship-west" ] );
    shipImages.push( [ new Image( imagePath + "ship-north-east.png" ), "ship-north-east" ] );
    shipImages.push( [ new Image( imagePath + "ship-north-west.png" ), "ship-north-west" ] );
    shipImages.push( [ new Image( imagePath + "ship-south-east.png" ), "ship-south-east" ] );
    shipImages.push( [ new Image( imagePath + "ship-south-west.png" ), "ship-south-west" ] );

    shipWidth = shipImages[ 0 ][ 0 ].getAttribute( "width" );
    shipHeight = shipImages[ 0 ][ 0 ].getAttribute( "height" );
    ship = shipImages[ 1 ][ 1 ];
    shipLeft = curX
    shipRight = curX + shipWidth
    shipTop = curY //  - shipHeight
    shipBottom = curY + shipHeight

    // Shapes.Move( ship, shipLeft, shipTop )

}

function initWeapons() {
    possibleBulletsOnScreen = 2;
    bulletColor = "red";
    bulletSpeed = 10;
    bulletWidth = 5;
    bulletHeight = 10;
    bulletShape = "rectangle";
    bulletStrength = 1;

    enemyBulletColors[ 1 ] = "orange";
    enemyBulletColors[ 2 ] = "red";
    enemyBulletColors[ 3 ] = "purple";
    enemyBulletColors[ 4 ] = "green";

}

//  Create explosion pieces
function initExplosion() {

    explodeImage[ 1 ] = new Image( imagePath + "explode-small1.png" );
    explodeImage[ 2 ] = new Image( imagePath + "explode-small1.png" );
    explodeImage[ 3 ] = new Image( imagePath + "explode-small1.png" );
    explodeImage[ 4 ] = new Image( imagePath + "explode-small1.png" );

    explodeImage[ 5 ] = new Image( imagePath + "explode-medium1.png" );
    explodeImage[ 6 ] = new Image( imagePath + "explode-medium1.png" );
    explodeImage[ 7 ] = new Image( imagePath + "explode-medium1.png" );
    explodeImage[ 8 ] = new Image( imagePath + "explode-medium1.png" );

    explodeImage[ 9 ] = new Image( imagePath + "explode-large1.png" );
    explodeImage[ 10 ] = new Image( imagePath + "explode-large1.png" );
    explodeImage[ 11 ] = new Image( imagePath + "explode-large1.png" );
    explodeImage[ 12 ] = new Image( imagePath + "explode-large1.png" );

    // //  Create small explosion pieces that are permanently available
    // for( var explosion_i = 1; explosion_i <= explodeImage.length; explosion_i++ ) {
    //     temp = Shapes.AddImage( explodeImage[ explosion_i ] )

    //     //  Move it immediately off screen so it isn't ever seen
    //     Shapes.Move( temp, 0, -100 )

    //     //  Save in array
    //     explosion[ explosion_i ] = temp
    // }

    //  Center of explosion
    explosionX = 0
    explosionY = 0
    explosionSpread = 0
    explosionAlpha = 100
    exploding = false
    explosionSize = 0
}

function MainLoop() {
    // ====================================================================================
    //  This is what makes the game possible.  Here we are going to use what is called
    //  a While loop.  This literally means, while the condition is true, execute the enclosed
    //  code.  As soon as the condition is false, stop.
    //  The variable play is initially set to "true" which means the game loop will start immediately.
    //  Each time the "loop" runs through the code it is called an iteration.  In each iteration of
    //  the loop in this case is similar to a frame in a movie.  In each frame we need to draw all
    //  of the sprites, bullets, background, ships in the appropriate positions, just like in a movie
    //  film.  If you look at a movie film, each frame is a still photo that looks almost identical to
    //  the one before it but with a very slight change.  If you scroll through the film strip at a
    //  fast pace the still pictures will give the sense that they are moving.  Same concept with
    //  the game here.  On each iteration we see if the user has pressed a key, then we act on that
    //  key press (remember the event listener at the top of this program?).  If the left key was
    //  pressed we need to move the user's ship to the left 1 step, and so on.  If the user has pressed
    //  the fire key we need to draw a new bullet on the screen.  We also need to advance any
    //  other bullets up one step (or more based on the speed of the bullet).  We also need to detect
    //  bullet hits (if we hit a target, or a enemy hit us), and collisions (astroid or enemy ran into us)
    //  We also need to add up the total points, update the score board that shows points, level, etc...
    //  In a nutshell, every aspect of the game needs to advance one "step".
    // ====================================================================================

    // =========================================================================
    //  KEY TOPIC:
    //  Loops
    //  Here is an example of a While loop.  In this case, we will loop while
    //  the value of "play" is equal to true.  When the user spends all of the
    //  lives, the game is over and the play variable is set to false (see
    //  the gameOver() Sub.  Use these types of loops cautiously since they can
    //  cause infinite loops if play never equals false.
    // =========================================================================

    while( play === true ) {


        if( pause == false ) {
            //  With this little trick we can pause the game.  The loop still runs, but the code will not
            //  until the pause key is pressed again.

            if( alive == true && gameEnd == false ) {
                //  Only if our player is still alive and the game hasn't ended do we need to
                //  continue the game.
                doKeys(); //  This function will act on the keys pressed since the last iteration
                addSprites(); // This function will add sprites (asteroids/enemies) to the screen if we've drop below the number allowed on this level
                updateScoreBoard(); // The most important part, update the score

            } else {
                //  Player is either dead or game is over.  We'll remove all sprites from the screen.
                removeAllSprites();
            }
            Explode(); //  This detects the need to explode something, then does it.
            Move(); //   This detects the need to move, then does it.


            //  Smooth estimate of time elapsed between frames
            tNow = Clock.Millisecond;
            dT = tNow - tLast;
            tLast = tNow;

            //  Handle millisecond rollover at 1 second marks
            if( dT < 0 ) {
                dT = dT + 1000
            }

            k = 0.1 //   1 = no smoothing, values less than 1 smooths.  0.1 default
            dTLossy = dTLossy * ( 1 - k ) + dT * k

            //  Figure out how long we need to wait to achieve desired average frame rate
            waitLoops = 1000 / fpsTarget - dTLossy
            waitLoops = waitLoops * loopsPerMilliSec
            for( var i = 1; i <= waitLoops; i++ ) {
                i = i
            }

        }
    }

}


// One function to move them all, one function to bind them, one function to...
// Seriously, this function will cause every movable object on the screen to move one
// step.  This includes bullets, asteroids, hero ship and enemy ships.  We will also
// be able to detect any target hits or collisions.
function Move() {
    // move ship
    if( alive ) {
        // If our player is alive, move the ship (based on player's move)
        moveShip();
    } else {
        alive++;
    }


    // move all active bullets
    tmpBullets = bullets.length;
    for( protected_b = 0; protected_b <= tmpBullets; protected_b++ ) {
        Shapes.Move( bullets[ protected_b ], Shapes.GetLeft( bullets[ protected_b ] ), Shapes.GetTop( bullets[ protected_b ] ) - 20 )
        if( Shapes.GetTop( bullets[ protected_b ] ) < -10 ) {
            shotRemoveIndex = protected_b
            RemoveShot()
        }
        tmpBullets = bullets.length
    }


    // Move enemy Bullets
    for( protected_e = 0; protected_e <= enemyBullets.length; protected_e++ ) {
        // If array.GetItemCount(enemyBullets[temp_a]) >= 0 Then
        // For protected_e = 0 To Array.GetItemCount(enemyBullets[temp_a])
        Shapes.Move( enemyBullets[ protected_e ][ 1 ], Shapes.GetLeft( enemyBullets[ protected_e ][ 1 ] ), Shapes.GetTop( enemyBullets[ protected_e ][ 1 ] ) + 20 )
        if( Shapes.GetTop( enemyBullets[ protected_e ][ 1 ] ) > windowHeight ) {
            enemyShotRemoveIndex = protected_e
            // enemyShotRemoveSpriteIndex = temp_a
            RemoveEnemyShot()
        }
        // }
        // }
    }

    // Move all active sprites
    tmpSprites = sprites.length
    for( protected_a = 1; protected_a <= sprites.length; protected_a++ ) {}
    curSprite = protected_a

    if( sprites[ protected_a ][ _direction ] === "left" ) {
        newLeft = Shapes.GetLeft( sprites[ protected_a ][ _shape ] ) - sprites[ protected_a ][ _x ]
    } else {
        newLeft = Shapes.GetLeft( sprites[ protected_a ][ _shape ] ) + sprites[ protected_a ][ _x ]
    }
    newTop = Shapes.GetTop( sprites[ protected_a ][ _shape ] ) - sprites[ protected_a ][ _y ]

    Shapes.Move( sprites[ protected_a ][ _shape ], newLeft, newTop )
    isSpriteVisible()
    if( sprites[ curSprite ][ _isVisible ] == 0 ) {
        if( sprites[ curSprite ][ _hasWeapons ] == true ) {
            // If this sprite is an enemy, bounce him off the wall
            if( newTop < windowHeight - sprites[ curSprite ][ _height ] ) {
                if( sprites[ curSprite ][ _direction ] === "right" ) {
                    sprites[ curSprite ][ _x ] = -sprites[ curSprite ][ _x ]
                    sprites[ curSprite ][ _direction ] = "left";
                } else {
                    sprites[ curSprite ][ _x ] = Math.Abs( sprites[ curSprite ][ _x ] )
                    sprites[ curSprite ][ _direction ] = "right";
                }
            } else {
                spriteRemoveIndex = curSprite
                removeSprite()
            }
        } else {
            spriteRemoveIndex = curSprite
            removeSprite()
        }
    } else {
        if( sprites[ protected_a ][ _hasWeapons ] == 1 && shapes.GetTop( sprites[ protected_a ][ _shape ] ) < curY && Shapes.GetLeft( sprites[ protected_a ][ _shape ] ) > curX - 100 && Shapes.GetLeft( sprites[ protected_a ][ _shape ] ) + sprites[ protected_a ][ _width ] < curX + shipWidth + 100 ) {

            if( sprites[ curSprite ][ _shots ] <= 10 && sprites[ curSprite ][ _shotTicker ] >= levels[ level ].shotInterval ) {
                sprites[ curSprite ][ _shotTicker ] = 0
                enemyShoot()
            }
            sprites[ curSprite ][ _shotTicker ] = sprites[ curSprite ][ _shotTicker ] + 1
        }
    }

    anyHits()

}

function moveShip() {
    shipLeft = curX
    shipRight = curX + shipWidth
    shipName = "ship";
    if( !NorthSouth === "" ) {

        shipName = shipName + " - " + NorthSouth
    }
    if( !EastWest === "" ) {

        shipName = shipName + " - " + EastWest
    }

    if( !curShipName === shipName ) {
        for( var s = 1; s <= shipImages.length; s++ ) {
            if( shipImages[ s ][ 2 ] === shipName ) {
                Shapes.Remove( ship )
                ship = Shapes.AddImage( shipImages[ s ][ 1 ] )
                s = 10000
            }
        }

    }
    curShipName = shipName
    Shapes.Move( ship, curX, curY )
}

function anyHits() {
    //  "a" will be the index of the enemy sprite and "b" will be the index of the bullet
    for( var a = 1; a <= sprites.length; a++ ) {
        spriteLeft = Shapes.GetLeft( sprites[ a ][ _shape ] )
        spriteTop = Shapes.GetTop( sprites[ a ][ _shape ] )
        spriteSize = sprites[ a ][ _width ]
        spriteBottom = spriteTop + spriteSize
        for( var b = 1; b <= bullets.length; b++ ) {
            bulletLeft = Shapes.GetLeft( bullets[ b ] )
            bulletRight = bulletLeft + bulletWidth
            bulletTop = Shapes.GetTop( bullets[ b ] )
            bulletBottom = bulletTop + bulletHeight

            //  Did we shoot the sprite
            if( bulletTop > 0 ) {
                // The top of the bullet (the player's bullet) is greater than zero, which means it is on the screen
                if( ( ( bulletLeft >= spriteLeft ) && ( bulletLeft <= spriteLeft + spriteSize ) ) && ( bulletTop < spriteBottom && bulletTop > spriteTop ) ) {
                    // The bullet's coordinates matches those of a enemy sprite, we hit it!
                    curSprite = a
                    shotRemoveIndex = b
                    RemoveShot()
                    tmpHits = sprites[ a ][ _hits ]
                    sprites[ a ][ _hits ] = sprites[ a ][ _hits ] - bulletStrength

                    if( sprites[ a ][ _hits ] <= 0 ) {
                        // Sprites each require a certain pre-determined number of hits before being destroyed.
                        // If we've reached that number, we will explode the enemy sprite and remove it from the screen.
                        explosionX = Shapes.GetLeft( sprites[ a ][ _shape ] )
                        explosionY = Shapes.GetTop( sprites[ a ][ _shape ] )
                        explosionSpread = sprites[ a ][ _width ] / 2
                        exploding = true
                        curPoints = sprites[ a ][ _maxSpritePoints ] * tmpHits
                        if( sprites[ a ][ _hasWeapons ] ) {
                            // If it had a weapon, that means it was an enemy and not just an asteroid.  This will
                            // count toward the player's destroy count, which determines level ups.
                            spritesDestroyed = spritesDestroyed + 1
                        }
                        // =========================================================================
                        //  KEY TOPIC:
                        //  function routines differ from Functions
                        //
                        //  Remember back when we talked about the difference between a Function
                        //  and a Sub?  Hint, you can't pass arguments to a Sub.  Well this is how I
                        //  get around that limitation.  In this case I have a variable spriteRemoveIndex
                        //  that will store the index position of the sprite we wish to remove.  This variable
                        //    is then used in the removeSprite() function to remove the specified sprite.
                        // =========================================================================
                        spriteRemoveIndex = a
                        removeSprite()

                    } else {
                        // Sprite was hit but not destroyed
                        if( sprites[ a ][ _hasWeapons ] === 0 ) {
                            // Non enemy sprites (asteroids) will shrink with each hit.
                            sprites[ a ][ _width ] = sprites[ a ][ _width ] * 0.75
                            sprites[ a ][ _height ] = sprites[ a ][ _height ] * 0.75
                            scale = sprites[ a ][ _width ] * .01
                            Shapes.Zoom( sprites[ a ][ _shape ], scale, scale )
                        }
                        curPoints = sprites[ a ][ _maxSpritePoints ] / sprites[ a ][ _totalHits ]
                        spriteLeft = Shapes.GetLeft( sprites[ a ][ _shape ] )
                        spriteTop = Shapes.GetTop( sprites[ a ][ _shape ] )
                        spriteRight = spriteLeft + sprites[ a ][ _width ]
                        spriteSize = sprites[ a ][ _width ]
                        spriteBottom = spriteTop + spriteSize
                        // change direction of the sprite's flight path.  This makes it a little more realistic.
                        if( sprites[ a ][ _direction ] = "left" ) {

                            sprites[ a ][ _direction ] = "right";
                        } else {
                            sprites[ a ][ _direction ] = "left";
                        }
                    }

                    updateScore()
                    a = sprites.length + 100;

                }
            }

        }
        // Did our ship collide with an sprite or enemy?
        if( alive ) {
            spriteLeft = Shapes.GetLeft( sprites[ a ][ _shape ] )
            spriteTop = Shapes.GetTop( sprites[ a ][ _shape ] )
            spriteRight = spriteLeft + sprites[ a ][ _width ]
            spriteBottom = spriteTop + sprites[ a ][ _height ]
            if( spriteBottom >= curY && spriteTop <= shipBottom ) {
                if( spriteLeft >= shipLeft && spriteLeft <= shipRight ) {
                    // we got hit
                    removeLife()
                    spriteRemoveIndex = a
                    removeSprite()
                    // force exiting out of the loops
                    a = 100000
                    b = 100000
                }
            }
        }
    }
    // Did we get shot?
    for( var e = 1; e <= enemyBullets.length; e++ ) {

        if( shapes.GetTop( enemyBullets[ e ][ 1 ] ) + 9 >= curY && Shapes.GetTop( enemyBullets[ e ][ 1 ] ) <= shipBottom ) {
            if( shipLeft <= Shapes.GetLeft( enemyBullets[ e ][ 1 ] ) && shipRight >= Shapes.GetLeft( enemyBullets[ e ][ 1 ] ) ) {}

            // we got hit
            removeLife()
            enemyShotRemoveIndex = e
            RemoveEnemyShot()
            // force exiting out of the loop
            e = 100000
        }
    }
}



function addSprites() {
    // This function is in charge of adding sprites to the screen.  This happens when the game starts,
    // as well as when sprites are either destroyed or fly off the screen.  We always try to keep
    // a set amount (depending on the level) of sprites on the screen to keep it challenging for
    // our player.
    curLevelMaxSprites = levels[ level ].maxSprites
    // =========================================================================
    //  KEY TOPIC:
    //  Debugging
    //
    //   Debugging is something that every progammer needs to be able to do.
    //   When a program doesn't quite act the way you expect, or an error is raised
    //   you need to be able to look behind the scenes to see what is going wrong. In
    //   most modern languages you can actually pause the execution of the program
    //   and see what values are in each variable, and where the current line of
    //   execution is.  Unfortunately SmallBasic doesn't yet have that (though they
    //   are planning to add it).  So for the meantime, when you need to peek under
    //   the hood while a program is running you need to somehow write it to the
    //   screen.  The below commented out code, if uncommented would open a
    //   text window (like a DOS window) and write the values of the spritesOnScreen
    //   and curLevelMaxSprites variables each time the addSprites function is called.
    //   I had actually used this to see why I wasn't seeing the correct number of
    //   sprites on the screen, which I fixed but left the debugging example here.
    // =========================================================================
    // TextWindow.WriteLine("sprites on screen: " + spritesOnScreen + "max sprites: " + curLevelMaxSprites)
    // =========================================================================

    check_count = 0
    while( spritesOnScreen < curLevelMaxSprites ) {
        check_count = check_count + 1
        if( check_count > curLevelMaxSprites ) {
            spriteOnScreen = curLevelMaxSprites
        }

        // add as many sprites as neccessary to fulfill the maxSprites for this level
        for( var addingSpriteIndex = curLevelMaxSprites - spritesOnScreen; addingSpriteIndex <= curLevelMaxSprites; addingSpriteIndex++ ) {

            protected_sprite = sprites.length + 1
            sprites[ protected_sprite ][ _size ] = Math.GetRandomNumber( 20 ) //  size
            if( sprites[ protected_sprite ][ _size ] < 5 ) {
                sprites[ protected_sprite ][ _size ] = 5 //  size
            }
            sprites[ protected_sprite ][ _size ] = sprites[ protected_sprite ][ _size ] / 10

            sprites[ protected_sprite ][ _startpos ] = Math.GetRandomNumber( windowWidth + 100 ) // X
            speedX = Math.GetRandomNumber( levels[ level ].maxSpriteSpeed )
            speedY = Math.GetRandomNumber( levels[ level ].maxSpriteSpeed )

            // Quick random logic to determine if the sprite is an object or a enemy (enemy has weapons, objects don't)
            sprites[ protected_sprite ][ _hasWeapons ] = Math.Remainder( Math.GetRandomNumber( 2 ), 2 )
            if( sprites[ protected_sprite ][ _hasWeapons ] = 0 ) {
                tmpSpriteImage = new Image( spriteImage[ Math.GetRandomNumber( spriteImage.length ) ] ) // Image
            } else {
                tmpSpriteImage = new Image( enemyImage[ Math.GetRandomNumber( enemyImage.length ) ] ) // Image
                speedX = speedX * 1.5
                speedY = speedY * 1.5
            }

            if( speedX < levels[ level ].minSpriteSpeed ) {
                speedX = levels[ level ].minSpriteSpeed
            }

            if( speedY < levels[ level ].minSpriteSpeed ) {
                speedY = levels[ level ].minSpriteSpeed
            }

            if( speedX === 0 ) {
                speedX = levels[ level ].maxSpriteSpeed * .5
            }

            if( speedY === 0 ) {
                speedY = levels[ level ].maxSpriteSpeed * .5
            }
            // Setup the direction and speed for this Sprite
            if( sprites[ protected_sprite ][ _startpos ] > centerX ) {
                // came from the right, move toward the left
                sprites[ protected_sprite ][ _x ] = speedX;
                sprites[ protected_sprite ][ _direction ] = "left";
            } else {
                // came from the left, move toward the right
                sprites[ protected_sprite ][ _x ] = speedX;
                sprites[ protected_sprite ][ _direction ] = "right";
            }
            sprites[ protected_sprite ][ _y ] = -speedY;

            // Add the sprite image to the sprites array
            sprites[ protected_sprite ][ _shape ] = Shapes.AddImage( tmpSpriteImage )
            // Grab the exact width and height of the sprite
            sprites[ protected_sprite ][ _width ] = ImageList.GetWidthOfImage( tmpSpriteImage )
            sprites[ protected_sprite ][ _height ] = ImageList.GetHeightOfImage( tmpSpriteImage )

            if( sprites[ protected_sprite ][ _hasWeapons ] == false ) {
                Shapes.Zoom( sprites[ protected_sprite ][ _shape ], sprites[ protected_sprite ][ _size ], sprites[ protected_sprite ][ _size ] )
                // Grab the exact width and height of the sprite
                sprites[ protected_sprite ][ _width ] = sprites[ protected_sprite ][ _size ] * sprites[ protected_sprite ][ _width ]
                sprites[ protected_sprite ][ _height ] = sprites[ protected_sprite ][ _size ] * sprites[ protected_sprite ][ _height ]
            }

            sprites[ protected_sprite ][ _speed ] = speedX
            sprites[ protected_sprite ][ _isVisible ] = 1
            sprites[ protected_sprite ][ _shots ] = 0 //  Keeps running total of shots fired by this enemy
            sprites[ protected_sprite ][ _shotTicker ] = 1
            // Enemy sprites hits depends on level
            if( sprites[ protected_sprite ][ _hasWeapons ] == true ) {
                sprites[ protected_sprite ][ _hits ] = Math.GetRandomNumber( levels[ level ].maxHits ) // This will decrease each time it is hit, once zero the sprite will explode
                sprites[ protected_sprite ][ _bulletColor ] = enemyBulletColors[ Math.GetRandomNumber( enemyBulletColors.length ) ] //  Each sprite can have its own bullet color
                // Asteroid sprites have different hits based on zoom size
            } else {
                sprites[ protected_sprite ][ _hits ] = Math.Ceiling( sprites[ protected_sprite ][ _size ] * 1.5 ) // This will decrease each time it is hit, once zero the asteroid will explode
            }

            sprites[ protected_sprite ][ _totalHits ] = sprites[ protected_sprite ][ _hits ] // This will remember how many hits it took for score calculations
            sprites[ protected_sprite ][ _maxSpritePoints ] = Math.GetRandomNumber( levels[ level ].pointWorth )
            // Move the sprite to it's initial position
            Shapes.Move( sprites[ protected_sprite ][ _shape ], sprites[ protected_sprite ][ _startpos ], -200 )
            // Update the count of Sprites on the screen
            spritesOnScreen = sprites.length
            curSprite = protected_sprite


        }


    }


}

function isSpriteVisible() {
    // This determines if the sprite is still visible.
    if( sprites[ curSprite ][ _direction ] === "left" && ( Shapes.GetLeft( sprites[ curSprite ][ _shape ] ) <= -sprites[ curSprite ][ _width ] ) ) {
        sprites[ curSprite ][ _isVisible ] = false;
    } else if( sprites[ curSprite ][ _direction ] = "right" && ( Shapes.GetLeft( sprites[ curSprite ][ _shape ] ) > windowWidth + sprites[ curSprite ][ _width ] ) ) {
        sprites[ curSprite ][ _isVisible ] = true;
    }

    if( Shapes.GetTop( sprites[ curSprite ][ _shape ] ) > windowHeight ) {
        sprites[ curSprite ][ _isVisible ] = false

    }
    // =========================================================================
    //  KEY TOPIC:
    //  Debugging
    //   Another debugging example.  In this case, I was trying to find out when the
    //   sprites were being removed from the screen.
    //
    // if( sprites[curSprite][_isVisible] = false Then){
    //   GraphicsWindow.ShowMessage("sprite " + curSprite + "moving: " + sprites[curSprite][_direction] +"is not visible.X: " + Shapes.GetLeft(sprites[curSprite][_shape]) + "Y: " + Shapes.GetTop(sprites[curSprite][_shape]) + "VS window width: " + windowWidth + "height: " + windowHeight , "test ""
    // }
    // =========================================================================

}


function removeAllSprites() {
    // Convenience function to remove all active sprites
    for( var spriteRemoveIndex = 1; spriteRemoveIndex <= sprites.length; spriteRemoveIndex++ ) {
        removeSprite()
        spritesOnScreen = 0
    }
}

function removeSprite() {
    // Removes a single sprite from the screen

    //  Remove graphic
    Shapes.Remove( sprites[ spriteRemoveIndex ][ _shape ] )

    //  Pack down the arrays to have a continuous index (don't leave holes)
    for( var remove_i = spriteRemoveIndex; remove_i <= ( sprites.length - 1 ); remove_i++ ) {
        sprites[ remove_i ] = sprites[ remove_i + 1 ]
    }

    //  Remove item at end of list, it's either the one requested or a duplicate from packing above
    sprites[ sprites.length ] = ""

    spritesOnScreen = sprites.length // spritesOnScreen - 1


}

function updateScore() {
    // Update the score and refresh the score board

    score = Math.Floor( score + curPoints )
    if( spritesDestroyed >= levels[ level ].spritesToLevelUp ) {
        levelUp()
        // GraphicsWindow.BackgroundColor = "black"
    }
    // Add a new life everytime the player earns 10000 points
    pointsForOneUp = pointsForOneUp + curPoints
    if( pointsForOneUp >= 10000 ) {
        oneUp();
        pointsForOneUp = 0;
    }
    updateScoreBoard()
}

function oneUp() {
    // Give player an extra life
    lives = lives + 1;
    Sound.Stop( audioPath + "oneup.wav" );
    Sound.Play( audioPath + "oneup.wav " );
    // GraphicsWindow.ShowMessage("One Up!!!","One up!")

}

function drawPanel() {
    // Draws the panel for the score board
    //, 440, 100
    GraphicsWindow.drawImage( menuBg, 1, 1, 440, 100 );
    // GraphicsWindow.fillRect( 1, 1, 440, 100 )
}

function updateScoreBoard() {
    GraphicsWindow.fillStyle = "white";
    GraphicsWindow.font = "25pt COMIC SANS MS";
    drawPanel();

    GraphicsWindow.fillText( "Score: " + score, 10, 1 );
    GraphicsWindow.fillText( "Level: " + level, 205, 1 );
    GraphicsWindow.fillText( "Lives: " + lives, 10, 30 );
    GraphicsWindow.fillText( "Destroyed: " + spritesDestroyed, 165, 30 );
    // =========================================================================
    //  KEY TOPIC:
    //  Debugging
    //   Just another debugging example.  This one will draw the values in the score board
    //   so is quite convenient.  Try uncommenting this and watch the values in the score
    //   board.  The reason I had this here was so that I can make sure the program was
    //   only allowing the set number of bullets on the screen, and to see where the ship
    //   was to help determine the collision calculations.
    // GraphicsWindow.DrawText(5,50,"shipLeft: " + shipLeft + "shipRight: " + shipRight)
    // GraphicsWindow.DrawText(5,70,"bullets: " + bulletCount)
    // =========================================================================
}

function removeLife() {
    // Removes a life from the player.  If it was the last life, trigger the game over.
    GraphicsWindow.BackgroundColor = "DimGray"
    explosionX = curX
    explosionY = curY
    explosionSize = 4
    exploding = true
    Shapes.Move( ship, centerX, windowHeight + 100 )
    Explode()
    sleep( 1000 )
    lives = lives - 1
    alive = -40

    removeAllShots()
    removeAllEnemyShots()


    curX = centerX
    curY = windowHeight - shipHeight
    GraphicsWindow.Clear()
    initShip()
    initBackGround()
    initWeapons()
    initExplosion()
    initSprites()
    // If we// ve spent all of our lives, end the game
    if( lives < 0 ) {
        gameOver()
    }

}

function levelUp() {
    // Advance player to the next level.  If there is no next level, trigger the youWin sub.
    // First we'll change the background music (if any exist for this level)
    Sound.Stop( levels[ level ].BGMusic )
    // Then we'll clear the screen and begin the warp scene.
    GraphicsWindow.Clear()
    GraphicsWindow.KeyDown = doNothing
    // The onKeyUp function will fire when the user releases the key.
    // This is also defined later
    GraphicsWindow.KeyUp = doNothing
    removeAllEnemyShots()
    // Clear astroids off of screen
    removeAllSprites()
    // Clear all shots off the screen
    removeAllShots()

    // Reset the playing field to the next level.
    alive = true
    curX = centerX
    curY = windowHeight - shipHeight
    GraphicsWindow.Clear()
    GraphicsWindow.drawImage( warpbg, 1, 1, windowWidth, windowHeight )
    bullets = ""
    bulletCount = 0
    GraphicsWindow.FontSize = 30
    GraphicsWindow.drawImage( menuBg, centerX - 250, centerY - 100, 500, 200 )
    GraphicsWindow.fillRect( centerX - 250, centerY - 100, 500, 200 )
    GraphicsWindow.BrushColor = "white"
    GraphicsWindow.fillStyle = "white"
    GraphicsWindow.DrawText( centerX - 150, centerY - 100, "LEVEL" + level + "COMPLETE!" )
    GraphicsWindow.FontSize = 20
    GraphicsWindow.DrawText( centerX - 150, centerY - 50, "Score: " + score )
    GraphicsWindow.DrawText( centerX - 150, centerY, "Enemies Destroyed: " + spritesDestroyed )
    // Reset destroyed astroid count
    spritesDestroyed = 0
    sleep( 1000 )
    score = score + levels[ level ].completePoints
    level = level + 1

    // warp speed to next level
    warp()
    GraphicsWindow.Clear()
    initShip()
    initBackGround()
    initWeapons()
    initExplosion()
    initSprites()
    Sound.Play( levels[ level ].BGMusic )
    bulletCount = 0
    bullets = ""

    GraphicsWindow.KeyDown = onKeyDown
    // The onKeyUp function will fire when the user releases the key.
    // This is also defined later
    GraphicsWindow.KeyUp = onKeyUp

    if( level >= maxLevels ) {
        GraphicsWindow.Clear();
        GraphicsWindow.BackgroundColor = "MidnightBlue";
        youWin();
    }

}

function warp() {
    // Play cool warp sound
    Sound.Play( audioPath + "warp.mp3" )
    // Create and display our random star field
    initStars()
    for( var s = 1; s <= stars.length; s++ ) {
        Shapes.Rotate( warpbg, s * 5 )
        Shapes.Zoom( stars[ s ], 5, 5 )
        Shapes.Move( stars[ s ], centerX, centerY )
        newY = Math.GetRandomNumber( windowHeight * 2 )
        newX = Math.GetRandomNumber( windowWidth * 2 )
        GraphicsWindow.fillStyle = "white"
        Shapes.Animate( stars[ s ], newX, newY, 500 )
        Shapes.Zoom( stars[ s ], 0, 0 )
        if( s == 100 ) {
            s = stars.length + 1
        }
    }
    Sound.PlayAndWait( audioPath + "warp.mp3" );
    sleep( 300 );
    bulletCount = 0;
    bullets = "";
}

function gameOver() {
    // Display game over message and restart game.
    play = true
    pause = false
    alive = false
    gameEnd = true
    GraphicsWindow.Clear()
    GraphicsWindow.FontBold = 1
    GraphicsWindow.BrushColor = "DimGray"
    GraphicsWindow.FontSize = 120
    GraphicsWindow.drawImage( gameOverBg, 0, 0, windowWidth, windowHeight )
    GraphicsWindow.DrawText( centerX - 350, 1, "GAME OVER" )

    // Restart game
    RestartGame()

}


function youWin() {
    // Display you win scene and restart game
    removeAllSprites()
    play = true
    pause = true
    gameEnd = true
    alive = false
    GraphicsWindow.Clear()
    GraphicsWindow.FontBold = 1
    GraphicsWindow.FontSize = 120
    GraphicsWindow.BrushColor = "white"
    GraphicsWindow.DrawText( centerX - 350, 10, "YOU WIN!" )

    // Restart game
    RestartGame()

}


function doKeys() {
    // This will handle the player's key press events.
    EastWest = ""
    NorthSouth = ""
    if( rightKeyPressed == true && leftKeyPressed == true ) {
        //  Figure out which direction based on last pressed or released
        if( leftRightPriority === rightKey ) {
            curX = curX + 20
            EastWest = "east"
        } else {
            curX = curX - 20
            EastWest = "west"
        }
    } else if( rightKeyPressed === true ) {
        curX = curX + 20
        EastWest = "east"
    } else if( leftKeyPressed === true ) {
        curX = curX - 20
        EastWest = "west"
    }

    if( curX + shipWidth > windowWidth ) {
        curX = windowWidth - shipWidth
    }

    if( curX <= 0 ) {
        curX = 0 // shipWidth
    }

    if( upKeyPressed === true ) {
        curY = curY - 20;
        NorthSouth = "north"
    }

    if( downKeyPressed === true ) {
        curY = curY + 20;
        NorthSouth = "south"
    }

    if( curY > windowHeight - shipHeight ) {
        curY = windowHeight - shipHeight
    } else if( curY < 0 ) {
        curY = 0
    }
    shipTop = curY - shipHeight
    shipBottom = curY

}

function changeWeapon() {
    // Kind of a underdeveloped and hidden feature, but this will
    // change the players wepon from a tiny fireball to a huge one.
    // The huge one kills just about anything in one hit.  This would
    // be a great feature to enhance so that on certain levels new
    // weapons could be unlocked, which would have varying properties
    // such as how many bullets on the screen, hit strength, number
    // of bullets that it can fire before switching back to the default
    // weapon, etc...
    if( bulletColor === "red" ) {
        possibleBulletsOnScreen = 10
        bulletColor = "purple"
        bulletSpeed = 20
        bulletWidth = 60
        bulletHeight = 40
        bulletShape = "circle"
        bulletStrength = 5
        bulletCount = 0
    } else {
        possibleBulletsOnScreen = 2
        bulletColor = "red"
        bulletSpeed = 10
        bulletWidth = 5
        bulletHeight = 10
        bulletShape = "rectangle"
        bulletStrength = 1
    }
}

function shoot() {
    // Fire a shot
    bulletCount = bullets.length + 1

    if( bulletCount <= possibleBulletsOnScreen && alive === true && gameEnd === false ) {
        if( bulletShape === "circle" ) {

            // Sound.Stop( audioPath + "fireball.mp3" )
            Sound.src = audioPath + "fireball.mp3";
            Sound.Play();

            bullets[ bulletCount ] = Shapes.AddImage( fireBallImage )
            bulletWidth = ImageList.GetWidthOfImage( fireBallImage )
            bulletHeight = ImageList.GetheightOfImage( fireBallImage )

        } else {
            Sound.Stop( audioPath + "photon-blaster.mp3" )
            Sound.Play( audioPath + "photon-blaster.mp3" )
            if( bulletCount > possibleBulletsOnScreen ) {
                bulletCount = bullets.length
            }
            bullets[ bulletCount ] = Shapes.AddImage( blueFireBallSmallImage )
            bulletWidth = ImageList.GetWidthOfImage( blueFireBallSmallImage )
            bulletHeight = ImageList.GetheightOfImage( blueFireBallSmallImage )

        }

        // Not so pretty hack to overcome issues where the bullet "sticks" on the screen
        // this will remove any shot that has been on the screen for over 1000 milliseconds
        Timer.Interval = 1000
        Timer.Tick = RemoveShot

        // Move the bullet
        Shapes.Move( bullets[ bulletCount ], curX, curY - ( shipHeight + ( bulletHeight / 2 ) ) )
    }
}

function enemyShoot() {
    // Each enemy ship has it's own random bullet color
    GraphicsWindow.fillStyle = sprites[ curSprite ][ _bulletColor ]

    enemyBullets[ enemyBullets.length + 1 ][ 1 ] = Shapes.AddRectangle( 5, 9 )
    enemyBullets[ enemyBullets.length ][ 2 ] = curSprite //  used for tracking
    sprites[ curSprite ][ _shots ] = sprites[ curSprite ][ _shots ] + 1
    Shapes.Move( enemyBullets[ enemyBullets.length ][ 1 ], Shapes.GetLeft( sprites[ curSprite ][ _shape ] ) + ( sprites[ curSprite ][ _width ] / 2 ), Shapes.GetTop( sprites[ curSprite ][ _shape ] ) + sprites[ curSprite ][ _height ] )
}

function removeAllShots() {
    // Convenience function to remove all shots from the screen
    tmpBulletCount = bullets.length

    while( tmpBulletCount > 0 ) {
        shotRemoveIndex = tmpBulletCount;
        RemoveShot();
        tmpBulletCount = bullets.length;
    }

    bullets = ""

}

function RemoveShot() {
    // Remove a single shot from the screen.
    //  Remove graphic shot
    Shapes.Remove( bullets[ shotRemoveIndex ] )

    //  Pack down the arrays to have a continuous index (don't leave holes)
    for( var i = shotRemoveIndex; i <= ( bullets.length - 1 ); i++ ) {
        bullets[ i ] = bullets[ i + 1 ]
    }

    //  Remove item at end of list, it's either the one requested or a duplicate from packing above
    bullets[ bullets.length ] = ""

}


function removeAllEnemyShots() {
    // Convenience function to remove all enemy shots from the screen.
    tmpBulletCount = enemyBullets.length
    for( var enemyShotRemoveIndex = 1; enemyShotRemoveIndex <= tmpBulletCount; enemyShotRemoveIndex++ ) {

        RemoveEnemyShot()

    }

    enemyBullets = ""

}

function RemoveEnemyShot() {
    //  Remove enemy shot
    Shapes.Remove( enemyBullets[ enemyShotRemoveIndex ][ 1 ] );
    sprites[ enemyBullets[ enemyShotRemoveIndex ][ 2 ] ][ _shots ] = sprites[ enemyBullets[ enemyShotRemoveIndex ][ 2 ] ][ _shots ] - 1;
    //  Pack down the arrays to have a continuous index (don't leave holes)
    for( var i = enemyShotRemoveIndex; i <= ( enemyBullets.length - 1 ); i++ ) {
        enemyBullets[ i ] = enemyBullets[ i + 1 ]
    }

    //  Remove item at end of list, it's either the one requested or a duplicate from packing above
    enemyBullets[ enemyBullets.length ] = ""

}

function CalibrateDelay() {
    //  Figure out dummy wait loops per millisecond
    //  Used instead of sleep()'s coarse resolution of 16 ms
    // tLast = Clock.Millisecond
    // for( var ci = 1; ci <= 20000; ci++ ) {
    //     ci = ci
    // }
    // tNow = Clock.Millisecond
    // dT = tNow - tLast
    // if( dT < 0 ) {
    //     dT = dT + 1000
    // }
    // loopsPerMilliSec = 20000 / dT
}

//  Read key event
//  Note that key priority is remembered in case both up/down pressed
//  we will do what the last key press indicates.
//  Also note that this is an event handler, so key presses can
//  interrupt code running }else{where at any time, must be careful not to
//  change variables etc that could affect code undesireably.
function onKeyDown() {

    if( GraphicsWindow.LastKey === rightKey ) {
        rightKeyPressed = true

        //  if both left & right pressed, this has higher priority since pressed last
        leftRightPriority = rightKey
    }

    if( GraphicsWindow.LastKey === leftKey ) {
        leftKeyPressed = true
        leftRightPriority = leftKey
    }

    if( GraphicsWindow.LastKey === upKey ) {
        upKeyPressed = true
        upDownPriority = upKey
    }

    if( GraphicsWindow.LastKey === downKey ) {
        downKeyPressed = true
        upDownPriority = downKey
    }

    if( GraphicsWindow.LastKey = fireKey ) {
        fireKeyPressed = true
    }

    if( GraphicsWindow.LastKey === pauseKey ) {
        if( pause = true ) {
            pause = false
        } else {
            pause = true
        }
    } else if( GraphicsWindow.LastKey === quitKey ) {
        play = false
    }

    if( GraphicsWindow.LastKey === hyperspaceKey ) {
        hyperspaceKeyPressed = true
    }

    if( GraphicsWindow.LastKey === changeWeaponKey ) {
        changeWeaponKeyPressed = true
    }

    //  Save letters for high score input
    highScoreLetter = GraphicsWindow.LastKey

}

//  Run on key release, see note above
function onKeyUp() {

    if( GraphicsWindow.LastKey === rightKey ) {
        rightKeyPressed = false
    }

    if( GraphicsWindow.LastKey === leftKey ) {
        leftKeyPressed = false
    }

    if( GraphicsWindow.LastKey === upKey ) {
        upKeyPressed = false
    }

    if( GraphicsWindow.LastKey === downKey ) {
        downKeyPressed = false
    }

    if( GraphicsWindow.LastKey === fireKey ) {
        //  Only allow one shot per key press
        shoot()
        fireKeyPressed = false
    }

    if( GraphicsWindow.LastKey === hyperspaceKey ) {
        hyperspaceKeyPressed = false
    }

    if( GraphicsWindow.LastKey === changeWeaponKey ) {
        changeWeapon()
        changeWeaponKeyPressed = false
    }

}


function Explode() {

    //  Animate exploding stuff (only 1 thing can explode at a time)
    if( exploding === true ) {
        //  Move along with ground
        explosionX = explosionX
        explosionSpread = explosionSpread + 4
        explosionAlpha = explosionAlpha - 10
        offset = explosionSize
        if( explosionSpread > 40 ) {
            exploding = false
            explosionSpread = 0

            //  Move parts off screen
            Shapes.Move( explosion[ offset + 1 ], 0, -50 )
            Shapes.Move( explosion[ offset + 2 ], 0, -50 )
            Shapes.Move( explosion[ offset + 3 ], 0, -50 )
            Shapes.Move( explosion[ offset + 4 ], 0, -50 )
            explosionAlpha = 110
        } else {

            //  Move all pieces of explosion in four directions
            Shapes.Move( explosion[ offset + 1 ], explosionX + explosionSpread, explosionY + explosionSpread )
            Shapes.Move( explosion[ offset + 2 ], explosionX + explosionSpread, explosionY - explosionSpread )
            Shapes.Move( explosion[ offset + 3 ], explosionX - explosionSpread, explosionY + explosionSpread )
            Shapes.Move( explosion[ offset + 4 ], explosionX - explosionSpread, explosionY - explosionSpread )

        }
        // fade explosion
        for( var i = 1; i <= 4; i++ ) {
            Shapes.SetOpacity( explosion[ offset + i ], explosionAlpha )
        }
    }

}

//  Pull in scores from file
function GetHighScores() {
    var highScores = [];
    var rawFile = new XMLHttpRequest();
    rawFile.open( "GET", "/scores.txt", false );
    rawFile.onreadystatechange = function() {
        if( rawFile.readyState === 4 ) {
            if( rawFile.status === 200 || rawFile.status == 0 ) {
                var allText = rawFile.responseText;
                // alert( allText );
                //  Read in 5 scores, name then below it is score
                // console.log( allText );
                for( var z = 1; z <= 5; z++ ) {
                    highScores.push( allText.split( '\n' )[ z ] );
                    // highScoreValues[ z ] = readTextFile( "/scores.txt", z * 2 )
                }
                // console.log( highScores );
            }
        }
    }
    rawFile.send( null );


}

//  Get players score if higher than scoreboard, show scoreboard.
//  Show high scores with nice graphic effect - it's their only reward
function ShowHighScores() {

    //  Look through all scores and see if player beat one, starting with highest score
    for( var i = 1; i <= highScoreNames.length; i++ ) {
        if( score > highScoreValue[ i ] ) {
            //  We beat a score, play tune
            // Sound.Stop( audioPath + "scores.mp3" )
            Sound.src = audioPath + "scores.mp3";
            Sound.Play();

            //  Shift all scores down 1 slot
            for( var j = highScoreNames.length - 1; j <= i; j-- ) {
                highScoreNames[ j + 1 ] = highScoreNames[ j ]
                highScoreValue[ j + 1 ] = highScoreValue[ j ]
            }

            //  Get players name
            GraphicsWindow.fontStyle = "DimGray"
            GraphicsWindow.font = "40pt courier";
            GraphicsWindow.drawText( "YOU MADE THE TOP 5!", centerX - 150, 140 );
            GraphicsWindow.font = "30pt courier";
            GraphicsWindow.drawText( "ENTER INITIALS: ", centerX - 150, 180 );

            k = 0 //  no letters entered yet
            temp2 = ""
            while( k < 3 ) {
                //  Only allow typical characters (may need tweak for other languages)
                //  Get copy of entered key in uppercase, changes in event handler
                temp = Text.ConvertToUpperCase( highScoreLetter )

                if( Text.GetLength( temp ) == 1 && Text.GetCharacterCode( temp ) >= 64 && Text.GetCharacterCode( temp ) <= 95 ) {
                    //  Show letter entered
                    GraphicsWindow.fontStyle = "DimGray";
                    GraphicsWindow.font = "30pt courier";
                    GraphicsWindow.DrawText( temp, centerX - 100 * ( 1.5 - k ), 200 );

                    //  Build name string
                    temp2 = temp2 + " " + temp;

                    k = k + 1

                    sleep( 200 );
                    highScoreLetter = "";

                }

            }

            Sound.src = audioPath + "score_entered.mp3";
            Sound.Play();

            sleep( 2000 )

            //  Save name/score to array
            highScoreNames[ i ] = temp2
            highScoreValue[ i ] = score

            //  Save score to file.  Write 5 scores, name then below it is the score
            for( var z = 1; z <= highScoreNames.length; z++ ) {
                File.WriteLine( "/scores.txt", z * 2 - 1, highScoreNames[ z ] )
                File.WriteLine( "/scores.txt", z * 2, highScoreValue[ z ] )
            }

            //  exit for
            i = 100
        }
    }

    //  Clear drawn graphics
    GraphicsWindow.fillStyle = "black";

    //  Display list of scores
    GraphicsWindow.font = "30pt courier";
    GraphicsWindow.fillText( "HIGH SCORES ", centerX - 100, centerY + 50 );

    GraphicsWindow.fontStyle = "FireBrick";

    //  If no list of high scores, probably had file error reading them in, or file I/O remarked out
    if( highScoreNames.length === 0 ) {
        GraphicsWindow.font = "10pt courier";
        GraphicsWindow.fillText( "Error Reading High Scores,Ensure // File.//  Uncommented In Source Code!", windowWidth / 2 - 10 * 25, windowHeight / 4 );
    } else {
        highScoreLetter = "";

        //  Create sinewave of color intensity to give score reflection look,
        //  and wait for player to press key to start another game
        GraphicsWindow.fillText( "PRESS ANY KEY TO START", centerX - 200, windowHeight - 50 );
        i = 6.28 //  2 * pi
        while( highScoreLetter === "" ) {
            i = i - 0.15
            if( i < 0 ) {
                i = 6.28
            }

            for( var j = 1; j <= highScoreNames.length; j++ ) {
                //  Each name in score has slightly different phase offset to give rolling reflection look
                k = Math.floor( 7.5 + 7.4 * Math.sin( Math.Remainder( i + j * 0.6, 6.28 ) ) );
                // temp = Text.Append( Text.GetSubText( hexaDecimal, k, 1 ), "0" );
                // temp2 = Text.Append( "#FF", temp );
                // temp2 = Text.Append( temp2, temp );

                GraphicsWindow.BrushColor = "#FF" + hexaDecimal.split( '' )[ i ];

                temp = highScoreNames[ j ] + "  -  ", highScoreValue[ j ];

                GraphicsWindow.fillText( temp, centerX - 100, centerY + 50 + j * 35 );
            }
            sleep( 33 )

        }
        startGame()
    }


}

function startGame() {
    // Start the game play (when user pressed any key to continue)
    level = 1
    alive = true
    gameEnd = false
    // Sound.Stop( audioPath + "introduction.mp3" )
    Sound.src = levels[ level ].BGMusic;
    Sound.Play();
}

function RestartGame() {
    //  Restart entire game
    Sound.Stop( levels[ level ].BGMusic )
    level = 1
    //  Get name if high score, show scoreboard
    ShowHighScores()
    sleep( 1000 )
    initBackground()
    initShip()
    initGame()
}

function doNothing() {
    // Used to temporarily disable keystrokes
}
