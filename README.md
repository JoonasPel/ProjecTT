# ProjecTT
## Summary of the Game

### Features present in initial commit:
- Movement, Cam rotation and movement animations (unity 3rd party player controller)
- Attack:
    Object pooled bullets can be shot to where player is facing.
- Ground loot:
    Objects can be marked as a collectable. Looking towards a collectable highlights it temporarily. Clicking E while looking towards a collectable (not before meaning can't hold E and "sweep" around) "collects"(destroys) it. Collecting triggers collecting animation.
- Resource Manager and Save/Load
    Primitive resource manager to track how much ores or coins player has and manipulate these. Save/Load Manager also implemented to save resource numbers to a file and load them.
- Working Ragdoll character that can be freezed to create some kind of an enemy that freezes (literally) when hit.

