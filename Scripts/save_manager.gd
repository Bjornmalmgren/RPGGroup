extends Node

var save_path = "user://player_progress.save"

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func save():
	var file = FileAccess.open(save_path, FileAccess.WRITE)
	# ---store data----
	# player stats (health ect.)
	# player current position
	file.store_var(get_tree().get_nodes_in_group("player")[0].position)
	# current map scene (NEEDS FUTHER WORK ON SCENE MANAGER
	#current quest state (NEEDS FUTHER WORK ON WHERE TO STORE QUEST PROGRESS)

func load_from_save():
	var load_file = FileAccess.open(save_path, FileAccess.READ)
	# ---load data and update variables---
	#player stats(health ect.)
	#player position
	#current map scene
	#current quest state
