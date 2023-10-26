extends Area2D

@export var speed = 400
var screen_size


func _ready():
	screen_size = get_viewport_rect().size()


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
