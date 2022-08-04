Bow and arrow in VR is one of the most satisfying inputs so far in my opinion. I wanted one to have fun with when debugging other VR projects so I made one. Took inspiration from my favorite bow ive used in VR: RecRoom. Sure its more cartoony but I think their way of using 2 hands for pointing the bow gives better control.

https://user-images.githubusercontent.com/46794418/182766555-5b5ef505-6c55-45b8-adcd-0e5388a8412e.mov

Tried to make the scripts pretty modular so that maybe they could be reused for other purposes.

Still want to make:

-alternate script to make collision have arrow stick to object instead of world.
-Make StretchSound script more straightforward.
-version with sockets so anything can be shot in game.

Notes:

-Uses Unity Editor 2020.3.13f1  
-Uses 2.0.1 XRI Toolkit.
-You also need to add the Starter Assets for the XRI Default Input Actions.
-DemoScene has script that turns off physics interaction between layer 6(arrow),7(bow) so it works in that scene if you import the package into your project.
-Colliders needed on hands to pickup and pull.


Let me know if you have any comments or questions. I had fun with it and think some of the scripts are pretty cool. Hope you do too!
