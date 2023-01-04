<h1 id="original-idea">Original Idea</h1>
<p>My first idea was to create a VR shooter game, at the beginning it
was going very well as I managed to develop a complete player movement
full with jumping, sprinting, moving up on slopes, crouch and slide.
Then I replaced the basic map I created with pro builder with an
American city I’ve bought some time ago from the unity asset store.</p>
<p>I tried to implement a grappling gun mechanic which worked perfectly
and then a normal gun, after doing this I didn’t quite like, therefore I
wanted to implement arms that would follow your arm, also this was done
pretty quickly, it was quite challenging when it came to shooting and
holding the weapon and matching perfectly with the animations.</p>
<p>Here is also where some problems started to come up, in order to have
a nice animations with a weapon you needed to have inverse kinematic
which was a really big problem for me since my entire player was based
on rigid body.</p>
<p>Since the project was due 1 month I didn’t know if I could manage to
finish it on time, therefore I decided to start working on something
new.</p>
<h1 id="second-idea">Second Idea</h1>
<p>For my second idea game I wanted to develop new skills, I remembered
that some years ago I got a Nintendo 3DS XL, after learning unity I
decided to create a game for it and requested a Nintendo developer, I
took some months but as I got accepted I totally forgot about.</p>
<p>However as second idea I wanted to recreate a game that was made with
the unity engine and the first thing that came in my mind was Among US.
Of course I want recreate the entire game with the 4 maps and the
multiplayer but only a single player version with The Skeld as only
map</p>
<h1 id="assets">Assets</h1>
<p>After looking at how many assets there are there was no way I could
do them by my one so I searched some up on the internet without any
success though.</p>
<p>My only option was to take the Among Us folder with all the files and
extract the assets from thanks to a tool I found some time ago on
GitHub.</p>
<p><a href="https://github.com/AssetRipper/AssetRipper">Here</a> is the
repository link to download the tool.</p>
<h1 id="game-development">Game Development</h1>
<p>Before even starting to develop this game I had to use a scuffed
version of unity 5 which is from 2015 and completely outdated and on top
of that all the assets that I copied from the real among us where from
unity v2021 and as I mentioned before there is now actual way to convert
them, therefore I had to do that manually.</p>
<p>To over complicate everything was the Nintendo 3DS hardware as it has
only 6 MB of VRAM and 256 MB of RAM, for example I had scale down every
sprite with a maximum of 512 pixel and I couldn’t leave parts of the map
active if they are not rendered to the screen as I would get a memory
leak.</p>
<p>Of course just does two things weren’t enough in fact there was
another problem, Nintendo removed the unity support for their old
consoles, this means that I wasn’t a verified developer anymore and
couldn’t test my game without a work around which was jail breaking my
3DS. <a href="https://github.com/d0k3/GodMode9">God mode 9</a> was what
I used in order to do that.</p>
<p>The entire game was create by self except for the AI path finding
where, since I didn’t know how to get started, I followed <a
href="https://www.youtube.com/watch?v=-L-WgKMFuhE&amp;list=PLFt_AvWsXl0cq5Umv3pMC9SPnKjfp9eGW&amp;index=1&amp;t=0s">this</a>
tutorial from Sebastian Lague which helped my out a ton.</p>
<p>I designed the game so that every script could be reusable and not
specific to a single task for example every task will have a script
"GameTask" which will contain the name of the task, how many points you
get when you complete. Also the animations are and the crew mate /
impostor are shared between the player and the AIs.</p>
<p>Creating this scripts was very time consuming at the beginning but I
knew that was necessary if I wanted to build a large game, because when
you start writing and writing so much code you will many files and many
components on your game objects what you actually don’t really want
since your project must be scalable.</p>
<h1 id="game-play">Game play</h1>
<p>The game play is almost identical to the normal game but with less
task and instead of multiplayer you are playing with AI, the game comes
to an end when all the task are completed or you have been killed or you
successfully killed all the players.</p>
<p>I’ll leave here the game play video so that it is more
understandable.</p>
<h1 id="installation">Installation</h1>
<p>In order to test this game you will need to jailbreak your Nintendo
3DS (both the old and the new one are fine as well as the Nintendo 2DS
even if I haven’t test it) then with holding the START + POWER button so
that you enter in the god mode then make sure to have on your SD card
the .cci file that you can install from my GitHub repository <a
href="https://github.com/AlexSteiner30/Among-US-3DS-Edition">here</a>
and navigate to it from clicking on SD card then select the file press A
twice and go to install game image.</p>
<p>After those steps are completed you are ready to go and can play the
best version of Among Us ever made: Among Us Nintendo 3DS Edition.</p>
