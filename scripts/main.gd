extends Node

@export var mob_scene : PackedScene
var score

func _ready():
	pass


func _process(delta):
	pass


func game_over():
	$ScoreTimer.stop()
	$MobTimer.stop()


func new_game():
	score = 0
	$Player.start($StartPosition.position)
	$StartTimer.start()