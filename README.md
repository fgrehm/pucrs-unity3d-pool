# Unity 3D Pool

A very basic [Straight Pool](http://en.wikipedia.org/wiki/Straight_pool)
[Unity 3D](http://unity3d.com/) game built for the PUCRS Computer Graphics 2015.1
course.

Tested on Ubuntu 14.04, using Unity 4.6.2f1 and Wine 1.7.38.

## Known issues

Every now and then, on Ubuntu, usually after modifying a script, you might need
to `Assets -> Reimport all` if you get a compilation errors.

## Resources

- [Very good introductory tutorial on basic Unity concepts](http://unity3d.com/learn/tutorials/projects/roll-a-ball)
- [Setting up Unity on Ubuntu 14.04](http://wiki.unity3d.com/index.php/Running_Unity_on_Linux_through_Wine)
- [Fixing grayed out Unity dashboard on Ubuntu](http://wiki.unity3d.com/index.php/Running_Unity_on_Linux_through_Wine#Unity_dashboard_is_all_grayed_out)
- [Using Git with Unity 3D](http://stackoverflow.com/a/18225479)
- [Introduction to projectors](https://www.youtube.com/watch?v=44Nad3QwuoA)

## TODO

- [x] Strike balls using a cue and fixed force
- [x] Add bounce to balls
- [x] Aim ball strike with and arrow keys and shoot with Ctrl
- [x] Prevent balls from bouncing off the table
- [ ] Strike balls with dynamic force
- [ ] Pocket a ball
- [ ] Handle white ball on pocket
- [ ] 2 players
- [ ] Count score per player
- [x] Textures with ball numbers
- [ ] Ambient (ex: a bar, 2 lights at the top...)
- [ ] Sound of balls colliding
- [ ] Increase size of table (?)
- [ ] Aux camera with top view of the table
- [ ] Document basic architecture / interaction between game objects
- [ ] Document how to build
- [x] Tweak bounciness and friction

## Credits

- Table cloth texture from http://opengameart.org/content/pool-table-3d-model
- Balls textures from http://opengameart.org/content/billiard-balls
