# Dictionary-Serialization-inside-Unity
Unity Serializes fields only and types like Dictionary are not supported . In this repo , I will provide a hack to do to overcome this problem .  
To overcome the problem of dictionary serialization inside unity: you can create a struct whose fields are the dictionary keys, you wished your nested dictionary has . Just keep one of these fields is unique . Make a list of this struct and with some work , you can store it in a json format . You can later load them in dictionary format using the unique field.
