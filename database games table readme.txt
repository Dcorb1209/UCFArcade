game_name - varchar(255) - The name of the game (Must be unique)
game_creator - int(11) - the ID of the creator
game_creatorname - varchar(255) - the username of the creator
game_description - TEXT - the full description of the game
game_controls - TEXT - the written guide for the controls
game_videolink - TEXT - the link to a video of gameplay
game_genres - varchar(32) - the flags for the genres (flags TBD)
game_status - varchar(1) - the flag for the status currently (a - accepted, p - pending review, r - rejected)
game_onarcade - bit(1) - True/False boolean to determine if it belongs on the arcade machine (0 means it does not belong on the arcade machine. 1 means it does belong on the arcade machine)
game_path - varchar(255) - The file path on s3 to the location of the game zip file
game_image0 - varchar(255) - The file path on s3 to the location of the default display image
game_image1 - varchar(255) - The file path on s3 to the location of the optional slideshow image #1
game_image2 - varchar(255) - The file path on s3 to the location of the optional slideshow image #2
game_image3 - varchar(255) - The file path on s3 to the location of the optional slideshow image #3
game_image4 - varchar(255) - The file path on s3 to the location of the optional slideshow image #4
game_submissiondate - DATETIME - The date and time the game was submitted
game_reviewdate - DATETIME - The date and time the game was reviewed