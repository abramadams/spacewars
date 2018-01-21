Module space_warsModule
    Dim version, windowHeight, windowWidth, centerX, centerY, highScoreLetter, offset, leftKey, rightKey, upKey, downKey, fireKey, pauseKey, quitKey, hyperspaceKey, changeWeaponKey, leftKeyPressed, __false, rightKeyPressed, upKeyPressed, downKeyPressed, fireKeyPressed, hyperspaceKeyPressed, changeWeaponKeyPressed, leftRightPriority, upDownPriority, hexaDecimal, imagePath, audioPath, _size, _x, _y, _shape, _isVisible, _angle, _speed, _maxSpeed, _startPos, _width, _height, _hits, _direction, _totalHits, _maxSpritePoints, _completePoints, _shots, _hasWeapons, _shotTicker, _bulletColor, _maxSprites, _spritesToLevelUp, _pointWorth, _minSpriteSpeed, _maxSpriteSpeed, _shotInterval, _backgroundImages, _objectImages, _enemyImages, _EnemyRatio, _maxHits, _hasBoss, _BGMusic, __true, play, pause, alive, gameEnd, fpsTarget, level, maxLevels, score, lives, curPoints, pointsForOneUp, curX, curY, shipHeight, spritesOnScreen, currentSprite, spritesDestroyed, i, temp, temp2, bg, menuBg, gameOverBg, warpbg, fireBallImage, fireBallSmallImage, blueFireBallImage, blueFireBallSmallImage, level_count, levelBGImages, levelEnemyImages, levelObjectImages, levelBGMusic, levels, spriteImage, enemyImage, starCount, starColors, stars, starSize, starX, starY, bgImage, EastWest, NorthSouth, curShipName, shipImages, shipWidth, ship, shipLeft, shipRight, shipTop, shipBottom, possibleBulletsOnScreen, bulletColor, bulletSpeed, bulletWidth, bulletHeight, bulletShape, bulletStrength, enemyBulletColors, explodeImage, explosion_i, explosion, explosionX, explosionY, explosionSpread, explosionAlpha, exploding, explosionSize, tNow, dT, tLast, k, dTLossy, waitLoops, loopsPerMilliSec, tmpBullets, bullets, protected_b, shotRemoveIndex, protected_e, enemyBullets, enemyShotRemoveIndex, tmpSprites, sprites, protected_a, curSprite, newLeft, newTop, spriteRemoveIndex, shipName, s, a, spriteLeft, spriteTop, spriteSize, spriteBottom, b, bulletLeft, bulletRight, bulletTop, bulletBottom, tmpHits, scale, spriteRight, e, curLevelMaxSprites, check_count, spriteOnScreen, addingSpriteIndex, protected_sprite, speedX, speedY, tmpSpriteImage, remove_i, bulletCount, newY, newX, ci, tmpBulletCount, z, highScoreName, highScoreValue, j As Primitive
    Sub Main()
        '  SpaceWars
        '
        '  Version info
        version = "version 0.1 - 10/29/09 - Abram Adams"
        'DISCLAIMER: Though most of this code is unique, I did "borrow" some code from StarGates
        'namely the CalibrateDelay, ShowHighScores and GetHighScores subs


        '**************************************************************************
        '*	INTRODUCTION TO THIS CODE/GUIDE
        '**************************************************************************
        'This program was written as a teaching tool to expose students
        'to the various aspects of programming.  SmallBasic is a great
        'starter tool that is simple and easy to use, but still allows you
        'to create some pretty cool things.
        '
        'Throughout the code you will find comments (like this one) that will
        'describe the section of code around it.  Key topics such will be 
        'explained such as:
        '		Comments
        '                                Variables
        '		Constants
        '		Sub Routines
        '		Function
        '		Class
        '		Properties
        '		Data Types
        '		Loops, Logic Control and Program Flow
        '		Events and Event Handlers
        '		Some basic "Best Practices" to become familiar with
        '
        'When these topics are discussed, you will see a heading such as:
        '**************************************************************************
        '*	KEY TOPIC:
        '*	Variables
        '**************************************************************************
        ' Once the key topics have been covered, there will be much less descriptive 
        ' commentary, so if you see something later you don't recall, look back toward
        ' the top of the file and see if it is explained (otherwise ask your instructor)
        ' 
        ' This game uses basic and advanced techniques.  Depending on your 
        ' programming experience you may be able to fully understand all that is
        ' going on, but if you don't that's OK.  Most programmers start out "playing"
        ' with code they don't understand.  Tweek a value here or change a formula
        ' there and watch how it changes the program (or breaks it!). Trial and error
        ' is a very good way to learn programming.

        '**************************************************************************
        '*	  FILE/FOLDER STRUCTURE
        '**************************************************************************
        'This game uses several image and audio files, such as images for the 
        'background, enemy ships, asteroids, etc... as well as explosion, shot, and intro
        'sounds.  Many of the images/sounds used are level specific, and can be changed
        'without changing any of the code.  Simply add an image file to the appropriate
        'directory and a new enemy/asteroid will be added to that level.
        'The structure looks like
        '   --space_wars/
        '     scores.txt <-- used to keep high scores
        '     SmallBasicLibrary.dll <-- required, SmallBasic file
        '     space_wars.exe <-- the game, compiled to execute.  This will run the game without the need for SmallBasic
        '     space_wars.pdb <-- SmallBasic generated file
        '     space_wars.sb <-- the uncompilled code (this file)
        '     |-- audio/
        '         |--levels/
        '             |--1/
        '                 |--bgm/
        '                       <mp3 files to play as background music for level 1>
        '             |--2/
        '                 |--bgm/
        '                       <mp3 files to play as background music for level 2>
        '             This repeats up to level 10
        '     |-- images/
        '         |--levels/
        '             |--1/
        '                 |--background/
        '                       <image file for background for level 1>
        '                 |--enemies/
        '                       <image files for enemy ships for level 1>
        '                 |--objects/
        '                       <image files for objects (i.e. asteroids) for level 1>
        '             |--2/
        '                 |--background/
        '                       <image file for background for level 2>
        '                 |--enemies/
        '                       <image files for enemy ships for level 2>
        '                 |--objects/
        '                       <image files for objects (i.e. asteroids) for level 2>
        '             This repeats up to level 10
        '         |--objects/
        '
        ' So try to add a few enemy ships or asteroid objects into a level and see it in action.

        '**************************************************************************
        '*	  DISCLAIMER ABOUT THE GAME PLAY
        '**************************************************************************
        ' This game was kept fairly basic, and does contain a few glitches due to both
        ' the current limitations of SmallBasic and some oversimplified mathematics
        ' used (i.e. to detect collisions,etc...).  So while you play the game you may 
        ' notice your fireball may seem to pass through an enemy, or attimes you may
        ' also see objects "freeze" or the game might crash altogether.  If any of this
        ' happens to you, sorry.  Hopefully some day you can fix these bugs!
        ' 

        'Now, on with the program.

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Comments
        '*  One of the most important things to learn in any programming languages
        '*  is how to write comments.  Comments are meant to describe or explain
        '*  a section of code, or to temporarily disable a line or section of code. When 
        '*  the program runs it will skip all comments.
        '*  In small basic you create a comment by preceeding the text with a single
        '*  quote ( ' ).  Each line of your comment must begin with the single qoute and
        '*  everything following that quote will be skipped.
        '**************************************************************************


        '**************************************************************************
        '*	KEY TOPIC:
        '*	Program Flow
        '*	Programming is much like writing a story.  First you set the stage,
        '*	describe the environment, set boundaries then you proceed in the telling
        '*  of the story.  In this case, we are setting up the window that will
        '*	contain our game.
        '**************************************************************************
        'Setup the game window
        GraphicsWindow.CanResize = false
        '**************************************************************************
        '*	KEY TOPIC:
        '*	Variables
        '*	Variables are placeholders used in programming to represent a specific
        '*	value.  These are typically used to inform a part of the program how
        '*	behave.
        '*	For instance, the below variables will define the width and height
        '*	of our window.  We are using Properties of the Desktop class (more on
        '*	classes and properties later) to calculate how wide and high to draw
        '*	our window and where to place it.  Notice the usage of simple mathematics
        '*	to dynamically size the window.  Our program window height will be the
        '*	height of the computer's desktop height less 100 pixels and the width
        '*	will be 10 pixels narrower than the desktop.
        '*	Note: Variable names cannot have spaces or punctuation.
        '**************************************************************************
        windowHeight = Desktop.Height - 100
        windowWidth = Desktop.Width - 10
        centerX = windowWidth / 2
        centerY = windowHeight / 2 'This (and centerX) is used later to find the center of the window
        GraphicsWindow.Width = windowWidth
        GraphicsWindow.Height = windowHeight
        '**************************************************************************
        'Some more variables
        GraphicsWindow.Title = "Abram's Space Wars" 'Sets the text in the title bar of the window.
        GraphicsWindow.Left = (Desktop.Width - windowWidth) / 2
        GraphicsWindow.Top = 10
        GraphicsWindow.BackgroundColor = "black"
        'Now show the window.  This is the Function SmallBasic provides to display the window.
        'More on Functions later.
        GraphicsWindow.Show()

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Events and Event Handlers
        '*	Events are actions that happen, either automated by the system or
        '*	generated by a user interaction, such as pressing down a key
        '*	In this case, when the key is pressed down we will execute the 
        '*	Sub routine called "onKeyDown" which we define later.  This Sub routine
        '*	is known as the Event Handler, as it Handles the Event action
        '**************************************************************************
        AddHandler GraphicsWindow.KeyDown, AddressOf onKeyDown
        'The onKeyUp Sub will fire when the user releases the key.
        'This is also defined later
        AddHandler GraphicsWindow.KeyUp, AddressOf onKeyUp
        '**************************************************************************

        'Key controls
        'These are variables that will make it easier to program
        'later when we are using directional inputs to navigate
        'our game.  Since in SmallBasic when we start typing a 
        'word it gives us a drop down list of options that match
        'what we've typed, we can use that to be sure that we 
        'don't mispell a variable name.  It also allows us to assign
        'a meaningful name to the actual key code, so instead of
        'remembering what key makes the ship fire a bullet, we
        'just need to use the fireKey variable.
        leftKey = "Left"
        rightKey = "Right"
        upKey = "Up"
        downKey = "Down"
        fireKey = "Space"
        pauseKey = "P"
        quitKey = "Escape"
        hyperspaceKey = "RightCtrl"
        changeWeaponKey = "G"
        'Now we'll setup some more convenience variables that we'll
        'use later to determine what key was pressed, and in which order.
        leftKeyPressed = __false
        rightKeyPressed = __false
        upKeyPressed = __false
        downKeyPressed = __false
        fireKeyPressed = __false
        hyperspaceKeyPressed = __false
        changeWeaponKeyPressed = __false
        leftRightPriority = rightKey
        upDownPriority = upKey


        ' Dec2Hex conversion string
        hexaDecimal = "0123456789ABCDEF"
        'Since we will use external files for images and sound, we'll set up a 
        'couple variables to point to these directories.  This makes it easier
        'to reference the directory paths (less typing) and it also makes it
        'easier to move or rename the folders if need be.  In those cases
        'we'd just need to update the new folder in one place and everywhere
        'in our program that uses those directories will automatically use
        'the new ones.
        imagePath = Program.Directory + "\images\"
        audioPath = Program.Directory + "\audio\"

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Sub Routines
        '*	In this section we introduce the use of sub routines.  Sub routines are a 
        '*	pre-defined set of steps or actions that are grouped into a single name 
        '*	that can be executed anywhere in our program.  This will allow us to 
        '*	easily reproduce the results at any time in our program.
        '*	Before we create a Sub routine, look at the following lines to see how a 
        '*	sub routine is executed (otherwise known as "called" or "fired").  In the
        '*	following lines we execute Sub routines that are defined later in the
        '*	code.
        '**************************************************************************
        'Load images
        initImages()
        'Load sounds
        initSounds()
        ' Determine speed of computer
        CalibrateDelay()
        '**************************************************************************
        '*	You will notice that there are just three lines of code (not counting the 
        '*	comments) that actually do all the work to load the images and sounds 
        '*	used in our program.  You'll also notice they end with (), this tells SmallBasic
        '*	that these are calls to a Sub routine and they are to be executed as soon as
        '*	they are encountered.  In general terms, SmallBasic will execute your code
        '*	from top to bottom, left to right (just like you would read it).  When
        '*	it encounters a sub routine call, it replaces the name() with the actual
        '*	code that that Sub represents.
        '*	
        '*	Note:
        '*	You may recall from above that we assigned Sub routines to the KeyDown
        '*	and KeyUp events.  When we did we did not include the () at the end.  That
        '*	is because we don't want the sub routines to execute when that line is 
        '*	interpreted by SmallBasic, rather we want them to execute when the event
        '*	they are assigned to occurs.
        '***********************************************************************

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Constants	
        '*	Programmers often use techniques that help them be more efficient, as well
        '*	as to help those that may work on the code in the future.  One of the ways we
        '*	do this is to use "constants".  Constants are a basically a variable that will
        '*	not change during the life of the application run.  These are typically used
        '*	to store numeric values that are used as pointers into user friendly variable
        '*	names.  In this particular section we are setting up named indicies to use 
        '*	when referencing specific positions in an array.  
        '**************************************************************************
        '*	KEY TOPIC:
        '*	Data Types
        '*	Information stored in variables can be many different data types.  Some of
        '*	the typical data types are "String" types.  These are simple plain text 
        '*	values such as numbers, or letters/words.  Other data types are more complex
        '*	and can store more information than just numbers and words.  Arrays for instance
        '*              gives us a special way to store data in a single variable.  Arrays are sort 
        '*	of like a list of values, each item in the list is numbered sequentially.  
        '*	So if the array had the following values:
        '*	   hat, shoes, shirt
        '*	and you wanted the value of the shoes you'd ask for the 2nd position (or
        '*	index) of the array.  In SmallBasic that would look like:
        '*	   myArray[2]
        '*	The number in the square brackets tell the myArray variable which position
        '*	to return.
        '*	Of course there are many other data types, such as objects which can
        '*	themselves contain simple and complex data.
        '***********************************************************************
        '*	
        '*	Back to this set of variables...  Each position in the arrays used in
        '*	this program store different type of information, for instance the first 
        '*	position in the array stores the size, the second and third store the X 
        '*	and Y coordinates.  When you are programming it is impossible to remember 
        '*	all of these positions by number, especially when there could be thousands.  
        '*	Therefore we use these constants for clarity and easy reference, and set 
        '*	their values to the position in the index we wish to reference.
        _size = 1
        _x = 2
        _y = 3
        _shape = 4
        _isVisible = 5
        _angle = 6
        _speed = 7
        _maxSpeed = 8
        _startPos = 9
        _width = 10
        _height = 11
        _hits = 12
        _direction = 13
        _totalHits = 14
        _maxSpritePoints = 15
        _completePoints = 16
        _shots = 17
        _hasWeapons = 18
        _shotTicker = 19
        _bulletColor = 20
        'level constants
        _maxSprites = 1
        _spritesToLevelUp = 2
        _pointWorth = 3
        _minSpriteSpeed = 4
        _maxSpriteSpeed = 5
        _shotInterval = 6
        _backgroundImages = 7
        _objectImages = 8
        _enemyImages = 9
        _EnemyRatio = 10
        _maxHits = 11
        _hasBoss = 12
        _BGMusic = 13

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Best Practice
        '*	Notice in the above section I prefix variables with an underscore (_). 
        '*	This is a simple way to identify that these are array index variables.
        '*	Having the underscore in the name does not change anything about how
        '*	it works, it just stands out when you a reading it.  Various techniques
        '*	like this are used (and sometimes vary between languages).  For instance
        '*	I use what is called Lower Camel Case to name my Functions, Subs, variables,
        '*	etc... Since you cannot have spaces in variable names it makes it easier
        '*	to read something like: thisIsLowerCamelCase than it is to read
        '*	thisislowercamelcase.
        '**************************************************************************

        'Some other constants
        __true = 1
        __false = 0
        play = __true
        pause = __false
        alive = __true
        gameEnd = __false

        'Desired frames per second (but will be lower on slower computers)
        fpsTarget = 30

        'Here we are ready to start the actual game.  Our window is setup and visible,
        'our images and sounds are loaded, our variables that we will be using are 
        'initialized and we are ready to go.  
        'Here we will begin to appreciate the use of sub routines.  Each one of these
        'sub routines do a lot of work.  If we didn't have sub routines we'd have to
        'type all of that work out right here.  Ok, not convincing, but what if you
        'wanted to perform the same set of actions again.  Without subs you'd have
        'to re-write those steps every time you wanted to use them.  But there's more,
        'now consider if you wanted to add a feature, or change the way something
        'worked.  You'd have to make sure you change it in each location exactly the same.
        'Many of the below subs are used in other places in this program, such as the 
        'initGame() sub is used to restart the game (such as after a game over)
        initGame()
        initLevels()
        GetHighScores()
        initBackground()
        intro()
        drawPanel()
        updateScoreBoard()
        initBackground()
        initSprites()
        initExplosion()
        initShip()
        initWeapons()

        ' The game loop
        MainLoop()

        ' Exit game
        Program.End()

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Sub Routines
        '*	Our first Sub routine
        '*	Sub routines are defined by using the Sub keyword followed by the name
        '*	(no spaces/punctuation) and the definition is completed by the EndSub
        '*	keyword.  The code between Sub and EndSub will execute when the sub is
        '*	called using name() (replacing "name" with the actual name)
        '*	
        '*	Note that sub routines can reside anywhere in the applicaiton, even at
        '*	a later point than when they are called.  This is because SmallBasic will
        '*	compile your code before it runs.  
        '*	As a personal preference I prefer (as you see in this program) to place
        '*	all my application variable setup and declaration at the top of the file
        '*	and place the sub routines at the bottom.  You'll also notice that I don't
        '*	declare (or create) any variables outside of sub routines beyond this point.
        '*	I could, but it makes it difficult to debug (or figure out what went wrong)
        '*	later.
        '***************************************************************************




        ' Preload all sounds in game by loading then immediately stopping them.
        ' Makes it quick to play later since retained in memory.










        ' Create explosion pieces



        'One sub to move them all, one sub to bind them, one sub to...
        'Seriously, this sub will cause every movable object on the screen to move one 
        'step.  This include bullets, asteroids, hero ship and enemy ships.  We will also
        'be able to detect any target hits or collisions.





























        ' Read key event
        ' Note that key priority is remembered in case both up/down pressed 
        ' we will do what the last key press indicates.
        ' Also note that this is an event handler, so key presses can
        ' interrupt code running elsewhere at any time, must be careful not to 
        ' change variables etc that could affect code undesireably.

        ' Run on key release, see note above




        ' Pull in scores from file

        ' Get players score if higher than scoreboard, show scoreboard.
        ' Show high scores with nice graphic effect - it's their only reward



    End Sub
    Sub initGame()
        'Setup Game
        'All this sub really does is set/reset all the neccessary variables to
        'a predefined "starting" point.  This makes it easy to reset the game.
        play = 1
        level = 1
        maxLevels = 10
        score = 0
        lives = 5
        curPoints = 0
        pointsForOneUp = 0

        curX = centerX
        curY = windowHeight - shipHeight

        'Setup Sprites
        spritesOnScreen = 0
        currentSprite = 1
        spritesDestroyed = 0

    End Sub
    Sub intro()
        '**************************************************************************
        '*	KEY TOPIC:
        '*	Classes
        '*	"Sound" is a SmallBasic class that provides some basic tools to play
        '*	music and/or sounds.  In programming languages, classes are collections
        '*	of properties and functions that are in some way related.  The Sound 
        '*	class for instance has functions to play, pause and stop music files
        '*	such as mp3 files.  It also has functions to play chimes, click sounds
        '*	and musical notes.
        '*	To use a function provided by a class you use what is called the dot notation.
        '*	That is done by typing the name of the class (Sound in this case), then followed 
        '*	by a period.  In SmallBasic (and most modern programming language editors) once
        '*	you type the period you will be presented with a drop-down list of available 
        '*	functions and properties inside of that class to choose from.
        '**************************************************************************
        Sound.Play(audioPath + "introduction.mp3")

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Functions
        '*	Functions are very similar to sub routines in that they group a section of
        '*	instructions to execute whenever the program encounters the function's name.  The
        '*	difference between a Sub and a Function is that Functions can accept arguments.
        '*	Arguments allow the function to receive information from the program that calls
        '*	the function, which can be used to alter the behaviour of the function.  Using
        '*	the Sound.Play() function for example.  This function accepts a file path argument
        '*	which tells it what file to play.  Unfortunately, in SmallBasic (at least the 
        '*	current version at the time of this writing) you cannot create your own Functions, 
        '*	only Sub routines.  In this program, I use variables to store information that
        '*	alter the Sub routines behaviour, so before a Sub is executed I set the value that
        '*	changes the behaviour.  This works well enough in this program, but can (and does)
        '*	create conflicts when a variable gets overridden before the Sub executes.

        GraphicsWindow.FontName = "courier"
        GraphicsWindow.FontSize = 70

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Properties
        '*	Properties store information about the class it belongs to.  For instance, the
        '*	GraphicsWindow class has FontName and FontSize properties which change the
        '*	way text is drawn on the screen.
        '***************************************************************************

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Loops
        '*	Loops are powerful tools, and can really reduce the amount of code you have to 
        '*	manually write (among other benefits).  In SmallBasic there are two types of
        '*	loops: For Loop and While Loop.
        '*	For loops will loop a set number of times and While loops will continually loop
        '*	until a certain condition is met. 
        '*	This particular loop is a For type loop and is going to loop 14 times, and 
        '*	execute the code inside of the "For" and "endFor" lines each time. The goal of 
        '*	this loop is trivial, we are transitioning the text color of the high scores 
        '*	from red to white by slowly changing the color value on each iteration of the 
        '*	loop.  This loop is a reverse loop in that it will start at 15 and count backwards 
        '*	by 1 to 1.  Each time the loop completes an iteration, the "i" variable will be
        '*	reduced by 1 until it reaches the "to" value, which in this case is 1
        For i = 15 To 1 Step -1
            'Animate intro color from white to red - hex conversion technique borrowed from Rushworks "Gorillas"

            'This technique will grab a single character from the hexaDecimal variable set earlier starting from the
            'end of the value and working its way to the beginning on each iteration.  This will build the hex color
            'value which will start at white "#FFF", and ease its way to red "#FF0"
            temp = Text.Append(Text.GetSubText(hexaDecimal, i, 1), "0")
            temp2 = Text.Append("#FF", temp)
            temp2 = Text.Append(temp2, temp)
            'Now that we have the color, we'll set the BrushColor to use when drawing the text;
            GraphicsWindow.BrushColor = temp2
            'Now draw the text to the screen.  I'm using a little math to center the text in the screen
            'This is a typical scenario that a little bit of simple math will help with.  To explain, look at the
            'first argument passed to the DrawText function.  This argument is the X position or the horizontal
            'position in which to start drawing.  The variable windowWidth holds the value of the actual window 
            'width.  If we divide that by 2 we get exactly half the window width.  However, that is where DrawText
            'will start drawing, so the text won't be truely centered.  That is why we reduce that value by 210, which
            'is the actual pixel width of the text to be drawn.  Now we have our exact left edge, we do somethinge very
            'similar to determine the Y or vertical coordinate.  With these to plot points we now have our top left corner
            'where our text will start from. 
            GraphicsWindow.DrawText((windowWidth / 2) - 210, windowHeight / 2.4, "SPACE WARS")

            'Loops are very fast, so if we just did a loop changing the color you'd likely not see any transition, you'd
            'probably only see blinking text randomly changing from white directly to red with no transition.  This is
            'where a Delay() funciton comes in real handy.  This will tell the program to wait for 150 milliseconds before
            'continuing to the next iteration of the loop.
            Program.Delay(150)
        Next
        '***********************************************************************
        '   Notice that we can call sub rotuines from within a sub routine.  This 
        '   opens a lot of possibilities
        ShowHighScores()

    End Sub
    Sub initImages()
        ' Load various images that will be used in the game.
        '**************************************************************************
        '*	KEY TOPIC:
        '*	Data Types
        '*	This is another example of a complex data type.  These variables will
        '*	store the actual image loaded from a file.  We can then use these later
        '*	to change the background, or display various objects on the screen.
        '**************************************************************************	
        bg = ImageList.LoadImage(imagePath + "background.jpg")
        menuBg = ImageList.LoadImage(imagePath + "menu-background.jpg")
        gameOverBg = ImageList.LoadImage(imagePath + "gameover.jpg")
        warpbg = ImageList.LoadImage(imagePath + "warp.jpg")
        fireBallImage = ImageList.LoadImage(imagePath + "fireball.png")
        fireBallSmallImage = ImageList.LoadImage(imagePath + "fireball-small.png")
        blueFireBallImage = ImageList.LoadImage(imagePath + "blue-fireball.png")
        blueFireBallSmallImage = ImageList.LoadImage(imagePath + "blue-fireball-small.png")

    End Sub
    Sub initSounds()
        'By playing then immediately stopping the music files we are 
        'loading them into memory
        Sound.Play(audioPath + "scores.mp3")
        Sound.Stop(audioPath + "scores.mp3")
        Sound.Play(audioPath + "score_entered.mp3")
        Sound.Stop(audioPath + "score_entered.mp3")
        Sound.Play(audioPath + "destruction.mp3")
        Sound.Stop(audioPath + "destruction.mp3")
        Sound.Play(audioPath + "introduction.mp3")
        Sound.Stop(audioPath + "introduction.mp3")
        Sound.Play(audioPath + "battle.mp3")
        Sound.Stop(audioPath + "battle.mp3")
        Sound.Play(audioPath + "small-explosion.wav")
        Sound.Stop(audioPath + "small-explosion.wav")
        Sound.Play(audioPath + "warp.mp3")
        Sound.Stop(audioPath + "warp.mp3")

        ' Play and wait for a quiet sound to finish.  When done
        ' all sounds are loaded & ready to go
        Sound.PlayAndWait(audioPath + "quiet.mp3")

    End Sub
    Sub initLevels()
        'Here we will loop from 1 to the maximum levels described in maxLevels
        For level_count = 1 To maxLevels
            'Grab the images for this level
            'Each level has its own folder, so we can swap out the images per level.
            'So far we've only assinged plain text or numeric values to variables.  Here, we are going
            'to assign an array to the levelObjectImages.  The File.GetFiles() function returns an array
            'of files in the specified directory
            levelBGImages = File.GetFiles(Program.Directory + "\images\levels\" + level_count + "\background\")
            levelEnemyImages = File.GetFiles(Program.Directory + "\images\levels\" + level_count + "\enemies\")
            levelObjectImages = File.GetFiles(Program.Directory + "\images\levels\" + level_count + "\objects\")
            '**************************************************************************
            '*	KEY TOPIC:
            '*	Logic Control
            '*	Often we need to make decisions in our applications based on the current
            '*	state of "things".  For instance, based on what the current value of 
            '*	a variable is set to, or the number of items in an array (see below 
            '*	about arrays)
            '*	"If" statements are used to make decisions.  The format is:
            '*	If expression = true Then
            '*		do something
            '*	EndIF
            '* 	The expression = true can be anything that can result in a true/false answer.
            '*	This logic block is checking to see if the variable levelObjectImages is
            '*	of data type "Array" OR if levelObjectImages has zero items. If not, then
            '*	it will execute the code between "If" and "EndIf", if so, then it will skip
            '*	it.
            If (Microsoft.SmallBasic.Library.Array.IsArray(levelObjectImages) = __False) Or (Microsoft.SmallBasic.Library.Array.GetItemCount(levelObjectImages) <= 0) Then
                levelObjectImages = File.GetFiles(Program.Directory + "\images\objects\")
            End If

            levelBGMusic = File.GetFiles(Program.Directory + "\audio\levels\" + level_count + "\bgm\")
            '**************************************************************************
            '*	KEY TOPIC:
            '*	Data Types - Arrays
            '*	Here's were things get interesting with arrays.
            '*	The levels array is what is called a two dimensional array.  This simply 
            '*	means it is an array that contains a list of arrays inside of it.  The 
            '*	array inside the array is typically closely related to the parent array.  
            '*	Consider the game's levels. Say there are 10 levels, and on each level 
            '*	you want to change how many points you get for hitting an enemy target.  
            '*	The fastest way in SmallBasic to do that is to create a two dimensional 
            '*	array. The first dimension of the array is a sequential number from 1, 
            '*	to the number of levels. The second dimension of the array contains the 
            '*	values of various aspects of that level.
            '*	See the following example:
            '*	levels[1][_pointWorth] = 100
            '*	levels[1][_maxSprites] = 5
            '*	levels[2][_pointWort] = 200
            '*	levels[2][_maxSprites] = 10
            '*	This would mean that on level 1, the point for hitting a target would 
            '*	be 100 and ther will be no more than 5 enemies on the screen at a time, 
            '*	level 2 would give 200 points per hit and show up to 10 enemies on the 
            '*	screen at a time.
            '*	
            '*	Notice the use of variables in the [], the level_count variable is the 
            '*	iteration count of the loop, so will be 1 to the number of levels.  The 
            '*	second dimension uses the constants we setup earlier.
            '*	
            '*	Two dimensional arrays not only give us a convenient way to store related 
            '*	data, but it also allows us to retrieve the data dynamically based on the 
            '*	state of the application at any given point.  For instance, when the user 
            '*	reaches the next level, the global variable "level" is incremented by 1 
            '*	(i.e. from level 1 to level 2).  Now to reference level specific 
            '*	information we just pass that in as the first dimension of the levels[] 
            '*	array and we get back level 2 data. The alternative would be to have a 
            '*	variable for each aspect of each level (130 just in this sub routine if 
            '*	there are 10 levels) and a whole bunch of if statements to determine 
            '*	which variable to use
            '**************************************************************************
            levels(level_count)(_maxSprites) = 3 + (Microsoft.SmallBasic.Library.Math.Ceiling(level_count / 2) * 1.5) ' number of sprites at a time
            levels(level_count)(_spritesToLevelUp) = 5 + Microsoft.SmallBasic.Library.Math.Round(2 * level_count) ' number of enemy sprites (not asteroids) needed to beat level
            levels(level_count)(_maxSpriteSpeed) = level_count * .75 ' max speed of sprites
            levels(level_count)(_minSpriteSpeed) = levels(level_count)(_maxSpriteSpeed) / 2 ' min speed of sprites
            levels(level_count)(_pointWorth) = level_count * 55 ' point value for sprite
            levels(level_count)(_completePoints) = level_count * 1000 'bonus points for completing a level
            levels(level_count)(_shotInterval) = (maxLevels - (level_count + 2)) * 7 '  interval of enemy shots
            levels(level_count)(_enemyImages) = levelEnemyImages
            levels(level_count)(_objectImages) = levelObjectImages
            levels(level_count)(_backgroundImages) = levelBGImages
            levels(level_count)(_EnemyRatio) = .01 * level_count
            levels(level_count)(_maxHits) = Microsoft.SmallBasic.Library.Math.Round(level_count / 2)
            levels(level_count)(_hasBoss) = Microsoft.SmallBasic.Library.Math.Remainder(level_count, 5)
            levels(level_count)(_BGMusic) = levelBGMusic(1)
        Next

    End Sub
    Sub initSprites()
        '*************************************************************************************
        '   This Sub initializes all the sprites that will appear in the game.  In game programming
        '   and movie/animation programming sprites are any visible object that has behavior
        '   in this game, sprites are things like asteroids and space ships.  They have properties
        '   such as they can move, space ships can fire bullets, they can take various hits before
        '   being destroyed, asteroids change direction and get smaller when you shoot them, 
        '   ships bounce of the edges of the screen, etc...

        'setup sprites
        'Recall how we setup the levels array in the initLevels sub?  This is one of the uses for it
        'We are now seting up how many asteroids will appear on the screen, and what images
        'we use for them.  Each level can have its own asteroid image, it doesn't even have to be
        'an asteroid, it could be a image of a hairless chiuaua if you so desired. 
        For i = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(levels(level)(_objectImages))
            spriteImage(i) = levels(level)(_objectImages)(i)
        Next

        'spriteImage[1] = imagePath + "sprite1.gif"
        For i = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(levels(level)(_enemyImages))
            enemyImage(i) = levels(level)(_enemyImages)(i)
        Next

    End Sub
    Sub initStars()

        'Setup stars.  Thes are random sized/colored dots that we draw randomly on the screen
        'during warp to give the impression of a star field.
        starCount = 300
        starColors(1) = "white"
        starColors(2) = "red"
        starColors(3) = "LightCyan"
        stars = ""
        For i = 1 To starCount
            GraphicsWindow.PenColor = starColors(Microsoft.SmallBasic.Library.Math.GetRandomNumber(3))
            GraphicsWindow.BrushColor = GraphicsWindow.PenColor
            starSize = Microsoft.SmallBasic.Library.Math.GetRandomNumber(3)
            starX = Microsoft.SmallBasic.Library.Math.GetRandomNumber(Desktop.Width)
            starY = Microsoft.SmallBasic.Library.Math.GetRandomNumber(windowHeight)
            'GraphicsWindow.FillEllipse(starX,starY,starSize,starSize) 
            stars(Microsoft.SmallBasic.Library.Array.GetItemCount(stars) + 1) = Shapes.AddEllipse(starSize, starSize)
            Shapes.Move(stars(Microsoft.SmallBasic.Library.Array.GetItemCount(stars)), starX, starY)
        Next

    End Sub
    Sub initBackground()
        bgImage = ImageList.LoadImage(levels(level)(_backgroundImages)(1))
        GraphicsWindow.DrawResizedImage(bgImage, 0, 0, windowWidth, windowHeight)
    End Sub
    Sub initShip()
        'Load ship 
        EastWest = ""
        NorthSouth = ""
        curShipName = "ship"
        'Here's an example of a two dimensional array without using constants.  Since 
        'there were only two indexes in this array it was ok to just use the numbers, though
        'it would still be best practice to use constants for clarity.
        shipImages(1)(1) = ImageList.LoadImage(imagePath + "ship.png")
        shipImages(1)(2) = "ship"
        shipImages(2)(1) = ImageList.LoadImage(imagePath + "ship-north.png")
        shipImages(2)(2) = "ship-north"
        shipImages(3)(1) = ImageList.LoadImage(imagePath + "ship-east.png")
        shipImages(3)(2) = "ship-east"
        shipImages(4)(1) = ImageList.LoadImage(imagePath + "ship-south.png")
        shipImages(4)(2) = "ship-south"
        shipImages(5)(1) = ImageList.LoadImage(imagePath + "ship-west.png")
        shipImages(5)(2) = "ship-west"
        shipImages(6)(1) = ImageList.LoadImage(imagePath + "ship-north-east.png")
        shipImages(6)(2) = "ship-north-east"
        shipImages(7)(1) = ImageList.LoadImage(imagePath + "ship-north-west.png")
        shipImages(7)(2) = "ship-north-west"
        shipImages(8)(1) = ImageList.LoadImage(imagePath + "ship-south-east.png")
        shipImages(8)(2) = "ship-south-east"
        shipImages(9)(1) = ImageList.LoadImage(imagePath + "ship-south-west.png")
        shipImages(9)(2) = "ship-south-west"

        shipWidth = ImageList.GetWidthOfImage(shipImages(1)(1))
        shipHeight = ImageList.GetHeightOfImage(shipImages(1)(1))
        ship = Shapes.AddImage(shipImages(1)(1))
        shipLeft = curX
        shipRight = curX + shipWidth
        shipTop = curY ' - shipHeight 
        shipBottom = curY + shipHeight

        Shapes.Move(ship, shipLeft, shipTop)

    End Sub
    Sub initWeapons()
        possibleBulletsOnScreen = 2
        bulletColor = "red"
        bulletSpeed = 10
        bulletWidth = 5
        bulletHeight = 10
        bulletShape = "rectangle"
        bulletStrength = 1

        enemyBulletColors(1) = "orange"
        enemyBulletColors(2) = "red"
        enemyBulletColors(3) = "purple"
        enemyBulletColors(4) = "green"

    End Sub
    Sub initExplosion()

        explodeImage(1) = ImageList.LoadImage(imagePath + "explode-small1.png")
        explodeImage(2) = ImageList.LoadImage(imagePath + "explode-small1.png")
        explodeImage(3) = ImageList.LoadImage(imagePath + "explode-small1.png")
        explodeImage(4) = ImageList.LoadImage(imagePath + "explode-small1.png")

        explodeImage(5) = ImageList.LoadImage(imagePath + "explode-medium1.png")
        explodeImage(6) = ImageList.LoadImage(imagePath + "explode-medium1.png")
        explodeImage(7) = ImageList.LoadImage(imagePath + "explode-medium1.png")
        explodeImage(8) = ImageList.LoadImage(imagePath + "explode-medium1.png")

        explodeImage(9) = ImageList.LoadImage(imagePath + "explode-large1.png")
        explodeImage(10) = ImageList.LoadImage(imagePath + "explode-large1.png")
        explodeImage(11) = ImageList.LoadImage(imagePath + "explode-large1.png")
        explodeImage(12) = ImageList.LoadImage(imagePath + "explode-large1.png")

        ' Create small explosion pieces that are permanently available
        For explosion_i = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(explodeImage)
            temp = Shapes.AddImage(explodeImage(explosion_i))

            ' Move it immediately off screen so it isn't ever seen
            Shapes.Move(temp, 0, -100)

            ' Save in array 
            explosion(explosion_i) = temp
        Next

        ' Center of explosion
        explosionX = 0
        explosionY = 0
        explosionSpread = 0
        explosionAlpha = 100
        exploding = __false
        explosionSize = 0
    End Sub
    Sub MainLoop()
        '*************************************************************************************
        ' This is what makes the game possible.  Here we are going to use what is called
        ' a While loop.  This literally means, while the condition is true, execute the enclosed
        ' code.  As soon as the condition is false, stop.
        ' The variable play is initially set to "true" which means the game loop will start immediately.
        ' Each time the "loop" runs through the code it is called an iteration.  In each iteration of
        ' the loop in this case is similar to a frame in a movie.  In each frame we need to draw all
        ' of the sprites, bullets, background, ships in the appropriate positions, just like in a movie
        ' film.  If you look at a movie film, each frame is a still photo that looks almost identical to
        ' the one before it but with a very slight change.  If you scroll through the film strip at a
        ' fast pace the still pictures will give the sense that they are moving.  Same concept with
        ' the game here.  On each iteration we see if the user has pressed a key, then we act on that
        ' key press (remember the event listener at the top of this program?).  If the left key was 
        ' pressed we need to move the user's ship to the left 1 step, and so on.  If the user has pressed
        ' the fire key we need to draw a new bullet on the screen.  We also need to advance any
        ' other bullets up one step (or more based on the speed of the bullet).  We also need to detect
        ' bullet hits (if we hit a target, or a enemy hit us), and collisions (astroid or enemy ran into us)
        ' We also need to add up the total points, update the score board that shows points, level, etc...
        ' In a nutshell, every aspect of the game needs to advance one "step".
        '*************************************************************************************

        '**************************************************************************
        '*	KEY TOPIC:
        '*	Loops
        '*	Here is an example of a While loop.  In this case, we will loop while 
        '*	the value of "play" is equal to true.  When the user spends all of the
        '*	lives, the game is over and the play variable is set to false (see 
        '*	the gameOver() Sub.  Use these types of loops cautiously since they can
        '*	cause infinite loops if play never equals false.
        '**************************************************************************

        While play = __true


            If pause = __false Then
                ' With this little trick we can pause the game.  The loop still runs, but the code will not
                ' until the pause key is pressed again.

                If (alive = __true) AND (gameEnd = __false) Then
                    ' Only if our player is still alive and the game hasn't ended do we need to 
                    ' continue the game.
                    doKeys() ' This sub will act on the keys pressed since the last iteration
                    addSprites() 'This sub will add sprites (asteroids/enemies) to the screen if we've drop below the number allowed on this level
                    updateScoreBoard() 'The most important part, update the score

                Else
                    ' Player is either dead or game is over.  We'll remove all sprites from the screen.
                    removeAllSprites()
                End If
                Explode() ' This detects the need to explode something, then does it.
                Move() '  This detects the need to move, then does it.


                ' Smooth estimate of time elapsed between frames
                tNow = Clock.Millisecond
                dT = tNow - tLast
                tLast = tNow

                ' Handle millisecond rollover at 1 second marks
                If dT < 0 Then
                    dT = dT + 1000
                End If

                k = 0.1 '  1 = no smoothing, values less than 1 smooths.  0.1 default
                dTLossy = (dTLossy * (1 - k)) + (dT * k)

                ' Figure out how long we need to wait to achieve desired average frame rate
                waitLoops = (1000 / fpsTarget) - dTLossy
                waitLoops = waitLoops * loopsPerMilliSec
                For i = 1 To waitLoops
                    i = i
                Next

            End If
        End While

    End Sub
    Sub Move()
        'move ship
        If alive = __true Then
            'If our player is alive, move the ship (based on player's move)
            moveShip()
        Else
            alive = alive + 1
        End If


        'move all active bullets
        tmpBullets = Microsoft.SmallBasic.Library.Array.GetItemCount(bullets)
        For protected_b = 1 To tmpBullets
            Shapes.Move(bullets(protected_b), Shapes.GetLeft(bullets(protected_b)), Shapes.GetTop(bullets(protected_b)) - 20)
            If Shapes.GetTop(bullets(protected_b)) < -10 Then
                shotRemoveIndex = protected_b
                RemoveShot()
            End If
            tmpBullets = Microsoft.SmallBasic.Library.Array.GetItemCount(bullets)
        Next


        'Move enemy Bullets
        For protected_e = 0 To Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBullets)
            'If array.GetItemCount(enemyBullets[temp_a]) >= 0 Then
            'For protected_e = 0 To Array.GetItemCount(enemyBullets[temp_a])
            Shapes.Move(enemyBullets(protected_e)(1), Shapes.GetLeft(enemyBullets(protected_e)(1)), Shapes.GetTop(enemyBullets(protected_e)(1)) + 20)
            If Shapes.GetTop(enemyBullets(protected_e)(1)) > windowHeight Then
                enemyShotRemoveIndex = protected_e
                'enemyShotRemoveSpriteIndex = temp_a
                RemoveEnemyShot()
            End If
            'EndFor
            'EndIf  
        Next

        'Move all active sprites
        tmpSprites = Microsoft.SmallBasic.Library.Array.GetItemCount(sprites)
        For protected_a = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(sprites)
            curSprite = protected_a

            If sprites(protected_a)(_direction) = CType("left", Primitive) Then
                newLeft = Shapes.GetLeft(sprites(protected_a)(_shape)) - sprites(protected_a)(_x)
            Else
                newLeft = Shapes.GetLeft(sprites(protected_a)(_shape)) + sprites(protected_a)(_x)
            End If
            newTop = Shapes.GetTop(sprites(protected_a)(_shape)) - sprites(protected_a)(_y)

            Shapes.Move(sprites(protected_a)(_shape), newLeft, newTop)
            isSpriteVisible()
            If sprites(curSprite)(_isVisible) = 0 Then
                If sprites(curSprite)(_hasWeapons) = __true Then
                    'If this sprite is an enemy, bounce him off the wall
                    If newTop < (windowHeight - sprites(curSprite)(_height)) Then
                        If sprites(curSprite)(_direction) = CType("right", Primitive) Then
                            sprites(curSprite)(_x) = -sprites(curSprite)(_x)
                            sprites(curSprite)(_direction) = "left"
                        Else
                            sprites(curSprite)(_x) = Microsoft.SmallBasic.Library.Math.Abs(sprites(curSprite)(_x))
                            sprites(curSprite)(_direction) = "right"
                        End If
                    Else
                        spriteRemoveIndex = curSprite
                        removeSprite()
                    End If
                Else
                    spriteRemoveIndex = curSprite
                    removeSprite()
                End If
            ElseIf (sprites(protected_a)(_hasWeapons) = 1) And (shapes.GetTop(sprites(protected_a)(_shape)) < curY) And (Shapes.GetLeft(sprites(protected_a)(_shape)) > (curX - 100)) And ((Shapes.GetLeft(sprites(protected_a)(_shape)) + sprites(protected_a)(_width)) < (curX + shipWidth + 100)) Then

                If (sprites(curSprite)(_shots) <= 10) And (sprites(curSprite)(_shotTicker) >= levels(level)(_shotInterval)) Then
                    sprites(curSprite)(_shotTicker) = 0
                    enemyShoot()
                End If
                sprites(curSprite)(_shotTicker) = sprites(curSprite)(_shotTicker) + 1
            End If
        Next

        anyHits()

    End Sub
    Sub moveShip()
        shipLeft = curX
        shipRight = curX + shipWidth
        shipName = "ship"
        If NorthSouth <> CType("", Primitive) Then
            shipName = shipName + "-" + NorthSouth
        End If
        If EastWest <> CType("", Primitive) Then
            shipName = shipName + "-" + EastWest
        End If

        If curShipName <> shipName Then
            For s = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(shipImages)
                If shipImages(s)(2) = shipName Then
                    Shapes.Remove(ship)
                    ship = Shapes.AddImage(shipImages(s)(1))
                    s = 10000
                End If
            Next

        End If
        curShipName = shipName
        Shapes.Move(ship, curX, curY)
    End Sub
    Sub anyHits()
        ' "a" will be the index of the enemy sprite and "b" will be the index of the bullet 
        For a = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(sprites)
            spriteLeft = Shapes.GetLeft(sprites(a)(_shape))
            spriteTop = Shapes.GetTop(sprites(a)(_shape))
            spriteSize = sprites(a)(_width)
            spriteBottom = spriteTop + spriteSize
            For b = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(bullets)
                bulletLeft = Shapes.GetLeft(bullets(b))
                bulletRight = bulletLeft + bulletWidth
                bulletTop = Shapes.GetTop(bullets(b))
                bulletBottom = bulletTop + bulletHeight

                ' Did we shoot the sprite
                If bulletTop > 0 Then
                    'The top of the bullet (the player's bullet) is greater than zero, which means it is on the screen
                    If ((bulletLeft >= spriteLeft) And (bulletLeft <= (spriteLeft + spriteSize))) And ((bulletTop < spriteBottom) And (bulletTop > spriteTop)) Then
                        'The bullet's coordinates matches those of a enemy sprite, we hit it!
                        curSprite = a
                        shotRemoveIndex = b
                        RemoveShot()
                        tmpHits = sprites(a)(_hits)
                        sprites(a)(_hits) = sprites(a)(_hits) - bulletStrength

                        If sprites(a)(_hits) <= 0 Then
                            'Sprites each require a certain pre-determined number of hits before being destroyed.
                            'If we've reached that number, we will explode the enemy sprite and remove it from the screen.
                            explosionX = Shapes.GetLeft(sprites(a)(_shape))
                            explosionY = Shapes.GetTop(sprites(a)(_shape))
                            explosionSpread = sprites(a)(_width) / 2
                            exploding = __true
                            curPoints = sprites(a)(_maxSpritePoints) * tmpHits
                            If sprites(a)(_hasWeapons) = __true Then
                                'If it had a weapon, that means it was an enemy and not just an asteroid.  This will
                                'count toward the player's destroy count, which determines level ups.
                                spritesDestroyed = spritesDestroyed + 1
                            End If
                            '**************************************************************************
                            '*	KEY TOPIC:
                            '*	Sub routines differ from Functions
                            '*	
                            '*	Remember back when we talked about the difference between a Function 
                            '*	and a Sub?  Hint, you can't pass arguments to a Sub.  Well this is how I 
                            '*	get around that limitation.  In this case I have a variable spriteRemoveIndex
                            '*	that will store the index position of the sprite we wish to remove.  This variable
                            '*   is then used in the removeSprite() sub to remove the specified sprite.
                            '**************************************************************************
                            spriteRemoveIndex = a
                            removeSprite()

                        Else
                            'Sprite was hit but not destroyed
                            If sprites(a)(_hasWeapons) = 0 Then
                                'Non enemy sprites (asteroids) will shrink with each hit.
                                sprites(a)(_width) = sprites(a)(_width) * 0.75
                                sprites(a)(_height) = sprites(a)(_height) * 0.75
                                scale = sprites(a)(_width) * .01
                                Shapes.Zoom(sprites(a)(_shape), scale, scale)
                            End If
                            curPoints = sprites(a)(_maxSpritePoints) / sprites(a)(_totalHits)
                            spriteLeft = Shapes.GetLeft(sprites(a)(_shape))
                            spriteTop = Shapes.GetTop(sprites(a)(_shape))
                            spriteRight = spriteLeft + sprites(a)(_width)
                            spriteSize = sprites(a)(_width)
                            spriteBottom = spriteTop + spriteSize
                            'change direction of the sprite's flight path.  This makes it a little more realistic.
                            If sprites(a)(_direction) = CType("left", Primitive) Then
                                sprites(a)(_direction) = "right"
                            Else
                                sprites(a)(_direction) = "left"
                            End If
                        End If

                        updateScore()
                        a = Microsoft.SmallBasic.Library.Array.GetItemCount(sprites) + 100

                    End If
                End If

            Next
            'Did our ship collide with an sprite or enemy?
            If alive = __true Then
                spriteLeft = Shapes.GetLeft(sprites(a)(_shape))
                spriteTop = Shapes.GetTop(sprites(a)(_shape))
                spriteRight = spriteLeft + sprites(a)(_width)
                spriteBottom = spriteTop + sprites(a)(_height)
                If (spriteBottom >= curY) And (spriteTop <= shipBottom) Then
                    If (spriteLeft >= shipLeft) AND (spriteLeft <= shipRight) Then
                        'we got hit
                        removeLife()
                        spriteRemoveIndex = a
                        removeSprite()
                        'force exiting out of the loops
                        a = 100000
                        b = 100000
                    End If
                End If
            End If
        Next
        'Did we get shot?
        For e = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBullets)

            If ((shapes.GetTop(enemyBullets(e)(1)) + 9) >= curY) And (Shapes.GetTop(enemyBullets(e)(1)) <= shipBottom) Then
                If (shipLeft <= Shapes.GetLeft(enemyBullets(e)(1))) AND (shipRight >= Shapes.GetLeft(enemyBullets(e)(1))) Then

                    'we got hit
                    removeLife()
                    enemyShotRemoveIndex = e
                    RemoveEnemyShot()
                    'force exiting out of the loop
                    e = 100000
                End If
            End If
        Next

    End Sub
    Sub addSprites()
        'This sub is in charge of adding sprites to the screen.  This happens when the game starts,
        'as well as when sprites are either destroyed or fly off the screen.  We always try to keep
        'a set amount (depending on the level) of sprites on the screen to keep it challenging for 
        'our player.
        curLevelMaxSprites = levels(level)(_maxSprites)
        '**************************************************************************
        '*	KEY TOPIC:
        '*	Debugging
        '*
        '*  Debugging is something that every progammer needs to be able to do.
        '*  When a program doesn't quite act the way you expect, or an error is raised
        '*  you need to be able to look behind the scenes to see what is going wrong. In
        '*  most modern languages you can actually pause the execution of the program
        '*  and see what values are in each variable, and where the current line of
        '*  execution is.  Unfortunately SmallBasic doesn't yet have that (though they
        '*  are planning to add it).  So for the meantime, when you need to peek under
        '*  the hood while a program is running you need to somehow write it to the 
        '*  screen.  The below commented out code, if uncommented would open a 
        '*  text window (like a DOS window) and write the values of the spritesOnScreen
        '*  and curLevelMaxSprites variables each time the addSprites Sub is called.
        '*  I had actually used this to see why I wasn't seeing the correct number of
        '*  sprites on the screen, which I fixed but left the debugging example here.
        '**************************************************************************
        'TextWindow.WriteLine("sprites on screen: " + spritesOnScreen + " max sprites: " + curLevelMaxSprites)
        '**************************************************************************

        check_count = 0
        While spritesOnScreen < curLevelMaxSprites
            check_count = check_count + 1
            If check_count > curLevelMaxSprites Then
                spriteOnScreen = curLevelMaxSprites
            End If

            'add as many sprites as neccessary to fulfill the maxSprites for this level
            For addingSpriteIndex = curLevelMaxSprites - spritesOnScreen To curLevelMaxSprites

                protected_sprite = Microsoft.SmallBasic.Library.Array.GetItemCount(sprites) + 1
                sprites(protected_sprite)(_size) = Microsoft.SmallBasic.Library.Math.GetRandomNumber(20) ' size
                If sprites(protected_sprite)(_size) < 5 Then
                    sprites(protected_sprite)(_size) = 5 ' size
                End If
                sprites(protected_sprite)(_size) = sprites(protected_sprite)(_size) / 10

                sprites(protected_sprite)(_startpos) = Microsoft.SmallBasic.Library.Math.GetRandomNumber(windowWidth + 100) 'X
                speedX = Microsoft.SmallBasic.Library.Math.GetRandomNumber(levels(level)(_maxSpriteSpeed))
                speedY = Microsoft.SmallBasic.Library.Math.GetRandomNumber(levels(level)(_maxSpriteSpeed))

                'Quick random logic to determine if the sprite is an object or a enemy (enemy has weapons, objects don't)
                sprites(protected_sprite)(_hasWeapons) = Microsoft.SmallBasic.Library.Math.Remainder(Microsoft.SmallBasic.Library.Math.GetRandomNumber(2), 2)
                If sprites(protected_sprite)(_hasWeapons) = 0 Then
                    tmpSpriteImage = ImageList.LoadImage(spriteImage(Microsoft.SmallBasic.Library.Math.GetRandomNumber(Microsoft.SmallBasic.Library.Array.GetItemCount(spriteImage)))) 'Image
                Else
                    tmpSpriteImage = ImageList.LoadImage(enemyImage(Microsoft.SmallBasic.Library.Math.GetRandomNumber(Microsoft.SmallBasic.Library.Array.GetItemCount(enemyImage)))) 'Image
                    speedX = speedX * 1.5
                    speedY = speedY * 1.5
                End If

                If speedX < levels(level)(_minSpriteSpeed) Then
                    speedX = levels(level)(_minSpriteSpeed)
                End If

                If speedY < levels(level)(_minSpriteSpeed) Then
                    speedY = levels(level)(_minSpriteSpeed)
                End If

                If speedX = 0 Then
                    speedX = levels(level)(_maxSpriteSpeed) * .5
                End If

                If speedY = 0 Then
                    speedY = levels(level)(_maxSpriteSpeed) * .5
                End If
                'Setup the direction and speed for this Sprite
                If sprites(protected_sprite)(_startpos) > centerX Then
                    'came from the right, move toward the left        
                    sprites(protected_sprite)(_x) = speedX
                    sprites(protected_sprite)(_direction) = "left"
                Else
                    'came from the left, move toward the right
                    sprites(protected_sprite)(_x) = speedX
                    sprites(protected_sprite)(_direction) = "right"
                End If
                sprites(protected_sprite)(_y) = -speedY

                'Add the sprite image to the sprites array
                sprites(protected_sprite)(_shape) = Shapes.AddImage(tmpSpriteImage)
                'Grab the exact width and height of the sprite
                sprites(protected_sprite)(_width) = ImageList.GetWidthOfImage(tmpSpriteImage)
                sprites(protected_sprite)(_height) = ImageList.GetHeightOfImage(tmpSpriteImage)

                If sprites(protected_sprite)(_hasWeapons) = __false Then
                    Shapes.Zoom(sprites(protected_sprite)(_shape), sprites(protected_sprite)(_size), sprites(protected_sprite)(_size))
                    'Grab the exact width and height of the sprite
                    sprites(protected_sprite)(_width) = sprites(protected_sprite)(_size) * sprites(protected_sprite)(_width)
                    sprites(protected_sprite)(_height) = sprites(protected_sprite)(_size) * sprites(protected_sprite)(_height)
                End If

                sprites(protected_sprite)(_speed) = speedX
                sprites(protected_sprite)(_isVisible) = 1
                sprites(protected_sprite)(_shots) = 0 ' Keeps running total of shots fired by this enemy
                sprites(protected_sprite)(_shotTicker) = 1
                'Enemy sprites hits depends on level
                If sprites(protected_sprite)(_hasWeapons) = __true Then
                    sprites(protected_sprite)(_hits) = Microsoft.SmallBasic.Library.Math.GetRandomNumber(levels(level)(_maxHits)) 'This will decrease each time it is hit, once zero the sprite will explode
                    sprites(protected_sprite)(_bulletColor) = enemyBulletColors(Microsoft.SmallBasic.Library.Math.GetRandomNumber(Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBulletColors))) ' Each sprite can have its own bullet color
                    'Asteroid sprites have different hits based on zoom size
                Else
                    sprites(protected_sprite)(_hits) = Microsoft.SmallBasic.Library.Math.Ceiling(sprites(protected_sprite)(_size) * 1.5) 'This will decrease each time it is hit, once zero the asteroid will explode
                End If

                sprites(protected_sprite)(_totalHits) = sprites(protected_sprite)(_hits) 'This will remember how many hits it took for score calculations
                sprites(protected_sprite)(_maxSpritePoints) = Microsoft.SmallBasic.Library.Math.GetRandomNumber(levels(level)(_pointWorth))
                'Move the sprite to it's initial position
                Shapes.Move(sprites(protected_sprite)(_shape), sprites(protected_sprite)(_startpos), -200)
                'Update the count of Sprites on the screen
                spritesOnScreen = Microsoft.SmallBasic.Library.Array.GetItemCount(sprites)
                curSprite = protected_sprite


            Next


        End While


    End Sub
    Sub isSpriteVisible()
        'This determines if the sprite is still visible.
        If (sprites(curSprite)(_direction) = CType("left", Primitive)) AND (Shapes.GetLeft(sprites(curSprite)(_shape)) <= -sprites(curSprite)(_width)) Then
            sprites(curSprite)(_isVisible) = __false
        ElseIf (sprites(curSprite)(_direction) = CType("right", Primitive)) AND (Shapes.GetLeft(sprites(curSprite)(_shape)) > (windowWidth + sprites(curSprite)(_width))) Then
            sprites(curSprite)(_isVisible) = __true
        End If

        If Shapes.GetTop(sprites(curSprite)(_shape)) > windowHeight Then
            sprites(curSprite)(_isVisible) = __false

        End If
        '**************************************************************************
        '*	KEY TOPIC:
        '*	Debugging
        '*  Another debugging example.  In this case, I was trying to find out when the
        '*  sprites were being removed from the screen.
        '*
        'If sprites[curSprite][_isVisible] = false Then 
        '  GraphicsWindow.ShowMessage("sprite " + curSprite + "moving: " + sprites[curSprite][_direction] +" is not visible. X:" + Shapes.GetLeft(sprites[curSprite][_shape]) + " Y:" + Shapes.GetTop(sprites[curSprite][_shape]) + " VS window width:" + windowWidth + " height:" + windowHeight ,"test")
        'EndIf 
        '**************************************************************************

    End Sub
    Sub removeAllSprites()
        'Convenience Sub to remove all active sprites
        For spriteRemoveIndex = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(sprites)
            removeSprite()
            spritesOnScreen = 0
        Next
    End Sub
    Sub removeSprite()
        'Removes a single sprite from the screen

        ' Remove graphic 
        Shapes.Remove(sprites(spriteRemoveIndex)(_shape))

        ' Pack down the arrays to have a continuous index (don't leave holes)
        For remove_i = spriteRemoveIndex To Microsoft.SmallBasic.Library.Array.GetItemCount(sprites) - 1
            sprites(remove_i) = sprites(remove_i + 1)
        Next

        ' Remove item at end of list, it's either the one requested or a duplicate from packing above
        sprites(Microsoft.SmallBasic.Library.Array.GetItemCount(sprites)) = ""

        spritesOnScreen = Microsoft.SmallBasic.Library.Array.GetItemCount(sprites) 'spritesOnScreen - 1


    End Sub
    Sub updateScore()
        'Update the score and refresh the score board

        score = Microsoft.SmallBasic.Library.Math.Floor(score + curPoints)
        If spritesDestroyed >= levels(level)(_spritesToLevelUp) Then
            levelUp()
            GraphicsWindow.BackgroundColor = "black"
        End If
        'Add a new life everytime the player earns 10000 points
        pointsForOneUp = pointsForOneUp + curPoints
        If pointsForOneUp >= 10000 Then
            oneUp()
            pointsForOneUp = 0
        End If
        updateScoreBoard()
    End Sub
    Sub oneUp()
        'Give player an extra life
        lives = lives + 1
        Sound.Stop(audioPath + "oneup.wav")
        Sound.Play(audioPath + "oneup.wav")
        'GraphicsWindow.ShowMessage("One Up!!!","One up!")

    End Sub
    Sub drawPanel()
        'Draws the panel for the score board
        GraphicsWindow.DrawResizedImage(menuBg, 1, 1, 440, 100)
        GraphicsWindow.DrawRectangle(1, 1, 440, 100)
    End Sub
    Sub updateScoreBoard()
        GraphicsWindow.PenColor = "white"
        GraphicsWindow.FontName = "COMIC SANS MS"
        GraphicsWindow.FontSize = 25
        drawPanel()

        GraphicsWindow.BrushColor = "white"
        GraphicsWindow.DrawText(10, 1, "Score: " + score)
        GraphicsWindow.DrawText(205, 1, "Level: " + level)
        GraphicsWindow.DrawText(10, 30, "Lives: " + lives)
        GraphicsWindow.DrawText(165, 30, "Destroyed: " + spritesDestroyed)
        '**************************************************************************
        '*	KEY TOPIC:
        '*	Debugging
        '*  Just another debugging example.  This one will draw the values in the score board
        '*  so is quite convenient.  Try uncommenting this and watch the values in the score
        '*  board.  The reason I had this here was so that I can make sure the program was
        '*  only allowing the set number of bullets on the screen, and to see where the ship
        '*  was to help determine the collision calculations.
        'GraphicsWindow.DrawText(5,50,"shipLeft: " + shipLeft + " shipRight: " + shipRight)
        'GraphicsWindow.DrawText(5,70,"bullets: " + bulletCount)
        '**************************************************************************
    End Sub
    Sub removeLife()
        'Removes a life from the player.  If it was the last life, trigger the game over.
        GraphicsWindow.BackgroundColor = "DimGray"
        explosionX = curX
        explosionY = curY
        explosionSize = 4
        exploding = __true
        Shapes.Move(ship, centerX, windowHeight + 100)
        Explode()
        Program.Delay(1000)
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
        'If we've spent all of our lives, end the game
        If lives < 0 Then
            gameOver()
        End If

    End Sub
    Sub levelUp()
        'Advance player to the next level.  If there is no next level, trigger the youWin sub.
        'First we'll change the background music (if any exist for this level)
        Sound.Stop(levels(level)(_BGMusic))
        'Then we'll clear the screen and begin the warp scene.
        GraphicsWindow.Clear()
        AddHandler GraphicsWindow.KeyDown, AddressOf doNothing
        'The onKeyUp Sub will fire when the user releases the key.
        'This is also defined later
        AddHandler GraphicsWindow.KeyUp, AddressOf doNothing
        removeAllEnemyShots()
        'Clear astroids off of screen
        removeAllSprites()
        'Clear all shots off the screen
        removeAllShots()

        'Reset the playing field to the next level.
        alive = __true
        curX = centerX
        curY = windowHeight - shipHeight
        GraphicsWindow.Clear()
        GraphicsWindow.DrawResizedImage(warpbg, 1, 1, windowWidth, windowHeight)
        bullets = ""
        bulletCount = 0
        GraphicsWindow.FontSize = 30
        GraphicsWindow.DrawResizedImage(menuBg, centerX - 250, centerY - 100, 500, 200)
        GraphicsWindow.DrawRectangle(centerX - 250, centerY - 100, 500, 200)
        GraphicsWindow.BrushColor = "white"
        GraphicsWindow.PenColor = "white"
        GraphicsWindow.DrawText(centerX - 150, centerY - 100, "LEVEL " + level + " COMPLETE!")
        GraphicsWindow.FontSize = 20
        GraphicsWindow.DrawText(centerX - 150, centerY - 50, "Score: " + score)
        GraphicsWindow.DrawText(centerX - 150, centerY, "Enemies Destroyed: " + spritesDestroyed)
        'Reset destroyed astroid count
        spritesDestroyed = 0
        Program.Delay(1000)
        score = score + levels(level)(_completePoints)
        level = level + 1

        'warp speed to next level
        warp()
        GraphicsWindow.Clear()
        initShip()
        initBackGround()
        initWeapons()
        initExplosion()
        initSprites()
        Sound.Play(levels(level)(_BGMusic))
        bulletCount = 0
        bullets = ""

        AddHandler GraphicsWindow.KeyDown, AddressOf onKeyDown
        'The onKeyUp Sub will fire when the user releases the key.
        'This is also defined later
        AddHandler GraphicsWindow.KeyUp, AddressOf onKeyUp

        If level >= maxLevels Then
            GraphicsWindow.Clear()
            GraphicsWindow.BackgroundColor = "MidnightBlue"
            youWin()
        End If

    End Sub
    Sub warp()
        'Play cool warp sound
        Sound.Play(audioPath + "warp.mp3")
        'Create and display our random star field
        initStars()
        For s = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(stars)
            Shapes.Rotate(warpbg, s * 5)
            Shapes.Zoom(stars(s), 5, 5)
            Shapes.Move(stars(s), centerX, centerY)
            newY = Microsoft.SmallBasic.Library.Math.GetRandomNumber(windowHeight * 2)
            newX = Microsoft.SmallBasic.Library.Math.GetRandomNumber(windowWidth * 2)
            GraphicsWindow.PenColor = "white"
            Shapes.Animate(stars(s), newX, newY, 500)
            Shapes.Zoom(stars(s), 0, 0)
            If s = 100 Then
                s = Microsoft.SmallBasic.Library.Array.GetItemCount(stars) + 1
            End If
        Next
        Sound.PlayAndWait(audioPath + "warp.mp3")
        Program.Delay(300)
        bulletCount = 0
        bullets = ""
    End Sub
    Sub gameOver()
        'Display game over message and restart game.
        play = __true
        pause = __false
        alive = __false
        gameEnd = __true
        GraphicsWindow.Clear()
        GraphicsWindow.FontBold = 1
        GraphicsWindow.BrushColor = "DimGray"
        GraphicsWindow.FontSize = 120
        GraphicsWindow.DrawResizedImage(gameOverBg, 0, 0, windowWidth, windowHeight)
        GraphicsWindow.DrawText(centerX - 350, 1, "GAME OVER")

        'Restart game
        RestartGame()

    End Sub
    Sub youWin()
        'Display you win scene and restart game
        removeAllSprites()
        play = __true
        pause = __true
        gameEnd = __true
        alive = __false
        GraphicsWindow.Clear()
        GraphicsWindow.FontBold = 1
        GraphicsWindow.FontSize = 120
        GraphicsWindow.BrushColor = "white"
        GraphicsWindow.DrawText(centerX - 350, 10, "YOU WIN!")

        'Restart game
        RestartGame()

    End Sub
    Sub doKeys()
        'This will handle the player's key press events.
        EastWest = ""
        NorthSouth = ""
        If (rightKeyPressed = __true) And (leftKeyPressed = __true) Then
            ' Figure out which direction based on last pressed or released
            If leftRightPriority = rightKey Then
                curX = curX + 20
                EastWest = "east"
            Else
                curX = curX - 20
                EastWest = "west"
            End If
        Else
            If rightKeyPressed = __true Then
                curX = curX + 20
                EastWest = "east"
            ElseIf leftKeyPressed = __true Then
                curX = curX - 20
                EastWest = "west"
            End If
        End If

        If (curX + shipWidth) > windowWidth Then
            curX = windowWidth - shipWidth
        End If

        If curX <= 0 Then
            curX = 0 'shipWidth
        End If

        If upKeyPressed = __true Then
            curY = curY - 20
            NorthSouth = "north"
        End If

        If downKeyPressed = __true Then
            curY = curY + 20
            NorthSouth = "south"
        End If

        If curY > (windowHeight - shipHeight) Then
            curY = windowHeight - shipHeight
        ElseIf curY < 0 Then
            curY = 0
        End If
        shipTop = curY - shipHeight
        shipBottom = curY

    End Sub
    Sub changeWeapon()
        'Kind of a underdeveloped and hidden feature, but this will
        'change the players wepon from a tiny fireball to a huge one.
        'The huge one kills just about anything in one hit.  This would
        'be a great feature to enhance so that on certain levels new
        'weapons could be unlocked, which would have varying properties
        'such as how many bullets on the screen, hit strength, number
        'of bullets that it can fire before switching back to the default
        'weapon, etc...  
        If bulletColor = CType("red", Primitive) Then
            possibleBulletsOnScreen = 10
            bulletColor = "purple"
            bulletSpeed = 20
            bulletWidth = 60
            bulletHeight = 40
            bulletShape = "circle"
            bulletStrength = 5
            bulletCount = 0
        Else
            possibleBulletsOnScreen = 2
            bulletColor = "red"
            bulletSpeed = 10
            bulletWidth = 5
            bulletHeight = 10
            bulletShape = "rectangle"
            bulletStrength = 1
        End If
    End Sub
    Sub shoot()
        'Fire a shot
        bulletCount = Microsoft.SmallBasic.Library.Array.GetItemCount(bullets) + 1

        If (bulletCount <= possibleBulletsOnScreen) And (alive = __true) And (gameEnd = __false) Then
            If bulletShape = CType("circle", Primitive) Then
                Sound.Stop(audioPath + "fireball.mp3")
                Sound.Play(audioPath + "fireball.mp3")

                bullets(bulletCount) = Shapes.AddImage(fireBallImage)
                bulletWidth = ImageList.GetWidthOfImage(fireBallImage)
                bulletHeight = ImageList.GetheightOfImage(fireBallImage)

            Else
                Sound.Stop(audioPath + "photon-blaster.mp3")
                Sound.Play(audioPath + "photon-blaster.mp3")
                If bulletCount > possibleBulletsOnScreen Then
                    bulletCount = Microsoft.SmallBasic.Library.Array.GetItemCount(bullets)
                End If
                bullets(bulletCount) = Shapes.AddImage(blueFireBallSmallImage)
                bulletWidth = ImageList.GetWidthOfImage(blueFireBallSmallImage)
                bulletHeight = ImageList.GetheightOfImage(blueFireBallSmallImage)

            End If

            'Not so pretty hack to overcome issues where the bullet "sticks" on the screen
            'this will remove any shot that has been on the screen for over 1000 milliseconds
            Timer.Interval = 1000
            AddHandler Timer.Tick, AddressOf RemoveShot

            'Move the bullet
            Shapes.Move(bullets(bulletCount), curX, curY - (shipHeight + (bulletHeight / 2)))
        End If
    End Sub
    Sub enemyShoot()
        'Each enemy ship has it's own random bullet color
        GraphicsWindow.PenColor = sprites(curSprite)(_bulletColor)

        enemyBullets(Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBullets) + 1)(1) = Shapes.AddRectangle(5, 9)
        enemyBullets(Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBullets))(2) = curSprite ' used for tracking
        sprites(curSprite)(_shots) = sprites(curSprite)(_shots) + 1
        Shapes.Move(enemyBullets(Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBullets))(1), Shapes.GetLeft(sprites(curSprite)(_shape)) + (sprites(curSprite)(_width) / 2), Shapes.GetTop(sprites(curSprite)(_shape)) + sprites(curSprite)(_height))
    End Sub
    Sub removeAllShots()
        'Convenience Sub to remove all shots from the screen
        tmpBulletCount = Microsoft.SmallBasic.Library.Array.GetItemCount(bullets)

        While tmpBulletCount > 0
            shotRemoveIndex = tmpBulletCount
            RemoveShot()
            tmpBulletCount = Microsoft.SmallBasic.Library.Array.GetItemCount(bullets)
        End While

        bullets = ""

    End Sub
    Sub RemoveShot()
        'Remove a single shot from the screen.
        ' Remove graphic shot
        Shapes.Remove(bullets(shotRemoveIndex))

        ' Pack down the arrays to have a continuous index (don't leave holes)
        For i = shotRemoveIndex To Microsoft.SmallBasic.Library.Array.GetItemCount(bullets) - 1
            bullets(i) = bullets(i + 1)
        Next

        ' Remove item at end of list, it's either the one requested or a duplicate from packing above
        bullets(Microsoft.SmallBasic.Library.Array.GetItemCount(bullets)) = ""

    End Sub
    Sub removeAllEnemyShots()
        'Convenience function to remove all enemy shots from the screen.
        tmpBulletCount = Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBullets)
        For enemyShotRemoveIndex = 1 To tmpBulletCount

            RemoveEnemyShot()

        Next

        enemyBullets = ""

    End Sub
    Sub RemoveEnemyShot()
        ' Remove enemy shot
        Shapes.Remove(enemyBullets(enemyShotRemoveIndex)(1))
        sprites(enemyBullets(enemyShotRemoveIndex)(2))(_shots) = sprites(enemyBullets(enemyShotRemoveIndex)(2))(_shots) - 1
        ' Pack down the arrays to have a continuous index (don't leave holes)
        For i = enemyShotRemoveIndex To Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBullets) - 1
            enemyBullets(i) = enemyBullets(i + 1)
        Next

        ' Remove item at end of list, it's either the one requested or a duplicate from packing above
        enemyBullets(Microsoft.SmallBasic.Library.Array.GetItemCount(enemyBullets)) = ""

    End Sub
    Sub CalibrateDelay()
        ' Figure out dummy wait loops per millisecond
        ' Used instead of Program.Delay()'s coarse resolution of 16 ms
        tLast = Clock.Millisecond
        For ci = 1 To 20000
            ci = ci
        Next
        tNow = Clock.Millisecond
        dT = tNow - tLast
        If dT < 0 Then
            dT = dT + 1000
        End If
        loopsPerMilliSec = 20000 / dT
    End Sub
    Sub OnKeyDown()

        If GraphicsWindow.LastKey = rightKey Then
            rightKeyPressed = __true

            ' If both left & right pressed, this has higher priority since pressed last
            leftRightPriority = rightKey
        End If

        If GraphicsWindow.LastKey = leftKey Then
            leftKeyPressed = __true
            leftRightPriority = leftKey
        End If

        If GraphicsWindow.LastKey = upKey Then
            upKeyPressed = __true
            upDownPriority = upKey
        End If

        If GraphicsWindow.LastKey = downKey Then
            downKeyPressed = __true
            upDownPriority = downKey
        End If

        If GraphicsWindow.LastKey = fireKey Then
            fireKeyPressed = __true
        End If

        If GraphicsWindow.LastKey = pauseKey Then
            If pause = __true Then
                pause = __false
            Else
                pause = __true
            End If
        ElseIf GraphicsWindow.LastKey = quitKey Then
            play = __false
        End If

        If GraphicsWindow.LastKey = hyperspaceKey Then
            hyperspaceKeyPressed = __true
        End If

        If GraphicsWindow.LastKey = changeWeaponKey Then
            changeWeaponKeyPressed = __true
        End If

        ' Save letters for high score input
        highScoreLetter = GraphicsWindow.LastKey

    End Sub
    Sub OnKeyUp()

        If GraphicsWindow.LastKey = rightKey Then
            rightKeyPressed = __false
        End If

        If GraphicsWindow.LastKey = leftKey Then
            leftKeyPressed = __false
        End If

        If GraphicsWindow.LastKey = upKey Then
            upKeyPressed = __false
        End If

        If GraphicsWindow.LastKey = downKey Then
            downKeyPressed = __false
        End If

        If GraphicsWindow.LastKey = fireKey Then
            ' Only allow one shot per key press
            shoot()
            fireKeyPressed = __false
        End If

        If GraphicsWindow.LastKey = hyperspaceKey Then
            hyperspaceKeyPressed = __false
        End If

        If GraphicsWindow.LastKey = changeWeaponKey Then
            changeWeapon()
            changeWeaponKeyPressed = __false
        End If

    End Sub
    Sub Explode()

        ' Animate exploding stuff (only 1 thing can explode at a time)
        If exploding = __true Then
            ' Move along with ground
            explosionX = explosionX
            explosionSpread = explosionSpread + 4
            explosionAlpha = explosionAlpha - 10
            offset = explosionSize
            If explosionSpread > 40 Then
                exploding = __false
                explosionSpread = 0

                ' Move parts off screen
                Shapes.Move(explosion(offset + 1), 0, -50)
                Shapes.Move(explosion(offset + 2), 0, -50)
                Shapes.Move(explosion(offset + 3), 0, -50)
                Shapes.Move(explosion(offset + 4), 0, -50)
                explosionAlpha = 110
            Else

                ' Move all pieces of explosion in four directions
                Shapes.Move(explosion(offset + 1), explosionX + explosionSpread, explosionY + explosionSpread)
                Shapes.Move(explosion(offset + 2), explosionX + explosionSpread, explosionY - explosionSpread)
                Shapes.Move(explosion(offset + 3), explosionX - explosionSpread, explosionY + explosionSpread)
                Shapes.Move(explosion(offset + 4), explosionX - explosionSpread, explosionY - explosionSpread)

            End If
            'fade explosion
            For i = 1 To 4
                Shapes.SetOpacity(explosion(offset + i), explosionAlpha)
            Next
        End If

    End Sub
    Sub GetHighScores()

        ' Read in 5 scores, name then below it is score
        For z = 1 To 5
            highScoreName(z) = File.ReadLine(Program.Directory + "\scores.txt", (z * 2) - 1)
            highScoreValue(z) = File.ReadLine(Program.Directory + "\scores.txt", z * 2)
        Next

    End Sub
    Sub ShowHighScores()

        ' Look through all scores and see if player beat one, starting with highest score
        For i = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(highScoreName)
            If score > highScoreValue(i) Then
                ' We beat a score, play tune
                Sound.Stop(audioPath + "scores.mp3")
                Sound.Play(audioPath + "scores.mp3")

                ' Shift all scores down 1 slot
                For j = Microsoft.SmallBasic.Library.Array.GetItemCount(highScoreName) - 1 To i Step -1
                    highScoreName(j + 1) = highScoreName(j)
                    highScoreValue(j + 1) = highScoreValue(j)
                Next

                ' Get players name
                GraphicsWindow.BrushColor = "DimGray"
                GraphicsWindow.FontName = "courier"
                GraphicsWindow.FontSize = 40
                GraphicsWindow.DrawText(centerX - 150, 140, "YOU MADE THE TOP 5!")
                GraphicsWindow.FontSize = 30
                GraphicsWindow.DrawText(centerX - 150, 180, "ENTER INITIALS: ")

                k = 0 ' no letters entered yet
                temp2 = ""
                While k < 3
                    ' Only allow typical characters (may need tweak for other languages)
                    ' Get copy of entered key in uppercase, changes in event handler
                    temp = Text.ConvertToUpperCase(highScoreLetter)

                    If (Text.GetLength(temp) = 1) And (Text.GetCharacterCode(temp) >= 64) And (Text.GetCharacterCode(temp) <= 95) Then
                        ' Show letter entered
                        GraphicsWindow.BrushColor = "DimGray"
                        GraphicsWindow.FontName = "courier"
                        GraphicsWindow.FontSize = 30
                        GraphicsWindow.DrawText(centerX - (100 * (1.5 - k)), 200, temp)

                        ' Build name string
                        temp2 = Text.Append(temp2, temp)

                        k = k + 1

                        Program.Delay(200)
                        highScoreLetter = ""

                    End If

                End While

                Sound.Stop(audioPath + "score_entered.mp3")
                Sound.Play(audioPath + "score_entered.mp3")

                Program.Delay(2000)

                ' Save name/score to array
                highScoreName(i) = temp2
                highScoreValue(i) = score

                ' Save score to file.  Write 5 scores, name then below it is the score
                For z = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(highScoreName)
                    File.WriteLine(Program.Directory + "\scores.txt", (z * 2) - 1, highScoreName(z))
                    File.WriteLine(Program.Directory + "\scores.txt", z * 2, highScoreValue(z))
                Next

                ' exit for 
                i = 100
            End If
        Next

        ' Clear drawn graphics
        GraphicsWindow.PenColor = "black"
        GraphicsWindow.BrushColor = "black"

        ' Display list of scores
        GraphicsWindow.FontName = "courier"
        GraphicsWindow.FontSize = 30
        GraphicsWindow.BrushColor = "DimGray"
        GraphicsWindow.DrawText(centerX - 100, centerY + 50, "HIGH SCORES")

        GraphicsWindow.BrushColor = "FireBrick"

        ' If no list of high scores, probably had file error reading them in, or file I/O remarked out
        If Microsoft.SmallBasic.Library.Array.GetItemCount(highScoreName) = 0 Then
            GraphicsWindow.FontSize = 10
            GraphicsWindow.DrawText((windowWidth / 2) - (10 * 25), windowHeight / 4, "Error Reading High Scores, Ensure 'File.' Uncommented In Source Code!")
        Else
            highScoreLetter = ""

            ' Create sinewave of color intensity to give score reflection look,
            ' and wait for player to press key to start another game
            GraphicsWindow.DrawText(centerX - 200, windowHeight - 50, "PRESS ANY KEY TO START")
            i = 6.28 ' 2 * pi
            While highScoreLetter = CType("", Primitive)
                i = i - 0.15
                If i < 0 Then
                    i = 6.28
                End If

                For j = 1 To Microsoft.SmallBasic.Library.Array.GetItemCount(highScoreName)
                    ' Each name in score has slightly different phase offset to give rolling reflection look
                    k = Microsoft.SmallBasic.Library.Math.Floor(7.5 + (7.4 * Microsoft.SmallBasic.Library.Math.Sin(Microsoft.SmallBasic.Library.Math.Remainder(i + (j * 0.6), 6.28))))
                    temp = Text.Append(Text.GetSubText(hexaDecimal, k, 1), "0")
                    temp2 = Text.Append("#FF", temp)
                    temp2 = Text.Append(temp2, temp)

                    GraphicsWindow.BrushColor = temp2

                    temp = Text.Append(highScoreName(j) + "  -  ", highScoreValue(j))

                    GraphicsWindow.DrawText(centerX - 100, centerY + 50 + (j * 35), temp)
                Next
                Program.Delay(33)

            End While
            startGame()
        End If


    End Sub
    Sub startGame()
        'Start the game play (when user pressed any key to continue)
        level = 1
        alive = __true
        gameEnd = __false
        Sound.Stop(audioPath + "introduction.mp3")
        Sound.Play(levels(level)(_BGMusic))
    End Sub
    Sub RestartGame()
        ' Restart entire game 
        Sound.Stop(levels(level)(_BGMusic))
        level = 1
        ' Get name if high score, show scoreboard
        ShowHighScores()
        Program.Delay(1000)
        initBackground()
        initShip()
        initGame()
    End Sub
    Sub doNothing()
        'Used to temporarily disable keystrokes
    End Sub
End Module
