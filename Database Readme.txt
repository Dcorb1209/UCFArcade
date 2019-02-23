Table - games (Contains all games submitted until they are deleted or rejected - ie. Contina submitted games pending review & accepted games)

game_id - int(11)(pk) - Database game ID
game_name - varchar(255) - The name of the game (Must be unique)
game_creator_id - int(11) - the ID of the creator
game_creatorname - varchar(255) - the username of the creator
game_description - TEXT - the full description of the game
game_controls - TEXT - the written guide for the controls
game_videolink - TEXT - the link to a video of gameplay
game_genres - varchar(32) - the flags for the genres (flags TBD)
game_status - varchar(1) - the flag for the status currently (a - accepted, p - pending review, t - pending tests, r - rejected)
game_onarcade - bit(1) - True/False boolean to determine if it belongs on the arcade machine (0 means it does not belong on the arcade machine. 1 means it does belong on the arcade machine)
game_path - varchar(255) - The file path on s3 to the location of the game zip file
game_image0 - varchar(255) - The file path on s3 to the location of the default display image
game_image1 - varchar(255) - The file path on s3 to the location of the optional slideshow image #1
game_image2 - varchar(255) - The file path on s3 to the location of the optional slideshow image #2
game_image3 - varchar(255) - The file path on s3 to the location of the optional slideshow image #3
game_image4 - varchar(255) - The file path on s3 to the location of the optional slideshow image #4
game_submissiondate_utc - DATETIME - The date and time the game was submitted in utc time
game_reviewdate_utc - DATETIME - The date and time the game was reviewed in utc time

Table - submissions
submission_id - int(11)(pk) - Database submissions ID
creator_id - int(11) - Creators ID
game_id - int(11) - Database game ID
submission_name - varchar(255) - Game name
submission_status - varchar(1) - Status flag of the game (see game_status in games table)
submission_image0 - varchar(255) - See game_image0
submission_date_utc - DATETIME - same as game_submissiondate_utc
submission_reviewdate_utc DATETIME - same as game_reviewdate_utc

Table - tests
game_id - int(11)(pk)(fk) - Database game ID
test_opens - tinyint - Bool for storing result of the opening test
test_5min - tinyint - Bool for storing restult of the 5 minute test
test_closes - tinyint - Bool for storing result of the closing test
test_randombuttons - tinyint - Bool for storing result of the random buttons test
test_attempts - int(11) - Stores the number of attempts used to test the game

Table - testsqueue
game_id - int(11)(pk)(fk) - Database game ID
retry_count - int(11) - Number of attempts used to test the game