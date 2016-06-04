param([string]$instance=".\SQLEXPRESS")
$database = "SpeakR"
.\src\packages\roundhouse.0.8.6\bin\rh.exe -s $instance -d $database -f . /drop --silent
.\src\packages\roundhouse.0.8.6\bin\rh.exe -s $instance -d $database -f . /simple --silent