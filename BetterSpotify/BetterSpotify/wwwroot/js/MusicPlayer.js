var TrackName = document.querySelector(".Player-Title");
var TrackAuthor = document.querySelector(".Player-Author");

let Image_Track = document.querySelector(".Player-Image");
let curr_track = document.createElement('audio');
let PausePlay = document.getElementById("PausePlay");

let curr_time = document.querySelector(".Player-Slider-CurrentTime");
let total_duration = document.querySelector(".Player-Slider-EndTime");
let seek_slider = document.querySelector(".Player-Slider-Time");

var isPlaying = false;
let updateTimer;

function StartTrack(IdSong, SongName, SongAuthor, SongFile) {
    console.log("Now Playing:");
    console.log("idSong: " + IdSong);
    console.log("SongName: " + SongName);
    console.log("SongAuthor: " + SongAuthor);
    console.log("SongFile: " + SongFile);

    console.log(curr_track);

    TrackName.textContent = SongName;
    TrackAuthor.textContent = SongAuthor;

    clearInterval(updateTimer);

    curr_time.textContent = "00:00";
    total_duration.textContent = "00:00";
    seek_slider.value = 0;

    seekUpdate();
    updateTimer = setInterval(seekUpdate, 1000);

    curr_track.src = "/music/musicfiles/" + SongFile
    curr_track.load();
    playTrack();
    isPlaying = true;
}

function resetValues() {
    curr_time.textContent = "00:00";
    total_duration.textContent = "00:00";
    seek_slider.value = 0;
}

function playpauseTrack() {
    if (!isPlaying) playTrack();
    else pauseTrack();
}

function playTrack() {
    
    curr_track.play();
    isPlaying = true;

    PausePlay.innerHTML = '<i class="bi bi-pause"></i>'
}

function pauseTrack() {

    curr_track.pause();
    isPlaying = false;

    PausePlay.innerHTML = '<i class="bi bi-play"></i>'
}


function seekTo() {
    // Calculate the seek position by the
    // percentage of the seek slider
    // and get the relative duration to the track
    seekto = curr_track.duration * (seek_slider.value / 100);

    // Set the current track position to the calculated seek position
    curr_track.currentTime = seekto;
}

function setVolume() {
    // Set the volume according to the
    // percentage of the volume slider set
    curr_track.volume = volume_slider.value / 100;
}

function seekUpdate() {
    let seekPosition = 0;

    // Check if the current track duration is a legible number
    if (!isNaN(curr_track.duration)) {
        seekPosition = curr_track.currentTime * (100 / curr_track.duration);
        seek_slider.value = seekPosition;

        // Calculate the time left and the total duration
        let currentMinutes = Math.floor(curr_track.currentTime / 60);
        let currentSeconds = Math.floor(curr_track.currentTime - currentMinutes * 60);
        let durationMinutes = Math.floor(curr_track.duration / 60);
        let durationSeconds = Math.floor(curr_track.duration - durationMinutes * 60);

        // Add a zero to the single digit time values
        if (currentSeconds < 10) { currentSeconds = "0" + currentSeconds; }
        if (durationSeconds < 10) { durationSeconds = "0" + durationSeconds; }
        if (currentMinutes < 10) { currentMinutes = "0" + currentMinutes; }
        if (durationMinutes < 10) { durationMinutes = "0" + durationMinutes; }

        // Display the updated duration
        curr_time.textContent = currentMinutes + ":" + currentSeconds;
        total_duration.textContent = durationMinutes + ":" + durationSeconds;
    }
}